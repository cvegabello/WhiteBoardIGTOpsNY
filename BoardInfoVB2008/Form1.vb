Imports MySql.Data.MySqlClient
Imports System.Media

Public Class Form1
    Private Player As New SoundPlayer
    Declare Sub Sleep Lib "kernel32" (ByVal milliseconds As Long)

    Private Sub infoBoard()

        Dim tableQhostSystems As DataTable
        Dim tableQonCallCurrent As DataTable
        Dim tableQserverdb_app As DataTable
        Dim tableRes As DataTable
        Dim tableDate As DataTable
        Dim tableBigg As DataTable
        Dim tableLoto As DataTable
        Dim tablePwrb As DataTable
        'Dim tableLife As DataTable
        Dim tableWin As DataTable
        Dim tableRomVersion As DataTable
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim fecha As Date
        Dim dayInt, cdcInt, drawInt, errCod As Integer
        Dim jackpotDbl As Double
        Dim jackPotStr, shortNameListStr, shortNameStr As String
        Dim msgErrorStr As String = ""
        Dim valueObj As Object

        fecha = Format(Now, "MM/dd/yyyy")

        tableQonCallCurrent = dataSourceAccess.RunStoreQueryWithoutParameters("qoncallcurrent")
        grdOnCall.DataSource = tableQonCallCurrent
        formatGridOnCall(grdOnCall)
        tableQhostSystems = dataSourceAccess.RunStoreQueryWithoutParameters("qhostsystems")
        Label21.Text = tableQhostSystems.Rows(0).Item(0)
        Label21.ForeColor = returnColor(Label21.Text)
        Label22.Text = tableQhostSystems.Rows(0).Item(1)
        Label22.ForeColor = returnColor(Label22.Text)
        Label23.Text = tableQhostSystems.Rows(0).Item(2)
        Label23.ForeColor = returnColor(Label23.Text)
        Label24.Text = tableQhostSystems.Rows(0).Item(3)
        Label24.ForeColor = returnColor(Label24.Text)
        Label25.Text = tableQhostSystems.Rows(0).Item(4)
        Label25.ForeColor = returnColor(Label25.Text)
        tableQserverdb_app = dataSourceAccess.RunStoreQueryWithoutParameters("qserverdb_app")
        Label32.Text = tableQserverdb_app.Rows(0).Item(0)
        Label41.Text = tableQserverdb_app.Rows(0).Item(1)
        Label43.Text = tableQserverdb_app.Rows(0).Item(2)
        Label3.Text = tableQserverdb_app.Rows(0).Item(3)


        'lblCdcOtg.Text = returnCDC_OTG(fecha)

        tableDate = Utils.getInfoDateTbl(fecha)
        grdDate1.DataSource = tableDate
        formatGridDate()

        tableRes = Utils.getDrawsGamesTbl(fecha)
        grdDraws.DataSource = tableRes
        formatGrid()

        tableBigg = getLast2WinnersJackpotTbl(1)
        grdBigg.DataSource = tableBigg
        formatGridLast2Winners(grdBigg)


        valueObj = grdBigg.Item(2, 0)
        If (valueObj.value > 0) Then
            drawInt = CInt(grdBigg.Item(1, 0).Value)
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            tableWin = getShortNameStateTbl(1, cdcInt)
            shortNameListStr = ""
            For Each row1 In tableWin.Rows
                shortNameStr = row1("short_name")
                If shortNameListStr = "" Then
                    shortNameListStr = shortNameStr
                Else
                    shortNameListStr = shortNameListStr & "," & shortNameStr
                End If
            Next
            Button19.Text = shortNameListStr
        Else
            Button19.Text = ""
        End If

        valueObj = grdBigg.Item(2, 1)
        If (valueObj.value > 0) Then
            drawInt = CInt(grdBigg.Item(1, 1).Value)
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            tableWin = getShortNameStateTbl(1, cdcInt)
            shortNameListStr = ""
            For Each row1 In tableWin.Rows
                shortNameStr = row1("short_name")
                If shortNameListStr = "" Then
                    shortNameListStr = shortNameStr
                Else
                    shortNameListStr = shortNameListStr & "," & shortNameStr
                End If
            Next
            Button20.Text = shortNameListStr
        Else
            Button20.Text = ""
        End If


        valueObj = grdBigg.Item(3, 0)
        jackpotDbl = valueObj.value

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            grdBigg.Item(3, 0).Value = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            grdBigg.Item(3, 0).Value = jackPotStr
        End If

        valueObj = grdBigg.Item(3, 1)
        jackpotDbl = valueObj.value

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            grdBigg.Item(3, 1).Value = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            grdBigg.Item(3, 1).Value = jackPotStr
        End If


        tableLoto = getLast2WinnersJackpotTbl(6)
        grdLoto.DataSource = tableLoto
        formatGridLast2Winners(grdLoto)


        valueObj = grdLoto.Item(3, 0)
        jackpotDbl = valueObj.value

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            grdLoto.Item(3, 0).Value = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            grdLoto.Item(3, 0).Value = jackPotStr
        End If

        valueObj = grdLoto.Item(3, 1)
        jackpotDbl = valueObj.value

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            grdLoto.Item(3, 1).Value = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            grdLoto.Item(3, 1).Value = jackPotStr
        End If


        tablePwrb = getLast2WinnersJackpotTbl(10)
        grdPwrb.DataSource = tablePwrb
        formatGridLast2Winners(grdPwrb)


        valueObj = grdPwrb.Item(2, 0)
        If (valueObj.value > 0) Then
            drawInt = CInt(grdPwrb.Item(1, 0).Value)
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            tableWin = getShortNameStateTbl(10, cdcInt)
            shortNameListStr = ""
            For Each row1 In tableWin.Rows
                shortNameStr = row1("short_name")
                If shortNameListStr = "" Then
                    shortNameListStr = shortNameStr
                Else
                    shortNameListStr = shortNameListStr & "," & shortNameStr
                End If
            Next
            Button28.Text = shortNameListStr
        Else
            Button28.Text = ""
        End If

        valueObj = grdPwrb.Item(2, 1)
        If (valueObj.value > 0) Then
            drawInt = CInt(grdPwrb.Item(1, 1).Value)
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            tableWin = getShortNameStateTbl(10, cdcInt)
            shortNameListStr = ""
            For Each row1 In tableWin.Rows
                shortNameStr = row1("short_name")
                If shortNameListStr = "" Then
                    shortNameListStr = shortNameStr
                Else
                    shortNameListStr = shortNameListStr & "," & shortNameStr
                End If
            Next
            Button27.Text = shortNameListStr
        Else
            Button27.Text = ""
        End If


        valueObj = grdPwrb.Item(3, 0)
        jackpotDbl = valueObj.value

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            grdPwrb.Item(3, 0).Value = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            grdPwrb.Item(3, 0).Value = jackPotStr
        End If

        valueObj = grdPwrb.Item(3, 1)
        jackpotDbl = valueObj.value

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            grdPwrb.Item(3, 1).Value = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            grdPwrb.Item(3, 1).Value = jackPotStr
        End If


        'tableLife = getLast2WinnersJackpotTbl(5)
        'grdLife.DataSource = tableLife
        'formatGridLast2Winners(grdLife)

        'valueObj = grdLife.Item(2, 0)
        'If (valueObj.value > 0) Then
        '    drawInt = CInt(grdLife.Item(1, 0).Value)
        '    parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
        '    parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
        '    errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
        '    tableWin = getShortNameStateTbl(5, cdcInt)
        '    shortNameListStr = ""
        '    For Each row1 In tableWin.Rows
        '        shortNameStr = row1("short_name")
        '        If shortNameListStr = "" Then
        '            shortNameListStr = shortNameStr
        '        Else
        '            shortNameListStr = shortNameListStr & "," & shortNameStr
        '        End If
        '    Next
        '    Button31.Text = shortNameListStr
        'Else
        '    Button31.Text = ""
        'End If

        'valueObj = grdLife.Item(2, 1)
        'If (valueObj.value > 0) Then
        '    drawInt = CInt(grdLife.Item(1, 1).Value)
        '    parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
        '    parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
        '    errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
        '    tableWin = getShortNameStateTbl(5, cdcInt)
        '    shortNameListStr = ""
        '    For Each row1 In tableWin.Rows
        '        shortNameStr = row1("short_name")
        '        If shortNameListStr = "" Then
        '            shortNameListStr = shortNameStr
        '        Else
        '            shortNameListStr = shortNameListStr & "," & shortNameStr
        '        End If
        '    Next
        '    Button29.Text = shortNameListStr
        'Else
        '    Button29.Text = ""
        'End If


        tableRomVersion = getAppVersion()
        grdROMVersion.DataSource = tableRomVersion
        formatGridRomVersion(grdROMVersion)


        For i = 0 To 3
            grdTake5Hor.Rows.Add()
        Next
        dayInt = Weekday(fecha)
        Select Case dayInt

            Case 1 'Sunday
                Utils.getLastWinnersTake5TblHorizontal(7)

            Case 2 'Monday
                Utils.getLastWinnersTake5TblHorizontal(1)

            Case 3 'Tuesday
                Utils.getLastWinnersTake5TblHorizontal(2)

            Case 4 'Wednesday
                Utils.getLastWinnersTake5TblHorizontal(3)

            Case 5 'Thursday
                Utils.getLastWinnersTake5TblHorizontal(4)

            Case 6 'Friday
                Utils.getLastWinnersTake5TblHorizontal(5)

            Case 7 'Saturday
                Utils.getLastWinnersTake5TblHorizontal(6)
        End Select
        formatGridTake5WinnersHorizontal(grdTake5Hor)

        '--------------------------------------------------------------------------------
        jackpotDbl = getCurrentJackpotFromDatabase(1) 'BIGG

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            Button2.Text = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            Button2.Text = jackPotStr
        End If

        jackpotDbl = getCurrentJackpotFromDatabase(10) 'PWRB

        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            Button4.Text = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            Button4.Text = jackPotStr
        End If


        jackpotDbl = getCurrentJackpotFromDatabase(6) 'LOTO
        If jackpotDbl < 1000000000 Then
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
            Button3.Text = jackPotStr
        Else
            jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
            Button3.Text = jackPotStr
        End If
        '----------------------------------------------------------------------------------------

        If fecha = nextDayDraw(12, fecha) Then

            Label8.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label8.ForeColor = Color.DarkGreen
            Label8.Location = New System.Drawing.Point(50, 50)
            Label8.Text = "TONIGHT "
            Label54.ForeColor = Color.DarkGreen
            Label54.Text = "22:45:00"
            Label4.Text = ""
        Else
            Label8.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label8.ForeColor = Color.Navy
            Label8.Location = New System.Drawing.Point(25, 58)
            Label8.Text = Format(nextDayDraw(12, fecha), "MMM dd yyyy")

            Label54.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label54.ForeColor = Color.Navy
            Label54.Text = "22:45:00"
            Label4.Text = returnDayWeek(Weekday(Label8.Text))

            'Label1.Enabled = False
        End If

        If fecha = nextDayDraw(15, fecha) Then
            Label11.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label11.ForeColor = Color.DarkGreen
            Label11.Location = New System.Drawing.Point(50, 50)
            Label11.Text = "TONIGHT"
            Label55.ForeColor = Color.DarkGreen
            Label55.Text = "22:00:00"
            Label14.Text = ""
        Else
            Label11.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label11.ForeColor = Color.Navy
            Label11.Location = New System.Drawing.Point(25, 58)
            Label11.Text = Format(nextDayDraw(15, fecha), "MMM dd yyyy")
            Label55.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label55.ForeColor = Color.Navy
            Label55.Text = "22:00:00"
            Label14.Text = returnDayWeek(Weekday(Label11.Text))
            'Label16.Enabled = False
        End If

        If fecha = nextDayDraw(8, fecha) Then

            Label13.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label13.ForeColor = Color.DarkGreen
            Label13.Location = New System.Drawing.Point(50, 50)
            Label13.Text = "TONIGHT"
            Label56.ForeColor = Color.DarkGreen
            Label56.Text = "20:00:00"
            Label17.Text = ""
        Else
            Label13.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label13.ForeColor = Color.Navy
            Label13.Location = New System.Drawing.Point(25, 58)
            Label13.Text = Format(nextDayDraw(8, fecha), "MMM dd yyyy")

            Label56.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label56.ForeColor = Color.Navy
            Label56.Text = "20:00:00"
            Label17.Text = returnDayWeek(Weekday(Label13.Text))

            'Label17.Enabled = False
        End If


        If fecha = nextDayDraw(13, fecha) Then
            Label15.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label15.ForeColor = Color.DarkGreen
            Label15.Location = New System.Drawing.Point(50, 75)
            Label15.Text = "TONIGHT"
            Label57.ForeColor = Color.DarkGreen
            Label57.Text = "20:45:00"
        Else
            Label15.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label15.ForeColor = Color.Navy
            Label15.Location = New System.Drawing.Point(25, 75)
            Label15.Text = Format(nextDayDraw(13, fecha), "MMM dd yyyy")
            Label57.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Label57.ForeColor = Color.Navy
            Label57.Text = "20:45:00"
            'Label18.Enabled = False
        End If

        'Label20.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Label20.ForeColor = Color.DarkGreen
        'Label20.Text = "DAILY"


        If (IsDrawDay(12, fecha)) Then
            'Label1.Enabled = True
            LinkLblBigg.Enabled = True
        Else
            'Label1.Enabled = False
            LinkLblBigg.Enabled = False
        End If


        If (IsDrawDay(15, fecha)) Then
            'Label16.Enabled = True
            LinkLblPwb.Enabled = True
        Else
            'Label16.Enabled = False
            LinkLblPwb.Enabled = False
        End If


        If (IsDrawDay(8, fecha)) Then
            'Label17.Enabled = True
            LinkLblLoto.Enabled = True
        Else
            'Label17.Enabled = False
            LinkLblLoto.Enabled = False

        End If

        If (IsDrawDay(13, fecha)) Then
            'Label18.Enabled = True
            LinkLblLife.Enabled = True
        Else
            'Label18.Enabled = False
            LinkLblLife.Enabled = False
        End If

    End Sub




    Private Sub formatGridDate()

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle

        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn



        Column1 = grdDate1.Columns(0)
        Column2 = grdDate1.Columns(1)


        For i = 0 To 2
            grdDate1.Rows(i).Height = 68
        Next

        'colTitle
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        'DataGridViewCellStyle1.BackColor = Color.DarkKhaki
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 42.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.WhiteSmoke
        'DataGridViewCellStyle1.ForeColor = Drawing.Color.Navy
        'DataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki
        DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Black
        Column1.DefaultCellStyle = DataGridViewCellStyle1
        Column1.HeaderText = ""

        Column1.Resizable = DataGridViewTriState.[True]
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        Column1.Width = 175


        'colValue
        ''
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 42.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Red
        DataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = Drawing.Color.Red
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        Column2.HeaderText = ""

        Column2.Resizable = DataGridViewTriState.[True]
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        Column2.Width = 315


    End Sub


    Private Sub formatGrid()

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle

        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column3 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim celda As DataGridViewCell
        Column1 = grdDraws.Columns(0)
        Column2 = grdDraws.Columns(1)
        Column3 = grdDraws.Columns(2)



        'colProducts
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        'DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Black
        Column1.DefaultCellStyle = DataGridViewCellStyle1
        Column1.HeaderText = "GAME"

        Column1.Resizable = DataGridViewTriState.[True]
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        Column1.Width = 200


        'colDraw1
        ''
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = Drawing.Color.Black
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        Column2.HeaderText = "FIRST DRAW"

        Column2.Resizable = DataGridViewTriState.[True]
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        Column2.Width = 150


        ''colDraw2
        ''
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = Drawing.Color.Black
        Column3.DefaultCellStyle = DataGridViewCellStyle3
        Column3.HeaderText = "LAST DRAW"

        Column3.Resizable = DataGridViewTriState.[True]
        Column3.SortMode = DataGridViewColumnSortMode.NotSortable
        Column3.Width = 150


        For i = 1 To 2
            celda = grdDraws.Rows(8).Cells(i)
            celda.Style.Font = New System.Drawing.Font("Calibri", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Next

    End Sub


    Private Sub formatGridLast2Winners(ByVal dataGridWinners As DataGridView)

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle

        'Dim DataGridHeaderStyle1 As DataGridView = New DataGridViewTopLeftHeaderCell

        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column3 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column4 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn


        Column1 = dataGridWinners.Columns(0)
        Column2 = dataGridWinners.Columns(1)
        Column3 = dataGridWinners.Columns(2)
        Column4 = dataGridWinners.Columns(3)

        For i = 0 To 1
            dataGridWinners.Rows(i).Height = 45
        Next

        'colDayWeek
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Black



        Column1.DefaultCellStyle = DataGridViewCellStyle1

        Column1.HeaderText = "DAY"

        Column1.Resizable = DataGridViewTriState.[True]
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        Column1.Width = 170
        'Column1.Width = 10



        'colDraw
        ''
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = Drawing.Color.Black
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        Column2.HeaderText = "DRAW"
        Column2.Resizable = DataGridViewTriState.[True]
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        'Column2.Width = 0
        Column2.Visible = False


        ''colWinners
        ''
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = Drawing.Color.Black
        Column3.DefaultCellStyle = DataGridViewCellStyle3
        Column3.HeaderText = "WINNERS"
        Column3.Resizable = DataGridViewTriState.[True]
        Column3.SortMode = DataGridViewColumnSortMode.NotSortable
        Column3.Width = 120


        ''colJackPot
        ''
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle4.SelectionForeColor = Drawing.Color.Black
        DataGridViewCellStyle4.Format = "$##,##0"
        Column4.DefaultCellStyle = DataGridViewCellStyle4
        Column4.HeaderText = "JACKPOT"
        Column4.Resizable = DataGridViewTriState.[True]
        Column4.SortMode = DataGridViewColumnSortMode.NotSortable
        Column4.Width = 190



    End Sub

    Private Sub formatGridRomVersion(ByVal dataGridROM As DataGridView)

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle

        'Dim DataGridHeaderStyle1 As DataGridView = New DataGridViewTopLeftHeaderCell

        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column3 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn

        Column1 = dataGridROM.Columns(0)
        Column2 = dataGridROM.Columns(1)
        Column3 = dataGridROM.Columns(2)


        For i = 0 To 15
            dataGridROM.Rows(i).Height = 48
        Next

        'APP NAME
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Black

        Column1.DefaultCellStyle = DataGridViewCellStyle1

        Column1.HeaderText = "APPLICATION NAME"

        Column1.Resizable = DataGridViewTriState.[True]
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        Column1.Width = 260

        'Column1.Width = 10



        'version
        ''
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = Drawing.Color.Black
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        Column2.HeaderText = "VERSION"
        Column2.Resizable = DataGridViewTriState.[True]
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        Column2.Width = 135

        'Column2.Visible = False


        ''Date
        ''
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = Drawing.Color.Black
        Column3.DefaultCellStyle = DataGridViewCellStyle3
        Column3.HeaderText = "LAST SUBMISSION TIME"
        Column3.Resizable = DataGridViewTriState.[True]
        Column3.SortMode = DataGridViewColumnSortMode.NotSortable
        Column3.Width = 220


        ''colJackPot
        ''



    End Sub
    Private Sub formatGridTake5WinnersHorizontal(ByVal dataGridWinners As DataGridView)

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle

        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column3 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column4 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column5 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column6 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column7 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column8 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn

        Column1 = dataGridWinners.Columns(0)
        Column2 = dataGridWinners.Columns(1)
        Column3 = dataGridWinners.Columns(2)
        Column4 = dataGridWinners.Columns(3)
        Column5 = dataGridWinners.Columns(4)
        Column6 = dataGridWinners.Columns(5)
        Column7 = dataGridWinners.Columns(6)
        Column8 = dataGridWinners.Columns(7)

        For i = 0 To 4
            dataGridWinners.Rows(i).Height = 40
        Next

        'colDayWeek
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Black
        Column1.DefaultCellStyle = DataGridViewCellStyle1
        Column1.Width = 162


        'colDraw
        ''
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = Drawing.Color.Black
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        Column2.Width = 122



        ''
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.SelectionForeColor = Drawing.Color.Black
        Column3.DefaultCellStyle = DataGridViewCellStyle3
        Column3.Width = 122



        ' ''
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle4.SelectionForeColor = Drawing.Color.Black
        Column4.DefaultCellStyle = DataGridViewCellStyle4
        Column4.Width = 122



        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionForeColor = Drawing.Color.Black
        Column5.DefaultCellStyle = DataGridViewCellStyle5
        Column5.Width = 123


        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle6.SelectionForeColor = Drawing.Color.Black
        Column6.DefaultCellStyle = DataGridViewCellStyle6
        Column6.Width = 122


        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle7.SelectionForeColor = Drawing.Color.Black
        Column7.DefaultCellStyle = DataGridViewCellStyle7
        Column7.Width = 122

        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = Color.WhiteSmoke
        DataGridViewCellStyle8.SelectionForeColor = Drawing.Color.Black
        Column8.DefaultCellStyle = DataGridViewCellStyle8
        Column8.Width = 122


    End Sub
    Private Sub formatGridOnCall(ByVal grdOnCall As DataGridView)

        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle



        Dim Column1 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column2 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
        Dim Column3 As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn



        Column1 = grdOnCall.Columns(0)
        Column2 = grdOnCall.Columns(1)
        Column3 = grdOnCall.Columns(2)


        For i = 0 To 3
            grdOnCall.Rows(i).Height = 50
        Next



        'level
        '
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Drawing.Color.Black
        'DataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki
        'DataGridViewCellStyle1.SelectionForeColor = Drawing.Color.Navy

        Column1.DefaultCellStyle = DataGridViewCellStyle1

        'Column1.HeaderText = "DAY"

        'Column1.Resizable = DataGridViewTriState.[True]
        Column1.SortMode = DataGridViewColumnSortMode.NotSortable
        Column1.Width = 30
        'Column1.Width = 10



        'name On call
        ''
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Drawing.Color.Black
        Column2.DefaultCellStyle = DataGridViewCellStyle2
        'Column2.HeaderText = "DRAW"
        'Column2.Resizable = DataGridViewTriState.[True]
        Column2.SortMode = DataGridViewColumnSortMode.NotSortable
        Column2.Width = 235



        ''Phone Number
        ''
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Drawing.Color.Black
        Column3.DefaultCellStyle = DataGridViewCellStyle3
        'Column3.HeaderText = "WINNERS"
        'Column3.Resizable = DataGridViewTriState.[True]
        Column3.SortMode = DataGridViewColumnSortMode.NotSortable
        Column3.Width = 192



    End Sub
    Private Sub LoadBoard()

        Dim resCodBool As Boolean
        Dim result As Windows.Forms.DialogResult = Windows.Forms.DialogResult.OK

        Timer1.Enabled = False
        Me.timeLbl.Text = Format(TimeOfDay, "HH:mm:ss")
        'controlsVisible(False)
        resCodBool = dataSourceAccess.ConexionMySQL()

        If (resCodBool) Then

            Me.infoBoard()

            Me.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Me.loginToolStrip.Visible = False
            Me.Cursor = Cursors.Default
            Timer1.Enabled = True

        End If
        

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim encontrado As Boolean = False
        Dim p As Process
        Dim cont As Integer = 0
        Timer1.Enabled = False
        For Each p In Process.GetProcesses()
            If Not p Is Nothing Then
                If p.ProcessName = "WhiteBoard 3.0" Then
                    cont += 1
                End If
            End If
        Next
        If cont <= 1 Then
            LoadBoard()
        ElseIf cont > 1 Then
            MsgBox("The White Board already is open. Press Shift, Windows and LEFT arrow key to move the app to the PC screen.", MsgBoxStyle.Information, "White Board")
            Me.Dispose()
        End If

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim resultsStrDays, productSysNameStr, strPath, strFlagFileWithPath, strFileHostMode, shortNameStr, shortNameListStr, strFlagFileAppWithPath As String
        Dim messErrorStr As String = ""
        Dim drawDayInt, idProductInt, timeDrawInt, dayOfWeekInt, cdcInt As Integer
        Dim tableQproducts As DataTable
        Dim drawDateCurrent As Date
        Dim time As Date = Date.Now
        Dim initDate As Date
        Dim diff1 As TimeSpan
        Dim drawDaysStr(1) As String
        Dim tableDate As DataTable
        Dim tableRes As DataTable
        Dim tableBigg As DataTable
        Dim tableLoto As DataTable
        Dim tablePwrb As DataTable
        'Dim tableLife As DataTable
        Dim tableWin As DataTable
        Dim tableQhostSystems As DataTable
        Dim tableRomVersion As DataTable
        Dim dayInt As Integer
        Dim jackpotDbl, firstDrawKenoDbl As Double
        Dim jackPotStr As String
        Dim fecha As Date
        Dim errCodeInt As Integer = 0
        Dim errMessageStr As String = ""
        Dim hostNumberArray(5) As String
        Dim Parametros1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim strFilePath As String
        Dim resBool As Boolean
        Dim valueObj As Object
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim drawInt, errCod As Integer
        Dim msgErrorStr As String = ""
        Dim flagJackpotPendingArray() As String = {"", "", ""}

        Me.timeLbl.Text = Format(TimeOfDay, "HH:mm:ss")

        controlsVisible(True)
        tableQproducts = dataSourceAccess.RunStoreQueryWithoutParameters("qproducts")

        For Each row1 In tableQproducts.Rows
            If Not (IsDBNull(row1("drawDateCurrent"))) Then
                drawDateCurrent = row1("drawDateCurrent")
                productSysNameStr = Trim(row1("productSysName"))
                idProductInt = row1("idProduct")
                initDate = drawDateCurrent
                diff1 = initDate.Subtract(time)
                If (diff1.Seconds < 0) Or (diff1.Minutes < 0) Or (diff1.Hours < 0) Or (diff1.Days < 0) Then
                    If IsNumeric(Trim(row1("drawDay"))) Then
                        drawDayInt = CInt(row1("drawDay"))
                        Select Case drawDayInt
                            Case 0
                                drawDateCurrent = drawDateCurrent.AddDays(1)

                                'Me.Player.SoundLocation = "C:\Users\cvegabello\Documents\VisualStudio2008\Projects\BoardInfoVB2008\BoardInfoVB2008\bin\Debug\DefaultSound.wav"
                                'Me.Player.Play()


                            Case 10
                                timeDrawInt = drawDateCurrent.Hour
                                If timeDrawInt = 12 Then
                                    drawDateCurrent = drawDateCurrent.AddHours(7)
                                    drawDateCurrent = drawDateCurrent.AddMinutes(10)
                                Else
                                    drawDateCurrent = drawDateCurrent.AddHours(16)
                                    drawDateCurrent = drawDateCurrent.AddMinutes(50)

                                End If

                        End Select

                    Else
                        dayOfWeekInt = drawDateCurrent.DayOfWeek
                        drawDaysStr = Split(Trim(row1("drawDay")), "|")
                        If dayOfWeekInt = drawDaysStr(0) Then
                            While dayOfWeekInt <> drawDaysStr(1)
                                drawDateCurrent = drawDateCurrent.AddDays(1)
                                dayOfWeekInt = drawDateCurrent.DayOfWeek
                            End While

                        Else
                            While dayOfWeekInt <> drawDaysStr(0)
                                drawDateCurrent = drawDateCurrent.AddDays(1)
                                dayOfWeekInt = drawDateCurrent.DayOfWeek
                            End While
                        End If

                    End If
                    Parametros1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawDateCurrent", drawDateCurrent)
                    Parametros1(1) = New MySql.Data.MySqlClient.MySqlParameter("@idProduct", idProductInt)
                    RunStoreProcedureParametersNonQuery("UpdateDrawDateCurrent", Parametros1, messErrorStr)
                Else
                    resultsStrDays = diff1.Days.ToString.PadLeft(2, "0") & ":" & diff1.Hours.ToString.PadLeft(2, "0") & ":" & diff1.Minutes.ToString.PadLeft(2, "0") & ":" & diff1.Seconds.ToString.PadLeft(2, "0")

                    Select Case productSysNameStr
                        Case "PCK3"
                            'Me.pck3CountDownLbl.Text = resultsStrDays

                        Case "PCK4"

                            'Me.pck4CountDownLbl.Text = resultsStrDays

                        Case "DKNO"
                            'Me.dknoCountDownLbl.Text = resultsStrDays

                        Case "BIGG"
                            'Me.biggCountDownLbl.Text = resultsStrDays

                            If (resultsStrDays = "00:00:05:00") Then
                                'Me.Player.SoundLocation = "C:\Users\cvegabello\Documents\VisualStudio2008\Projects\BoardInfoVB2008\BoardInfoVB2008\bin\Debug\reminder.wav"
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button5.Text = resultsStrDays
                                'For i = 0 To 4
                                '    'Label1.Visible = False
                                '    Sleep(1000)
                                '    'Label1.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label1.Visible = True
                                '    'Label1.Refresh()
                                '    Sleep(1000)
                                'Next


                            ElseIf (resultsStrDays = "00:00:00:25") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button5.Text = resultsStrDays
                                'For i = 0 To 2
                                '    'Label1.Visible = False
                                '    Sleep(1000)
                                '    'Label1.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label1.Visible = True
                                '    'Label1.Refresh()
                                '    Sleep(1000)
                                'Next
                            ElseIf (resultsStrDays = "00:00:00:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\DefaultSound.wav"
                                Me.Player.Play()
                                Me.Button5.Text = resultsStrDays
                                'For i = 0 To 4
                                '    'Label1.Visible = False
                                '    Sleep(1000)
                                '    'Label1.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label1.Visible = True
                                '    'Label1.Refresh()
                                '    Sleep(1000)
                                'Next

                            End If

                            Me.Button5.Text = resultsStrDays

                        Case "LOTO"

                            'Me.lotoCountDownLbl.Text = resultsStrDays

                            If (resultsStrDays = "00:00:05:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button7.Text = resultsStrDays
                                'For i = 0 To 4
                                '    'Label17.Visible = False
                                '    Sleep(1000)
                                '    'Label17.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label17.Visible = True
                                '    'Label17.Refresh()
                                '    Sleep(1000)
                                'Next


                            ElseIf (resultsStrDays = "00:00:00:25") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button7.Text = resultsStrDays
                                'For i = 0 To 2
                                '    'Label17.Visible = False
                                '    Sleep(1000)
                                '    'Label17.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label17.Visible = True
                                '    'Label17.Refresh()
                                '    Sleep(1000)
                                'Next
                            ElseIf (resultsStrDays = "00:00:00:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\DefaultSound.wav"
                                Me.Player.Play()
                                Me.Button7.Text = resultsStrDays
                                'For i = 0 To 4
                                '    'Label17.Visible = False
                                '    Sleep(1000)
                                '    'Label17.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label17.Visible = True
                                '    'Label17.Refresh()
                                '    Sleep(1000)
                                'Next

                            End If

                            Me.Button7.Text = resultsStrDays

                        Case "CSH5"
                            'Me.csh5CountDownLbl.Text = resultsStrDays

                        Case "LIFE"
                            'Me.lifeCountDownLbl.Text = resultsStrDays


                            If (resultsStrDays = "00:00:05:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button8.Text = resultsStrDays
                                'For i = 0 To 4
                                '    'Label18.Visible = False
                                '    Sleep(1000)
                                '    'Label18.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label18.Visible = True
                                '    'Label18.Refresh()
                                '    Sleep(1000)
                                'Next


                            ElseIf (resultsStrDays = "00:00:00:25") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button8.Text = resultsStrDays
                                'For i = 0 To 2
                                '    'Label18.Visible = False
                                '    Sleep(1000)
                                '    'Label18.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label18.Visible = True
                                '    'Label18.Refresh()
                                '    Sleep(1000)
                                'Next
                            ElseIf (resultsStrDays = "00:00:00:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\DefaultSound.wav"
                                Me.Player.Play()
                                Me.Button8.Text = resultsStrDays
                                'For i = 0 To 4
                                '    'Label18.Visible = False
                                '    Sleep(1000)
                                '    'Label18.Refresh()
                                '    'Label18.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                                '    'Label18.Visible = True
                                '    'Label18.Refresh()
                                '    Sleep(1000)
                                'Next

                            End If
                            'Label18.Font = New System.Drawing.Font("Impact", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            Me.Button8.Text = resultsStrDays

                        Case "PWRB"

                            'Me.pwrbCountDownLbl.Text = resultsStrDays

                            If (resultsStrDays = "00:00:05:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button6.Text = resultsStrDays
                                'For i = 0 To 4

                                '    Sleep(2000)


                                'Next


                            ElseIf (resultsStrDays = "00:00:00:25") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\reminder.wav"
                                Me.Player.Play()
                                Me.Button6.Text = resultsStrDays
                                'For i = 0 To 2
                                '    Sleep(2000)
                                'Next
                            ElseIf (resultsStrDays = "00:00:00:00") Then
                                Me.Player.SoundLocation = Application.StartupPath & "\DefaultSound.wav"
                                Me.Player.Play()
                                Me.Button6.Text = resultsStrDays
                                'For i = 0 To 4
                                '    Sleep(2000)
                                'Next

                            End If


                            Me.Button6.Text = resultsStrDays


                    End Select



                End If

            End If

        Next
        fecha = Format(Now, "MM/dd/yyyy")

        strPath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()

        strFlagFileAppWithPath = strPath & "\flagFileAppVersion.txt"

        If (My.Computer.FileSystem.FileExists(strFlagFileAppWithPath)) Then
            My.Computer.FileSystem.DeleteFile(strFlagFileAppWithPath)
            tableRomVersion = getAppVersion()
            grdROMVersion.DataSource = tableRomVersion
            formatGridRomVersion(grdROMVersion)

        End If

        strFlagFileWithPath = strPath & "\flagFile.txt"


        If (My.Computer.FileSystem.FileExists(strFlagFileWithPath)) Then
            My.Computer.FileSystem.DeleteFile(strFlagFileWithPath)
            Utils.getAndSaveWinnersALLProduct(fecha, flagJackpotPendingArray, errCodeInt, errMessageStr)
            If errCodeInt = 0 Then
                saveLogLogin("Scheduled.", Now, "UPDATE WINNERS.")
            Else
                MsgBox("Error: " & errMessageStr, MsgBoxStyle.Information, "Error")
            End If

            strFileHostMode = strPath & "\hostMode.txt"
            If (My.Computer.FileSystem.FileExists(strFileHostMode)) Then
                errCodeInt = getSaveHostMode(strFileHostMode, hostNumberArray, errMessageStr)
                If errCodeInt = 0 Then
                    saveLogLogin("Scheduled.", Now, "UPDATE HOST MODE.")
                    My.Computer.FileSystem.DeleteFile(strFileHostMode)
                ElseIf errCodeInt = 2 Then
                    My.Computer.FileSystem.DeleteFile(strFileHostMode)
                Else
                    MsgBox("Error: " & errMessageStr, MsgBoxStyle.Information, "Error")
                End If
            End If


            tableQhostSystems = dataSourceAccess.RunStoreQueryWithoutParameters("qhostsystems")
            Label21.Text = tableQhostSystems.Rows(0).Item(0)
            Label21.ForeColor = returnColor(Label21.Text)
            Label22.Text = tableQhostSystems.Rows(0).Item(1)
            Label22.ForeColor = returnColor(Label22.Text)
            Label23.Text = tableQhostSystems.Rows(0).Item(2)
            Label23.ForeColor = returnColor(Label23.Text)
            Label24.Text = tableQhostSystems.Rows(0).Item(3)
            Label24.ForeColor = returnColor(Label24.Text)
            Label25.Text = tableQhostSystems.Rows(0).Item(4)
            Label25.ForeColor = returnColor(Label25.Text)


            tableBigg = getLast2WinnersJackpotTbl(1)
            grdBigg.DataSource = tableBigg
            formatGridLast2Winners(grdBigg)


            valueObj = grdBigg.Item(2, 0)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdBigg.Item(1, 0).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(1, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button19.Text = shortNameListStr
            Else
                Button19.Text = ""
            End If

            valueObj = grdBigg.Item(2, 1)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdBigg.Item(1, 1).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(1, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button20.Text = shortNameListStr
            Else
                Button20.Text = ""
            End If

            valueObj = grdBigg.Item(3, 0)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdBigg.Item(3, 0).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdBigg.Item(3, 0).Value = jackPotStr
            End If


            valueObj = grdBigg.Item(3, 1)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdBigg.Item(3, 1).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdBigg.Item(3, 1).Value = jackPotStr
            End If


            tableLoto = getLast2WinnersJackpotTbl(6)
            grdLoto.DataSource = tableLoto
            formatGridLast2Winners(grdLoto)


            valueObj = grdLoto.Item(3, 0)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdLoto.Item(3, 0).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdLoto.Item(3, 0).Value = jackPotStr
            End If

            valueObj = grdLoto.Item(3, 1)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdLoto.Item(3, 1).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdLoto.Item(3, 1).Value = jackPotStr
            End If


            tablePwrb = getLast2WinnersJackpotTbl(10)
            grdPwrb.DataSource = tablePwrb
            formatGridLast2Winners(grdPwrb)

            valueObj = grdPwrb.Item(2, 0)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdPwrb.Item(1, 0).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(10, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button28.Text = shortNameListStr
            Else
                Button28.Text = ""
            End If

            valueObj = grdPwrb.Item(2, 1)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdPwrb.Item(1, 1).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(10, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button27.Text = shortNameListStr
            Else
                Button27.Text = ""
            End If

            valueObj = grdPwrb.Item(3, 0)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdPwrb.Item(3, 0).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdPwrb.Item(3, 0).Value = jackPotStr
            End If

            valueObj = grdPwrb.Item(3, 1)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdPwrb.Item(3, 1).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdPwrb.Item(3, 1).Value = jackPotStr
            End If


            'tableLife = getLast2WinnersJackpotTbl(5)
            'grdLife.DataSource = tableLife
            'formatGridLast2Winners(grdLife)

            'valueObj = grdLife.Item(2, 0)
            'If (valueObj.value > 0) Then
            '    drawInt = CInt(grdLife.Item(1, 0).Value)
            '    parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            '    parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
            '    errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            '    tableWin = getShortNameStateTbl(5, cdcInt)
            '    shortNameListStr = ""
            '    For Each row1 In tableWin.Rows
            '        shortNameStr = row1("short_name")
            '        If shortNameListStr = "" Then
            '            shortNameListStr = shortNameStr
            '        Else
            '            shortNameListStr = shortNameListStr & "," & shortNameStr
            '        End If
            '    Next
            '    Button31.Text = shortNameListStr
            'Else
            '    Button31.Text = ""
            'End If

            'valueObj = grdLife.Item(2, 1)
            'If (valueObj.value > 0) Then
            '    drawInt = CInt(grdLife.Item(1, 1).Value)
            '    parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            '    parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
            '    errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            '    tableWin = getShortNameStateTbl(5, cdcInt)
            '    shortNameListStr = ""
            '    For Each row1 In tableWin.Rows
            '        shortNameStr = row1("short_name")
            '        If shortNameListStr = "" Then
            '            shortNameListStr = shortNameStr
            '        Else
            '            shortNameListStr = shortNameListStr & "," & shortNameStr
            '        End If
            '    Next
            '    Button29.Text = shortNameListStr
            'Else
            '    Button29.Text = ""
            'End If

            grdTake5Hor.Rows.Clear()

            For i = 0 To 3
                grdTake5Hor.Rows.Add()
            Next


            dayInt = Weekday(fecha)
            Select Case dayInt

                Case 1
                    Utils.getLastWinnersTake5TblHorizontal(7)

                Case 2
                    Utils.getLastWinnersTake5TblHorizontal(1)

                Case 3
                    Utils.getLastWinnersTake5TblHorizontal(2)

                Case 4
                    Utils.getLastWinnersTake5TblHorizontal(3)

                Case 5
                    Utils.getLastWinnersTake5TblHorizontal(4)
                Case 6
                    Utils.getLastWinnersTake5TblHorizontal(5)

                Case 7
                    Utils.getLastWinnersTake5TblHorizontal(6)
            End Select
            formatGridTake5WinnersHorizontal(grdTake5Hor)

            '------------------------------------------------------------------------------------
            If flagJackpotPendingArray(1) <> "BIGG_PENDING" Then
                jackpotDbl = getCurrentJackpotFromDatabase(1) 'BIGG
                If jackpotDbl < 1000000000 Then
                    jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                    Button2.Text = jackPotStr
                Else
                    jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                    Button2.Text = jackPotStr
                End If
            End If


            If flagJackpotPendingArray(2) <> "PWRB_PENDING" Then
                jackpotDbl = getCurrentJackpotFromDatabase(10) 'PWRB
                If jackpotDbl < 1000000000 Then
                    jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                    Button4.Text = jackPotStr
                Else
                    jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                    Button4.Text = jackPotStr
                End If
            End If

            If flagJackpotPendingArray(0) <> "LOTO_PENDING" Then
                jackpotDbl = getCurrentJackpotFromDatabase(6) 'LOTO
                If jackpotDbl < 1000000000 Then
                    jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                    Button3.Text = jackPotStr
                Else
                    jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                    Button3.Text = jackPotStr
                End If
            End If



            '-------------------------------------------------------------------------------------------------------


            strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
            msgErrorStr = ""
            resBool = moveFiles(strFilePath, strFilePath & "\History", fecha, msgErrorStr)

            If Not resBool Then
                MsgBox("Error in move the files to History folder: " & msgErrorStr, MsgBoxStyle.Critical, "Error")

            End If


        End If


        If Me.timeLbl.Text = "00:00:00" Then

            'lblCdcOtg.Text = returnCDC_OTG(fecha)
            tableDate = Utils.getInfoDateTbl(fecha)
            grdDate1.DataSource = tableDate
            formatGridDate()

            tableRes = Utils.getDrawsGamesTbl(fecha)
            grdDraws.DataSource = tableRes
            formatGrid()

            If fecha = nextDayDraw(12, fecha) Then

                Label8.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label8.ForeColor = Color.DarkGreen
                Label8.Location = New System.Drawing.Point(50, 50)
                Label8.Text = "TONIGHT "
                Label54.ForeColor = Color.DarkGreen
                Label54.Text = "22:45:00"
                Label4.Text = ""
            Else
                Label8.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label8.ForeColor = Color.Navy
                Label8.Location = New System.Drawing.Point(25, 58)
                Label8.Text = Format(nextDayDraw(12, fecha), "MMM dd yyyy")

                Label54.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label54.ForeColor = Color.Navy
                Label54.Text = "22:45:00"
                Label4.Text = returnDayWeek(Weekday(Label8.Text))
                'Label1.Enabled = False
            End If

            If fecha = nextDayDraw(15, fecha) Then
                Label11.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label11.ForeColor = Color.DarkGreen
                Label11.Location = New System.Drawing.Point(50, 50)
                Label11.Text = "TONIGHT"
                Label55.ForeColor = Color.DarkGreen
                Label55.Text = "22:00:00"
                Label14.Text = ""
            Else
                Label11.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label11.ForeColor = Color.Navy
                Label11.Location = New System.Drawing.Point(25, 58)
                Label11.Text = Format(nextDayDraw(15, fecha), "MMM dd yyyy")
                Label55.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label55.ForeColor = Color.Navy
                Label55.Text = "22:00:00"
                Label14.Text = returnDayWeek(Weekday(Label11.Text))
                'Label16.Enabled = False
            End If

            If fecha = nextDayDraw(8, fecha) Then

                Label13.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label13.ForeColor = Color.DarkGreen
                Label13.Location = New System.Drawing.Point(50, 50)
                Label13.Text = "TONIGHT"
                Label56.ForeColor = Color.DarkGreen
                Label56.Text = "20:00:00"
                Label17.Text = ""
            Else
                Label13.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label13.ForeColor = Color.Navy
                Label13.Location = New System.Drawing.Point(25, 58)
                Label13.Text = Format(nextDayDraw(8, fecha), "MMM dd yyyy")
                Label56.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label56.ForeColor = Color.Navy
                Label56.Text = "20:00:00"
                Label17.Text = returnDayWeek(Weekday(Label13.Text))
                'Label17.Enabled = False
            End If


            If fecha = nextDayDraw(13, fecha) Then
                Label15.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label15.ForeColor = Color.DarkGreen
                Label15.Location = New System.Drawing.Point(50, 75)
                Label15.Text = "TONIGHT"
                Label57.ForeColor = Color.DarkGreen
                Label57.Text = "20:45:00"
            Else

                Label15.Font = New System.Drawing.Font("Calibri", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label15.ForeColor = Color.Navy
                Label15.Location = New System.Drawing.Point(25, 75)
                Label15.Text = Format(nextDayDraw(13, fecha), "MMM dd yyyy")
                Label57.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Label57.ForeColor = Color.Navy
                Label57.Text = "20:45:00"
                'Label18.Enabled = False
            End If

            'Label20.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Label20.ForeColor = Color.DarkGreen
            'Label20.Text = "DAILY"


            If (IsDrawDay(12, fecha)) Then
                'Label1.Enabled = True
                LinkLblBigg.Enabled = True
            Else
                'Label1.Enabled = False
                LinkLblBigg.Enabled = False
            End If


            If (IsDrawDay(15, fecha)) Then
                'Label16.Enabled = True
                LinkLblPwb.Enabled = True
            Else
                'Label16.Enabled = False
                LinkLblPwb.Enabled = False
            End If


            If (IsDrawDay(8, fecha)) Then
                'Label17.Enabled = True
                LinkLblLoto.Enabled = True
            Else
                'Label17.Enabled = False
                LinkLblLoto.Enabled = False

            End If

            If (IsDrawDay(13, fecha)) Then
                'Label18.Enabled = True
                LinkLblLife.Enabled = True
            Else
                'Label18.Enabled = False
                LinkLblLife.Enabled = False
            End If
        ElseIf Me.timeLbl.Text = "03:30:00" Then
            tableDate = Utils.getInfoDateTbl(fecha)
            grdDate1.DataSource = tableDate
            formatGridDate()
            firstDrawKenoDbl = Utils.GetSetting(appName, "FirstDrawKeno", "").ToString()
            Utils.SalvarSetting(appName, "FirstDrawKeno", firstDrawKenoDbl + 351)
            tableRes = Utils.getDrawsGamesTbl(fecha)
            grdDraws.DataSource = tableRes
            formatGrid()

        End If



        'diff1 = initDate.Subtract(time)
        'resultsStrDays = diff1.Days & ":" & diff1.Hours & ":" & diff1.Minutes & ":" & diff1.Seconds
        'Me.dknoCountDownLbl.Text = resultsStrDays




    End Sub
    Private Sub controlsVisible(ByRef resBool As Boolean)

        PictureBox3.Visible = resBool
        PictureBox4.Visible = resBool
        PictureBox9.Visible = resBool

        'biggPic.Visible = resBool
        PictureBox5.Visible = resBool
        PictureBox6.Visible = resBool

        PictureBox7.Visible = resBool
        PictureBox8.Visible = resBool
        PictureBox13.Visible = resBool
        PictureBox14.Visible = resBool
        'Panel1.Visible = resBool

        'Panel2.Visible = resBool
        'Panel3.Visible = resBool
        Panel4.Visible = resBool
        Panel5.Visible = resBool
        Panel6.Visible = resBool
        Panel7.Visible = resBool
        timeLbl.Visible = resBool
        Panel9.Visible = resBool
        Panel10.Visible = resBool
        grdDate1.Visible = resBool
        grdOnCall.Visible = resBool
        grdROMVersion.Visible = resBool
        grdDraws.Visible = resBool
        grdBigg.Visible = resBool
        grdPwrb.Visible = resBool
        grdLoto.Visible = resBool
        'grdLife.Visible = resBool
        grdTake5Hor.Visible = resBool
        Button2.Visible = resBool
        Button4.Visible = resBool
        Button3.Visible = resBool

        PictureBox12.Visible = resBool
        PictureBox1.Visible = resBool
        PictureBox2.Visible = resBool
        PictureBox10.Visible = resBool
        'PictureBox11.Visible = resBool

        Button19.Visible = resBool
        Button20.Visible = resBool
        Button28.Visible = resBool
        Button27.Visible = resBool
        Button31.Visible = resBool
        'Button29.Visible = resBool

        LinkLblBigg.Visible = resBool
        LinkLblPwb.Visible = resBool
        LinkLblLoto.Visible = resBool
        LinkLblLife.Visible = resBool

        'Label20.Visible = resBool


    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim valueObj As Object
        Dim drawInt, cdcInt, errCod, numWinInt As Integer
        Dim frmWinnersXStateObj As frmWinnersXState
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim msgErrorStr As String = ""
        valueObj = grdBigg.Item(2, 0)
        numWinInt = valueObj.value
        If numWinInt <> 0 Then
            valueObj = grdBigg.Item(1, 0)
            drawInt = valueObj.value
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            frmWinnersXStateObj = New frmWinnersXState(1, cdcInt, drawInt)
            frmWinnersXStateObj.ShowDialog()
        Else
            MsgBox("No JACKPOT MEGA MILLIONS Winners", MsgBoxStyle.Information, "No Winners")
        End If
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim valueObj As Object
        Dim drawInt, cdcInt, errCod, numWinInt As Integer
        Dim frmWinnersXStateObj As frmWinnersXState
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim msgErrorStr As String = ""

        valueObj = grdBigg.Item(2, 1)
        numWinInt = valueObj.value
        If numWinInt <> 0 Then
            valueObj = grdBigg.Item(1, 1)
            drawInt = valueObj.value
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            frmWinnersXStateObj = New frmWinnersXState(1, cdcInt, drawInt)
            frmWinnersXStateObj.ShowDialog()
        Else
            MsgBox("No JACKPOT MEGA MILLIONS Winners", MsgBoxStyle.Information, "No Winners")
        End If
    End Sub
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Dim valueObj As Object
        Dim drawInt, cdcInt, errCod, numWinInt As Integer
        Dim frmWinnersXStateObj As frmWinnersXState
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim msgErrorStr As String = ""
        valueObj = grdPwrb.Item(2, 0)
        numWinInt = valueObj.value
        If numWinInt <> 0 Then
            valueObj = grdPwrb.Item(1, 0)
            drawInt = valueObj.value
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            frmWinnersXStateObj = New frmWinnersXState(10, cdcInt, drawInt)
            frmWinnersXStateObj.ShowDialog()
        Else
            MsgBox("No JACKPOT POWERBALL Winners", MsgBoxStyle.Information, "No Winners")
        End If
    End Sub
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click

        Dim valueObj As Object
        Dim drawInt, cdcInt, errCod, numWinInt As Integer
        Dim frmWinnersXStateObj As frmWinnersXState
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim msgErrorStr As String = ""

        valueObj = grdPwrb.Item(2, 1)
        numWinInt = valueObj.value
        If numWinInt <> 0 Then
            valueObj = grdPwrb.Item(1, 1)
            drawInt = valueObj.value
            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
            frmWinnersXStateObj = New frmWinnersXState(10, cdcInt, drawInt)
            frmWinnersXStateObj.ShowDialog()
        Else
            MsgBox("No JACKPOT POWERBALL Winners", MsgBoxStyle.Information, "No Winners")
        End If
    End Sub
    'Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
    '    Dim valueObj As Object
    '    Dim drawInt, cdcInt, errCod, numWinInt As Integer
    '    Dim frmWinnersXStateObj As frmWinnersXState
    '    Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
    '    Dim msgErrorStr As String = ""
    '    valueObj = grdLife.Item(2, 0)
    '    numWinInt = valueObj.value
    '    If numWinInt <> 0 Then
    '        valueObj = grdLife.Item(1, 0)
    '        drawInt = valueObj.value
    '        parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
    '        parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
    '        errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
    '        frmWinnersXStateObj = New frmWinnersXState(5, cdcInt, drawInt)
    '        frmWinnersXStateObj.ShowDialog()
    '    Else
    '        MsgBox("No JACKPOT CASH4LIFE Winners", MsgBoxStyle.Information, "No Winners")
    '    End If
    'End Sub
    'Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim valueObj As Object
    '    Dim drawInt, cdcInt, errCod, numWinInt As Integer
    '    Dim frmWinnersXStateObj As frmWinnersXState
    '    Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
    '    Dim msgErrorStr As String = ""
    '    valueObj = grdLife.Item(2, 1)
    '    numWinInt = valueObj.value
    '    If numWinInt <> 0 Then
    '        valueObj = grdLife.Item(1, 1)
    '        drawInt = valueObj.value
    '        parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
    '        parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
    '        errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
    '        frmWinnersXStateObj = New frmWinnersXState(5, cdcInt, drawInt)
    '        frmWinnersXStateObj.ShowDialog()
    '    Else
    '        MsgBox("No JACKPOT CASH4LIFE Winners", MsgBoxStyle.Information, "No Winners")
    '    End If
    'End Sub
    Private Sub LinkLblPwb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLblPwb.LinkClicked
        Dim vWinnersJackpotFrm As New winnersJackpotFrm(10)
        Dim jackpotDbl As Double
        Dim jackPotStr As String
        Dim valueObj As Object
        Dim table1 As DataTable
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim tableWin As DataTable
        Dim shortNameListStr, shortNameStr As String
        Dim msgErrorStr As String = ""
        Dim cdcInt, drawInt, errCod As Integer


        If vWinnersJackpotFrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            table1 = getLast2WinnersJackpotTbl(10)
            grdPwrb.DataSource = table1
            formatGridLast2Winners(grdPwrb)


            valueObj = grdPwrb.Item(2, 0)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdPwrb.Item(1, 0).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(10, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button28.Text = shortNameListStr
            Else
                Button28.Text = ""
            End If

            valueObj = grdPwrb.Item(2, 1)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdPwrb.Item(1, 1).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 10)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(10, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button27.Text = shortNameListStr
            Else
                Button27.Text = ""
            End If

            valueObj = grdPwrb.Item(3, 0)
            jackpotDbl = valueObj.value
            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdPwrb.Item(3, 0).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdPwrb.Item(3, 0).Value = jackPotStr
            End If
            valueObj = grdPwrb.Item(3, 1)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdPwrb.Item(3, 1).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdPwrb.Item(3, 1).Value = jackPotStr
            End If


        End If
    End Sub
    Private Sub LinkLblBigg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLblBigg.LinkClicked
        Dim table1 As DataTable
        Dim jackpotDbl As Double
        Dim jackPotStr As String
        Dim cdcInt, drawInt, errCod As Integer
        Dim valueObj As Object
        Dim vWinnersJackpotFrm As New winnersJackpotFrm(1)
        Dim result As Windows.Forms.DialogResult
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim tableWin As DataTable
        Dim shortNameListStr, shortNameStr As String
        Dim msgErrorStr As String = ""
        result = vWinnersJackpotFrm.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            table1 = getLast2WinnersJackpotTbl(1)
            grdBigg.DataSource = table1
            formatGridLast2Winners(grdBigg)
            valueObj = grdBigg.Item(2, 0)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdBigg.Item(1, 0).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(1, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button19.Text = shortNameListStr
            Else
                Button19.Text = ""
            End If
            valueObj = grdBigg.Item(2, 1)
            If (valueObj.value > 0) Then
                drawInt = CInt(grdBigg.Item(1, 1).Value)
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 1)
                errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
                tableWin = getShortNameStateTbl(1, cdcInt)
                shortNameListStr = ""
                For Each row1 In tableWin.Rows
                    shortNameStr = row1("short_name")
                    If shortNameListStr = "" Then
                        shortNameListStr = shortNameStr
                    Else
                        shortNameListStr = shortNameListStr & "," & shortNameStr
                    End If
                Next
                Button20.Text = shortNameListStr
            Else
                Button20.Text = ""
            End If
            valueObj = grdBigg.Item(3, 0)
            jackpotDbl = valueObj.value
            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdBigg.Item(3, 0).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdBigg.Item(3, 0).Value = jackPotStr
            End If
            valueObj = grdBigg.Item(3, 1)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdBigg.Item(3, 1).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdBigg.Item(3, 1).Value = jackPotStr
            End If

        End If
    End Sub
    Private Sub LinkLblLoto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLblLoto.LinkClicked
        Dim vWinnersJackpotFrm As New winnersJackpotFrm(6)
        Dim table1 As DataTable
        Dim jackpotDbl As Double
        Dim jackPotStr As String
        Dim valueObj As Object
        If vWinnersJackpotFrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            table1 = getLast2WinnersJackpotTbl(6)
            grdLoto.DataSource = table1
            formatGridLast2Winners(grdLoto)
            valueObj = grdLoto.Item(3, 0)
            jackpotDbl = valueObj.value
            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdLoto.Item(3, 0).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdLoto.Item(3, 0).Value = jackPotStr
            End If
            valueObj = grdLoto.Item(3, 1)
            jackpotDbl = valueObj.value

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                grdLoto.Item(3, 1).Value = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                grdLoto.Item(3, 1).Value = jackPotStr
            End If
        End If
    End Sub
    'Private Sub LinkLblLife_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLblLife.LinkClicked
    '    Dim vWinnersJackpotFrm As New winnersJackpotFrm(5)
    '    Dim table1 As DataTable
    '    Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
    '    Dim tableWin As DataTable
    '    Dim shortNameListStr, shortNameStr As String
    '    Dim msgErrorStr As String = ""
    '    Dim cdcInt, drawInt, errCod As Integer
    '    Dim valueObj As Object
    '    If vWinnersJackpotFrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        table1 = getLast2WinnersJackpotTbl(5)
    '        grdLife.DataSource = table1
    '        formatGridLast2Winners(grdLife)
    '        valueObj = grdLife.Item(2, 0)
    '        If (valueObj.value > 0) Then
    '            drawInt = CInt(grdLife.Item(1, 0).Value)
    '            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
    '            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
    '            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
    '            tableWin = getShortNameStateTbl(5, cdcInt)
    '            shortNameListStr = ""
    '            For Each row1 In tableWin.Rows
    '                shortNameStr = row1("short_name")
    '                If shortNameListStr = "" Then
    '                    shortNameListStr = shortNameStr
    '                Else
    '                    shortNameListStr = shortNameListStr & "," & shortNameStr
    '                End If
    '            Next
    '            Button31.Text = shortNameListStr
    '        Else
    '            Button31.Text = ""
    '        End If

    '        valueObj = grdLife.Item(2, 1)
    '        If (valueObj.value > 0) Then
    '            drawInt = CInt(grdLife.Item(1, 1).Value)
    '            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@drawGame", drawInt)
    '            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", 5)
    '            errCod = RunStoreProcedureScalarString("returnCDCXGameXDraw", parameters1, cdcInt, msgErrorStr)
    '            tableWin = getShortNameStateTbl(5, cdcInt)
    '            shortNameListStr = ""
    '            For Each row1 In tableWin.Rows
    '                shortNameStr = row1("short_name")
    '                If shortNameListStr = "" Then
    '                    shortNameListStr = shortNameStr
    '                Else
    '                    shortNameListStr = shortNameListStr & "," & shortNameStr
    '                End If
    '            Next
    '            Button29.Text = shortNameListStr
    '        Else
    '            Button29.Text = ""
    '        End If
    '    End If
    'End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim jackpotDbl As Double
        Dim jackPotStr As String
        Dim result As Windows.Forms.DialogResult = Windows.Forms.DialogResult.OK
        Dim dJackPot As New DialogJackPot(12)
        result = dJackPot.ShowDialog()
        If (result = Windows.Forms.DialogResult.OK) Then
            jackpotDbl = getCurrentJackpotFromDatabase(1) 'BIGG
            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                Button2.Text = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                Button2.Text = jackPotStr
            End If
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim jackpotDbl As Double
        Dim jackPotStr As String
        Dim result As Windows.Forms.DialogResult = Windows.Forms.DialogResult.OK
        Dim dJackPot As New DialogJackPot(15)
        result = dJackPot.ShowDialog()
        If (result = Windows.Forms.DialogResult.OK) Then
            jackpotDbl = getCurrentJackpotFromDatabase(10) 'PWRB

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                Button4.Text = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                Button4.Text = jackPotStr
            End If
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim jackpotDbl As Double
        Dim jackPotStr As String
        Dim result As Windows.Forms.DialogResult = Windows.Forms.DialogResult.OK
        Dim dJackPot As New DialogJackPot(8)

        result = dJackPot.ShowDialog()

        If (result = Windows.Forms.DialogResult.OK) Then
            jackpotDbl = getCurrentJackpotFromDatabase(6) 'LOTO

            If jackpotDbl < 1000000000 Then
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000)) & " Million"
                Button3.Text = jackPotStr
            Else
                jackPotStr = "$" & Trim(Str(jackpotDbl / 1000000000)) & " Billion"
                Button3.Text = jackPotStr
            End If

        End If



    End Sub
    Private Sub exitToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitToolStrip.Click
        Me.Dispose()
    End Sub
    Private Sub settingsToolStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles settingsToolStrip.Click
        Dim f As New frmUbiFiles()
        f.ShowDialog()
    End Sub
    Private Sub grdOnCall_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOnCall.DoubleClick
        Dim f As New frmOnCall(Me)
        Dim tableQonCallCurrent As DataTable
        f.ShowDialog()

        tableQonCallCurrent = dataSourceAccess.RunStoreQueryWithoutParameters("qoncallcurrent")
        grdOnCall.DataSource = tableQonCallCurrent

        formatGridOnCall(grdOnCall)
    End Sub
    Private Sub Panel9_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel9.DoubleClick
        Dim f As New Form3(Me)
        Dim tableQhostSystems As DataTable
        'Dim frmLoginFormObj As LoginForm1
        Dim result As Windows.Forms.DialogResult = Windows.Forms.DialogResult.OK
        'lblFlag.Text = "0"
        'frmLoginFormObj = New LoginForm1(Me, 1)
        'result = frmLoginFormObj.ShowDialog()

        'If (result = Windows.Forms.DialogResult.OK) And lblFlag.Text = 1 Then
        f.ShowDialog()

        tableQhostSystems = dataSourceAccess.RunStoreQueryWithoutParameters("qhostsystems")
        Label21.Text = tableQhostSystems.Rows(0).Item(0)
        Label21.ForeColor = returnColor(Label21.Text)
        Label22.Text = tableQhostSystems.Rows(0).Item(1)
        Label22.ForeColor = returnColor(Label22.Text)
        Label23.Text = tableQhostSystems.Rows(0).Item(2)
        Label23.ForeColor = returnColor(Label23.Text)
        Label24.Text = tableQhostSystems.Rows(0).Item(3)
        Label24.ForeColor = returnColor(Label24.Text)
        Label25.Text = tableQhostSystems.Rows(0).Item(4)
        Label25.ForeColor = returnColor(Label25.Text)

        'Label33.Text = "LAST UPDATE: " & tableQhostSystems.Rows(0).Item(5)
        'Label34.Text = "USER: " & tableQhostSystems.Rows(0).Item(6)

        'dateTakeOverLbl.Text = tableQhostSystems.Rows(0).Item(5)
        'usernameTakeOverLbl.Text = tableQhostSystems.Rows(0).Item(6)


        'ElseIf (result = Windows.Forms.DialogResult.OK) And lblFlag.Text = 2 Then

        'MessageBox.Show("User has no privileges for make this action.")

        'ElseIf (result = Windows.Forms.DialogResult.OK) And lblFlag.Text = 3 Then
        'MessageBox.Show("Invalid User")

        'ElseIf (result = Windows.Forms.DialogResult.OK) And lblFlag.Text = 0 Then
        'MessageBox.Show("Invalid Pasword")

        'End If
    End Sub
    Private Sub Panel10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel10.DoubleClick
        Dim f As New frmDB_Appserver()
        Dim tableQserverdb_app As DataTable

        f.ShowDialog()

        tableQserverdb_app = dataSourceAccess.RunStoreQueryWithoutParameters("qserverdb_app")
        Label32.Text = tableQserverdb_app.Rows(0).Item(0)
        Label41.Text = tableQserverdb_app.Rows(0).Item(1)
        Label43.Text = tableQserverdb_app.Rows(0).Item(2)
        Label3.Text = tableQserverdb_app.Rows(0).Item(3)
    End Sub

    
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    
    Private Sub LinkLblLife_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLblLife.LinkClicked

        Dim vWinnersJackpotFrm As New winnersJackpotFrm(5)
        Dim parameters1(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim msgErrorStr As String = ""
        Dim dayInt As Integer
        Dim fecha As Date
        If vWinnersJackpotFrm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fecha = Format(Now, "MM/dd/yyyy")
            dayInt = Weekday(fecha)
            Select Case dayInt

                Case 1 'Sunday
                    Utils.getLastWinnersTake5TblHorizontal(7)

                Case 2 'Monday
                    Utils.getLastWinnersTake5TblHorizontal(1)

                Case 3 'Tuesday
                    Utils.getLastWinnersTake5TblHorizontal(2)

                Case 4 'Wednesday
                    Utils.getLastWinnersTake5TblHorizontal(3)

                Case 5 'Thursday
                    Utils.getLastWinnersTake5TblHorizontal(4)

                Case 6 'Friday
                    Utils.getLastWinnersTake5TblHorizontal(5)

                Case 7 'Saturday
                    Utils.getLastWinnersTake5TblHorizontal(6)
            End Select
            formatGridTake5WinnersHorizontal(grdTake5Hor)

        End If



    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim frmWinnersXStateObj As frmWinnersXState
    '    Dim drawInt, cdcInt As Integer
    '    frmWinnersXStateObj = New frmWinnersXState(5, cdcInt, drawInt)
    '    frmWinnersXStateObj.ShowDialog()
    'End Sub
End Class
