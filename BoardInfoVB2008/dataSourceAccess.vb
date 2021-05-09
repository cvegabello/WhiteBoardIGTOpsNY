'Imports System.Data.OleDb
'Imports System.Data.Odbc
Imports MySql.Data.MySqlClient

Module dataSourceAccess

    Public dbConnMySqlBoard As New MySqlConnection



    Function ConexionMySQL() As Boolean

        'Dim DataBaseName As String = "boardinfony"
        'Dim server As String = "127.0.0.1"
        'Dim userName As String = "root"
        'Dim password As String = "Welcome1"

        Dim DataBaseName As String
        Dim server As String
        Dim userName As String
        Dim password As String
        Dim conexionStr As String
        Dim conStrinDatabaseStr As String
        Dim cont As Integer
        Dim substrings() As String

        conStrinDatabaseStr = Utils.GetSettingConfigServerDB(appName, "conStringDatabase", "").ToString()

        cont = conStrinDatabaseStr.Length
        If cont <> 0 Then
            substrings = conStrinDatabaseStr.Split("|")
            DataBaseName = substrings(0)
            server = substrings(1)
            userName = substrings(2)
            password = substrings(3)
        Else
            DataBaseName = ""
            server = ""
            userName = ""
            password = ""

        End If


        If Not dbConnMySqlBoard Is Nothing Then dbConnMySqlBoard.Close()
        conexionStr = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", server, userName, password, DataBaseName)
        dbConnMySqlBoard.ConnectionString = conexionStr

        Try
            dbConnMySqlBoard.Open()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message & " Failed to connect to data source")
            Return False
        End Try


    End Function

    Function RunStoreQueryWithoutParameters(ByVal procedureName As String) As DataTable
        Try
            Dim sqlAdapter As MySqlDataAdapter
            Dim dtable As DataTable
            Dim numRecords As Integer
            Dim cmd As New MySqlCommand(procedureName, dbConnMySqlBoard)
            cmd.CommandType = CommandType.TableDirect
            cmd.CommandTimeout = Integer.MaxValue
            sqlAdapter = New MySqlDataAdapter(cmd)
            dtable = New DataTable
            numRecords = sqlAdapter.Fill(dtable)
            Return dtable
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Function RunStructureProcedureReturnDtable(ByVal ProcedureName As String, ByVal parametros() As MySqlParameter) As DataTable
        Try
            Dim dtable As DataTable
            Dim tmpParametro As MySqlParameter
            Dim sqlAdapter As MySqlDataAdapter
            Dim numRecords As Integer

            Dim cmd As New MySqlCommand(ProcedureName, dbConnMySqlBoard)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = Integer.MaxValue

            For Each tmpParametro In parametros
                cmd.Parameters.Add(tmpParametro)
            Next

            sqlAdapter = New MySqlDataAdapter(cmd)
            dtable = New DataTable
            numRecords = sqlAdapter.Fill(dtable)
            Return dtable

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function RunStoreProcedureParametersNonQuery(ByVal ProcedureName As String, ByRef parametros() As MySqlParameter, ByRef msgError As String) As Integer

        Dim cmd As New MySqlCommand(ProcedureName, dbConnMySqlBoard)
        'Dim tmpParameter As New MySqlParameter
        Dim ErrCodInt As Integer

        Try

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = Integer.MaxValue

            For Each tmpParametro In parametros
                cmd.Parameters.Add(tmpParametro)
            Next
            cmd.ExecuteNonQuery()
            Return 0
        Catch ex As MySqlException
            msgError = ex.Message
            ErrCodInt = ex.ErrorCode
            Return ErrCodInt
        End Try
    End Function

    Public Function RunStoreProcedureScalar(ByVal ProcedureName As String, ByRef parametros() As MySqlParameter, ByRef newJackpotDbl As Double, ByRef msgError As String) As Double

        Dim cmd As New MySqlCommand(ProcedureName, dbConnMySqlBoard)
        Dim tmpParameter As New MySqlParameter

        Try

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = Integer.MaxValue

            For Each tmpParametro In parametros
                cmd.Parameters.Add(tmpParametro)
            Next
            newJackpotDbl = cmd.ExecuteScalar()
            Return 0
        Catch ex As Exception
            msgError = ex.Message
            Return 1
        End Try
    End Function

    Public Function RunStoreProcedureScalarString(ByVal ProcedureName As String, ByRef parametros() As MySqlParameter, ByRef strReturn As String, ByRef msgError As String) As Double

        Dim cmd As New MySqlCommand(ProcedureName, dbConnMySqlBoard)
        Dim tmpParameter As New MySqlParameter

        Try

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = Integer.MaxValue

            For Each tmpParametro In parametros
                cmd.Parameters.Add(tmpParametro)
            Next
            strReturn = cmd.ExecuteScalar()
            Return 0
        Catch ex As Exception
            msgError = ex.Message
            Return 1
        End Try
    End Function


    Public Function RunStoreProcedureScalarInteger(ByVal ProcedureName As String, ByRef parametros() As MySqlParameter, ByRef intReturn As String, ByRef msgError As String) As Integer

        Dim cmd As New MySqlCommand(ProcedureName, dbConnMySqlBoard)
        Dim tmpParameter As New MySqlParameter

        Try

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = Integer.MaxValue

            For Each tmpParametro In parametros
                cmd.Parameters.Add(tmpParametro)
            Next
            intReturn = cmd.ExecuteScalar()
            Return 0
        Catch ex As Exception
            msgError = ex.Message
            Return 1
        End Try
    End Function


End Module
