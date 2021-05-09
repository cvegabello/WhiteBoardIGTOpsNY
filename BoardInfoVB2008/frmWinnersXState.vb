Public Class frmWinnersXState

    Public _gameNumber As Integer
    Public _cdcInt As Integer
    Public _drawInt As Integer

    Public Sub New(ByVal gameNumber As Integer, ByVal cdcInt As Integer, ByVal drawInt As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _gameNumber = gameNumber
        _cdcInt = cdcInt
        _drawInt = drawInt

    End Sub

    Private Sub frmWinnersXState_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim numrecordsInt As Integer

        Dim table1 As DataTable


        Select Case _gameNumber
            Case 1
                Label11.Text = "MEGA MILLIONS"
                Me.Text = "MEGA MILLIONS"

            Case 10
                Label11.Text = "POWERBALL"
                Me.Text = "POWERBALL"

            Case 6
                Label11.Text = "LOTTO"
                Me.Text = "LOTTO"

            Case 5
                Label11.Text = "CASH4LIFE"
                Me.Text = "CASH4LIFE"

        End Select

        Label12.Text = CStr(_cdcInt)
        Label1.Text = CStr(_drawInt)


        parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", _gameNumber)
        parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", _cdcInt)
        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("numWinnerXStateXGameXcdc", parameters1)
        grdWinnersStates.DataSource = table1
        numrecordsInt = table1.Rows.Count

        If numrecordsInt <> 0 Then
            formatGridWinnersXState(grdWinnersStates, numrecordsInt)
        Else

        End If


    End Sub

    

    Private Sub formatGridWinnersXState(ByVal dataGridWinners As DataGridView, ByVal numRows As Integer)

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle


        'Dim DataGridHeaderStyle1 As DataGridView = New DataGridViewTopLeftHeaderCell

        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn


        Column1 = dataGridWinners.Columns(0)
        Column2 = dataGridWinners.Columns(1)


        For i = 0 To numRows
            dataGridWinners.Rows(i).Height = 20
        Next

        'State
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.DarkKhaki
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki
        DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Navy

        Column1.DefaultCellStyle = DataGridViewCellStyle1

        Column1.HeaderText = "STATE"

        Column1.Resizable = DataGridViewTriState.[True]
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        Column1.Width = 100



        'Winners
        ''
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = Color.DarkKhaki
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Navy
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        Column2.HeaderText = "WINNERS"
        Column2.Resizable = DataGridViewTriState.[True]
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        Column2.Width = 100

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class