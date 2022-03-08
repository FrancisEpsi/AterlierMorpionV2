Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.Text
Imports MorpionBase

Public Class Console
    Dim Serveur As New Server(Me)
    Private Delegate Sub OneStringParamDelegate(ByVal text As String)

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Log(ByVal text As String)
        Dim dAppendLog As New OneStringParamDelegate(AddressOf AppendLog)
        Me.Invoke(dAppendLog, text)
        Debug.WriteLine(text)
    End Sub

    Private Sub AppendLog(ByVal text As String)
        LB_Logs.Items.Add(text)
        If LB_Logs.Items.Count > 0 Then LB_Logs.SelectedIndex = LB_Logs.Items.Count - 1
    End Sub

    Private Sub DémarrerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DémarrerToolStripMenuItem.Click
        Serveur.StartServer()
    End Sub

    Private Sub ArrêterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArrêterToolStripMenuItem.Click
        Serveur.StopServer()
    End Sub

    Private Sub JoueursToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JoueursToolStripMenuItem.Click
        SyncLock Serveur.playerListLock
            For Each player In Serveur.playerList
                MsgBox(player.Pseudo & " " & player.ID & ". PING = " & player.Ping)
            Next
        End SyncLock
    End Sub

#Region "Contrôles utilisateurs"

#Region "Boutons"



#End Region

#End Region
End Class

Public Class Server
    Public console As Console

    Public playerList As New List(Of Player)
    Public playerListLock As Object = New Object

    Private listenning As Boolean = False
    Private listennerThread As Thread = Nothing
    Private listenningInterface As IPEndPoint = Nothing
    Private listenningPort As Integer = 27502
    Private listennerSocket As Socket = Nothing

    Sub New(ByVal sender As Console)
        Me.console = sender
    End Sub

    Sub StartServer()
        If listenning = True Then MsgBox("Inutile de démarrer le serveur car il est déjà allumer." & Environment.NewLine & "Veuillez arrêter le serveur puis le démarrer à nouveau pour effectuer un redémarrage proprement.", vbExclamation, "Opération annulée") : Console.Log("Tentative de démarrer du serveur annuler : Le serveur tourne déjà.") : Exit Sub
        playerList = New List(Of Player)
        listenning = True
        listennerThread = New Thread(AddressOf Listen)
        listenningInterface = New IPEndPoint(IPAddress.Any, listenningPort)
        Try
            listennerSocket = New Socket(SocketType.Stream, ProtocolType.Tcp)
            listennerSocket.Bind(listenningInterface)
            Log("Le serveur est à l'écoute de connexion sur le port " & Me.listenningPort)
        Catch ex As Exception
            MsgBox("Impossible de démarrer le serveur ! Détail de l'exception:" & Environment.NewLine & ex.Message, vbCritical, "Serveur.StartServer()")
            StopServer()
            Exit Sub
        End Try

        listennerThread.Start()
    End Sub

    Sub StopServer()
        Log("Arrêt du serveur en cours...")
        listenning = False
        listennerSocket.Close()
        listenningInterface = Nothing
        DisconnectAllPlayersAsync()
    End Sub

    Private Sub Listen()
        listennerSocket.Listen(2)
        While listenning
            Try
                AddPlayer(New Player(listennerSocket.Accept, Me))
                'Log("Nouvelle connection traitée")
            Catch ex As Exception
                'Si le listennerSocket à été arrêter (par StopServer() par exemple), une SocketException sera attrapée
            End Try
        End While
        listennerSocket.Close()
    End Sub

    Public Sub DisconnectAllPlayersAsync()
        Dim tDisconnect As New Thread(AddressOf DisconnectAllPlayers)
        tDisconnect.Start()
    End Sub
    Private Sub DisconnectAllPlayers()
        SyncLock playerListLock
            For Each player In playerList
                player.Disconnect(False) 'l'argument false permet que la classe cliente ne s'enlève pas de la liste mère elle même afin d'éviter l'erreur de type "La collection à été modifié"
            Next
            playerList.Clear()
        End SyncLock
        Log("Tous les clients ont bien été déconnectés !")
    End Sub

    Public Sub AddPlayer(ByVal player As Player)
        SyncLock playerListLock
            playerList.Add(player)
        End SyncLock
    End Sub

    Public Sub RemovePlayer(ByVal player As Player)
        SyncLock playerListLock
            playerList.Remove(player)
        End SyncLock
        Log("- " & player.Pseudo & "@" & player.ID)
    End Sub

    Public Sub RemovePlayer(ByVal PlayerID As String)
        SyncLock playerListLock
            Dim PlayerIndex As Integer = -1
            For i = 0 To playerList.Count - 1
                If playerList(i).ID = PlayerID Then PlayerIndex = i
            Next
            If Not PlayerIndex = -1 Then
                Try
                    playerList.RemoveAt(PlayerIndex)
                Catch ex As Exception

                End Try
            End If
        End SyncLock
    End Sub

    Public Sub Log(ByVal text As String)
        Me.console.Log(text)
    End Sub


End Class


Public Class Player
    Private server As Server = Nothing
    Private socketSession As Socket = Nothing
    Public connected As Boolean = False

    Private DataReaderThread As Thread = Nothing


    Public ID As String = Nothing
    Public IP As String = Nothing
    Public Pseudo As String = Nothing
    Public Symbol As String = Nothing

    Public Ping As Long = 0

    Sub New(ByVal sock As Socket, ByVal sender As Server)
        Me.socketSession = sock
        Me.server = sender
        Me.IP = socketSession.RemoteEndPoint.ToString
        Me.ID = Guid.NewGuid.ToString

        If Not socketSession Is Nothing Then
            Me.socketSession.ReceiveTimeout = 5000
            connected = True
            DataReaderThread = New Thread(AddressOf DataReader)
            DataReaderThread.Start()
        End If
    End Sub

    Sub Disconnect(Optional ByVal RemoveFromPlayerList As Boolean = True)
        connected = False
        Thread.Sleep(6000) 'On attend que le ReceiveTimout soit dépassé afin que le DataReaderThread se termine par lui même
        If Not socketSession Is Nothing Then
            Try
                socketSession.Close()
            Catch ex As Exception
            End Try
            socketSession = Nothing
        End If

        If RemoveFromPlayerList Then If Not server Is Nothing Then server.RemovePlayer(Me)
        server.Log("[-] Déconnexion de " & Me.Pseudo & " (" & Me.IP & ")")
    End Sub

    Function SendMessage(ByVal msg As Message) As Boolean
        Dim buffer() = msg.ToBytes
        If buffer Is Nothing Then Return False
        If buffer.Count = 0 Then Return False
        Try
            socketSession.Send(buffer)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub DataReader()
        While connected
            Dim buffer(1024) As Byte
            Dim bytes_received As Integer = 0
            Try
                bytes_received = socketSession.Receive(buffer)
            Catch ex As Exception

                If TypeOf ex Is ArgumentNullException Then
                    server.Log("Exception de reception (ArgumentNullException): " & ex.Message)
                    Continue While
                ElseIf TypeOf ex Is ObjectDisposedException Then
                    'Joueur déjà déconnecter par exemple ou pas encore connecté
                    server.Log("Exception de reception (ObjectDisposedException): " & ex.Message)
                    connected = False
                    If Not server Is Nothing Then server.RemovePlayer(Me)
                    Exit Sub
                ElseIf TypeOf ex Is SocketException Then
                    'Joueur ne répond plus, ou l'hôte distant à fermer la connexion
                    server.Log("Exception de reception (SocketException): " & ex.Message)
                    Try
                        socketSession.Close()
                    Catch ex2 As Exception
                    End Try
                    connected = False
                    If Not server Is Nothing Then server.RemovePlayer(Me)
                    Exit Sub
                Else
                    server.Log("Exception de reception : " & ex.Message)
                    'Problème de sécurité et autre:
                    Continue While
                End If
            End Try

            If bytes_received > 0 Then
                Dim msg As New Message
                If msg.LoadFromBytes(buffer) = True Then
                    Dim threadExecuteMessage As New Thread(New ParameterizedThreadStart(AddressOf ExecuteMessage))
                    threadExecuteMessage.Start(msg)
                End If
            End If
        End While
    End Sub

    Sub ExecuteMessage(ByVal msg As Message)
        server.Log("ExecuteMessage() : " & Me.Pseudo & " > " & msg.Command.ToString)

        Select Case msg.Command
            Case MessageContent.LOGIN
                Me.Pseudo = msg.GetArg("PSEUDO")
                server.Log("+ " & Me.Pseudo)
            Case MessageContent.PING
                Try
                    Dim EuroDatageClient As Date = msg.Objs(0)
                    Dim t1 = Now
                    Dim EuroDatageServeur As Date = Tools.GetTimeExternal
                    Dim TimeToRequest = Now - t1
                    EuroDatageServeur.Subtract(TimeToRequest)
                    Me.Ping = (EuroDatageServeur - EuroDatageClient).TotalMilliseconds
                    Dim PongMessage As New Message
                    PongMessage.Command = MessageContent.PONG
                    PongMessage.AddArg("TIMEELAPSED", Me.Ping)
                    SendMessage(PongMessage)
                Catch ex As Exception

                End Try
            Case MessageContent.DISCONNECT
                Me.Disconnect()
        End Select
    End Sub
End Class
