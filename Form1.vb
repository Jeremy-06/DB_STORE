Imports System.Data.SqlClient

Public Class Form1
    Public conn As New SqlConnection("Data Source=IDEAPADSLIM3\SQLEXPRESS01;Initial Catalog=RONSTORE_DB;Integrated Security=True")
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public dt As DataTable = New DataTable()
    Public query As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            dataLoad()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Public Sub dataLoad()
        Try
            query = "SELECT * FROM RONSTORE"
            da = New SqlDataAdapter(query, conn)
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()
            query = "INSERT INTO RONSTORE (PRODUCTID, PRODUCTNAME, PRODUCTPRICE, PRODUCTSTOCK) VALUES (@PRODUCTID, @PRODUCTNAME, @PRODUCTPRICE, @PRODUCTSTOCK)"
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@PRODUCTID", TextBox1.Text)
            cmd.Parameters.AddWithValue("@PRODUCTNAME", TextBox2.Text)
            cmd.Parameters.AddWithValue("@PRODUCTPRICE", TextBox3.Text)
            cmd.Parameters.AddWithValue("@PRODUCTSTOCK", TextBox4.Text)
            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Product inserted successfully.")
                dataLoad()
            Else
                MessageBox.Show("Insert failed.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            conn.Open()
            query = "UPDATE RONSTORE SET PRODUCTNAME = @PRODUCTNAME, PRODUCTPRICE = @PRODUCTPRICE, PRODUCTSTOCK = @PRODUCTSTOCK WHERE PRODUCTID = @PRODUCTID"
            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@PRODUCTNAME", TextBox2.Text)
            cmd.Parameters.AddWithValue("@PRODUCTPRICE", TextBox3.Text)
            cmd.Parameters.AddWithValue("@PRODUCTSTOCK", TextBox4.Text)
            cmd.Parameters.AddWithValue("@PRODUCTID", TextBox1.Text)
            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Product updated successfully.")
                dataLoad()
            Else
                MessageBox.Show("Update failed.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                conn.Open()
                query = "DELETE FROM RONSTORE WHERE PRODUCTID = @PRODUCTID"
                cmd = New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PRODUCTID", TextBox1.Text)
                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MessageBox.Show("Product deleted successfully.")
                    dataLoad()
                Else
                    MessageBox.Show("Delete failed.")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class
