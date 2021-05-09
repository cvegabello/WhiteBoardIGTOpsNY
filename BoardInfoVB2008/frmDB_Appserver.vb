Imports MySql.Data.MySqlClient

Public Class frmDB_Appserver

    Private Sub frmDB_Appserver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tableQserverdb_app As DataTable

        tableQserverdb_app = dataSourceAccess.RunStoreQueryWithoutParameters("qserverdb_app")
        NumericUpDown1.Text = tableQserverdb_app.Rows(0).Item(0)
        NumericUpDown2.Text = tableQserverdb_app.Rows(0).Item(1)
        NumericUpDown3.Text = tableQserverdb_app.Rows(0).Item(2)
        NumericUpDown4.Text = tableQserverdb_app.Rows(0).Item(3)

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        Dim num1 As Integer
        Dim Parametros1(3) As MySqlParameter
        Dim msgErrorStr As String = ""
        Dim priNYDBInt, priNYPPDBInt, priNYB2BAPPInt, prinNYPPAPPInt As Integer

        priNYDBInt = CInt(NumericUpDown1.Value)
        priNYPPDBInt = CInt(NumericUpDown2.Value)
        priNYB2BAPPInt = CInt(NumericUpDown3.Value)
        prinNYPPAPPInt = CInt(NumericUpDown4.Value)


        Parametros1(0) = New MySqlParameter("@pridbInt", priNYDBInt)
        Parametros1(1) = New MySqlParameter("@prippdbInt", priNYPPDBInt)
        Parametros1(2) = New MySqlParameter("@prib2bappInt", priNYB2BAPPInt)
        Parametros1(3) = New MySqlParameter("@prippappInt", prinNYPPAPPInt)
        
        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertdbapp", Parametros1, msgErrorStr)
        If num1 = 0 Then
            Me.Close()
        Else
            MsgBox("Error trying to insert DB and APP primary servers: " & msgErrorStr, MsgBoxStyle.Information, "Error")

        End If
        

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class