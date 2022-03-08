Imports Microsoft.VisualBasic

Public Shared Module Base
    Public Enum MessageContent As Byte
        PING = CByte(0)
        PONG = CByte(0)
    End Enum

    Public Class Message
        Public Command As MessageContent
        Public Args As New List(Of String)

    End Class
End Module
