Imports MySql.Data.MySqlClient

Public Class winnersJackpotFrm

    Public _gameNumber As Integer

    Public Sub New(ByVal gameNumber As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _gameNumber = gameNumber

    End Sub

    Private Sub winnersJackpotFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim fechaYesterday As Date
        Dim cdcInt, numrecordsInt, codProductInt As Integer
        Dim Parametros1(1) As MySqlParameter
        Dim table1 As DataTable

        GroupBox5.Visible = False
        GroupBox6.Visible = False
        GroupBox7.Visible = False
        GroupBox8.Visible = False
        GroupBox9.Visible = False
        GroupBox10.Visible = False
        GroupBox11.Visible = False
        GroupBox12.Visible = False


        'dataSourceAccess.ConexionMySQL()
        Select Case _gameNumber
            Case 1
                Label11.Text = "MEGA MILLIONS"
                Me.Text = "WINNERS PER STATE - MEGA MILLIONS -"

            Case 5
                Label11.Text = "CASH 4 LIFE"
                Me.Text = "WINNERS PER STATE - CASH 4 LIFE  -"

            Case 10
                Label11.Text = "POWERBALL"
                Me.Text = "WINNERS PER STATE - POWERBALL  -"

            Case 6
                Label11.Text = "LOTTO"
                Me.Text = "WINNERS PER STATE - LOTTO  -"


            Case 2
                Label11.Text = "TAKE 5"
                Me.Text = "WINNERS PER STATE - TAKE 5  -"


        End Select

        Me.fillCombos()


        fechaYesterday = Format(Now.AddDays(-1), "MM/dd/yyyy")

        cdcInt = returnCDC(fechaYesterday)
        Label10.Text = fechaYesterday
        Label12.Text = cdcInt


        codProductInt = _gameNumber
        Parametros1(0) = New MySqlParameter("@CodGame", codProductInt)
        Parametros1(1) = New MySqlParameter("@cdc", cdcInt)
        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("numWinnerXStateXGameXcdc", Parametros1)
        'table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnStateUsaXGameXday", Parametros1)
        numrecordsInt = table1.Rows.Count


        If numrecordsInt > 0 Then

            NumericUpDown1.Value = numrecordsInt
            Select Case numrecordsInt


                Case 1

                    GroupBox5.Visible = True
                    ComboBox1.Text = table1.Rows(0).Item(0)
                    NumericUpDown2.Value = table1.Rows(0).Item(1)


                Case 2


                    GroupBox5.Visible = True
                    ComboBox1.Text = table1.Rows(0).Item(0)
                    NumericUpDown2.Value = table1.Rows(0).Item(1)


                    GroupBox6.Visible = True
                    ComboBox2.Text = table1.Rows(1).Item(0)
                    NumericUpDown3.Value = table1.Rows(1).Item(1)

                Case 3

                    GroupBox5.Visible = True
                    ComboBox1.Text = table1.Rows(0).Item(0)
                    NumericUpDown2.Value = table1.Rows(0).Item(1)


                    GroupBox6.Visible = True
                    ComboBox2.Text = table1.Rows(1).Item(0)
                    NumericUpDown3.Value = table1.Rows(1).Item(1)


                    GroupBox7.Visible = True
                    ComboBox3.Text = table1.Rows(2).Item(0)
                    NumericUpDown4.Value = table1.Rows(2).Item(1)


                Case 4

                    GroupBox5.Visible = True
                    ComboBox1.Text = table1.Rows(0).Item(0)
                    NumericUpDown2.Value = table1.Rows(0).Item(1)


                    GroupBox6.Visible = True
                    ComboBox2.Text = table1.Rows(1).Item(0)
                    NumericUpDown3.Value = table1.Rows(1).Item(1)


                    GroupBox7.Visible = True
                    ComboBox3.Text = table1.Rows(2).Item(0)
                    NumericUpDown4.Value = table1.Rows(2).Item(1)


                    GroupBox8.Visible = True
                    ComboBox4.Text = table1.Rows(3).Item(0)
                    NumericUpDown5.Value = table1.Rows(3).Item(1)

                Case 5

                    GroupBox5.Visible = True
                    ComboBox1.Text = table1.Rows(0).Item(0)
                    NumericUpDown2.Value = table1.Rows(0).Item(1)


                    GroupBox6.Visible = True
                    ComboBox2.Text = table1.Rows(1).Item(0)
                    NumericUpDown3.Value = table1.Rows(1).Item(1)


                    GroupBox7.Visible = True
                    ComboBox3.Text = table1.Rows(2).Item(0)
                    NumericUpDown4.Value = table1.Rows(2).Item(1)


                    GroupBox8.Visible = True
                    ComboBox4.Text = table1.Rows(3).Item(0)
                    NumericUpDown5.Value = table1.Rows(3).Item(1)


                    GroupBox9.Visible = True
                    ComboBox5.Text = table1.Rows(4).Item(0)
                    NumericUpDown6.Value = table1.Rows(4).Item(1)


                Case 6


                    GroupBox5.Visible = True
                    ComboBox1.Text = table1.Rows(0).Item(0)
                    NumericUpDown2.Value = table1.Rows(0).Item(1)


                    GroupBox6.Visible = True
                    ComboBox2.Text = table1.Rows(1).Item(0)
                    NumericUpDown3.Value = table1.Rows(1).Item(1)


                    GroupBox7.Visible = True
                    ComboBox3.Text = table1.Rows(2).Item(0)
                    NumericUpDown4.Value = table1.Rows(2).Item(1)


                    GroupBox8.Visible = True
                    ComboBox4.Text = table1.Rows(3).Item(0)
                    NumericUpDown5.Value = table1.Rows(3).Item(1)


                    GroupBox9.Visible = True
                    ComboBox5.Text = table1.Rows(4).Item(0)
                    NumericUpDown6.Value = table1.Rows(4).Item(1)


                    GroupBox10.Visible = True
                    ComboBox6.Text = table1.Rows(5).Item(0)
                    NumericUpDown7.Value = table1.Rows(5).Item(1)

            End Select

            '    NumericUpDown1.Value = table1.Rows(0).Item(3)

            '    For Each row1 In table1.Rows
            '        numDayDrawInt = row1("numWinners")

            '    Next

        End If

    End Sub


    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        'Button1.Enabled = True

        Dim numStatesInt As Integer


        GroupBox5.Visible = False
        GroupBox6.Visible = False
        GroupBox7.Visible = False
        GroupBox8.Visible = False
        GroupBox9.Visible = False
        GroupBox10.Visible = False
        GroupBox11.Visible = False
        GroupBox12.Visible = False


        numStatesInt = NumericUpDown1.Value

        Select Case numStatesInt


            Case 1

                GroupBox5.Visible = True

            Case 2


                GroupBox5.Visible = True
                GroupBox6.Visible = True


            Case 3

                GroupBox5.Visible = True
                GroupBox6.Visible = True
                GroupBox7.Visible = True


            Case 4

                GroupBox5.Visible = True
                GroupBox6.Visible = True
                GroupBox7.Visible = True
                GroupBox8.Visible = True


            Case 5

                GroupBox5.Visible = True
                GroupBox6.Visible = True
                GroupBox7.Visible = True
                GroupBox8.Visible = True
                GroupBox9.Visible = True



            Case 6

                GroupBox5.Visible = True
                GroupBox6.Visible = True
                GroupBox7.Visible = True
                GroupBox8.Visible = True
                GroupBox9.Visible = True
                GroupBox10.Visible = True


                'Case 7

                '    Label2.Visible = True
                '    ComboBox1.Visible = True

                '    Label3.Visible = True
                '    ComboBox2.Visible = True

                '    Label4.Visible = True
                '    ComboBox3.Visible = True

                '    Label5.Visible = True
                '    ComboBox4.Visible = True

                '    Label6.Visible = True
                '    ComboBox5.Visible = True

                '    Label7.Visible = True
                '    ComboBox6.Visible = True

                '    Label8.Visible = True
                '    ComboBox7.Visible = True


                'Case 8

                '    Label2.Visible = True
                '    ComboBox1.Visible = True

                '    Label3.Visible = True
                '    ComboBox2.Visible = True

                '    Label4.Visible = True
                '    ComboBox3.Visible = True

                '    Label5.Visible = True
                '    ComboBox4.Visible = True

                '    Label6.Visible = True
                '    ComboBox5.Visible = True

                '    Label7.Visible = True
                '    ComboBox6.Visible = True

                '    Label8.Visible = True
                '    ComboBox7.Visible = True

                '    Label9.Visible = True
                '    ComboBox8.Visible = True



        End Select



    End Sub
    Private Sub fillCombos()

        ComboBox1.DataSource = RunStoreQueryWithoutParameters("qstates_usa")
        ComboBox1.DisplayMember = "long_name"
        ComboBox1.ValueMember = "idstates_usa"

        ComboBox2.DataSource = RunStoreQueryWithoutParameters("qstates_usa")
        ComboBox2.DisplayMember = "long_name"
        ComboBox2.ValueMember = "idstates_usa"


        ComboBox3.DataSource = RunStoreQueryWithoutParameters("qstates_usa")
        ComboBox3.DisplayMember = "long_name"
        ComboBox3.ValueMember = "idstates_usa"


        ComboBox4.DataSource = RunStoreQueryWithoutParameters("qstates_usa")
        ComboBox4.DisplayMember = "long_name"
        ComboBox4.ValueMember = "idstates_usa"


        ComboBox5.DataSource = RunStoreQueryWithoutParameters("qstates_usa")
        ComboBox5.DisplayMember = "long_name"
        ComboBox5.ValueMember = "idstates_usa"


        ComboBox6.DataSource = RunStoreQueryWithoutParameters("qstates_usa")
        ComboBox6.DisplayMember = "long_name"
        ComboBox6.ValueMember = "idstates_usa"


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim numStatesInt, codProductInt, cdcInt, stateCodInt, numWinnersInt, numrecordsInt, errorCodeInt, myerrorCodeInt As Integer
        Dim parameters1(4) As MySql.Data.MySqlClient.MySqlParameter
        Dim parameters2(1) As MySql.Data.MySqlClient.MySqlParameter
        Dim parameters3(2) As MySql.Data.MySqlClient.MySqlParameter
        Dim msgErrorStr As String = ""
        Dim table1 As DataTable
        Dim numWinnerStr As String

        myerrorCodeInt = 0

        numStatesInt = NumericUpDown1.Value
        codProductInt = _gameNumber
        cdcInt = CInt(Label12.Text)
        'parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
        'parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)

        'dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)

        Select Case numStatesInt

            Case 0

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)

                'Actualizar ganadores en history_draw
                parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", "0")

                dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)
                MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                Me.Dispose()

            Case 1

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)

                stateCodInt = ComboBox1.SelectedValue
                numWinnersInt = NumericUpDown2.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                numrecordsInt = table1.Rows.Count

                If numrecordsInt = 0 Then
                    numWinnerStr = "0"
                Else
                    numWinnerStr = CStr(table1.Rows(0).Item(2))
                End If

                'Actualizar ganadores en history_draw
                parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", numWinnerStr)

                dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)

                MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                Me.Dispose()



            Case 2

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)


                stateCodInt = ComboBox1.SelectedValue
                numWinnersInt = NumericUpDown2.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)
                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select

                stateCodInt = ComboBox2.SelectedValue
                numWinnersInt = NumericUpDown3.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                Select Case myerrorCodeInt

                    Case 0
                        parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                        parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                        numrecordsInt = table1.Rows.Count

                        If numrecordsInt = 0 Then
                            numWinnerStr = "0"
                        Else
                            numWinnerStr = CStr(table1.Rows(0).Item(2))
                        End If

                        'Actualizar ganadores en history_draw
                        parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                        parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", numWinnerStr)

                        dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)

                        MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                        Me.Dispose()

                    Case -10
                        MsgBox("There is a state duplicated. This will not be added.", MsgBoxStyle.Critical, "STATE DUPLICATED ERROR.")

                    Case -1

                        MsgBox("Error trying to add a winner." & " " & msgErrorStr, MsgBoxStyle.Critical, "ERROR.")

                End Select


            Case 3

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)


                stateCodInt = ComboBox1.SelectedValue
                numWinnersInt = NumericUpDown2.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)
                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                stateCodInt = ComboBox2.SelectedValue
                numWinnersInt = NumericUpDown3.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)

                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                stateCodInt = ComboBox3.SelectedValue
                numWinnersInt = NumericUpDown4.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)

                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                Select Case myerrorCodeInt

                    Case 0
                        parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                        parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                        numrecordsInt = table1.Rows.Count

                        If numrecordsInt = 0 Then
                            numWinnerStr = "0"
                        Else
                            numWinnerStr = CStr(table1.Rows(0).Item(2))
                        End If

                        'Actualizar ganadores en history_draw
                        parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                        parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", numWinnerStr)

                        dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)

                        MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                        Me.Dispose()

                    Case -10
                        MsgBox("There is a state duplicated. This will not be added.", MsgBoxStyle.Critical, "STATE DUPLICATED ERROR.")

                    Case -1

                        MsgBox("Error trying to add a winner." & " " & msgErrorStr, MsgBoxStyle.Critical, "ERROR.")

                End Select




            Case 4

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)


                stateCodInt = ComboBox1.SelectedValue
                numWinnersInt = NumericUpDown2.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select




                stateCodInt = ComboBox2.SelectedValue
                numWinnersInt = NumericUpDown3.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select




                stateCodInt = ComboBox3.SelectedValue
                numWinnersInt = NumericUpDown4.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox4.SelectedValue
                numWinnersInt = NumericUpDown5.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""

                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                Select Case myerrorCodeInt

                    Case 0
                        parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                        parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                        numrecordsInt = table1.Rows.Count

                        If numrecordsInt = 0 Then
                            numWinnerStr = "0"
                        Else
                            numWinnerStr = CStr(table1.Rows(0).Item(2))
                        End If

                        'Actualizar ganadores en history_draw
                        parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                        parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", numWinnerStr)

                        dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)

                        MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                        Me.Dispose()

                    Case -10
                        MsgBox("There is a state duplicated. This will not be added.", MsgBoxStyle.Critical, "STATE DUPLICATED ERROR.")

                    Case -1

                        MsgBox("Error trying to add a winner." & " " & msgErrorStr, MsgBoxStyle.Critical, "ERROR.")

                End Select


            Case 5

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)


                stateCodInt = ComboBox1.SelectedValue
                numWinnersInt = NumericUpDown2.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                stateCodInt = ComboBox2.SelectedValue
                numWinnersInt = NumericUpDown3.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox3.SelectedValue
                numWinnersInt = NumericUpDown4.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox4.SelectedValue
                numWinnersInt = NumericUpDown5.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                stateCodInt = ComboBox5.SelectedValue
                numWinnersInt = NumericUpDown6.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                Select Case myerrorCodeInt

                    Case 0
                        parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                        parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                        numrecordsInt = table1.Rows.Count

                        If numrecordsInt = 0 Then
                            numWinnerStr = "0"
                        Else
                            numWinnerStr = CStr(table1.Rows(0).Item(2))
                        End If

                        'Actualizar ganadores en history_draw
                        parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                        parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", numWinnerStr)

                        dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)

                        MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                        Me.Dispose()

                    Case -10
                        MsgBox("There is a state duplicated. This will not be added.", MsgBoxStyle.Critical, "STATE DUPLICATED ERROR.")

                    Case -1

                        MsgBox("Error trying to add a winner." & " " & msgErrorStr, MsgBoxStyle.Critical, "ERROR.")

                End Select


            Case 6

                parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@CodGame", codProductInt)
                parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                dataSourceAccess.RunStoreProcedureParametersNonQuery("deleteWinnnerXproductXcdc", parameters2, msgErrorStr)


                stateCodInt = ComboBox1.SelectedValue
                numWinnersInt = NumericUpDown2.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox2.SelectedValue
                numWinnersInt = NumericUpDown3.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox3.SelectedValue
                numWinnersInt = NumericUpDown4.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox4.SelectedValue
                numWinnersInt = NumericUpDown5.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                stateCodInt = ComboBox5.SelectedValue
                numWinnersInt = NumericUpDown6.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""
                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select



                stateCodInt = ComboBox6.SelectedValue
                numWinnersInt = NumericUpDown7.Value
                parameters1(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                parameters1(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                parameters1(2) = New MySql.Data.MySqlClient.MySqlParameter("@codstate", stateCodInt)
                parameters1(3) = New MySql.Data.MySqlClient.MySqlParameter("@numwinners", numWinnersInt)
                parameters1(4) = New MySql.Data.MySqlClient.MySqlParameter("@dateTimeInsert", Now)
                msgErrorStr = ""

                errorCodeInt = dataSourceAccess.RunStoreProcedureParametersNonQuery("insertWinnnerXstate", parameters1, msgErrorStr)


                Select Case errorCodeInt
                    Case 0
                        myerrorCodeInt = 0

                    Case -2147467259

                        myerrorCodeInt = -10

                    Case Else
                        myerrorCodeInt = -1
                End Select


                Select Case myerrorCodeInt

                    Case 0
                        parameters2(0) = New MySql.Data.MySqlClient.MySqlParameter("@codproduct", codProductInt)
                        parameters2(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        table1 = dataSourceAccess.RunStructureProcedureReturnDtable("returnTotalWinners", parameters2)
                        numrecordsInt = table1.Rows.Count

                        If numrecordsInt = 0 Then
                            numWinnerStr = "0"
                        Else
                            numWinnerStr = CStr(table1.Rows(0).Item(2))
                        End If

                        'Actualizar ganadores en history_draw
                        parameters3(0) = New MySql.Data.MySqlClient.MySqlParameter("@codGame", codProductInt)
                        parameters3(1) = New MySql.Data.MySqlClient.MySqlParameter("@cdc", cdcInt)
                        parameters3(2) = New MySql.Data.MySqlClient.MySqlParameter("@numWinnerStr", numWinnerStr)

                        dataSourceAccess.RunStoreProcedureParametersNonQuery("updateNumWinners", parameters3, msgErrorStr)

                        MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
                        Me.Dispose()

                    Case -10
                        MsgBox("There is a state duplicated. This will not be added.", MsgBoxStyle.Critical, "STATE DUPLICATED ERROR.")

                    Case -1

                        MsgBox("Error trying to add a winner." & " " & msgErrorStr, MsgBoxStyle.Critical, "ERROR.")

                End Select



                'Case 7

                '    Label2.Visible = True
                '    ComboBox1.Visible = True

                '    Label3.Visible = True
                '    ComboBox2.Visible = True

                '    Label4.Visible = True
                '    ComboBox3.Visible = True

                '    Label5.Visible = True
                '    ComboBox4.Visible = True

                '    Label6.Visible = True
                '    ComboBox5.Visible = True

                '    Label7.Visible = True
                '    ComboBox6.Visible = True

                '    Label8.Visible = True
                '    ComboBox7.Visible = True


                'Case 8

                '    Label2.Visible = True
                '    ComboBox1.Visible = True

                '    Label3.Visible = True
                '    ComboBox2.Visible = True

                '    Label4.Visible = True
                '    ComboBox3.Visible = True

                '    Label5.Visible = True
                '    ComboBox4.Visible = True

                '    Label6.Visible = True
                '    ComboBox5.Visible = True

                '    Label7.Visible = True
                '    ComboBox6.Visible = True

                '    Label8.Visible = True
                '    ComboBox7.Visible = True

                '    Label9.Visible = True
                '    ComboBox8.Visible = True



        End Select

        'MsgBox("Winners per state have been saved successfully", MsgBoxStyle.Information, "DONE")
        'Me.Close()



    End Sub
End Class