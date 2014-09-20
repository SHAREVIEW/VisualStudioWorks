Public Class clsOyunAlani

    Public Shared picOyunAlani As PictureBox
    Public Shared Backcolor As Color 'Shared, obje olu�turmadan bir s�n�ftaki de�i�kenleri kullanmam�z� sa�lar(static)
    Public Shared WinHandle As System.IntPtr

    Public Const Width As Integer = 16
    Public Const Height As Integer = 30
    Public Const Boy As Integer = 10

    Private Shared arrOyunAlani(Width, Height) As clsKare 'kare objelerinden olu�an iki boyutlu dizi...
    Private Shared arrBitOyunAlani(Height) As Integer 'y�ksekli�i arrOyunAlani ile ayn�,geni�li�i her integer �n bitleri olacak...

    'bu iki sabit sayesinde her sat�r�n kontrol� i�in 16 d�ng�den kurtuluyoruz...
    Private Const BitBos As Integer = &H0& '00000000 0000000
    Private Const BitDolu As Integer = &HFFFF& '11111111 1111111

    Public Shared Function KareDurdur(ByVal Kare As clsKare, ByVal x As Integer, ByVal y As Integer) As Boolean
        'arrBitOyunAlani na 1 leri yaz�yoruz Or operat�r� ile... 1 or 0 = 1 mant��� ile...
        arrBitOyunAlani(y) = arrBitOyunAlani(y) Or (2 ^ x)
        'x ve y ler mant�k olarak ayn� gitsin diye dizi tetris ekran�n� kar��layacak �ekilde tan�mlanmad�...
        '30 sat�r 16 s�tun yerine,16 sat�r 30 s�tun
        arrOyunAlani(x, y) = Kare
    End Function

    Public Shared Function IsEmpty(ByVal x As Integer, ByVal y As Integer) As Boolean
        'arrOyunAlani de verilen x ve y de�erlerini kontrol ediyoruz...
        IsEmpty = True
        'kenarlara �arpma var m�?
        If (y < 0 Or y >= Height) Or (x < 0 Or x >= Width) Then
            IsEmpty = False
            'y inci sat�rdaki x inci biti test et...
            'arrBitOyunAlani(y) -> y. sat�rdaki 16 bit
            '2^x -> bitleri(1) kayd�rmak i�in. "00000000  01000000"
        ElseIf arrBitOyunAlani(y) And (2 ^ x) Then
            IsEmpty = False
        End If

    End Function

    Public Shared Function CizgiKontrol() As Integer
        Dim y, x As Integer
        Dim i As Integer
        CizgiKontrol = 0
        y = Height - 1 'y height e e�it olamaz...
        Do While y >= 0 'A�a��dan yukar�ya tara...
            'bo� s�raya ula��nca d�ng�den ��k...
            If arrBitOyunAlani(y) = BitBos Then y = 0
            ' e�er s�ran�n b�t�n bitleri '1' ise sayac� art�r ve �stteki s�ralar� bir a�a�� ta��...
            If arrBitOyunAlani(y) = BitDolu Then
                CizgiKontrol += 1
                ' di�er sat�rlar� a�a�� ta��
                ' e�er ge�erli sat�r ilk sat�r de�ilse...
                For i = y To 0 Step -1
                    If i > 0 Then
                        arrBitOyunAlani(i) = arrBitOyunAlani(i - 1)
                        For x = 0 To Width - 1
                            ' Copy the square
                            arrOyunAlani(x, i) = arrOyunAlani(x, i - 1)
                            ' yeri g�ncelle
                            Try
                                'bo� olan karelerin yeri olmad���ndan kontrol ediyoruz...
                                'kareyi 1 a�a�� ta��...
                                With arrOyunAlani(x, i)
                                    .Yer = New Point(.Yer.X, _
                                    .Yer.Y + Boy)
                                End With
                            Catch
                            End Try
                        Next
                    Else
                        'e�er ge�erli en �stteki sat�r ise...
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
        'oyunalan�n� temizle...
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
