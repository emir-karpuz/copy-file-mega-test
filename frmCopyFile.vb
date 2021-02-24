Imports Microsoft.VisualBasic.Strings
'!-- MEGA TEST projesi ver:1.2 ------------------

Public Class frmCopyFile
    Dim rndNum As Integer = 0
    Dim dosyaUzantisi As String = String.Empty
    Dim toplamDosyaSayisi As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim files() As String = IO.Directory.GetFiles(".\EXEnew\")  'Dosyaların adları alınır
        Dim random As New Random
        rndNum = random.Next(1000, 9999)
        Try
            For Each file As String In files
                file = dosyaAdiBul(file) & "." & dosyaUzantisi
                If IO.File.Exists(file) Then
                    prgGuncelle(file, rndNum)
                Else
                    My.Computer.FileSystem.CopyFile(".\EXEnew\" & file, Application.StartupPath & "\" & file, overwrite:=True)
                    txtNewFiles.Text += "Yeni Dosya Eklendi: " & file & vbCrLf
                End If
                toplamDosyaSayisi += 1
            Next
            lblResult.Text &= "İşlem Başarılı"
            lblNewFiles.Text &= toplamDosyaSayisi
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Hata")
        End Try



    End Sub

    Sub prgGuncelle(strPrgAdi, rnd)
        Try
            Dim exeOldFileName, currentFileName As String

            exeOldFileName = dosyaAdiBul(strPrgAdi) & "_" & gunHesapla() & "_" & rnd.ToString & "." & dosyaUzantisi
            My.Computer.FileSystem.RenameFile(strPrgAdi, exeOldFileName)
            My.Computer.FileSystem.MoveFile(Application.StartupPath & "\" & exeOldFileName, ".\EXEold\" & exeOldFileName)
            currentFileName = Application.StartupPath & "\" & strPrgAdi
            My.Computer.FileSystem.CopyFile(".\EXEnew\" & strPrgAdi, currentFileName, overwrite:=True)

            txtOldFiles.Text += "Eski Dosya Çıkarıldı: " & exeOldFileName & vbCrLf
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Hata")
        End Try
    End Sub

    Function dosyaAdiBul(dosyaAdi As String) As String
        Dim dosyaIlkParca As String() = Nothing
        Dim dosyaSonParca As String() = Nothing
        dosyaUzantisi = Strings.Right(dosyaAdi, 3)

        If dosyaAdi.Contains("\EXE") Then
            dosyaIlkParca = Split(dosyaAdi, "\")
            dosyaSonParca = Split(dosyaIlkParca(2), ".")
            dosyaAdi = dosyaSonParca(0)
        Else
            dosyaAdi = Strings.Left(dosyaAdi, InStr(dosyaAdi, ".") - 1)
        End If
        Return dosyaAdi
    End Function

    Function gunHesapla() As String
        Dim gun As String = DateTime.Today.ToString("yyMMdd")
        Return gun
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class
