Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class commands
    Public Shared Function ConnectionStringBuilder(ByRef Server As String, ByRef database As String, _
                                           ByRef userid As String, ByRef password As String) As String



        Dim sqlConnString As New System.Data.SqlClient.SqlConnectionStringBuilder() With {
            .DataSource = Server,
            .InitialCatalog = database,
            .UserID = userid,
            .Password = password
        }
        Return sqlConnString.ConnectionString
    End Function
    Friend Sub SelectRecord(ByVal SQLCommand As String, ByVal tablename As String, ByVal datagridname As DataGridView)
        SQLConnect.ConnectToDb()
        Dim SelectConn As New SqlCommand(SQLCommand, SQLConnect.SQLCon)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        Dim bs As New BindingSource
        da.SelectCommand = SelectConn
        da.Fill(ds, tablename)

        bs.DataSource = ds
        bs.DataMember = tablename
        datagridname.DataSource = bs
        SQLConnect.DisconnectToDb()
    End Sub

    Friend Sub AddRecord(ByVal SQLCommand As String)
        SQLConnect.ConnectToDb()
        Dim addComm As New SqlCommand(SQLCommand, SQLConnect.SQLCon)
        addComm.ExecuteNonQuery()
        SQLConnect.DisconnectToDb()
    End Sub

    Friend Sub Update(ByVal SQLCommand As String)
        SQLConnect.ConnectToDb()
        Dim updateRecords As New SqlCommand(SQLCommand, SQLConnect.SQLCon)
        updateRecords.ExecuteNonQuery()
        SQLConnect.DisconnectToDb()
    End Sub
  Friend Sub delete(ByVal SQLCommand As String)
    SQLConnect.ConnectToDb()
    Dim delete As New SqlCommand(SQLCommand, SQLConnect.SQLCon)
    delete.ExecuteNonQuery()
    SQLConnect.DisconnectToDb()
  End Sub
  Public Function LoaderData(ByVal strSql As String) As DataTable

    Dim dad As SqlDataAdapter

    Dim dtb As New DataTable





    Try
      SQLConnect.ConnectToDb()
      dad = New SqlDataAdapter(strSql, SQLConnect.SQLCon)
      dad.Fill(dtb)
      SQLConnect.Close()
      dad.Dispose()
    Catch ex As Exception
    SQLConnect.Close()

    End Try
    Return dtb
  End Function












  Function FindSpecificRecord(ByVal sqlCommand As String) As String
    Try
      Dim tempREcord As String
      tempREcord = ""
      SQLConnect.ConnectToDb()
      Dim selectSqlCommand As New SqlCommand(sqlCommand, SQLConnect.SQLCon)
      Dim dr As SqlDataReader = selectSqlCommand.ExecuteReader
      If dr.Read Then
        tempREcord = (dr.Item(0)).ToString
      End If
      Return tempREcord
      SQLConnect.DisconnectToDb()
    Catch ex As Exception
      Return ""
      'MessageBox.Show(ex.Message)
    End Try
  End Function
  Function getSpecificRecord(ByVal sqlStatements As String) As String
    Try
      SQLConnect.ConnectToDb()
      Dim RecordValue As String
      Dim searchUser As New SqlCommand(sqlStatements, SQLConnect.SQLCon)
      Dim dr As SqlDataReader = searchUser.ExecuteReader

      If dr.Read Then
        RecordValue = dr.Item(0).ToString
      Else
        RecordValue = ""
      End If

      Return RecordValue
      SQLConnect.DisconnectToDb()
    Catch ex As Exception
      Return ""
      'MessageBox.Show(ex.Message)
    End Try
  End Function
  Friend Sub fillCombox(ByVal ComboboxName As ComboBox, ByVal queryString As String, ByVal TableName As String, ByVal fieldName As String)
    Try
      SQLConnect.ConnectToDb()
      Dim searchAllRec As New SqlCommand(queryString, SQLConnect.SQLCon)
      Dim da As New SqlDataAdapter
      Dim bs As New BindingSource
      Dim ds As New DataSet

      da.SelectCommand = searchAllRec
      da.Fill(ds, TableName)

      bs.DataSource = ds
      bs.DataMember = TableName
      ComboboxName.DataSource = bs
      ComboboxName.DisplayMember = fieldName

      SQLConnect.DisconnectToDb()
    Catch ex As Exception
      'MessageBox.Show(ex.Message)
    End Try
    End Sub
    Function VerifyRecord(ByVal sqlStatements As String) As Boolean
    Try
      Dim recordSate As Boolean
      SQLConnect.ConnectToDb()
      Dim Searchuser As New SqlCommand(sqlStatements, SQLConnect.SQLCon)
      Dim dr As SqlDataReader = Searchuser.ExecuteReader
      If dr.Read Then
        recordSate = True
      Else
        recordSate = False
      End If
      Return recordSate
      SQLConnect.DisconnectToDb()
    Catch ex As Exception
      Return False
      MessageBox.Show("I'm Sorry invalid user..!")
        End Try
    End Function
End Class
