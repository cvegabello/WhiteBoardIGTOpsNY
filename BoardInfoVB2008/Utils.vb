
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Net
Imports System.DirectoryServices
Imports MySql.Data.MySqlClient
Imports Microsoft.Win32


Module Utils
    Public appName As String = "InfoBoard"

    Public Function GetSetting(ByVal APP_NAME As String, ByVal Keyname As String, Optional ByVal DefVal As String = "") As String
        Dim Key As RegistryKey
        Try
            Key = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("IGT").CreateSubKey(APP_NAME)
            Return Key.GetValue(Keyname, DefVal)


        Catch
            Return DefVal
        End Try
    End Function

    Public Sub SalvarSetting(ByVal APP_NAME As String, ByVal Keyname As String, ByVal Value As String)
        Dim Key As RegistryKey
        Try
            Key = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("IGT").CreateSubKey(APP_NAME)
            Key.SetValue(Keyname, Value)
        Catch
            Return
        End Try
    End Sub

    Public Sub SalvarSettingConfiServerDB(ByVal APP_NAME As String, ByVal Keyname As String, ByVal Value As String)
        Dim Key As RegistryKey
        Try
            Key = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("IGT").CreateSubKey(APP_NAME).CreateSubKey("Conection string database")
            Key.SetValue(Keyname, Value)
        Catch
            Return
        End Try
    End Sub
    'Public Sub SalvarSettingDrawKeno(ByVal APP_NAME As String, ByVal Keyname As String, ByVal Value As String)
    '    Dim Key As RegistryKey
    '    Try
    '        Key = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("IGT").CreateSubKey(APP_NAME)
    '        Key.SetValue(Keyname, Value)
    '    Catch
    '        Return
    '    End Try
    'End Sub


    Public Function GetSettingConfigServerDB(ByVal APP_NAME As String, ByVal Keyname As String, Optional ByVal DefVal As String = "") As String
        Dim Key As RegistryKey
        Try
            Key = Registry.CurrentUser.CreateSubKey("SOFTWARE").CreateSubKey("IGT").CreateSubKey(APP_NAME).CreateSubKey("Conection string database")
            Return Key.GetValue(Keyname, DefVal)
        Catch
            Return DefVal
        End Try
    End Function




    Function returnFecha(ByVal toKnowCdc As Integer) As Date
        Dim initDate As Date
        initDate = "1/1/1986"

        'Today = System.DateTime.Now
        returnFecha = initDate.AddDays(toKnowCdc)

        'returnFecha = (initDate + toKnowCdc) - 1

    End Function


    Function convertDateInt(ByVal toKnowDate As Date) As Integer
        Dim initDate As Date
        Dim diff1 As TimeSpan
        initDate = "1/1/1900"

        diff1 = toKnowDate.Subtract(initDate)
        convertDateInt = diff1.Days + 2

    End Function

    Function returnCDC(ByVal toKnowDate As Date) As Integer
        Dim initDate As Date
        Dim diff1 As TimeSpan
        initDate = "1/1/1986"

        diff1 = toKnowDate.Subtract(initDate)
        returnCDC = diff1.Days + 1

    End Function

    Function returnCDC_OTG(ByVal toKnowDate As Date) As Integer
        Dim initDate As Date
        Dim diff1 As TimeSpan
        initDate = "5/1/2013"

        diff1 = toKnowDate.Subtract(initDate)
        returnCDC_OTG = diff1.Days + 1

    End Function

    Function returnCDC_OP(ByVal toKnowDate As Date) As Integer
        'Dim initDate As Date
        ''Dim diff1 As TimeSpan
        'initDate = "5/1/2013"
        returnCDC_OP = returnCDC(toKnowDate) - 3652
        'diff1 = toKnowDate.Subtract(initDate)
        'returnCDC_OP = diff1.Days + 1

    End Function


    Function returnDayWeek(ByVal dayWeek As Integer) As String

        Select Case dayWeek
            Case 1
                returnDayWeek = "SUNDAY"

            Case 2
                returnDayWeek = "MONDAY"

            Case 3
                returnDayWeek = "TUESDAY"

            Case 4
                returnDayWeek = "WEDNESDAY"

            Case 5
                returnDayWeek = "THURSDAY"

            Case 6
                returnDayWeek = "FRIDAY"

            Case 7
                returnDayWeek = "SATURDAY"

            Case Else

                returnDayWeek = ""

        End Select

    End Function

    Function getDrawsGamesTbl(ByVal toKnowDate As Date) As DataTable

        Dim tableQproducts As DataTable
        Dim row1 As DataRow
        Dim idProductInt, codSysProductInt As Integer
        Dim productSysNameStr As String
        Dim drawGamesTbl As New DataTable("DRAWSGAMES")
        Dim nuevaFila As DataRow
        Dim cdcInt As Integer

        cdcInt = returnCDC(toKnowDate)
        drawGamesTbl = Utils.Despliegue
        tableQproducts = dataSourceAccess.RunStoreQueryWithoutParameters("qproducts")

        For Each row1 In tableQproducts.Rows
            codSysProductInt = row1("productSysCode")
            productSysNameStr = row1("productSysName")
            idProductInt = row1("IdProduct")

            nuevaFila = drawGamesTbl.NewRow()
            nuevaFila(0) = productSysNameStr


            If cdcInt < 12991 Then

                If (codSysProductInt = 9) Or (codSysProductInt = 14) Or (codSysProductInt = 22) Then
                    nuevaFila(1) = getDrawNumberXProductXday(codSysProductInt, toKnowDate, 1)
                    nuevaFila(2) = getDrawNumberXProductXday(codSysProductInt, toKnowDate, 2)
                Else
                    nuevaFila(2) = getDrawNumberXProductXday(codSysProductInt, toKnowDate, 0)
                End If
                drawGamesTbl.Rows.Add(nuevaFila)
            Else
                If (codSysProductInt = 9) Or (codSysProductInt = 14) Or (codSysProductInt = 22) Or (codSysProductInt = 10) Then
                    nuevaFila(1) = getDrawNumberXProductXday(codSysProductInt, toKnowDate, 1)
                    nuevaFila(2) = getDrawNumberXProductXday(codSysProductInt, toKnowDate, 2)
                Else
                    nuevaFila(2) = getDrawNumberXProductXday(codSysProductInt, toKnowDate, 0)
                End If
                drawGamesTbl.Rows.Add(nuevaFila)


            End If

        Next
        Return drawGamesTbl


    End Function

    Function Despliegue() As DataTable
        Dim productSysName As New DataColumn
        Dim numDraw1 As New DataColumn
        Dim numDraw2 As New DataColumn
        'Dim countDown As New DataColumn
        Dim drawsGamesTbl As New DataTable("DRAWSGAMES")

        productSysName.ColumnName = "PRODUCT_NAME"
        productSysName.DataType = System.Type.GetType("System.String")

        numDraw1.ColumnName = "NUM_DRAW1"
        numDraw1.DataType = System.Type.GetType("System.String")
        numDraw1.MaxLength = 50

        numDraw2.ColumnName = "NUM_DRAW2"
        numDraw2.DataType = System.Type.GetType("System.String")
        numDraw2.MaxLength = 50


        drawsGamesTbl.Columns.Add(productSysName)
        drawsGamesTbl.Columns.Add(numDraw1)
        drawsGamesTbl.Columns.Add(numDraw2)
        'drawsGamesTbl.Columns.Add(countDown)

        Despliegue = drawsGamesTbl

    End Function

    Function DespliegueDateInfo() As DataTable
        Dim titleDateCol As New DataColumn
        Dim infoDateCol As New DataColumn
        Dim dateTbl As New DataTable("DATEINFO")

        titleDateCol.ColumnName = "TITLE_DATE"
        titleDateCol.DataType = System.Type.GetType("System.String")

        infoDateCol.ColumnName = "INFO_DATE"
        infoDateCol.DataType = System.Type.GetType("System.String")
        infoDateCol.MaxLength = 50

        dateTbl.Columns.Add(titleDateCol)
        dateTbl.Columns.Add(infoDateCol)

        DespliegueDateInfo = dateTbl

    End Function


    Function DespliegueTake5Winners() As DataTable
        Dim dayName As New DataColumn
        Dim cdcInt As New DataColumn
        Dim numDraw As New DataColumn
        Dim winners As New DataColumn
        Dim winnersTake5Tbl As New DataTable("TAKE5_WINNERS")

        dayName.ColumnName = "DAY"
        dayName.DataType = System.Type.GetType("System.String")

        cdcInt.ColumnName = "CDC"
        cdcInt.DataType = System.Type.GetType("System.Single")


        'numDraw.ColumnName = "NUM_DRAW"
        'numDraw.DataType = System.Type.GetType("System.Single")

        winners.ColumnName = "WINNERS"
        winners.DataType = System.Type.GetType("System.Single")

        winnersTake5Tbl.Columns.Add(dayName)
        winnersTake5Tbl.Columns.Add(cdcInt)
        'winnersTake5Tbl.Columns.Add(numDraw)
        winnersTake5Tbl.Columns.Add(winners)

        DespliegueTake5Winners = winnersTake5Tbl

    End Function


    Sub getAndSaveWinnersALLProduct(ByVal toKnowDate As DateTime, ByRef flagJackpotPendingArray() As String, ByVal errCodeInt As Integer, ByRef errMessageStr As String)

        Dim tableQproducts As DataTable
        Dim row1 As DataRow
        Dim idProductInt, productSysCodeInt, drawNumberInt, cdcInt, stateCodInt, numWinnersInt, numrecordsInt, errCodInt As Integer
        Dim oldJackPotDbl, newJackPotDbl As Double
        Dim productSysNameStr, numWinnerStr, nameDayWeekStr, msgErrorStr As String
        Dim parameters1(4) As MySql.Data.MySqlClient.MySqlParameter
        Dim parameters2(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim table1 As DataTable
        'Dim resBool As Boolean
        Dim draw(3) As String

        cdcInt = returnCDC(toKnowDate)
        tableQproducts = dataSourceAccess.RunStoreQueryWithoutParameters("QProductsWinners")

        For Each row1 In tableQproducts.Rows
            productSysCodeInt = row1("ProductSysCode")
            productSysNameStr = row1("productSysName")
            idProductInt = row1("IdProduct")
            If (IsDBNull(row1("IdProduct"))) Then
                oldJackPotDbl = 0
            Else
                oldJackPotDbl = row1("currentJackpot")
            End If
            nameDayWeekStr = WeekdayName(Weekday(toKnowDate.AddDays(-1)))

            If productSysCodeInt = 10 Then

                If cdcInt < 12991 Then
                    drawNumberInt = getDrawNumberXProductXday(productSysCodeInt, toKnowDate, 0)
                    drawNumberInt -= 1
                Else
                    drawNumberInt = getDrawNumberXProductXday(productSysCodeInt, toKnowDate, 1)
                    drawNumberInt -= 2
                End If

                'drawNumberInt -= 2
                'cdcInt = returnCDC(toKnowDate)
                cdcInt -= 1
                numWinnerStr = Trim(getWinnersXProduct(toKnowDate, productSysCodeInt, errCodeInt, errMessageStr))
                msgErrorStr = ""
                errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
                If errCodInt = 0 Then
                    saveHistoryDaily(drawNumberInt, cdcInt, productSysNameStr, idProductInt, numWinnerStr, oldJackPotDbl, nameDayWeekStr)
                Else
                    MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
                End If

            End If

            If IsDrawDay(productSysCodeInt, toKnowDate) And (productSysCodeInt <> 10) Then
                errCodeInt = 0
                errMessageStr = ""
                numWinnerStr = Trim(getWinnersXProduct(toKnowDate, productSysCodeInt, errCodeInt, errMessageStr))
                'nameDayWeekStr = WeekdayName(Weekday(toKnowDate.AddDays(-1)))
                If errCodeInt = 0 Then
                    drawNumberInt = getDrawNumberXProductXday(productSysCodeInt, toKnowDate, 0)
                    drawNumberInt -= 1
                    cdcInt = returnCDC(toKnowDate)
                    cdcInt -= 1

                    stateCodInt = 35
                    numWinnersInt = CInt(numWinnerStr)
                    If numWinnersInt > 0 Then
                        parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", idProductInt)
                        parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                        parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                        parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                        msgErrorStr = ""
                        dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)
                    End If

                    parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", idProductInt)
                    parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                    table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                    numrecordsInt = table1.Rows.Count

                    If numrecordsInt = 0 Then
                        numWinnerStr = "0"
                    Else
                        numWinnerStr = CStr(table1.Rows(0).Item(2))
                    End If

                    If productSysCodeInt = 8 Or productSysCodeInt = 12 Or productSysCodeInt = 15 Then

                        newJackPotDbl = readJackpotFromFile(productSysCodeInt, toKnowDate, errCodeInt, errMessageStr)
                        If errCodeInt = 0 Then
                            If (newJackPotDbl <> oldJackPotDbl) And (newJackPotDbl <> 0) Then
                                msgErrorStr = ""
                                errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
                                If errCodInt = 0 Then
                                    saveHistoryDaily(drawNumberInt, cdcInt, productSysNameStr, idProductInt, numWinnerStr, oldJackPotDbl, nameDayWeekStr)
                                    updateJackPot(productSysCodeInt, newJackPotDbl)
                                Else
                                    MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
                                End If
                            ElseIf newJackPotDbl = 0 Then
                                Select Case productSysCodeInt
                                    Case 8
                                        Form1.Button3.Text = "PENDING"
                                        flagJackpotPendingArray(0) = "LOTO_PENDING"

                                    Case 12
                                        Form1.Button2.Text = "PENDING"
                                        flagJackpotPendingArray(1) = "BIGG_PENDING"

                                    Case 15
                                        Form1.Button4.Text = "PENDING"
                                        flagJackpotPendingArray(2) = "PWRB_PENDING"


                                End Select

                            End If
                        Else
                            MsgBox("Error reading Jackpot File: " & errMessageStr, MsgBoxStyle.OkOnly, "Error")
                        End If
                    Else
                        'newJackPotDbl = 0
                        msgErrorStr = ""
                        errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
                        If errCodInt = 0 Then
                            saveHistoryDaily(drawNumberInt, cdcInt, productSysNameStr, idProductInt, numWinnerStr, oldJackPotDbl, nameDayWeekStr)
                        Else
                            MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
                        End If

                    End If

                    'newJackPotDbl = leerJackpotFromPaginaWeb("http://www.lotteryusa.com/lottery/NY/NY_fcur.html", productSysCodeInt)
                Else
                    'If numWinnerStr = "-" Then
                    '    msgErrorStr = ""
                    '    errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
                    '    If errCodInt = 0 Then
                    '        saveHistoryDaily(0, cdcInt, productSysNameStr, idProductInt, numWinnerStr, 0, nameDayWeekStr)
                    '    Else
                    '        MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
                    '    End If

                    'Else
                    '    Exit Sub
                    'End If


                End If
            End If






            '    End If

            '    errCodeInt = 0
            '    errMessageStr = ""
            '    numWinnerStr = Trim(getWinnersXProduct(toKnowDate, productSysCodeInt, errCodeInt, errMessageStr))
            '    'nameDayWeekStr = WeekdayName(Weekday(toKnowDate.AddDays(-1)))
            '    If errCodeInt = 0 Then
            '        drawNumberInt = getDrawNumberXProductXday(productSysCodeInt, toKnowDate, 0)
            '        drawNumberInt -= 1
            '        cdcInt = returnCDC(toKnowDate)
            '        cdcInt -= 1

            '        stateCodInt = 35
            '        numWinnersInt = CInt(numWinnerStr)
            '        If numWinnersInt > 0 Then
            '            parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", idProductInt)
            '            parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
            '            parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
            '            parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
            '            parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
            '            msgErrorStr = ""
            '            dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)
            '        End If

            '        parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", idProductInt)
            '        parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
            '        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
            '        numrecordsInt = table1.Rows.Count

            '        If numrecordsInt = 0 Then
            '            numWinnerStr = "0"
            '        Else
            '            numWinnerStr = CStr(table1.Rows(0).Item(2))
            '        End If

            '        If productSysCodeInt = 8 Or productSysCodeInt = 12 Or productSysCodeInt = 15 Then

            '            newJackPotDbl = readJackpotFromFile(productSysCodeInt, toKnowDate, errCodeInt, errMessageStr)
            '            If errCodeInt = 0 Then
            '                If (newJackPotDbl <> oldJackPotDbl) And (newJackPotDbl <> 0) Then
            '                    msgErrorStr = ""
            '                    errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
            '                    If errCodInt = 0 Then
            '                        saveHistoryDaily(drawNumberInt, cdcInt, productSysNameStr, idProductInt, numWinnerStr, oldJackPotDbl, nameDayWeekStr)
            '                        updateJackPot(productSysCodeInt, newJackPotDbl)
            '                    Else
            '                        MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
            '                    End If
            '                ElseIf newJackPotDbl = 0 Then
            '                    Select Case productSysCodeInt
            '                        Case 8
            '                            Form1.Button3.Text = "PENDING"
            '                            flagJackpotPendingArray(0) = "LOTO_PENDING"

            '                        Case 12
            '                            Form1.Button2.Text = "PENDING"
            '                            flagJackpotPendingArray(1) = "BIGG_PENDING"

            '                        Case 15
            '                            Form1.Button4.Text = "PENDING"
            '                            flagJackpotPendingArray(2) = "PWRB_PENDING"


            '                    End Select

            '                End If
            '            Else
            '                MsgBox("Error reading Jackpot File: " & errMessageStr, MsgBoxStyle.OkOnly, "Error")
            '            End If
            '        Else
            '            'newJackPotDbl = 0
            '            msgErrorStr = ""
            '            errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
            '            If errCodInt = 0 Then
            '                saveHistoryDaily(drawNumberInt, cdcInt, productSysNameStr, idProductInt, numWinnerStr, oldJackPotDbl, nameDayWeekStr)
            '            Else
            '                MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
            '            End If

            '        End If

            '        'newJackPotDbl = leerJackpotFromPaginaWeb("http://www.lotteryusa.com/lottery/NY/NY_fcur.html", productSysCodeInt)
            '    Else
            '        'If numWinnerStr = "-" Then
            '        '    msgErrorStr = ""
            '        '    errCodInt = deleteHistoryDaily(idProductInt, cdcInt, msgErrorStr)
            '        '    If errCodInt = 0 Then
            '        '        saveHistoryDaily(0, cdcInt, productSysNameStr, idProductInt, numWinnerStr, 0, nameDayWeekStr)
            '        '    Else
            '        '        MsgBox("Error in delete HistoryDaily: " & msgErrorStr, MsgBoxStyle.Critical, "Error")
            '        '    End If

            '        'Else
            '        '    Exit Sub
            '        'End If


            '    End If
            'End If
        Next


    End Sub

    Function readJackpotFromFile(ByVal productSysCodeInt As Integer, ByVal toKnowDate As Date, ByRef errCodeInt As Integer, ByRef errMessageStr As String) As Double

        Dim reader1 As StreamReader
        Dim strLinea As String
        Dim strFile As String = ""
        Dim drawNumberStr, strValor, strFilePath As String
        Dim winnerStr As String = ""
        Dim drawNumberInt As Integer
        Dim jackPotDbl As Double

        strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()


        drawNumberInt = getDrawNumberXProductXday(productSysCodeInt, toKnowDate, 0)
        drawNumberStr = Trim(Str(drawNumberInt))
        drawNumberStr = drawNumberStr.PadLeft(6, "0")

        Select Case productSysCodeInt
            Case 8
                strFile = strFilePath & "\jackpot_" & drawNumberStr & "_loto.txt"

            Case 12
                strFile = strFilePath & "\jackpot_" & drawNumberStr & "_bigg.txt"

            Case 15
                strFile = strFilePath & "\jackpot_" & drawNumberStr & "_pwrb.txt"

        End Select

        Try
            reader1 = New StreamReader(strFile, Encoding.UTF7)
            strLinea = ""
            strLinea = reader1.ReadLine()
            strValor = Mid(strLinea, 41, 20)
            jackPotDbl = CDbl(strValor)
            reader1.Close()
            errCodeInt = 0
            Return jackpotDbl

        Catch ex As Exception

            errCodeInt = -1
            errMessageStr = ex.Message

        End Try



    End Function

    Function moveFiles(ByVal fromLocation As String, ByVal ToLocation As String, ByVal fecha As Date, ByRef msgError As String) As Boolean
        Dim nameFoundFileStr As String
        Dim monthStr, dayStr, yearStr As String

        monthStr = CStr(fecha.Month).PadLeft(2, "0")
        dayStr = CStr(fecha.Day).PadLeft(2, "0")
        yearStr = CStr(fecha.Year).PadLeft(4, "0")

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(fromLocation)
            nameFoundFileStr = My.Computer.FileSystem.GetName(foundFile)
            If nameFoundFileStr <> "LogTransferWinnnerAndJackpotFiles_" & monthStr & dayStr & yearStr & ".txt" Then
                Try
                    My.Computer.FileSystem.MoveFile(foundFile, ToLocation & "\" & nameFoundFileStr, True)
                Catch ex As Exception
                    msgError = ex.Message
                    Return False
                End Try
            End If
        Next
        Return True

    End Function


    Function getDrawNumberXProductXday(ByVal codSysProduct As Integer, ByVal toKnowDate As DateTime, ByVal dayDraw As Integer) As Integer

        Dim num1 As Integer
        Dim num3 As Integer
        Dim dayWeekInt As Integer
        Dim moduloRes As Integer
        Dim cocienteRes, cdcInt As Integer
        'Dim firstDrawKenoDbl As Double

        num1 = convertDateInt(toKnowDate)
        cdcInt = returnCDC(toKnowDate)
        'cdcInt = 12991

        'num1 = convertDateInt("7/15/2021")
        dayWeekInt = Weekday(toKnowDate)
        'indexFirstDrawKenoDbl = Utils.GetSetting(appName, "FirstDrawKeno", "").ToString()

        Select Case codSysProduct
            Case 22 'KENO

                cdcInt = CInt(Form1.grdDate1.Item(1, 1).Value)

                'cdcInt = returnCDC(toKnowDate)
                Select Case dayDraw
                    Case 1 'Initial
                        num3 = Utils.GetSetting(appName, "FirstDrawKeno", "")
                        'num3 = (cdcInt * 351) - indexFirstDrawKenoDbl
                    Case 2 'End
                        num3 = Utils.GetSetting(appName, "FirstDrawKeno", "") + 350
                        'num3 = ((cdcInt * 351) - indexFirstDrawKenoDbl) + 350
                End Select


            Case 8 'Loto

                Select Case dayWeekInt
                    Case 5
                        moduloRes = (num1 + 2) Mod 7
                        cocienteRes = ((num1 + 2) \ 7) * 2
                    Case 6
                        moduloRes = (num1 + 1) Mod 7
                        cocienteRes = ((num1 + 1) \ 7) * 2
                    Case Else
                        moduloRes = num1 Mod 7
                        cocienteRes = (num1 \ 7) * 2

                End Select
                If (moduloRes < 1) Then
                    num3 = cocienteRes - 11488
                Else
                    num3 = cocienteRes - 11487
                End If
                num3 += 2357



            Case 9 'PCK3 -NUMBERS-

                Select Case dayDraw
                    Case 1 'Midday
                        num3 = ((2 * num1) - 69216)
                    Case 2 'Evenning
                        num3 = (((2 * num1) - 69216) + 1)
                End Select

            Case 10 'csh5 TAKE5
                
                Select Case dayDraw
                    Case 0 'BEFORE CDC 12991
                        num3 = cdcInt - 4113
                    Case 1 'Midday
                        num3 = ((2 * cdcInt) - 17104)

                    Case 2 'Evenning
                        num3 = (((2 * cdcInt) - 17104) + 1)
                End Select

            Case 11

            Case 12 'BIGG
                If ((num1 Mod 7) < 4) Then
                    num3 = (((num1 \ 7) * 2) - 10682)
                Else
                    num3 = (((num1 \ 7) * 2) - 10681)
                End If

            Case 13 'LIFE

                If num1 <= 43647 Then
                    Select Case dayWeekInt
                        Case 6
                            num3 = (((num1 \ 7) * 2) - 11941)

                        Case Else
                            If ((num1 Mod 7) < 3) Then
                                num3 = (((num1 \ 7) * 2) - 11943)
                            Else
                                num3 = (((num1 \ 7) * 2) - 11942)
                            End If

                    End Select
                Else
                    num3 = (num1 - 43120)

                End If

            Case 14

                Select Case dayDraw
                    Case 1 'Midday
                        num3 = ((2 * num1) - 69216)
                    Case 2 'Evenning
                        num3 = (((2 * num1) - 69216) + 1)
                End Select


            Case 15 'PowerBall

                Select Case dayWeekInt
                    Case 5
                        moduloRes = (num1 + 2) Mod 7
                        cocienteRes = ((num1 + 2) \ 7) * 2
                    Case 6
                        moduloRes = (num1 + 1) Mod 7
                        cocienteRes = ((num1 + 1) \ 7) * 2
                    Case Else
                        moduloRes = num1 Mod 7
                        cocienteRes = (num1 \ 7) * 2

                End Select
                If (moduloRes < 1) Then
                    num3 = cocienteRes - 11488
                Else
                    num3 = cocienteRes - 11487
                End If

            Case 27 'DKNO
                num3 = (num1 - 31979)

        End Select
        Return num3
    End Function

    Function getInfoDateTbl(ByVal toKnowDate As String) As DataTable

        Dim drawGamesTbl As New DataTable("DATEINFO")
        Dim nuevaFila As DataRow

        drawGamesTbl = Utils.DespliegueDateInfo()

        nuevaFila = drawGamesTbl.NewRow()
        drawGamesTbl.Rows.Add(nuevaFila)
        nuevaFila(0) = "DATE:"
        nuevaFila(1) = toKnowDate


        nuevaFila = drawGamesTbl.NewRow()
        drawGamesTbl.Rows.Add(nuevaFila)
        nuevaFila(0) = "CDC:"
        'currentTimeStr = Format(TimeOfDay, "HH:mm:ss")
        If TimeOfDay >= "00:00:00" And TimeOfDay < "03:30:00" Then
            nuevaFila(1) = returnCDC(toKnowDate) - 1
        Else
            nuevaFila(1) = returnCDC(toKnowDate)
        End If


        nuevaFila = drawGamesTbl.NewRow()
        drawGamesTbl.Rows.Add(nuevaFila)
        nuevaFila(0) = "DAY:"
        nuevaFila(1) = returnDayWeek(Weekday(toKnowDate))


        Return drawGamesTbl
    End Function



    Function getWinnersXProduct(ByVal toKnowDate As DateTime, ByVal codSysProduct As Integer, ByRef errorCode As Integer, ByRef errorMessage As String) As String

        Dim reader1 As StreamReader
        Dim reader2 As XmlReader
        Dim strLinea As String
        Dim strFile, drawNumberStr, strValor, drawNumberPrevStr, strFileOld, strFilePath As String
        Dim winnerStr As String = ""
        Dim winnerTake5() As String = {"", ""}
        Dim drawNumberInt, cdcInt As Integer

        'drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, 0)
        'drawNumberInt -= 1
        'drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
        'drawNumberStr = Trim(Str(drawNumberInt))
        'strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
        'ChDir(strFilePath)

        cdcInt = returnCDC(toKnowDate)

        Select Case codSysProduct
            Case 10 'CSH5

                If cdcInt < 12991 Then
                    drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, 0)
                    drawNumberInt -= 1
                    drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
                    drawNumberStr = Trim(Str(drawNumberInt))
                    strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
                    ChDir(strFilePath)
                    drawNumberStr = drawNumberStr.PadLeft(6, "0")
                    drawNumberPrevStr = drawNumberPrevStr.PadLeft(6, "0")

                    strFileOld = strFilePath & "\winner_summary_report_p010_d" & drawNumberPrevStr & "_wincnt_english.rep"
                    Try
                        FileSystem.Kill(strFileOld)
                    Catch ex As Exception

                    End Try

                    strFile = strFilePath & "\winner_summary_report_p010_d" & drawNumberStr & "_wincnt_english.rep"

                    Try
                        reader1 = New StreamReader(strFile, Encoding.UTF7)
                        strLinea = ""

                        Do While Not (strLinea Is Nothing)
                            strLinea = reader1.ReadLine()
                            strValor = Mid(strLinea, 3, 3)
                            If strValor = "5/5" Then
                                winnerTake5(0) = "X"
                                winnerTake5(1) = Trim(Mid(strLinea, 25, 6))
                                Exit Do
                            End If

                        Loop
                        reader1.Close()
                    Catch ex As Exception
                        errorCode = -1
                        errorMessage = "The file TAKE5 WINNER SUMMARY -winner_summary_report_p010_d" & drawNumberStr & "_wincnt_english.rep-, is not in " & strFilePath
                        winnerTake5(0) = "X"
                        winnerTake5(1) = "X"

                    End Try

                Else
                    For i = 0 To 1

                        drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, i + 1)
                        drawNumberInt -= 2
                        drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
                        drawNumberStr = Trim(Str(drawNumberInt))
                        strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
                        ChDir(strFilePath)
                        drawNumberStr = drawNumberStr.PadLeft(6, "0")
                        drawNumberPrevStr = drawNumberPrevStr.PadLeft(6, "0")

                        strFileOld = strFilePath & "\winner_summary_report_p010_d" & drawNumberPrevStr & "_wincnt_english.rep"
                        Try
                            FileSystem.Kill(strFileOld)
                        Catch ex As Exception

                        End Try

                        strFile = strFilePath & "\winner_summary_report_p010_d" & drawNumberStr & "_wincnt_english.rep"

                        Try
                            reader1 = New StreamReader(strFile, Encoding.UTF7)
                            strLinea = ""

                            Do While Not (strLinea Is Nothing)
                                strLinea = reader1.ReadLine()
                                strValor = Mid(strLinea, 3, 3)
                                If strValor = "5/5" Then
                                    winnerTake5(i) = Trim(Mid(strLinea, 25, 6))
                                    Exit Do
                                End If

                            Loop
                            reader1.Close()
                        Catch ex As Exception
                            errorCode = -1
                            errorMessage = "The file TAKE5 WINNER SUMMARY -winner_summary_report_p010_d" & drawNumberStr & "_wincnt_english.rep-, is not in " & strFilePath
                            winnerTake5(i) = "X"

                        End Try

                    Next

                End If
                winnerStr = winnerTake5(0) & " - " & winnerTake5(1)

            Case 8 'LOTTO

                drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, 0)
                drawNumberInt -= 1
                drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
                drawNumberStr = Trim(Str(drawNumberInt))
                strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
                ChDir(strFilePath)

                drawNumberStr = drawNumberStr.PadLeft(6, "0")
                drawNumberPrevStr = drawNumberPrevStr.PadLeft(6, "0")

                strFileOld = strFilePath & "\winner_summary_report_p008_d" & drawNumberPrevStr & "_wincnt_english.rep"
                Try
                    FileSystem.Kill(strFileOld)
                Catch ex As Exception

                End Try

                strFile = strFilePath & "\winner_summary_report_p008_d" & drawNumberStr & "_wincnt_english.rep"

                Try
                    reader1 = New StreamReader(strFile, Encoding.UTF7)
                    strLinea = ""
                    Do While Not (strLinea Is Nothing)
                        strLinea = reader1.ReadLine()
                        strValor = Mid(strLinea, 3, 3)
                        If strValor = "6/6" Then
                            winnerStr = Mid(strLinea, 25, 6)
                            Exit Do
                        End If
                    Loop
                    reader1.Close()

                Catch ex As Exception

                    errorCode = -1
                    errorMessage = "The file LOTTO WINNER SUMMARY -winner_summary_report_p008_d" & drawNumberStr & "_wincnt_english.rep-, is not in " & strFilePath
                    winnerStr = "0"

                End Try




            Case 12 'BIGG

                drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, 0)
                drawNumberInt -= 1
                drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
                drawNumberStr = Trim(Str(drawNumberInt))
                strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
                ChDir(strFilePath)


                drawNumberStr = drawNumberStr.PadLeft(4, "0")
                drawNumberPrevStr = drawNumberPrevStr.PadLeft(4, "0")

                strFileOld = strFilePath & (("\winners_mm_" & drawNumberPrevStr) & ".xml")
                Try
                    FileSystem.Kill(strFileOld)
                Catch ex As Exception

                End Try


                strFile = strFilePath & (("\winners_mm_" & drawNumberStr) & ".xml")

                Try
                    reader2 = XmlReader.Create(strFile)
                    Do While reader2.Read()
                        If (reader2.NodeType = XmlNodeType.Element AndAlso reader2.Name = "winners") Then
                            winnerStr = reader2.GetAttribute(3)
                        End If
                    Loop
                    reader2.Close()
                Catch ex As Exception
                    errorCode = -1
                    errorMessage = "The file BIGG WINNERS  -winners_mm_" & drawNumberStr & ".xml- is not in " & strFilePath
                    winnerStr = "0"

                End Try



            Case 15 'PWRB

                drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, 0)
                drawNumberInt -= 1
                drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
                drawNumberStr = Trim(Str(drawNumberInt))
                strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
                ChDir(strFilePath)
                drawNumberStr = drawNumberStr.PadLeft(4, "0")
                drawNumberPrevStr = drawNumberPrevStr.PadLeft(4, "0")

                strFileOld = strFilePath & (("\winners_pb_" & drawNumberPrevStr) & ".xml")
                Try
                    FileSystem.Kill(strFileOld)
                Catch ex As Exception

                End Try

                strFile = strFilePath & (("\winners_pb_" & drawNumberStr) & ".xml")

                Try
                    reader2 = XmlReader.Create(strFile)
                    Do While reader2.Read()
                        If (reader2.NodeType = XmlNodeType.Element AndAlso reader2.Name = "winners") Then
                            winnerStr = reader2.GetAttribute(3)
                        End If
                    Loop
                    reader2.Close()

                Catch ex As Exception

                    errorCode = -1
                    errorMessage = "The file PWRB WINNERS  -winners_pb_" & drawNumberPrevStr & ".xml- is not in " & strFilePath
                    winnerStr = "0"

                End Try




            Case 13 'LIFE

                drawNumberInt = Utils.getDrawNumberXProductXday(codSysProduct, toKnowDate, 0)
                drawNumberInt -= 1
                drawNumberPrevStr = Trim(Str(drawNumberInt - 1))
                drawNumberStr = Trim(Str(drawNumberInt))
                strFilePath = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()
                ChDir(strFilePath)

                drawNumberStr = drawNumberStr.PadLeft(4, "0")
                drawNumberPrevStr = drawNumberPrevStr.PadLeft(4, "0")

                strFileOld = strFilePath & (("\winners_cl_" & drawNumberPrevStr) & ".xml")

                Try
                    FileSystem.Kill(strFileOld)
                Catch ex As Exception

                End Try

                strFile = strFilePath & (("\winners_cl_" & drawNumberStr) & ".xml")

                Try
                    reader2 = XmlReader.Create(strFile)
                    Do While reader2.Read()
                        If (reader2.NodeType = XmlNodeType.Element AndAlso reader2.Name = "winners") Then
                            winnerStr = reader2.GetAttribute(3)
                            'winnerStr = ((reader2.GetAttribute(3) & " | ") & reader2.GetAttribute(4))

                        End If
                    Loop
                    reader2.Close()

                Catch ex As Exception

                    errorCode = -1
                    errorMessage = "The file LIFE WINNERS  -winners_cl_" & drawNumberPrevStr & ".xml- is not in " & strFilePath
                    winnerStr = "-"

                End Try


        End Select
        Return winnerStr
    End Function

    Function IsDrawDay(ByVal codSysProduct As Integer, ByVal toKnowDate As DateTime) As Boolean
        Dim diaSorteoBool As Boolean
        Dim numDayDrawInt As Integer
        Dim dayNumberWeekInt As Integer
        Dim numrecordsInt As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim row1 As DataRow
        Dim table1 As DataTable
        diaSorteoBool = False

        dayNumberWeekInt = Weekday(toKnowDate.AddDays(-1))
        Parametros1(0) = New MySqlParameter("@CodProductSistema", codSysProduct)
        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("QDrawNumberXGame", Parametros1)
        numrecordsInt = table1.Rows.Count

        If (numrecordsInt > 0) Then
            For Each row1 In table1.Rows
                numDayDrawInt = row1("CodDayWeekDraw")
                If (dayNumberWeekInt = numDayDrawInt) Then
                    diaSorteoBool = True
                    Exit For
                End If
            Next
        End If

        IsDrawDay = diaSorteoBool

    End Function

    Function nextDayDraw(ByVal codSysProduct As Integer, ByVal toKnowDate As DateTime) As Date
        Dim encontro As Boolean = False
        Dim numDayDrawInt As Integer
        Dim dayNumberWeekInt As Integer
        Dim numrecordsInt As Integer
        Dim Parametros1(0) As MySqlParameter
        Dim row1 As DataRow
        Dim table1 As DataTable


        dayNumberWeekInt = Weekday(toKnowDate)
        Parametros1(0) = New MySqlParameter("@CodProductSistema", codSysProduct)
        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("QDrawNumberXGame", Parametros1)
        numrecordsInt = table1.Rows.Count

        While Not encontro

            For Each row1 In table1.Rows
                numDayDrawInt = row1("CodDayWeekDraw")
                If (dayNumberWeekInt = numDayDrawInt) Then
                    encontro = True
                    Exit For
                End If
            Next
            If encontro Then
                nextDayDraw = toKnowDate

            Else
                toKnowDate = toKnowDate.AddDays(1)
                dayNumberWeekInt = Weekday(toKnowDate)
            End If

        End While


    End Function

    Function deleteHistoryDaily(ByVal idProductInt As Integer, ByVal cdcInt As Integer, ByRef msgErrorStr As String) As Integer
        Dim num1 As Integer
        Dim Parametros1(1) As MySqlParameter

        Parametros1(0) = New MySqlParameter("@CodGame", idProductInt)
        Parametros1(1) = New MySqlParameter("@cdc", cdcInt)

        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteHistoryDrawXproductXcdc", Parametros1, msgErrorStr)

        Return num1

    End Function

    Function updateOnCall(ByVal onCallName As String, ByVal levelInt As Integer, ByRef msgErrorStr As String) As Integer
        Dim num1 As Integer
        Dim Parametros1(1) As MySqlParameter

        Parametros1(0) = New MySqlParameter("@onCallNameStr", onCallName)
        Parametros1(1) = New MySqlParameter("@currentLevelInt", levelInt)

        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("updateOnCall", Parametros1, msgErrorStr)

        Return num1

    End Function



    Sub saveHistoryDaily(ByVal newDrawInt As Integer, ByVal newCdcInt As Integer, ByVal productSysNameStr As String, ByVal idProductInt As Integer, ByVal winners As String, ByVal OldJackPotDbl As Double, ByVal dayWeekNameStr As String)
        Dim num1 As Integer
        Dim Parametros1(6) As MySqlParameter
        Dim msgErrorStr As String = ""

        Parametros1(0) = New MySqlParameter("@numDrawInt", newDrawInt)
        Parametros1(1) = New MySqlParameter("@numCDCInt", newCdcInt)
        Parametros1(2) = New MySqlParameter("@nomProductStr", productSysNameStr)
        Parametros1(3) = New MySqlParameter("@codigoProductInt", idProductInt)
        Parametros1(4) = New MySqlParameter("@numWinnerStr", winners)
        Parametros1(5) = New MySqlParameter("@JackpotDbl", OldJackPotDbl)
        Parametros1(6) = New MySqlParameter("@dayWeekNameStr", dayWeekNameStr)
        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("InsertDraw", Parametros1, msgErrorStr)

    End Sub

    Sub saveLogLogin(ByVal userNameStr As String, ByVal updateDate As Date, ByVal descriptionActStr As String)
        Dim num1 As Integer
        Dim Parametros1(2) As MySqlParameter
        Dim msgErrorStr As String = ""

        Parametros1(0) = New MySqlParameter("@updateUser", userNameStr)
        Parametros1(1) = New MySqlParameter("@updateDate", updateDate)
        Parametros1(2) = New MySqlParameter("@descriptionAction", descriptionActStr)

        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertLog_login", Parametros1, msgErrorStr)

    End Sub



    Sub updateJackPot(ByVal sysCodeProductInt As Integer, ByVal currentJackPotDbl As Double)
        Dim num1 As Integer
        Dim Parametros1(1) As MySqlParameter
        Dim msgErrorStr As String = ""

        Parametros1(0) = New MySqlParameter("@jackPotDbl", currentJackPotDbl)
        Parametros1(1) = New MySqlParameter("@sysCodeProductInt", sysCodeProductInt) 'System Code
        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("UpdateJackPot", Parametros1, msgErrorStr)
    End Sub

    Sub updateAppVersion(ByVal appVersion As String, ByVal appName As String, ByVal userNameStr As String)
        Dim num1 As Integer
        Dim Parametros1(2) As MySqlParameter
        Dim msgErrorStr As String = ""

        Parametros1(0) = New MySqlParameter("@appversion", appVersion)
        Parametros1(1) = New MySqlParameter("@appname", appName)
        Parametros1(2) = New MySqlParameter("@userNameStr", usernameStr)
        num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("updateAppVersion", Parametros1, msgErrorStr)
    End Sub
    Function getAppVersion() As DataTable

        Dim table1 As DataTable
        table1 = RunStoreQueryWithoutParameters("qgetappversion")
        Return table1
    End Function



    Function getLast2WinnersJackpotTbl(ByVal IdProductInt As Integer) As DataTable

        Dim Parametros1(0) As MySqlParameter
        Dim table1 As DataTable
        Parametros1(0) = New MySqlParameter("@codGame", IdProductInt)

        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("Q2LastWinnersXGame", Parametros1)

        Return table1
    End Function

    Function getShortNameStateTbl(ByVal IdProductInt As Integer, ByVal cdcInt As Integer) As DataTable

        Dim Parametros1(1) As MySqlParameter
        Dim table1 As DataTable
        Parametros1(0) = New MySqlParameter("@codGame", IdProductInt)
        Parametros1(1) = New MySqlParameter("@cdc", cdcInt)

        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnshortname", Parametros1)

        Return table1
    End Function

    Function getLastUserTbl(ByVal activityStr As String) As DataTable

        Dim Parametros1(0) As MySqlParameter
        Dim table1 As DataTable
        Parametros1(0) = New MySqlParameter("@activity", activityStr)

        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnLastUser", Parametros1)

        Return table1
    End Function

    Function getInfoUserFromDatabase(ByVal userNameStr As String) As DataTable

        Dim Parametros1(0) As MySqlParameter
        Dim table1 As DataTable

        Parametros1(0) = New MySqlParameter("@username", userNameStr)
        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnInfoUser", Parametros1)

        Return table1

    End Function

    Sub getLastWinnersTake5TblHorizontal(ByVal limitsInt As Integer)

        Dim Parametros1(0) As MySqlParameter
        Dim Parameters2(1) As MySqlParameter
        Dim Parameters3(6) As MySqlParameter
        Dim table1 As DataTable
        Dim contador, i, intError, cdcParameterInt, drawNumberInt, cdcInt As Integer
        Dim monthStr, dayStr, strWinner, shortNameListStr, shortNameStr As String
        Dim tableWin As DataTable
        Dim fechaDate As Date
        Dim numRecords As Integer = 0
        Dim strError As String = ""

        cdcParameterInt = returnCDC(Now) - 1

        drawNumberInt = getDrawNumberXProductXday(10, Now, 0)
        drawNumberInt = drawNumberInt - 1

        Parameters2(0) = New MySqlParameter("@cdc", cdcParameterInt)
        Parameters2(1) = New MySqlParameter("@codProduct", 2)

        Parameters3(0) = New MySqlParameter("@numDrawInt", drawNumberInt)
        Parameters3(1) = New MySqlParameter("@numCDCInt", cdcParameterInt)
        Parameters3(2) = New MySqlParameter("@nomProductStr", "CSH5")
        Parameters3(3) = New MySqlParameter("@codigoProductInt", 2)
        Parameters3(4) = New MySqlParameter("@numWinnerStr", "")
        Parameters3(5) = New MySqlParameter("@JackpotDbl", 0)

        If Weekday(Now) = 1 Then
            Parameters3(6) = New MySqlParameter("@dayWeekNameStr", "Saturday")
        Else
            Parameters3(6) = New MySqlParameter("@dayWeekNameStr", WeekdayName(Weekday(Now) - 1))

        End If

        intError = dataSourceAccess.RunStoreProcedureScalarInteger("qnumrecordsxcdcxproduct", Parameters2, numRecords, strError)
        If intError = 0 Then
            If numRecords = 0 Then
                intError = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertdraw", Parameters3, strError)
                If intError <> 0 Then
                    MsgBox(strError)
                End If

            End If
        Else
            MsgBox(strError)

        End If



        Parametros1(0) = New MySqlParameter("@limite", limitsInt)

        'winnersTake5Tbl = Utils.DespliegueTake5Winners

        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("winnersTake5", Parametros1)
        i = 1
        For Each row1 In table1.Rows

            Form1.grdTake5Hor.Rows(0).Cells(i).Value = Trim(row1("dayWeekName"))
            i += 1
        Next

        contador = limitsInt
        While contador < 7
            Form1.grdTake5Hor.Rows(0).Cells(i).Value = Trim(WeekdayName(contador + 1))
            contador = contador + 1
            i += 1
        End While

        i = 1
        For Each row1 In table1.Rows
            fechaDate = returnFecha(row1("numCDC") - 1)
            monthStr = CStr(fechaDate.Month).PadLeft(2, "0")
            dayStr = CStr(fechaDate.Day).PadLeft(2, "0")

            Form1.grdTake5Hor.Rows(1).Cells(i).Value = monthStr & "/" & dayStr
            cdcInt = row1("numCDC")
            Form1.grdTake5Hor.Rows(2).Cells(i).Value = cdcInt
            i += 1
        Next

        While i <= 7
            cdcInt = cdcInt + 1
            fechaDate = returnFecha(cdcInt - 1)
            monthStr = CStr(fechaDate.Month).PadLeft(2, "0")
            dayStr = CStr(fechaDate.Day).PadLeft(2, "0")

            Form1.grdTake5Hor.Rows(1).Cells(i).Value = monthStr & "/" & dayStr
            Form1.grdTake5Hor.Rows(2).Cells(i).Value = cdcInt
            i += 1
        End While



        i = 1
        For Each row1 In table1.Rows
            Form1.grdTake5Hor.Rows(3).Cells(i).Value = row1("Winners")
            i += 1
        Next


        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("winnersCash4Life", Parametros1)

        i = 1
        For Each row1 In table1.Rows
            strWinner = row1("Winners")
            Form1.grdTake5Hor.Rows(4).Cells(i).Value = strWinner
            If (strWinner > "0") Then
                Select Case i
                    Case 1
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button1.Visible = True
                        Form1.Button1.Text = shortNameListStr

                    Case 2
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button9.Visible = True
                        Form1.Button9.Text = shortNameListStr

                    Case 3
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button10.Visible = True
                        Form1.Button10.Text = shortNameListStr

                    Case 4
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button11.Visible = True
                        Form1.Button11.Text = shortNameListStr

                    Case 5
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button12.Visible = True
                        Form1.Button12.Text = shortNameListStr


                    Case 6
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button13.Visible = True
                        Form1.Button13.Text = shortNameListStr


                    Case 7
                        cdcInt = Form1.grdTake5Hor.Rows(2).Cells(i).Value
                        tableWin = getShortNameStateTbl(5, cdcInt)
                        shortNameListStr = ""
                        For Each row2 In tableWin.Rows
                            shortNameStr = row2("short_name")
                            If shortNameListStr = "" Then
                                shortNameListStr = shortNameStr
                            Else
                                shortNameListStr = shortNameListStr & "," & shortNameStr
                            End If
                        Next
                        Form1.Button14.Visible = True
                        Form1.Button14.Text = shortNameListStr
                End Select
            Else
                Select Case i
                    Case 1
                        Form1.Button1.Visible = False
                    Case 2
                        Form1.Button9.Visible = False
                    Case 3
                        Form1.Button10.Visible = False
                    Case 4
                        Form1.Button11.Visible = False
                    Case 5
                        Form1.Button12.Visible = False
                    Case 6
                        Form1.Button13.Visible = False
                    Case 7
                        Form1.Button14.Visible = False
                End Select

            End If
            i += 1
        Next

        Form1.grdTake5Hor.Rows(3).Cells(0).Value = "CSH5"
        Form1.grdTake5Hor.Rows(4).Cells(0).Value = "LIFE"
        Form1.grdTake5Hor.Rows(2).Cells(0).Value = "CDC"
        Form1.grdTake5Hor.Rows(1).Cells(0).Value = "DATE"


    End Sub




    Function getLastWinnersTake5Tbl(ByVal limitsInt As Integer) As DataTable

        Dim winnersTake5Tbl As New DataTable("TAKE5_WINNERS")
        Dim newRowTake5 As DataRow
        Dim Parametros1(0) As MySqlParameter
        Dim table1 As DataTable
        Dim contador As Integer

        Parametros1(0) = New MySqlParameter("@limite", limitsInt)

        winnersTake5Tbl = Utils.DespliegueTake5Winners

        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("winnersTake5", Parametros1)
        For Each row1 In table1.Rows

            newRowTake5 = winnersTake5Tbl.NewRow()
            newRowTake5(0) = Trim(row1("dayWeekName"))
            newRowTake5(1) = row1("numCDC")
            'newRowTake5(2) = row1("numDraw")
            newRowTake5(2) = row1("Winners")
            winnersTake5Tbl.Rows.Add(newRowTake5)

        Next


        contador = limitsInt
        While contador < 7
            newRowTake5 = winnersTake5Tbl.NewRow()
            newRowTake5(0) = Trim(WeekdayName(contador + 1))
            winnersTake5Tbl.Rows.Add(newRowTake5)
            contador = contador + 1
        End While



        'contador = 7
        'While contador > limitsInt
        '    newRowTake5 = winnersTake5Tbl.NewRow()
        '    newRowTake5(0) = Trim(WeekdayName(contador))
        '    winnersTake5Tbl.Rows.Add(newRowTake5)
        '    contador = contador - 1
        'End While



        Return winnersTake5Tbl
    End Function


    Function readJackpotFromPaginaWeb(ByVal laUrl As String, ByVal sysCodeProductInt As Integer) As Double
        Dim jackpotDbl As Double = 0
        Dim num2 As Integer
        Dim num3 As Integer
        Dim reader1 As StreamReader
        Dim request1 As WebRequest
        Dim response1 As WebResponse
        Dim str2 As String = ""
        Dim str3 As String
        Dim str4 As String
        Dim resultStringFromWebPageStr As String


        request1 = WebRequest.Create(laUrl)
        response1 = request1.GetResponse()
        reader1 = New StreamReader(response1.GetResponseStream())
        resultStringFromWebPageStr = reader1.ReadToEnd()
        reader1.Close()
        response1.Close()

        Select Case sysCodeProductInt

            Case 8
                str2 = "ROS-NY Lotto"

            Case 12
                str2 = "ROS-Mega Millions"

            Case 15
                str2 = "ROS-Powerball"

            Case Else
                Return jackpotDbl

        End Select
        num2 = InStr(1, resultStringFromWebPageStr, str2, CompareMethod.Text)
        str3 = Mid(resultStringFromWebPageStr, (num2 - 400), 200)
        num3 = InStr(1, str3, "next-jackpot-amount'>$", CompareMethod.Text)
        str4 = Mid(str3, (num3 + 22), 14)
        num3 = InStr(1, str4, "<", CompareMethod.Text)
        str4 = Mid(str4, 1, (num3 - 1))
        jackpotDbl = CDbl(str4)

        Return jackpotDbl
    End Function

    Function getCurrentJackpotFromDatabase(ByVal IdProductInt As Integer) As Double
        Dim jackpotDbl As Double = 0
        Dim err1 As Integer

        Dim Parametros1(0) As MySqlParameter
        Dim msgErrorStr As String = ""

        Parametros1(0) = New MySqlParameter("@CodGame", IdProductInt)
        err1 = dataSourceAccess.RunStoreProcedureScalar("returnNewJackpot", Parametros1, jackpotDbl, msgErrorStr)
        Return jackpotDbl
    End Function

    Function readHostModeFile(ByVal strFileModeHost As String, ByRef hostNumberArray() As String, ByRef errMessageStr As String) As Boolean

        Dim reader1 As StreamReader
        Dim strLinea As String

        Try
            reader1 = New StreamReader(strFileModeHost, Encoding.UTF7)
            strLinea = ""
            strLinea = reader1.ReadLine()
            hostNumberArray = strLinea.Split("|")
            reader1.Close()
            Return True

        Catch ex As Exception
            errMessageStr = ex.Message
            Return False

        End Try

    End Function


    Function getSaveHostMode(ByVal strFileModeHost As String, ByRef hostNumberArray() As String, ByRef errMessageStr As String) As Integer

        Dim Parametros1(7) As MySqlParameter
        Dim num1 As Integer
        Dim resBoolHostConfi As Boolean

        If readHostModeFile(strFileModeHost, hostNumberArray, errMessageStr) Then

            resBoolHostConfi = validateLastHostConfi(hostNumberArray(0), hostNumberArray(1), hostNumberArray(2), hostNumberArray(3), hostNumberArray(4)) 'Return True if the last record has the same configuration of hosts

            If Not resBoolHostConfi Then
                Parametros1(0) = New MySqlParameter("@primaryHost", hostNumberArray(0))
                Parametros1(1) = New MySqlParameter("@secondaryHost", hostNumberArray(1))
                Parametros1(2) = New MySqlParameter("@spare1", hostNumberArray(2))
                Parametros1(3) = New MySqlParameter("@spare2", hostNumberArray(3))
                Parametros1(4) = New MySqlParameter("@spare3", hostNumberArray(4))
                Parametros1(5) = New MySqlParameter("@dateday", Now)
                Parametros1(6) = New MySqlParameter("@updateDate", Now)
                Parametros1(7) = New MySqlParameter("@updateUser", "System")
                num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("inserthostsystems", Parametros1, errMessageStr)
                If num1 = 0 Then
                    Return 0

                Else
                    Return 1
                    'MsgBox("Error trying to insert Hosts: " & errMessageStr, MsgBoxStyle.Information, "Error")

                End If
            Else
                Return 2

            End If

        Else
            Return 3

        End If


    End Function


    Function validateEquals(ByVal priHostInt As Integer, ByVal secHostInt As Integer, ByVal spare1Int As Integer, ByVal spare2Int As Integer, ByVal spare3Int As Integer) As Boolean

        If (priHostInt = secHostInt) Or (priHostInt = spare1Int) Or (priHostInt = spare2Int) Or (priHostInt = spare3Int) Or (secHostInt = spare1Int) Or _
        (secHostInt = spare2Int) Or (secHostInt = spare3Int) Or (spare1Int = spare2Int) Or (spare1Int = spare3Int) Or (spare2Int = spare3Int) Then
            Return False
        Else
            Return True

        End If

    End Function

    Function validateLastHostConfi(ByVal priHostInt As Integer, ByVal secHostInt As Integer, ByVal spare1Int As Integer, ByVal spare2Int As Integer, ByVal spare3Int As Integer) As Boolean

        Dim tableHostConfi As DataTable
        Dim primaryHostDatabaseInt, secondaryHostDatabaseInt, spare1HostDatabaseInt, spare2HostDatabaseInt, spare3HostDatabaseInt As Integer

        tableHostConfi = dataSourceAccess.RunStoreQueryWithoutParameters("qhostsystems")

        primaryHostDatabaseInt = tableHostConfi.Rows(0).Item(0)
        secondaryHostDatabaseInt = tableHostConfi.Rows(0).Item(1)
        spare1HostDatabaseInt = tableHostConfi.Rows(0).Item(2)
        spare2HostDatabaseInt = tableHostConfi.Rows(0).Item(3)
        spare3HostDatabaseInt = tableHostConfi.Rows(0).Item(4)


        If (priHostInt = primaryHostDatabaseInt) And (secHostInt = secondaryHostDatabaseInt) And (spare1Int = spare1HostDatabaseInt) And (spare2Int = spare2HostDatabaseInt) And (spare3Int = spare3HostDatabaseInt) Then
            Return True
        Else
            Return False

        End If

    End Function



    Function returnColor(ByVal systemNumberInt As Integer) As Color

        Select Case systemNumberInt
            Case 1
                Return Color.Blue

            Case 2
                Return Color.Red

            Case 3
                Return Color.Green

            Case 4
                Return Color.Black

            Case 5
                Return Color.Purple

        End Select

    End Function

    Function UserAuthenticateActiveDirectory(ByVal Path As String, ByVal Username As String, ByVal Pass As String) As Boolean

        Dim dirSearch As DirectorySearcher
        Dim dirEntry As New DirectoryEntry(Path, Username, Pass, AuthenticationTypes.Secure)

        Try
            dirSearch = New DirectorySearcher(dirEntry)
            dirSearch.FindOne()
            Return True

        Catch ex As Exception

            Return False

        End Try


    End Function


    'Function getVersionApps() As DataTable

    '    Dim versionAppsTbl As New DataTable("VERSION_APPS")
    '    Dim newRowTake5 As DataRow
    '    Dim Parametros1(0) As MySqlParameter
    '    Dim table1 As DataTable
    '    Dim contador As Integer
    '    Parametros1(0) = New MySqlParameter("@limite", limitsInt)


    '    winnersTake5Tbl = Utils.DespliegueTake5Winners
    '    contador = 7
    '    While contador > limitsInt
    '        newRowTake5 = winnersTake5Tbl.NewRow()
    '        newRowTake5(0) = Trim(WeekdayName(contador))
    '        winnersTake5Tbl.Rows.Add(newRowTake5)
    '        contador = contador - 1
    '    End While

    '    table1 = dataSourceAccess.RunStructureProcedureReturnDtable("winnersTake5", Parametros1)
    '    For Each row1 In table1.Rows

    '        newRowTake5 = winnersTake5Tbl.NewRow()
    '        newRowTake5(0) = Trim(row1("dayWeekName"))
    '        newRowTake5(1) = row1("numCDC")
    '        newRowTake5(2) = row1("numDraw")
    '        newRowTake5(3) = row1("Winners")
    '        winnersTake5Tbl.Rows.Add(newRowTake5)

    '    Next

    '    Return winnersTake5Tbl
    'End Function





End Module
