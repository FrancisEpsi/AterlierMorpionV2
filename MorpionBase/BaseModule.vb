Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Net


Public Class Tools
    Public Shared Function GetTimeExternal() As Date
        Dim wc As New WebClient
        Dim t1 = Now
        Dim repStr = wc.DownloadString("http://worldclockapi.com/api/json/utc/now")
        If Not repStr Is Nothing Then
            Dim Fields() = repStr.Split(",")
            Dim currentFileTimeField() = Fields(6).Split(":")
            Dim currentFileTime As String = currentFileTimeField(1)
            Dim ConvertedDate = Date.FromFileTimeUtc(currentFileTime)
            Dim TimeElapsedDuringRequest = Now - t1
            ConvertedDate.Add(TimeElapsedDuringRequest)
            Return ConvertedDate
        End If
        Return Nothing
    End Function

End Class


Public Enum MessageContent As Byte
    'Connexion:
    PING = CByte(0)
    PONG = CByte(1)
    LOGIN = CByte(2)
    DISCONNECT = CByte(3)
    'Partie:
    START_GAME = CByte(10)
    END_GAME = CByte(11)
    GAME_READY = CByte(12)
    'Plateau:
    CHECK_CASE = CByte(20)
    CHANGE_ROLE = CByte(30)
End Enum


<Serializable>
Public Class Message
    ''' <summary>
    ''' La commande principale à communiquer dans ce Message. Les commandes sont listées dans l'énumération MessageContent
    ''' </summary>
    Public Command As MessageContent
    ''' <summary>
    ''' Dictionnaire d'argument. A utiliser avec les méthodes prévues à cet effet pour plus de faciliter et de stabilité.
    ''' </summary>
    Public Args As New List(Of String)
    ''' <summary>
    ''' Liste des objets à placer dans le message (comme des pièces jointes) (prévu au cas ou)
    ''' </summary>
    Public Objs As New List(Of Object)

    <NonSerialized>
    Private ArgSeparator As String = "⇉" 'Symbole permettant de séparer la clé de la valeure dans un élément du dictionnaire d'argument.

    ''' <summary>
    ''' Ajoute une valeure à une clée spécifique dans le dictionnaire d'argument.
    ''' </summary>
    ''' <param name="Key">La clé du dictionnaire (ou index) sur laquelle la valeure sera ajoutée</param>
    ''' <param name="Value">La valeure à définir sur la clé du dictionnaire d'argument</param>
    Public Sub AddArg(ByVal Key As String, ByVal Value As String)
        DeleteArg(Key)
        Dim ArgStr As String = Key & ArgSeparator & Value
        Args.Add(ArgStr)
    End Sub

    ''' <summary>
    ''' Obtient la valeure d'une clé dans le dictionnaire d'argument. Retourne Nothing si la clé n'existe pas.
    ''' </summary>
    ''' <param name="Key">La clé du dictionnaire d'argument dans laquelle la valeure à récupérer est stockée</param>
    Public Function GetArg(ByVal Key As String) As String
        For Each ArgStr In Args
            Dim argKey As String = ArgStr.Split(ArgSeparator)(0)
            Dim argValue As String = ArgStr.Split(ArgSeparator)(1)
            If argKey = Key Then Return argValue
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Supprime un élément du dictionnaire d'argument grâce à sa clé.
    ''' </summary>
    ''' <param name="Key">La clé du dictionnaire d'argument qui permet d'identifier l'élément à supprimer</param>
    ''' <returns>TRUE si la clé à été correctement supprimée, sinon retourne FALSE si la clé n'a pas pu être supprimée ou bien qu'elle n'existe pas</returns>
    Public Function DeleteArg(ByVal Key As String) As Boolean
        Dim IndexToDelete = -1 'L'index du tableau Args à laquelle se trouve l'élément à supprimer

        'On recherche l'index du tableau Args ou se trouve l'élément à supprimer:
        For i = 0 To Args.Count - 1
            Dim argKey As String = Args(i).Split(ArgSeparator)(0)
            Dim argValue As String = Args(i).Split(ArgSeparator)(1)
            If argKey = Key Then
                IndexToDelete = i
                Exit For
            End If
        Next

        If Not IndexToDelete = -1 Then
            'Si l'élément à supprimer est présent dans la liste et que son index à été trouvé, alors on le supprime:
            Try
                Args.RemoveAt(IndexToDelete)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Sérialise cet objet Message en un tableau d'octet, prêt à être envoyé via socket.
    ''' </summary>
    ''' <returns>Un tableau d'octet ou buffer.</returns>
    Public Function ToBytes() As Byte()
        Dim Serializer As New BinaryFormatter
        Dim stream As New MemoryStream
        Try
            Serializer.Serialize(stream, Me)
            Dim MsgByte() = stream.ToArray()
            Return MsgByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Charge cet objet Message à partir d'un tableau d'octet reçu d'un socket (ou buffer)
    ''' </summary>
    ''' <param name="buffer">Le tableau d'octet reçu par le socket.</param>
    ''' <returns>TRUE si la sérialisation s'est correctement déroulé et que les propriétées de cet objet message ont bien été définie, sinon FALSE si le buffer est vide, qu'il est impossible de créer un stream à partir du buffer, ou que le processus de désérialisation à échoué.</returns>
    Public Function LoadFromBytes(ByVal buffer() As Byte) As Boolean
        If buffer Is Nothing Then Return False
        If buffer.Count = 0 Then Return False

        Dim Deserializer As New BinaryFormatter
        Dim TempObj As Message = Nothing

        Try
            Dim stream As New MemoryStream(buffer)
            TempObj = Deserializer.Deserialize(stream)
        Catch ex As Exception
            Return False
        End Try

        If TempObj Is Nothing Then Return False

        With TempObj
            Me.Command = .Command
            Me.Args = .Args
            Me.Objs = .Objs
        End With
        Return True
    End Function
End Class


Module BaseModule

End Module
