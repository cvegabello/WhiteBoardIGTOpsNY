Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Net
Imports MySql.Data.MySqlClient
Public Class Form3

    Public _form1 As Form1

    Public Sub New(ByVal form1 As Form1)
        'MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        'Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + "\Nautilus.isl")
        InitializeComponent()
        _form1 = form1

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub




    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click


        Dim num1 As Integer
        Dim Parametros1(7) As MySqlParameter
        Dim msgErrorStr As String = ""
        Dim priHostInt, secHostInt, spare1Int, spare2Int, spare3Int As Integer
        Dim resBool, resBoolHostConfi As Boolean

        priHostInt = CInt(NumericUpDown1.Value)
        secHostInt = CInt(NumericUpDown2.Value)
        spare1Int = CInt(NumericUpDown3.Value)
        spare2Int = CInt(NumericUpDown4.Value)
        spare3Int = CInt(NumericUpDown5.Value)

        resBool = validateEquals(priHostInt, secHostInt, spare1Int, spare2Int, spare3Int)

        If resBool Then
            resBoolHostConfi = validateLastHostConfi(priHostInt, secHostInt, spare1Int, spare2Int, spare3Int) 'Return True if the last record has the same configuration of hosts

            If Not resBoolHostConfi Then
                Parametros1(0) = New MySqlParameter("@primaryHost", priHostInt)
                Parametros1(1) = New MySqlParameter("@secondaryHost", secHostInt)
                Parametros1(2) = New MySqlParameter("@spare1", spare1Int)
                Parametros1(3) = New MySqlParameter("@spare2", spare2Int)
                Parametros1(4) = New MySqlParameter("@spare3", spare3Int)
                Parametros1(5) = New MySqlParameter("@dateday", Now)
                Parametros1(6) = New MySqlParameter("@updateDate", Now)
                Parametros1(7) = New MySqlParameter("@updateUser", Trim(_form1.usernameTakeOverLbl.Text))
                num1 = dataSourceAccess.RunStoreProcedureParametersNonQuery("inserthostsystems", Parametros1, msgErrorStr)
                If num1 = 0 Then
                    Me.Close()
                Else
                    MsgBox("Error trying to insert Hosts: " & msgErrorStr, MsgBoxStyle.Information, "Error")

                End If
            End If

        Else
            MsgBox("Error trying to insert Hosts: System numbers must be differents", MsgBoxStyle.Information, "Error")

        End If



    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim tableQhostSystems As DataTable

        'dataSourceAccess.ConexionMySQL()

        tableQhostSystems = dataSourceAccess.RunStoreQueryWithoutParameters("qhostsystems")
        NumericUpDown1.Value = tableQhostSystems.Rows(0).Item(0)
        NumericUpDown2.Value = tableQhostSystems.Rows(0).Item(1)
        NumericUpDown3.Value = tableQhostSystems.Rows(0).Item(2)
        NumericUpDown4.Value = tableQhostSystems.Rows(0).Item(3)
        NumericUpDown5.Value = tableQhostSystems.Rows(0).Item(4)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class