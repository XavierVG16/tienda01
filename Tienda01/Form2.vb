Imports MySql.Data.MySqlClient

Public Class Form2
    Private conexion As MySqlConnection
    Private comando As MySqlCommand
    Private da As MySqlDataAdapter
    Private dr As MySqlDataReader
    Private strSql As String


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mostar()

    End Sub
    Public Sub mostar()
        Try
            conexion = New MySqlConnection("datasource=localhost; port=3306; user=root; password=; database= tienda")
            strSql = "select * from cliente"

            Dim dt As New DataTable
            da = New MySqlDataAdapter
            da = New MySqlDataAdapter(strSql, conexion)
            conexion.Open()
            da.Fill(dt)
            dataCliente.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("error")
        End Try
        conexion.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conexion = New MySqlConnection("datasource=localhost; port=3306; user=root; password=; database= tienda")
            strSql = "insert into  cliente (nombre, apellido, direccion, telefono) value (@nombre, @apellido, @direccion, @telefono)"
            comando = New MySqlCommand(strSql, conexion)
            comando.Parameters.AddWithValue("@nombre", TextBoxNombre.Text)
            comando.Parameters.AddWithValue("@apellido", TextBoxApellido.Text)
            comando.Parameters.AddWithValue("@direccion", TextBoxDireccion.Text)
            comando.Parameters.AddWithValue("@telefono", TextBoxTelefono.Text)
            conexion.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show("Datos Guardados")
            mostar()


        Catch ex As Exception
            MessageBox.Show("error")
        End Try
        conexion.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            conexion = New MySqlConnection("datasource=localhost; port=3306; user=root; password=; database= tienda")
            strSql = "delete from cliente where  id = @id"
            comando = New MySqlCommand(strSql, conexion)
            comando.Parameters.AddWithValue("@id", TextBoxId.Text)

            conexion.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show("Cliente eliminado")
            mostar()


        Catch ex As Exception
            MessageBox.Show("error")
        End Try
        conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            conexion = New MySqlConnection("datasource=localhost; port=3306; user=root; password=; database= tienda")
            strSql = "update cliente set nombre =  @nombre, apellido = @apellido, direccion = @direccion, telefono= @telefono where id = @id "
            comando = New MySqlCommand(strSql, conexion)
            comando.Parameters.AddWithValue("@nombre", TextBoxNombre.Text)
            comando.Parameters.AddWithValue("@apellido", TextBoxApellido.Text)
            comando.Parameters.AddWithValue("@direccion", TextBoxDireccion.Text)
            comando.Parameters.AddWithValue("@telefono", TextBoxTelefono.Text)
            comando.Parameters.AddWithValue("@id", TextBoxId.Text)
            conexion.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show("Datos Guardados")
            mostar()


        Catch ex As Exception
            MessageBox.Show("error")
        End Try
        conexion.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub dataCliente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataCliente.CellContentClick

    End Sub
End Class