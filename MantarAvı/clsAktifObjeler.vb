Public Class clsAktifObjeler 'Oyun alan�nda yer alan Background haricindeki di�er t�m objelerin kulland��� s�n�f...
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
        'bu bo� constructor child s�n�flar i�in...
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
    'Overload New fonksiyonunu kolayla�t�rmak i�in Yukle kullan�ld�...
    Function Yukle(ByVal ImageAdi As String) As Bitmap
        Try
            Yukle = Bitmap.FromFile(ImageAdi)
            Yukle.MakeTransparent(Color.FromArgb(255, 255, 255, 255))
        Catch
            MessageBox.Show("Dosya buluanamad�. L�tfen " & ImageAdi & " dosyas�n�n yolunun do�ru oldu�undan emin olun.", _
            "Mantar Av�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Yukle = Nothing
        End Try
    End Function

    Function Yukle(ByVal ImageAdi As String, ByVal TransparanRenk As Color) As Bitmap 'clsDal kullan�yo...
        Try
            Yukle = Bitmap.FromFile(ImageAdi)
            Yukle.MakeTransparent(TransparanRenk)
        Catch
            MessageBox.Show("Dosya buluanamad�. L�tfen " & ImageAdi & " dosyas�n�n yolunu do�ru oldu�undan emin olun.", _
            "Mantar Av�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Yukle = Nothing
        End Try
    End Function

#End Region

#Region "Obje �izme ve Silme Metodlar�"

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
