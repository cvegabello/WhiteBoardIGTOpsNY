
Imports System.Media

Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Public _form1 As Form1
    Public _btnNumber As Integer
    Private Player As New SoundPlayer
    Public Sub New(ByVal form1 As Form1, ByRef btnNumber As Integer)
        'MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        'Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + "\Nautilus.isl")
        InitializeComponent()
        _form1 = form1
        _btnNumber = btnNumber

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

    '    ''Dim VerifiPass As New ValidarUsuarioDominio.Service
    '    'Dim userNameStr, pswStr, pathStr, domainStr As String
    '    'Dim results As Boolean

    '    ''Wait.start_wait()
    '    'userNameStr = Trim(UsernameTextBox.Text)
    '    'pswStr = Trim(PasswordTextBox.Text)
    '    'pathStr = " LDAP://DC=GTK,DC=GTECH,DC=COM "
    '    'domainStr = "gtk.gtech.com"

    '    'results = Utils.UserAuthenticateActiveDirectory(pathStr, userNameStr, pswStr)
    '    'If results Then
    '    '    _formMain.StatusStrip.Items(1).Text = userNameStr
    '    '    'Current.UserName = userNameStr
    '    'Else
    '    '    MsgBox("Usuario o Clave invalidos en el domingio gtk.gtech.com.", MsgBoxStyle.Information)


    '    'End If
    '    ''results = True

    '    ''Wait.stopwait_wait()
    '    ''If results Then
    '    ''    _formMain.UltraToolbarsManager1.Ribbon.Tabs.Item(1).Visible = True
    '    ''    _formMain.UltraToolbarsManager1.Ribbon.Tabs.Item(0).Visible = False
    '    ''    

    '    ''Else 'Logueo Fallido 
    '    ''    MsgBox("Usuario o Clave invalidos en el domingio gtk.gtech.com.", MsgBoxStyle.Information)


    '    ''End If
    '    ''VerifiPass = Nothing
    '    GC.Collect()
    '    Me.Close()




    'End Sub

    'Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
    '    Me.Close()
    'End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case _btnNumber
            Case 0
                Me.Text = "LOGIN"
                UsernameTextBox.Text = Trim(_form1.lblUserTemp.Text)
            Case 1

                Me.Text = "TAKE OVER ESTE LOGIN"
                UsernameTextBox.Text = Trim(_form1.lblUserLogin.Text)
                PasswordTextBox.Select()

            Case 2

                Me.Text = "ROM RV LOGIN"
                UsernameTextBox.Text = Trim(_form1.lblUserLogin.Text)
                PasswordTextBox.Select()

            Case 3

                Me.Text = "LOGIN UPDATE"
                UsernameTextBox.Text = Trim(_form1.lblUserLogin.Text)
                PasswordTextBox.Select()

            Case 4



        End Select



    End Sub

    'Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

    '    Dim userNameStr, passStr, passwordFromDatabaseStr As String
    '    Dim coddepartmentInt, Cont As Integer
    '    Dim tableInfoUser As DataTable
    '    userNameStr = Trim(UsernameTextBox.Text)
    '    passStr = Trim(PasswordTextBox.Text)
    '    _form1.lblUserTemp.Text = userNameStr
    '    tableInfoUser = getInfoUserFromDatabase(userNameStr)
    '    Cont = tableInfoUser.Rows.Count

    '    Select Case _btnNumber
    '        Case 0

    '            If Cont = 0 Then
    '                _form1.lblFlag.Text = "3"
    '            Else

    '                passwordFromDatabaseStr = tableInfoUser.Rows(0).Item(0)
    '                coddepartmentInt = tableInfoUser.Rows(0).Item(1)

    '                If passwordFromDatabaseStr = passStr And coddepartmentInt = 1 Then
    '                    '_form1.lblUserUpdate.Text = userNameStr
    '                    '_form1.lblDateUpdate.Text = Now
    '                    _form1.lblUserLogin.Text = userNameStr
    '                    _form1.lblFlag.Text = "1"
    '                    saveLogLogin(userNameStr, Now, "INITIAL LOGIN.")
    '                ElseIf passwordFromDatabaseStr = passStr And coddepartmentInt <> 1 Then
    '                    _form1.lblUserLogin.Text = userNameStr
    '                    saveLogLogin(userNameStr, Now, "INITIAL LOGIN.")
    '                    _form1.lblFlag.Text = "2"

    '                Else
    '                    _form1.lblFlag.Text = "0"

    '                End If
    '            End If



    '        Case 1

    '            If Cont = 0 Then
    '                _form1.lblFlag.Text = "3"
    '            Else

    '                passwordFromDatabaseStr = tableInfoUser.Rows(0).Item(0)
    '                coddepartmentInt = tableInfoUser.Rows(0).Item(1)

    '                If passwordFromDatabaseStr = passStr And coddepartmentInt = 1 Then
    '                    _form1.usernameTakeOverLbl.Text = userNameStr
    '                    '_form1.lblDateUpdate.Text = Now
    '                    _form1.lblFlag.Text = "1"
    '                    saveLogLogin(userNameStr, Now, "TAKE OVER ESTE LOGIN.")
    '                ElseIf passwordFromDatabaseStr = passStr And coddepartmentInt <> 1 Then
    '                    _form1.lblFlag.Text = "2"

    '                Else
    '                    _form1.lblFlag.Text = "0"

    '                End If
    '            End If


    '        Case 2

    '            If Cont = 0 Then
    '                _form1.lblFlag.Text = "3"
    '            Else

    '                passwordFromDatabaseStr = tableInfoUser.Rows(0).Item(0)
    '                coddepartmentInt = tableInfoUser.Rows(0).Item(1)

    '                If passwordFromDatabaseStr = passStr And coddepartmentInt = 1 Then
    '                    '_form1.usernameRomRVLbl.Text = userNameStr
    '                    '_form1.lblDateUpdate.Text = Now
    '                    _form1.lblFlag.Text = "1"
    '                    saveLogLogin(userNameStr, Now, "ROM RV LOGIN.")
    '                ElseIf passwordFromDatabaseStr = passStr And coddepartmentInt <> 1 Then
    '                    _form1.lblFlag.Text = "2"

    '                Else
    '                    _form1.lblFlag.Text = "0"

    '                End If
    '            End If


    '        Case 3

    '            If Cont = 0 Then
    '                _form1.lblFlag.Text = "3"
    '            Else

    '                passwordFromDatabaseStr = tableInfoUser.Rows(0).Item(0)
    '                coddepartmentInt = tableInfoUser.Rows(0).Item(1)


    '                If passwordFromDatabaseStr = passStr And coddepartmentInt = 1 Then
    '                    '_form1.lblUserLogin.Text = userNameStr
    '                    _form1.lblDateUpdate.Text = Now
    '                    _form1.lblFlag.Text = "1"
    '                    saveLogLogin(userNameStr, Now, "UPDATE WINNERS LOGIN.")
    '                ElseIf passwordFromDatabaseStr = passStr And coddepartmentInt <> 1 Then
    '                    _form1.lblFlag.Text = "2"

    '                Else
    '                    _form1.lblFlag.Text = "0"
    '                    'Me.Visible = False
    '                    'Me.ShowDialog()

    '                End If
    '            End If

    '        Case 4



    '    End Select


    'End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click

        Select Case _btnNumber
            Case 0
                
                _form1.Close() 'Login
            Case 1

                Me.Close() 'Update

            Case 2


            Case 3

                Me.Close() 'Take over Este

            Case 4



        End Select



    End Sub
End Class
