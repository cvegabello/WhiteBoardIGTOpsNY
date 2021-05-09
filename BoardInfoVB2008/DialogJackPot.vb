Imports System.Windows.Forms


Public Class DialogJackPot
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Dim _productSysCodeInt As Integer


    Public Sub New(ByVal productSysCodeInt As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _productSysCodeInt = productSysCodeInt

        Select Case _productSysCodeInt

            Case 12
                Me.Text = "MegaMillions"

            Case 15
                Me.Text = "Powerball"

            Case 8
                Me.Text = "Lotto"

        End Select



    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim newJackPotDbl As Double

        newJackPotDbl = CDbl(TextBox1.Text)

        updateJackPot(_productSysCodeInt, newJackPotDbl)


        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogJackPot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        OK_Button.Enabled = False

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If IsNumeric(TextBox1.Text) Then
            TextBox1.Text = Format(CDbl(TextBox1.Text), "##,##0")
            Button1.Image = Global.WindowsApplication1.My.Resources.Resources.button_ok
            OK_Button.Enabled = True
        Else
            Button1.Image = Global.WindowsApplication1.My.Resources.Resources.button_cancel
        End If
    End Sub
End Class
