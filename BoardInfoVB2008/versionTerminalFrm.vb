Imports MySql.Data.MySqlClient

Public Class versionTerminalFrm

    Public _appNumber As Integer
    Public _userNameStr As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim verAppStr As String


        If TextBox1.Text <> "" Then

            Select Case _appNumber

                Case 1

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "NYVI_APIF", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "NYVI_APIF", _userNameStr)
                        
                    End If


                Case 2

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "GPT_APNE", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "GPT_APNE", _userNameStr)

                    End If


                Case 3

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "SST_APQE", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "SST_APQE", _userNameStr)

                    End If


                Case 4

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "NY_KENO", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "NY_KENO", _userNameStr)

                    End If

                Case 5

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "UC100", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "UC100", _userNameStr)

                    End If

                Case 6

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "GT1200_APEJ", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "GT1200_APEJ", _userNameStr)

                    End If

                Case 7

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "GT1200_APTD", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "GT1200_APTD", _userNameStr)

                    End If

                Case 8

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "NY_TRANS", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "NY_TRANS", _userNameStr)

                    End If

                Case 9

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "GEMINI", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "GEMINI", _userNameStr)

                    End If

                Case 10

                    If TextBox2.Text <> "" Then
                        verAppStr = Trim(TextBox1.Text & "/" & TextBox2.Text)
                        updateAppVersion(verAppStr, "PDM", _userNameStr)

                    Else
                        verAppStr = Trim(TextBox1.Text)
                        updateAppVersion(verAppStr, "PDM", _userNameStr)

                    End If


            End Select

            Me.Close()

        Else



        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Sub New(ByVal appNumber As Integer, ByVal userNameStr As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _appNumber = appNumber
        _userNameStr = userNameStr

    End Sub

    Private Sub versionTerminalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appVersionStr As String = ""
        Dim err1, numRegArray As Integer
        Dim appArray() As String
        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        Select Case _appNumber

            Case 1
                Parametros1(0) = New MySqlParameter("@appname", "NYVI_APIF")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "NYVI_APIF"

            Case 2
                Parametros1(0) = New MySqlParameter("@appname", "GPT_APNE")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "GPT_APNE"

            Case 3
                Parametros1(0) = New MySqlParameter("@appname", "SST_APQE")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "SST_APQE"

            Case 4
                Parametros1(0) = New MySqlParameter("@appname", "NY_KENO")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "NY_KENO"

            Case 5

                Parametros1(0) = New MySqlParameter("@appname", "UC100")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "UC100"

            Case 6

                Parametros1(0) = New MySqlParameter("@appname", "GT1200_APEJ")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "GT1200_APEJ"

            Case 7

                Parametros1(0) = New MySqlParameter("@appname", "GT1200_APTD")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "GT1200_APTD"

            Case 8

                Parametros1(0) = New MySqlParameter("@appname", "NY_TRANS")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "NY_TRANS"

            Case 9
                Parametros1(0) = New MySqlParameter("@appname", "GEMINI")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "GEMINI"

            Case 10
                Parametros1(0) = New MySqlParameter("@appname", "PDM")
                err1 = dataSourceAccess.RunStoreProcedureScalarString("returnAppVersion", Parametros1, appVersionStr, msgErrorStr)
                appArray = appVersionStr.Split("/")
                numRegArray = appArray.Length
                If numRegArray = 1 Then
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = ""
                Else
                    TextBox1.Text = appArray(0)
                    TextBox2.Text = appArray(1)
                End If

                Me.Text = "PDM"

        End Select


    End Sub

    
End Class