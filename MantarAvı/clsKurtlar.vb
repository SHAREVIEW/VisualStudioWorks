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
        ' redim yapmamak için büyük deðerden baþlat...
        ReDim KurtBody(150)
        Dim i As Integer
        Dim artimX As Integer = 0, artimY As Integer = 0
        'bilgisayar ya da insana göre (IIF) kafa resimlerini yükle...

        IsComputer = bIsComputer
        bmpKurtBasiK = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiK.gif")
        bmpKurtBasiG = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiG.gif")
        bmpKurtBasiD = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiD.gif")
        bmpKurtBasiB = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiB.gif")

        bmpKurtBasiYerkenK = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenK.gif")
        bmpKurtBasiYerkenG = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenG.gif")
        bmpKurtBasiYerkenD = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenD.gif")
        bmpKurtBasiYerkenB = Yukle(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBasiYerkenB.gif")
        'bilgisayar ya da insana göre body resimlerini yükle...
        For i = 0 To KurtBoyu - 1
            KurtBody(i) = New clsKurtBody(IsComputer)
        Next
        ' kurdun kafasýný verilen noktaya yerleþtir...
        Yon = BaslangicYonu
        Yer.X = x
        Yer.Y = y
        ' body bölümlerini kafanýn arkasýna yerleþtirmek için...
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
        'body bölümlerinin koordinatlarýný belirle...
        For i = 0 To KurtBoyu - 1
            x += artimX
            y += artimY
            KurtBody(i).Yer.X = x
            KurtBody(i).Yer.Y = y
        Next

    End Sub

    Sub Tasi(ByVal x As Integer, ByVal y As Integer, ByVal WinHandle As System.IntPtr, ByVal bMantarYedi As Boolean)
        Dim i As Integer
        ' son body parçasýný sil...
        KurtBody(KurtBoyu - 1).Sil(WinHandle)
        ' body pozisyonlarýný güncelle...
        For i = KurtBoyu - 1 To 1 Step -1
            KurtBody(i).Yer = KurtBody(i - 1).Yer
        Next
        'ilk body parçasýný kafanýn yerine getir...
        KurtBody(0).Yer = Yer 'kafanýn koordainatýný kendisinden bir önceki parçaya ver...
        Yer = New Point(x, y) 'kafanýn yeni yerini belirle...
        KurtBody(0).Ciz(WinHandle) ' ilk body parçasýný kafanýn üstüne çiz...
        Me.Ciz(WinHandle, bMantarYedi) 'kafayý çiz..
    End Sub

    Sub Ye_ve_Tasi(ByVal x As Integer, ByVal y As Integer, ByVal WinHandle As System.IntPtr, ByVal bMantarYedi As Boolean)
        Dim i As Integer
        Try
            KurtBody(KurtBoyu) = New clsKurtBody(IsComputer)
        Catch
            ReDim Preserve KurtBody(KurtBoyu + 150)
            KurtBody(KurtBoyu) = New clsKurtBody(IsComputer)
        End Try
        'yeni body parçasýna son parçanýn koordinatlarýný ver...
        KurtBody(KurtBoyu).Yer = KurtBody(KurtBoyu - 1).Yer
        ' body pozisyonlarýný güncelle...
        For i = KurtBoyu - 1 To 1 Step -1
            KurtBody(i).Yer = KurtBody(i - 1).Yer
        Next
        KurtBody(0).Yer = Yer
        KurtBody(0).Ciz(WinHandle)
        KurtBoyu += 1
        ' kafaýnýn yerini güncelle...
        Yer = New Point(x, y)
        'mantarý temizle...
        MyBase.Sil(WinHandle)
        ' kafayý çiz...
        Me.Ciz(WinHandle, bMantarYedi)
    End Sub

    Public Shadows Sub Ciz(ByVal WinHandle As System.IntPtr, ByVal MantarYedi As Boolean)
        Dim i As Integer
        'Kafayý çiz..
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
        'body yi çiz...
        For i = 0 To KurtBoyu - 1
            KurtBody(i).Ciz(WinHandle)
        Next
    End Sub

End Class
