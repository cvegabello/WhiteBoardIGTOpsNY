Imports MySql.Data.MySqlClient

Public Class frmRomRVAppsTerminal

    Public _form1 As Form1

    Public Sub New(ByVal form1 As Form1)
        'MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        'Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + "\Nautilus.isl")
        InitializeComponent()
        _form1 = form1

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub



    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Dim vTerminalFrm As New versionTerminalFrm(1, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""


        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "NYVI_APIF")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        nyviLbl.Text = appVersionStr
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click

        Dim vTerminalFrm As New versionTerminalFrm(2, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "GPT_APNE")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        gptLbl.Text = appVersionStr

    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Dim vTerminalFrm As New versionTerminalFrm(4, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "NY_KENO")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        kenoLbl.Text = appVersionStr
    End Sub

    Private Sub gt1200ApejBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gt1200ApejBtn.Click
        Dim vTerminalFrm As New versionTerminalFrm(6, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "GT1200_APEJ")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        gt1200ApejLbl.Text = appVersionStr
    End Sub

    Private Sub gt1200AptdBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gt1200AptdBtn.Click
        Dim vTerminalFrm As New versionTerminalFrm(7, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "GT1200_APTD")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        gt1200AptdLbl.Text = appVersionStr
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Dim vTerminalFrm As New versionTerminalFrm(9, Trim(usernameRomRVLbl.Text))
        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "GEMINI")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        geminiLbl.Text = appVersionStr
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim vTerminalFrm As New versionTerminalFrm(3, Trim(usernameRomRVLbl.Text))
        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "SST_APQE")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        sstLbl.Text = appVersionStr
    End Sub

    Private Sub transBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transBtn.Click
        Dim vTerminalFrm As New versionTerminalFrm(8, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "NY_TRANS")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        transLbl.Text = appVersionStr
    End Sub

    Private Sub uc100Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uc100Btn.Click
        Dim vTerminalFrm As New versionTerminalFrm(5, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "UC100")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        uc100Lbl.Text = appVersionStr
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Dim vTerminalFrm As New versionTerminalFrm(10, Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vTerminalFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "PDM")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        pdmLbl.Text = appVersionStr
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        Dim vLIAPPFrm As New versionLIAPPFrm(Trim(usernameRomRVLbl.Text))

        Dim appVersionStr As String = ""
        Dim err1 As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        vLIAPPFrm.ShowDialog()

        Parametros1(0) = New MySqlParameter("@appname", "LIAPP")
        err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
        liappLbl.Text = appVersionStr
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '_form1.nyviLbl.Text = Me.nyviLbl.Text
        '_form1.gptLbl.Text = Me.gptLbl.Text

        '_form1.kenoLbl.Text = Me.kenoLbl.Text
        '_form1.uc100Lbl.Text = Me.uc100Lbl.Text
        '_form1.pdmLbl.Text = Me.pdmLbl.Text
        '_form1.gt1200ApejLbl.Text = Me.gt1200ApejLbl.Text
        '_form1.gt1200AptdLbl.Text = Me.gt1200AptdLbl.Text
        '_form1.geminiLbl.Text = Me.geminiLbl.Text
        '_form1.sstLbl.Text = Me.sstLbl.Text
        '_form1.transLbl.Text = Me.transLbl.Text
        '_form1.liappLbl.Text = Me.liappLbl.Text
        '_form1.usernameRomRVLbl.Text = ""

        Me.Close()
    End Sub

    Private Sub frmRomRVAppsTerminal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.nyviLbl.Text = _form1.nyviLbl.Text
        'Me.gptLbl.Text = _form1.gptLbl.Text
        'Me.kenoLbl.Text = _form1.kenoLbl.Text
        'Me.uc100Lbl.Text = _form1.uc100Lbl.Text
        'Me.pdmLbl.Text = _form1.pdmLbl.Text
        'Me.gt1200ApejLbl.Text = _form1.gt1200ApejLbl.Text
        'Me.gt1200AptdLbl.Text = _form1.gt1200AptdLbl.Text
        'Me.geminiLbl.Text = _form1.geminiLbl.Text
        'Me.sstLbl.Text = _form1.sstLbl.Text
        'Me.transLbl.Text = _form1.transLbl.Text
        'Me.liappLbl.Text = _form1.liappLbl.Text
        'Me.usernameRomRVLbl.Text = _form1.usernameRomRVLbl.Text


    End Sub
End Class