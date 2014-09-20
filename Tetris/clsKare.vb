Public Class clsKare
    Public Yer As Point
    Public Boy As Size
    Public Forecolor As Color
    Public Backcolor As Color

    Public Sub Goster(ByVal WinHandle As System.IntPtr) 'IntPtr,makineye g�re de�i�ir ve pointer tutar...
        Dim G As Graphics
        Dim Kare As Rectangle
        Dim Yol As Drawing2D.GraphicsPath
        Dim Firca As Drawing2D.PathGradientBrush
        Dim Renk() As Color

        G = Graphics.FromHwnd(WinHandle)
        Yol = New Drawing2D.GraphicsPath
        Kare = New Rectangle(Yer.X, Yer.Y, Boy.Width, Boy.Height)
        Yol.AddRectangle(Kare)

        Firca = New Drawing2D.PathGradientBrush(Yol)
        Firca.CenterColor = Forecolor
        Renk = New Color() {Backcolor} 'Diziye de�er atama... Redim kullanmaya gerek olmuyo...
        Firca.SurroundColors = Renk

        G.FillPath(Firca, Yol)
    End Sub

    Public Sub Gizle(ByVal WinHandle As System.IntPtr)
        Dim G As Graphics
        Dim Kare As Rectangle

        G = Graphics.FromHwnd(WinHandle)
        Kare = New Rectangle(Yer.X, Yer.Y, Boy.Width, Boy.Height)
        G.FillRectangle(New SolidBrush(clsOyunAlani.Backcolor), Kare)
    End Sub
    'S�n�ftan obje olu�turuldu�u anda yap�lmas� istenenler buraya yaz�l�r...
    Public Sub New(ByVal BaslangicBoyu As Size, ByVal BaslangicForecolor As Color, ByVal BaslangicBackColor As Color)
        Boy = BaslangicBoyu
        Forecolor = BaslangicForecolor
        Backcolor = BaslangicBackColor
    End Sub
End Class
