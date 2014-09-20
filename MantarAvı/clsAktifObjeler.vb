Public Class clsAktifObjeler 'Oyun alanýnda yer alan Background haricindeki diðer tüm objelerin kullandýðý sýnýf...
    Public Const Image_Boy As Integer = 15
    Public Shared Image_Yol As String
    Protected BmpKaynagi As Bitmap
    Public Yon As enYon
    Public Yer As Point

    Public Enum enYon
        Kuzey = 1 : Dogu = 2 : Guney = 3 : Bati = 4
    End Enum

#Region "Kurucular"

    Sub New()
        'bu boþ constructor child sýnýflar için...
    End Sub

    Sub New(ByVal ImageAdi As String)
        BmpKaynagi = Yukle(ImageAdi)
    End Sub

    Sub New(ByVal ImageAdi As String, ByVal TransparanRenk As Color)
        Yukle(ImageAdi, TransparanRenk)
    End Sub

    Sub New(ByVal ImageAdi As String, ByVal Yerim As Point)
        BmpKaynagi = Yukle(ImageAdi)
        Yer = Yerim
    End Sub
    'Overload New fonksiyonunu kolaylaþtýrmak için Yukle kullanýldý...
    Function Yukle(ByVal ImageAdi As String) As Bitmap
        Try
            Yukle = Bitmap.FromFile(ImageAdi)
            Yukle.MakeTransparent(Color.FromArgb(255, 255, 255, 255))
        Catch
            MessageBox.Show("Dosya buluanamadý. Lütfen " & ImageAdi & " dosyasýnýn yolunun doðru olduðundan emin olun.", _
            "Mantar Avý", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Yukle = Nothing
        End Try
    End Function

    Function Yukle(ByVal ImageAdi As String, ByVal TransparanRenk As Color) As Bitmap 'clsDal kullanýyo...
        Try
            Yukle = Bitmap.FromFile(ImageAdi)
            Yukle.MakeTransparent(TransparanRenk)
        Catch
            MessageBox.Show("Dosya buluanamadý. Lütfen " & ImageAdi & " dosyasýnýn yolunu doðru olduðundan emin olun.", _
            "Mantar Avý", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Yukle = Nothing
        End Try
    End Function

#End Region

#Region "Obje Çizme ve Silme Metodlarý"

    Sub Ciz(ByVal WinHandle As System.IntPtr)
        Dim G As Graphics
        G = Graphics.FromHwnd(WinHandle)
        G.DrawImageUnscaled(BmpKaynagi, Yer.X * Image_Boy, Yer.Y * Image_Boy)
        G.Dispose()
    End Sub

    Sub Ciz(ByVal Image As Bitmap, ByVal WinHandle As System.IntPtr)
        Dim G As Graphics
        G = Graphics.FromHwnd(WinHandle)
        G.DrawImageUnscaled(Image, Yer.X * Image_Boy, Yer.Y * Image_Boy)
        G.Dispose()
    End Sub

    Sub Sil(ByVal WinHandle As System.IntPtr)
        Dim G As Graphics
        G = Graphics.FromHwnd(WinHandle)
        G.DrawImage(clsOyunMotoru.BackgroundImage, New Rectangle(Yer.X * Image_Boy, Yer.Y * Image_Boy, Image_Boy, Image_Boy), _
        New Rectangle(Yer.X * Image_Boy, Yer.Y * Image_Boy, Image_Boy, Image_Boy), GraphicsUnit.Pixel)
        G.Dispose()
    End Sub

#End Region

End Class
