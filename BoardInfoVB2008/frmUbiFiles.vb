Public Class frmUbiFiles

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.SaveSettings()
        MsgBox("Winner files location stored successfully.", MsgBoxStyle.Information, "Winner Files Location")

        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        FolderBrowserDialog1.SelectedPath = Trim(ubiWinFilesTxt.Text)
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            ubiWinFilesTxt.Text = Trim(FolderBrowserDialog1.SelectedPath)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub SaveSettings()
        Dim conStrinDatabaseStr As String
        Utils.SalvarSetting(appName, "UbiWinFileLocation", ubiWinFilesTxt.Text)
        'Utils.SalvarSetting(appName, "FirstDrawKeno", ubiWinFilesTxt.Text)

        conStrinDatabaseStr = dbNameTxt.Text & "|" & serverNameTxt.Text & "|" & userNameTxt.Text & "|" & passwordTxt.Text
        Utils.SalvarSettingConfiServerDB(appName, "conStringDatabase", conStrinDatabaseStr)


    End Sub

    Private Sub frmUbiFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GetSettings()
    End Sub

    Private Sub GetSettings()
        Dim conStrinDatabaseStr As String
        Dim substrings() As String
        Dim cont As Integer

        ubiWinFilesTxt.Text = Utils.GetSetting(appName, "UbiWinFileLocation", "").ToString()

        conStrinDatabaseStr = Utils.GetSettingConfigServerDB(appName, "conStringDatabase", "").ToString()

        cont = conStrinDatabaseStr.Length
        If cont <> 0 Then
            substrings = conStrinDatabaseStr.Split("|")
            dbNameTxt.Text = substrings(0)
            serverNameTxt.Text = substrings(1)
            userNameTxt.Text = substrings(2)
            passwordTxt.Text = substrings(3)
        Else
            dbNameTxt.Text = ""
            serverNameTxt.Text = ""
            userNameTxt.Text = ""
            passwordTxt.Text = ""

        End If




    End Sub



End Class