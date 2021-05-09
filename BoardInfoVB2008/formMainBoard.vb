Imports System.Windows.Forms

Public Class formMainBoard



    'Private Sub frm_Hijo(ByVal nomForm As String)
    '    'Wait.start_wait()
    '    Select Case nomForm
    '        'Case "frmPuntosVenta"
    '        '    Dim objPuntosVenta As New frmPuntosVenta(Me)
    '        '    'habilitarToolBar(False)
    '        '    'Me.UltraToolbarsManager1.Ribbon.IsMinimized = True
    '        '    objPuntosVenta.MdiParent = Me
    '        '    objPuntosVenta.Show()

    '        Case "LoginForm1"
    '            Dim objLoginFrm As New LoginForm1(Me)
    '            objLoginFrm.MdiParent = Me
    '            objLoginFrm.Show()

    '            'Case "frmRazonSocial"
    '            '    Dim objRsocial As New frmRazonSocial(Me)
    '            '    'habilitarToolBar(False)
    '            '    Me.UltraToolbarsManager1.Ribbon.IsMinimized = True
    '            '    objRsocial.MdiParent = Me
    '            '    objRsocial.Show()

    '            'Case "frmCadenas"
    '            '    Dim objCadenas As New frmCadenas(Me)
    '            '    'habilitarToolBar(False)
    '            '    Me.UltraToolbarsManager1.Ribbon.IsMinimized = True
    '            '    objCadenas.MdiParent = Me
    '            '    objCadenas.Show()

    '            'Case "FmrOrdenesDeTrabajo"
    '            '    Dim objOrdenesDeTrabajo As New FmrOrdenesDeTrabajo
    '            '    Me.UltraToolbarsManager1.Ribbon.IsMinimized = True
    '            '    objOrdenesDeTrabajo.MdiParent = Me
    '            '    objOrdenesDeTrabajo.Show()

    '    End Select
    '    'Wait.stopwait_wait()
    'End Sub



    'Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click

    '    frm_Hijo("LoginForm1")

    '    '' Create a new instance of the child form.
    '    'Dim ChildForm As New System.Windows.Forms.Form
    '    '' Make it a child of this MDI form before showing it.
    '    'ChildForm.MdiParent = Me

    '    'm_ChildFormNumber += 1
    '    'ChildForm.Text = "Window " & m_ChildFormNumber

    '    'ChildForm.Show()
    'End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

    End Sub
End Class
