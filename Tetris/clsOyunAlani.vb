Public Class clsOyunAlani

    Public Shared picOyunAlani As PictureBox
    Public Shared Backcolor As Color 'Shared, obje oluþturmadan bir sýnýftaki deðiþkenleri kullanmamýzý saðlar(static)
    Public Shared WinHandle As System.IntPtr

    Public Const Width As Integer = 16
    Public Const Height As Integer = 30
    Public Const Boy As Integer = 10

    Private Shared arrOyunAlani(Width, Height) As clsKare 'kare objelerinden oluþan iki boyutlu dizi...
    Private Shared arrBitOyunAlani(Height) As Integer 'yüksekliði arrOyunAlani ile ayný,geniþliði her integer ýn bitleri olacak...

    'bu iki sabit sayesinde her satýrýn kontrolü için 16 döngüden kurtuluyoruz...
    Private Const BitBos As Integer = &H0& '00000000 0000000
    Private Const BitDolu As Integer = &HFFFF& '11111111 1111111

    Public Shared Function KareDurdur(ByVal Kare As clsKare, ByVal x As Integer, ByVal y As Integer) As Boolean
        'arrBitOyunAlani na 1 leri yazýyoruz Or operatörü ile... 1 or 0 = 1 mantýðý ile...
        arrBitOyunAlani(y) = arrBitOyunAlani(y) Or (2 ^ x)
        'x ve y ler mantýk olarak ayný gitsin diye dizi tetris ekranýný karþýlayacak þekilde tanýmlanmadý...
        '30 satýr 16 sütun yerine,16 satýr 30 sütun
        arrOyunAlani(x, y) = Kare
    End Function

    Public Shared Function IsEmpty(ByVal x As Integer, ByVal y As Integer) As Boolean
        'arrOyunAlani de verilen x ve y deðerlerini kontrol ediyoruz...
        IsEmpty = True
        'kenarlara çarpma var mý?
        If (y < 0 Or y >= Height) Or (x < 0 Or x >= Width) Then
            IsEmpty = False
            'y inci satýrdaki x inci biti test et...
            'arrBitOyunAlani(y) -> y. satýrdaki 16 bit
            '2^x -> bitleri(1) kaydýrmak için. "00000000  01000000"
        ElseIf arrBitOyunAlani(y) And (2 ^ x) Then
            IsEmpty = False
        End If

    End Function

    Public Shared Function CizgiKontrol() As Integer
        Dim y, x As Integer
        Dim i As Integer
        CizgiKontrol = 0
        y = Height - 1 'y height e eþit olamaz...
        Do While y >= 0 'Aþaðýdan yukarýya tara...
            'boþ sýraya ulaþýnca döngüden çýk...
            If arrBitOyunAlani(y) = BitBos Then y = 0
            ' eðer sýranýn bütün bitleri '1' ise sayacý artýr ve üstteki sýralarý bir aþaðý taþý...
            If arrBitOyunAlani(y) = BitDolu Then
                CizgiKontrol += 1
                ' diðer satýrlarý aþaðý taþý
                ' eðer geçerli satýr ilk satýr deðilse...
                For i = y To 0 Step -1
                    If i > 0 Then
                        arrBitOyunAlani(i) = arrBitOyunAlani(i - 1)
                        For x = 0 To Width - 1
                            ' Copy the square
                            arrOyunAlani(x, i) = arrOyunAlani(x, i - 1)
                            ' yeri güncelle
                            Try
                                'boþ olan karelerin yeri olmadýðýndan kontrol ediyoruz...
                                'kareyi 1 aþaðý taþý...
                                With arrOyunAlani(x, i)
                                    .Yer = New Point(.Yer.X, _
                                    .Yer.Y + Boy)
                                End With
                            Catch
                            End Try
                        Next
                    Else
                        'eðer geçerli en üstteki satýr ise...
                        arrBitOyunAlani(i) = BitBos
                        For x = 0 To Width - 1
                            arrOyunAlani(x, i) = Nothing
                        Next
                    End If
                Next
            Else
                y -= 1
            End If
        Loop
    End Function

    Public Shared Function TekrarCiz() As Boolean
        Dim x, y As Integer
        'oyunalanýný temizle...
        picOyunAlani.Invalidate()
        Application.DoEvents()
        y = Height - 1
        Do While y >= 0 And arrBitOyunAlani(y) <> BitBos
            For x = 0 To Width - 1
                Try
                    arrOyunAlani(x, y).Goster(WinHandle)
                Catch ex As Exception
                End Try
            Next
            y -= 1
        Loop
    End Function

End Class
