Imports Oracle.DataAccess.Client
Public Class Form4
    Dim conn As OracleConnection
    Dim cmd As OracleCommand
    Dim query As String
    Dim temp As Integer
    Dim I As Integer
    Dim reader2 As Object
    Dim search As String
    Private bitmap As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = New OracleConnection("Data Source=localhost;User ID=BUSFINAL;Password=BUSFINAL")


        conn.Open()
        Try
            query = "Insert into MAIN values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox3.Text & "')"
            cmd = New OracleCommand(query, conn)
            cmd.CommandType = CommandType.Text



            temp = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())

        End Try
        If temp > 0 Then
            MsgBox("RECORD ADDED SUCCESSFULLY", vbOKOnly, "MESSAGE")
        Else
            MsgBox("INSERT OPERATION FAILED", vbOKOnly + vbCritical, "ERROR")
        End If

        conn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn = New OracleConnection("Data Source=localhost;User ID=BUSFINAL;password=BUSFINAL")
        conn.Open()
        Dim del As String

        del = "Delete from MAIN where BUS_ID ='" & TextBox1.Text & "'  and SEATS='" & TextBox2.Text & "'  and SOURCE='" & ComboBox1.Text & "' and DESTINATION='" & ComboBox2.Text & "' "
        cmd = New OracleCommand(del, conn)
        I = cmd.ExecuteNonQuery()
        If I > 0 Then
            MessageBox.Show("Item Successfully Deleted")
        Else
            MessageBox.Show("UNSuccessfully ")

        End If



    End Sub




    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim search As String
        conn = New OracleConnection("Data Source=localhost;User ID=BUSFINAL;Password=BUSFINAL")
        Dim reader2 As OracleDataReader
        search = "select * from MAIN where BUS_ID='" & TextBox1.Text & "' "
        cmd = New OracleCommand(search, conn)

        conn.Open()
        reader2 = cmd.ExecuteReader()

        Do While reader2.Read()
            TextBox1.Text = reader2("BUS_ID")
            TextBox2.Text = reader2("SEATS")
            ComboBox1.Text = reader2("SOURCE")
            ComboBox2.Text = reader2("DESTINATION")
            TextBox3.Text = reader2("PASSENGER_NAME")

        Loop
        reader2.Close()
        conn.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim l As New Form3
        l.Show()
        Me.Hide()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        conn = New OracleConnection("Data Source=localhost;User ID=BUSFINAL;Password=BUSFINAL")
        query = "Update MAIN Set SEATS='" & TextBox2.Text & "',SOURCE='" & ComboBox1.Text.ToUpper & "',DESTINATION='" & ComboBox2.Text & "',PASSENGER_NAME='" & TextBox3.Text & "' Where BUS_ID='" & TextBox1.Text & "'"

        cmd = New OracleCommand(query, conn)
        cmd.CommandType = CommandType.Text

        Try


            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())

        End Try
        MsgBox("Record updated successfully", vbOKOnly, "MESSAGE")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Button6.Visible = False
        'Add a Panel control.
        Dim panel As New Panel()
        Me.Controls.Add(panel)

        'Create a Bitmap of size same as that of the Form.
        Dim grp As Graphics = panel.CreateGraphics()
        Dim formSize As Size = Me.ClientSize
        Bitmap = New Bitmap(formSize.Width, formSize.Height, grp)
        grp = Graphics.FromImage(Bitmap)

        'Copy screen area that that the Panel covers.
        Dim panelLocation As Point = PointToScreen(panel.Location)
        grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize)

        'Show the Print Preview Dialog.
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()

        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
        Button6.Visible = True

    End Sub

    Private Sub PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Print the contents.
        e.Graphics.DrawImage(Bitmap, 0, 0)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim r As New Form6

        r.Show()
        Me.Hide()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class