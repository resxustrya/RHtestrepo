Imports System.Data.SqlClient
Module DatabaseConnection
    Dim dbConnection As SqlConnection
    Dim dbCommand As SqlCommand
    Dim dbDataReader As SqlDataReader

    Function OpenConnection() As Boolean
        Dim connString = "Data Source=LAPTOP-V8EE7K1M\SQLEXPRESS;Initial Catalog=TestDatabase;Integrated Security=True"
        dbConnection = New SqlConnection()
        dbConnection.ConnectionString = connString
        Try
            dbConnection.Open()
            If dbConnection.State = ConnectionState.Open Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function
    Function CloseConnection() As Boolean
        Try
            dbConnection.Close()
            If dbConnection.State = ConnectionState.Closed Then
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function
    Function ExecuteReadCommands(ByVal sqlCommands As String) As DataTable
        Dim resultSets As DataTable = New DataTable
        Try
            If OpenConnection() Then
                dbCommand = New SqlCommand(sqlCommands, dbConnection)
                dbDataReader = dbCommand.ExecuteReader()
                resultSets.Load(dbDataReader)
                CloseConnection()
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return resultSets
    End Function
    Function ExecuteCreateUpdateCommands(ByVal sqlCommands As String) As Integer
        Dim commandResult As Integer
        Try
            If OpenConnection() Then
                dbCommand = New SqlCommand(sqlCommands, dbConnection)
                commandResult = dbCommand.ExecuteNonQuery()
                CloseConnection()
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return commandResult
    End Function
End Module
