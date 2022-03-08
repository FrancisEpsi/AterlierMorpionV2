Public Class JoinGame
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Connect() Then
            TimerGetPing.Start()
            MsgBox("Connexion réussie")
        Else
            TimerGetPing.Stop()
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Disconnect() Then
            TimerGetPing.Stop()
            MsgBox("Déconnexion réussie")
        Else
            TimerGetPing.Start()
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(MorpionBase.Tools.GetTimeExternal().ToString("F"))
    End Sub

    Private Sub TimerGetPing_Tick(sender As Object, e As EventArgs) Handles TimerGetPing.Tick
        Label1.Text = "ping = " & Ping & " ms"
    End Sub
End Class
