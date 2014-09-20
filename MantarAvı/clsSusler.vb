Public Class clsSusler
    Inherits clsAktifObjeler

    Private bmpSusBas As Bitmap
    Private bmpSusOrta() As Bitmap
    Private bmpSusSon As Bitmap
    Public Boy As Integer

    Sub New(ByVal SusYonu As enYon, ByVal SusBoyu As Integer)
        ReDim bmpSusOrta(SusBoyu - 3) 'u�taki resmleri ��kar,birde 0 indisi i�in 1 ��kar...
        Dim i As Integer
        Dim OnEk As String

        Boy = SusBoyu
        OnEk = "Yat"
        Yon = clsAktifObjeler.enYon.Dogu

        If SusYonu = clsAktifObjeler.enYon.Kuzey Then
            OnEk = "Dik"
            Yon = clsAktifObjeler.enYon.Kuzey
        End If

        bmpSusBas = Yukle(Image_Yol & "resimler\" & OnEk & "SusBas.gif", Color.FromArgb(255, 255, 255, 255))
        For i = 0 To SusBoyu - 3
            bmpSusOrta(i) = Yukle(Image_Yol & "resimler\" & OnEk & "SusOrta.gif", Color.FromArgb(255, 255, 255, 255))
        Next
        bmpSusSon = Yukle(Image_Yol & "resimler\" & OnEk & "SusSon.gif", Color.FromArgb(255, 255, 255, 255))
    End Sub

    'shadows base s�n�fa daha esnek bir �ekilde eri�memizi sa�lar...
    'e�er shadows kullanmasayd�k iki farkl� Ciz metodu olacakt�...
    'overridable ve overrides kullanmaktan kurtar�yo...
    Shadows Sub Ciz(ByVal winHandle As System.IntPtr, ByVal x As Integer, ByVal y As Integer)
        Dim i As Integer

        Yer = New Point(x, y)

        MyBase.Ciz(bmpSusBas, winHandle)

        If Yon = clsAktifObjeler.enYon.Kuzey Or Yon = clsAktifObjeler.enYon.Guney Then
            ' dikey dal...
            For i = 0 To Boy - 3
                y += 1
                Yer = New Point(x, y)
                MyBase.Ciz(bmpSusOrta(i), winHandle)
            Next
            y += 1
        Else
            ' yatay dal...
            For i = 0 To Boy - 3
                x += 1
                Yer = New Point(x, y)
                MyBase.Ciz(bmpSusOrta(i), winHandle)
            Next
            x += 1
        End If

        Yer = New Point(x, y)
        MyBase.Ciz(bmpSusSon, winHandle)
    End Sub

End Class

