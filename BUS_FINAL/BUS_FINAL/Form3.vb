Public Class Form3
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim r As New Form4
        r.Show()
        Me.Hide()


    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As New Form5
        r.Show()
        Me.Hide()
    End Sub
End Class