Imports MySql.Data.MySqlClient
Public Class versionLIAPPFrm
    Public _userNameStr As String
    Private Sub versionLIAPPFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appVersionStr As String = ""
        Dim err1 As Integer

        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        Parametros1(0) = New MySqlParameter("@appname", "LIAPP")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)

        vLIAPPLbl.Text = appVersionStr
        Me.Text = "LIAPP"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim verAppStr As String


        If vLIAPPLbl.Text <> "" Then

            verAppStr = Trim(vLIAPPLbl.Text)
            updateAppVersion(verAppStr, "LIAPP", _userNameStr)
            Me.Close()

        Else
            
        End If


    End Sub

    Public Sub New(ByVal userNameStr As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _userNameStr = userNameStr

    End Sub

End Class