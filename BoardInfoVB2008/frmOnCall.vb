Public Class frmOnCall

    Public _form1 As Form1
    Public Sub New(ByVal form1 As Form1)
        'MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        'Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + "\Nautilus.isl")
        InitializeComponent()
        _form1 = form1

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub
    Private Sub frmOnCall_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tableQonCall As DataTable

        tableQonCall = dataSourceAccess.RunStoreQueryWithoutParameters("qoncall")
        ComboBox1.DataSource = tableQonCall
        ComboBox1.DisplayMember = "oncallname"
        tableQonCall = dataSourceAccess.RunStoreQueryWithoutParameters("qoncall")
        ComboBox2.DataSource = tableQonCall
        ComboBox2.DisplayMember = "oncallname"
        tableQonCall = dataSourceAccess.RunStoreQueryWithoutParameters("qoncall")
        ComboBox3.DataSource = tableQonCall
        ComboBox3.DisplayMember = "oncallname"

        ComboBox1.Text = _form1.grdOnCall.Item(1, 1).Value
        ComboBox2.Text = _form1.grdOnCall.Item(1, 2).Value
        ComboBox3.Text = _form1.grdOnCall.Item(1, 3).Value

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Dispose()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim msgErrorStr As String = ""
        Dim errorCode As Integer

        errorCode = updateOnCall(Trim(ComboBox1.Text), 1, msgErrorStr)

        Select Case errorCode
            Case 0

            Case Else

                MsgBox("Error: " & msgErrorStr, MsgBoxStyle.Critical, "ERROR")

        End Select

        errorCode = updateOnCall(Trim(ComboBox2.Text), 2, msgErrorStr)

        Select Case errorCode
            Case 0

            Case Else

                MsgBox("Error: " & msgErrorStr, MsgBoxStyle.Critical, "ERROR")

        End Select

        errorCode = updateOnCall(Trim(ComboBox3.Text), 3, msgErrorStr)

        Select Case errorCode
            Case 0

            Case Else

                MsgBox("Error: " & msgErrorStr, MsgBoxStyle.Critical, "ERROR")

        End Select



    End Sub
End Class