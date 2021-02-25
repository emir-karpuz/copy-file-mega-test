Public Class frmCopyFile
    Dim rndNum As Integer = 0
    Dim dosyaUzantisi As String = String.Empty
    Dim EXEnewDosyaSayisi As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim files() As String = IO.Directory.GetFiles(".\EXEnew\")  'Dosyaların adları alınır
        Dim random As New Random
        rndNum = random.Next(1000, 9999)
        Dim EXEnewDosyaIndex As Integer = 1
        Try
            For Each file As String In files
                file = dosyaAdiBul(file) & "." & dosyaUzantisi
                If IO.File.Exists(file) Then
                    prgGuncelle(file, rndNum)
                Else
                    My.Computer.FileSystem.CopyFile(".\EXEnew\" & file, Application.StartupPath & "\" & file, overwrite:=True)
                    EXEnewDosyaIndex = txtNewFiles.GetLineFromCharIndex(txtNewFiles.Text.Length) + 1
                    txtNewFiles.Text += EXEnewDosyaIndex & ". Yeni Dosya Eklendi: " & file & vbCrLf
                End If
                EXEnewDosyaSayisi += 1
            Next
            lblResult.Text &= "İşlem Başarılı"
            lblNewFiles.Text &= EXEnewDosyaSayisi
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Hata")
        End Try

    End Sub

    Sub prgGuncelle(strPrgAdi, rnd)
        Try
            Dim exeOldFileName, currentFileName As String
            Dim EXEoldDosyaIndex As Integer = 1
            exeOldFileName = dosyaAdiBul(strPrgAdi) & "_" & gunHesapla() & "_" & rnd.ToString & "." & dosyaUzantisi
            My.Computer.FileSystem.RenameFile(strPrgAdi, exeOldFileName)
            My.Computer.FileSystem.MoveFile(Application.StartupPath & "\" & exeOldFileName, ".\EXEold\" & exeOldFileName)
            currentFileName = Application.StartupPath & "\" & strPrgAdi
            My.Computer.FileSystem.CopyFile(".\EXEnew\" & strPrgAdi, currentFileName, overwrite:=True)

            EXEoldDosyaIndex = txtOldFiles.GetLineFromCharIndex(txtOldFiles.Text.Length) + 1

            txtOldFiles.Text += EXEoldDosyaIndex & ". Eski Dosya Çıkarıldı: " & exeOldFileName & vbCrLf

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
            dosyaAdi = Strings.Left(dosyaIlkParca(2), dosyaIlkParca(2).Length - 4)  'deneme.txt -> deneme, dosyaIlkParca(2)'da tutuluyor
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
