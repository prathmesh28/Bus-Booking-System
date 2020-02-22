Imports Oracle.DataAccess.Client


Public Class Form6
    Dim con1 As OracleConnection
    Dim cmd As OracleCommand
    Dim da As OracleDataAdapter
    Dim d As DataSet
    Dim query As String
    Dim temp As Integer
    Dim I As Integer
    Dim reader2 As Object
    Dim search As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con1 = New OracleConnection("Data Source=localhost;User ID=BUSFINAL;Password=BUSFINAL")
        Try
            con1.Open()
            query = "select * from MAIN order by BUS_ID"

            cmd = New OracleCommand(query, con1)

            da = New OracleDataAdapter(query, con1)
            d = New DataSet()
            da.Fill(d, "test")
            DataGridView1.DataSource = d.Tables(0)
        Catch EX As Exception
            MessageBox.Show(EX.ToString())

        End Try
        con1.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As New Form4
        r.Show()
        Me.Hide()
    End Sub
End Class