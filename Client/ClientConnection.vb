Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports MorpionBase
Module ClientConnection
    Dim socketClient As Socket
    Dim serverEndPoint As IPEndPoint
    Dim ReceiverThread As Threading.Thread
    Dim PingThread As Threading.Thread
    Public Ping As Long = 0

    Function Connect() As Boolean
        Try
            serverEndPoint = New IPEndPoint(IPAddress.Parse("127.0.0.1"), 27502)
            socketClient = New Socket(SocketType.Stream, ProtocolType.Tcp)
            socketClient.Connect(serverEndPoint)
            Dim LoginMessage As New Message
            LoginMessage.Command = MessageContent.LOGIN
            LoginMessage.AddArg("PSEUDO", My.Computer.Name)
            If SendMessage(LoginMessage) Then
                ReceiverThread = New Thread(AddressOf Receiver)
                ReceiverThread.Start()
                PingThread = New Thread(AddressOf Pinger)
                PingThread.Start()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function Disconnect() As Boolean
        Try
            Dim disconnectMsg As New Message
            disconnectMsg.Command = MessageContent.DISCONNECT
            SendMessage(disconnectMsg)
            socketClient.Disconnect(False)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function SendMessage(ByVal msg As Message) As Boolean
        Dim buffer() = msg.ToBytes
        If buffer Is Nothing Then Return False
        If buffer.Count = 0 Then Return False
        Try
            socketClient.Send(buffer)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub Pinger()
        While socketClient.Connected
            Thread.Sleep(1000)
            Dim PingMessage As New Message
            PingMessage.Command = MessageContent.PING
            Dim ApiTime As Date = MorpionBase.Tools.GetTimeExternal
            'PingMessage.AddArg("PINGAT", ApiTime)
            PingMessage.Objs.Add(ApiTime)
            SendMessage(PingMessage)
        End While
    End Sub

    Sub Receiver()
        If socketClient Is Nothing Then Exit Sub
        While socketClient.Connected
            Dim buffer(1024) As Byte
            Dim bytes_received As Integer = 0
            Try
                bytes_received = socketClient.Receive(buffer)
            Catch ex As Exception
                Continue While
            End Try
            If Not bytes_received = 0 Then
                Dim receivedMessage As New Message
                If receivedMessage.LoadFromBytes(buffer) = True Then
                    Dim threadExecuteMsg As New Thread(New ParameterizedThreadStart(AddressOf ExecuteMessage))
                    threadExecuteMsg.Start(receivedMessage)
                Else
                    Continue While
                End If
            End If
        End While
    End Sub

    Sub ExecuteMessage(ByVal msg As Message)
        Debug.WriteLine("[CLIENT] Nouveau Message: " & msg.Command.ToString)
        Select Case msg.Command
            Case MessageContent.PONG
                Try
                    Ping = msg.GetArg("TIMEELAPSED")
                Catch ex As Exception
                End Try

        End Select
    End Sub
End Module
