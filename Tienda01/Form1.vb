Imports MySql.Data.MySqlClient

Public Class Form1
    Dim conection As New MySqlConnection("datasource=localhost; port=3306; user=root; password=; database= tienda")

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If TextBoxPass.UseSystemPasswordChar = True Then
            TextBoxPass.UseSystemPasswordChar = False
        Else

            TextBoxPass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub ButtonIniciar_Click(sender As Object, e As EventArgs) Handles ButtonIniciar.Click
        Dim c As New MySqlCommand("select * from usuario where `nombre`= @nombre and  `pass` = @pass", conection)
        c.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = TextBoxUsuario.Text
        c.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextBoxPass.Text

        Dim adapter As New MySqlDataAdapter(c)
        Dim table As New DataTable()
        adapter.Fill(table)
        If table.Rows.Count = 0 Then
            MessageBox.Show("error")
        Else


            Form2.Show()
            Me.Hide()
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
