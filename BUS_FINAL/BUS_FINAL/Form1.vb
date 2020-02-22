Imports Oracle.DataAccess.Client
Public Class Form1

    Dim con1 As OracleConnection
    Dim cmd As OracleCommand
    Dim query As String
    Dim temp As Integer


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ((TextBox1.Text = " ") Or (TextBox2.Text = "")) Or ((TextBox1.Text = "lab") And (TextBox2.Text = "")) Or ((TextBox1.Text = "") And (TextBox2.Text = "lab")) Then
            MsgBox(" Enter the username and password ")
        Else

            Dim search As String
            Dim flag As Integer = 0
            con1 = New OracleConnection("Data Source=localhost;User ID=BUSFINAL;password=BUSFINAL")
            search = "select * from LOG_IN where USERNAME ='" & TextBox1.Text & "' "
            cmd = New OracleCommand(search, con1)
            Dim reader2 As OracleDataReader

            con1.Open()
            reader2 = cmd.ExecuteReader()

            Do While reader2.Read()
                query = reader2("password")
                flag = 1
            Loop
            reader2.Close()

            con1.Close()
            If flag = 0 Then
                MsgBox(" username doesnt exist", vbOKOnly + vbCritical, "ERROR")

            ElseIf TextBox2.Text = query Then
                Form3.Show()
                Me.Hide()

            Else
                MsgBox("Username and Password doesnt match.Please enter correct username and Password")
                TextBox2.Text = " "
                TextBox2.Focus()
            End If

        End If

    End Sub




    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim r As New Form2
        r.Show()
        Me.Hide()

    End Sub
End Class



