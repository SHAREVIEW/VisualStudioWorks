Public Class clsKurtlar
    Inherits clsAktifObjeler

    Private bmpKurtBasiK As Bitmap
    Private bmpKurtBasiG As Bitmap
    Private bmpKurtBasiD As Bitmap
    Private bmpKurtBasiB As Bitmap
    Private bmpKurtBasiYerkenK As Bitmap
    Private bmpKurtBasiYerkenG As Bitmap
    Private bmpKurtBasiYerkenD As Bitmap
    Private bmpKurtBasiYerkenB As Bitmap

    Public KurtBody() As clsKurtBody
    Public KurtBoyu As Integer = 4
    Public MantarYedi As Boolean = False
    Public IsComputer As Boolean = True
    Public IsDead As Boolean = False

    Sub New(ByVal x As Integer, ByVal y As Integer, ByVal BaslangicYonu As clsAktifObjeler.enYon, ByVal bIsComputer As Boolean)
        ' redim yapmamak i�in b�y�k de�erden ba�lat...
        ReDim KurtBody(150)
        Dim i As Integer
        Dim artimX As Integer = 0, artimY As Integer = 0
        'bilgisayar ya da insana g�re (IIF) kafa resimlerini y�kle...

        IsComputer = bIsComputer
        bmpKurtBasiK = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiK.gif")
        bmpKurtBasiG = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiG.gif")
        bmpKurtBasiD = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiD.gif")
        bmpKurtBasiB = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiB.gif")

        bmpKurtBasiYerkenK = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenK.gif")
        bmpKurtBasiYerkenG = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenG.gif")
        bmpKurtBasiYerkenD = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenD.gif")
        bmpKurtBasiYerkenB = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenB.gif")
        'bilgisayar ya da insana g�re body resimlerini y�kle...
        For i = 0 To KurtBoyu - 1
            KurtBody(i) = New clsKurtBody(IsComputer)
        Next
        ' kurdun kafas�n� verilen noktaya yerle�tir...
        Yon = BaslangicYonu
        Yer.X = x
        Yer.Y = y
        ' body b�l�mlerini kafan�n arkas�na yerle�tirmek i�in...
        Select Case Yon
            Case clsAktifObjeler.enYon.Dogu
                artimX = -1
            Case clsAktifObjeler.enYon.Guney
                artimY = -1
            Case clsAktifObjeler.enYon.Bati
                artimX = 1
            Case clsAktifObjeler.enYon.Kuzey
                artimY = 1
        End Select
        'body b�l�mlerinin koordinatlar�n� belirle...
        For i = 0 To KurtBoyu - 1
            x += artimX
            y += artimY
            KurtBody(i).Yer.X = x
            KurtBody(i).Yer.Y = y
        Next

    End Sub

    Sub Tasi(ByVal x As Integer, ByVal y As Integer, ByVal WinHandle As System.IntPtr, ByVal bMantarYedi As Boolean)
        Dim i As Integer
        ' son body par�as�n� sil...
        KurtBody(KurtBoyu - 1).Sil(WinHandle)
        ' body pozisyonlar�n� g�ncelle...
        For i = KurtBoyu - 1 To 1 Step -1
            KurtBody(i).Yer = KurtBody(i - 1).Yer
        Next
        'ilk body par�as�n� kafan�n yerine getir...
        KurtBody(0).Yer = Yer 'kafan�n koordainat�n� kendisinden bir �nceki par�aya ver...
        Yer = New Point(x, y) 'kafan�n yeni yerini belirle...
        KurtBody(0).Ciz(WinHandle) ' ilk body par�as�n� kafan�n �st�ne �iz...
        Me.Ciz(WinHandle, bMantarYedi) 'kafay� �iz..
    End Sub

    Sub Ye_ve_Tasi(ByVal x As Integer, ByVal y As Integer, ByVal WinHandle As System.IntPtr, ByVal bMantarYedi As Boolean)
        Dim i As Integer
        Try
            KurtBody(KurtBoyu) = New clsKurtBody(IsComputer)
        Catch
            ReDim Preserve KurtBody(KurtBoyu + 150)
            KurtBody(KurtBoyu) = New clsKurtBody(IsComputer)
        End Try
        'yeni body par�as�na son par�an�n koordinatlar�n� ver...
        KurtBody(KurtBoyu).Yer = KurtBody(KurtBoyu - 1).Yer
        ' body pozisyonlar�n� g�ncelle...
        For i = KurtBoyu - 1 To 1 Step -1
            KurtBody(i).Yer = KurtBody(i - 1).Yer
        Next
        KurtBody(0).Yer = Yer
        KurtBody(0).Ciz(WinHandle)
        KurtBoyu += 1
        ' kafa�n�n yerini g�ncelle...
        Yer = New Point(x, y)
        'mantar� temizle...
        MyBase.Sil(WinHandle)
        ' kafay� �iz...
        Me.Ciz(WinHandle, bMantarYedi)
    End Sub

    Public Shadows Sub Ciz(ByVal WinHandle As System.IntPtr, ByVal MantarYedi As Boolean)
        Dim i As Integer
        'Kafay� �iz..
        Select Case Yon
            Case clsAktifObjeler.enYon.Dogu
                MyBase.Ciz(IIf(MantarYedi, bmpKurtBasiYerkenD, bmpKurtBasiD), WinHandle)
            Case clsAktifObjeler.enYon.Guney
                MyBase.Ciz(IIf(MantarYedi, bmpKurtBasiYerkenG, bmpKurtBasiG), WinHandle)
            Case clsAktifObjeler.enYon.Bati
                MyBase.Ciz(IIf(MantarYedi, bmpKurtBasiYerkenB, bmpKurtBasiB), WinHandle)
            Case clsAktifObjeler.enYon.Kuzey
                MyBase.Ciz(IIf(MantarYedi, bmpKurtBasiYerkenK, bmpKurtBasiK), WinHandle)
        End Select
        'body yi �iz...
        For i = 0 To KurtBoyu - 1
            KurtBody(i).Ciz(WinHandle)
        Next
    End Sub

End Class
