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

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class
