Public Class clsBlok
    Public Boy As Integer = 10
    Private Backcolor As Color
    Private Forecolor As Color
    Public Kare1, Kare2, Kare3, Kare4 As clsKare

    Public Enum enDonmeDurumu
        Kuzey = 1
        Dogu = 2
        Guney = 3
        Bati = 4
    End Enum

    Public Enum enBlokTipi
        Tanimsiz = 0
        Kare = 1
        Cizgi = 2
        J = 3
        L = 4
        T = 5
        Z = 6
        S = 7
    End Enum

    Public DonmeDurumu As enDonmeDurumu = enDonmeDurumu.Kuzey
    Public BlokTipi As enBlokTipi

    Private Backcolors As Color() = {Nothing, Color.Red, Color.Blue, Color.Red, Color.Yellow, _
Color.Green, Color.White, Color.Yellow}

    Private ForeColors As Color() = {Nothing, Color.Purple, Color.LightBlue, Color.Yellow, Color.Red, _
Color.LightGreen, Color.Black, Color.White}

    Public Sub New(ByVal Yer As Point, Optional ByVal YeniBlokTipi As enBlokTipi = enBlokTipi.Tanimsiz)
        If YeniBlokTipi = enBlokTipi.Tanimsiz Then
            Randomize()
            BlokTipi = Int(Rnd(7) * 7) + 1
        Else
            BlokTipi = YeniBlokTipi
        End If

        Kare1 = New clsKare(New Size(Boy, Boy), ForeColors(BlokTipi), Backcolors(BlokTipi))
        Kare2 = New clsKare(New Size(Boy, Boy), ForeColors(BlokTipi), Backcolors(BlokTipi))
        Kare3 = New clsKare(New Size(Boy, Boy), ForeColors(BlokTipi), Backcolors(BlokTipi))
        Kare4 = New clsKare(New Size(Boy, Boy), ForeColors(BlokTipi), Backcolors(BlokTipi))

        Select Case BlokTipi
            Case enBlokTipi.Kare
                Kare1.Yer = New Point(Yer.X, Yer.Y)
                Kare2.Yer = New Point(Yer.X + Boy, Yer.Y)
                Kare3.Yer = New Point(Yer.X, Yer.Y + Boy)
                Kare4.Yer = New Point(Yer.X + Boy, Yer.Y + Boy)
            Case enBlokTipi.Cizgi
                Kare1.Yer = New Point(Yer.X, Yer.Y)
                Kare2.Yer = New Point(Yer.X, Yer.Y + Boy)
                Kare3.Yer = New Point(Yer.X, Yer.Y + 2 * Boy)
                Kare4.Yer = New Point(Yer.X, Yer.Y + 3 * Boy)
            Case enBlokTipi.J
                Kare1.Yer = New Point(Yer.X + Boy, Yer.Y)
                Kare2.Yer = New Point(Yer.X + Boy, Yer.Y + Boy)
                Kare3.Yer = New Point(Yer.X + Boy, Yer.Y + 2 * Boy)
                Kare4.Yer = New Point(Yer.X, Yer.Y + 2 * Boy)
            Case enBlokTipi.L
                Kare1.Yer = New Point(Yer.X, Yer.Y)
                Kare2.Yer = New Point(Yer.X, Yer.Y + Boy)
                Kare3.Yer = New Point(Yer.X, Yer.Y + 2 * Boy)
                Kare4.Yer = New Point(Yer.X + Boy, Yer.Y + 2 * Boy)
            Case enBlokTipi.T
                Kare1.Yer = New Point(Yer.X, Yer.Y)
                Kare2.Yer = New Point(Yer.X + Boy, Yer.Y)
                Kare3.Yer = New Point(Yer.X + 2 * Boy, Yer.Y)
                Kare4.Yer = New Point(Yer.X + Boy, Yer.Y + Boy)
            Case enBlokTipi.Z
                Kare1.Yer = New Point(Yer.X, Yer.Y)
                Kare2.Yer = New Point(Yer.X + Boy, Yer.Y)
                Kare3.Yer = New Point(Yer.X + Boy, Yer.Y + Boy)
                Kare4.Yer = New Point(Yer.X + 2 * Boy, Yer.Y + Boy)
            Case enBlokTipi.S
                Kare1.Yer = New Point(Yer.X, Yer.Y + Boy)
                Kare2.Yer = New Point(Yer.X + Boy, Yer.Y + Boy)
                Kare3.Yer = New Point(Yer.X + Boy, Yer.Y)
                Kare4.Yer = New Point(Yer.X + 2 * Boy, Yer.Y)
        End Select
    End Sub

    Public Function Asagi() As Boolean
        Asagi = True
        'eðer geçerli bloðun altýnda engel yoksa
        If clsOyunAlani.IsEmpty(Kare1.Yer.X / Boy, Kare1.Yer.Y / Boy + 1) _
        And clsOyunAlani.IsEmpty(Kare2.Yer.X / Boy, Kare2.Yer.Y / Boy + 1) _
        And clsOyunAlani.IsEmpty(Kare3.Yer.X / Boy, Kare3.Yer.Y / Boy + 1) _
        And clsOyunAlani.IsEmpty(Kare4.Yer.X / Boy, Kare4.Yer.Y / Boy + 1) _
        Then
            'geçerli bloðu sakla...
            Gizle(clsOyunAlani.WinHandle)
            've bloðu güncelle...
            Kare1.Yer = New Point(Kare1.Yer.X, Kare1.Yer.Y + Boy)
            Kare2.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + Boy)
            Kare3.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
            Kare4.Yer = New Point(Kare4.Yer.X, Kare4.Yer.Y + Boy)
            'bloðu tekrar göster...
            Goster(clsOyunAlani.WinHandle)
        Else
            'eðer bloðun altýnda engel varsa durdur ve diziye yerleþtir... 
            Asagi = False
            clsOyunAlani.KareDurdur(Kare1, Kare1.Yer.X / Boy, Kare1.Yer.Y / Boy)
            clsOyunAlani.KareDurdur(Kare2, Kare2.Yer.X / Boy, Kare2.Yer.Y / Boy)
            clsOyunAlani.KareDurdur(Kare3, Kare3.Yer.X / Boy, Kare3.Yer.Y / Boy)
            clsOyunAlani.KareDurdur(Kare4, Kare4.Yer.X / Boy, Kare4.Yer.Y / Boy)
        End If
    End Function
    Public Function Sag() As Boolean
        Sag = True
        If clsOyunAlani.IsEmpty(Kare1.Yer.X / Boy + 1, Kare1.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare2.Yer.X / Boy + 1, Kare2.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare3.Yer.X / Boy + 1, Kare3.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare4.Yer.X / Boy + 1, Kare4.Yer.Y / Boy) _
        Then
            Gizle(clsOyunAlani.WinHandle)
            Kare1.Yer = New Point(Kare1.Yer.X + Boy, Kare1.Yer.Y)
            Kare2.Yer = New Point(Kare2.Yer.X + Boy, Kare2.Yer.Y)
            Kare3.Yer = New Point(Kare3.Yer.X + Boy, Kare3.Yer.Y)
            Kare4.Yer = New Point(Kare4.Yer.X + Boy, Kare4.Yer.Y)
            Goster(clsOyunAlani.WinHandle)
        Else
            Sag = False
        End If
    End Function

    Public Function Sol() As Boolean
        Sol = True
        If clsOyunAlani.IsEmpty(Kare1.Yer.X / Boy - 1, Kare1.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare2.Yer.X / Boy - 1, Kare2.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare3.Yer.X / Boy - 1, Kare3.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare4.Yer.X / Boy - 1, Kare4.Yer.Y / Boy) _
        Then
            Gizle(clsOyunAlani.WinHandle)
            Kare1.Yer = New Point(Kare1.Yer.X - Boy, Kare1.Yer.Y)
            Kare2.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
            Kare3.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y)
            Kare4.Yer = New Point(Kare4.Yer.X - Boy, Kare4.Yer.Y)
            Goster(clsOyunAlani.WinHandle)
        Else
            Sol = False
        End If
    End Function

    Public Function Top() As Integer
        Top = Math.Min(Kare1.Yer.Y, Math.Min(Kare2.Yer.Y, Math.Min(Kare3.Yer.Y, Kare4.Yer.Y)))
    End Function

    Public Sub Dondur()
        Dim EskiYer1 As Point = Kare1.Yer
        Dim EskiYer2 As Point = Kare2.Yer
        Dim EskiYer3 As Point = Kare3.Yer
        Dim EskiYer4 As Point = Kare4.Yer
        Dim EskiDonmedurumu As enDonmeDurumu = DonmeDurumu 'ilk olarak kuzey olarak belirledik...
        Gizle(clsOyunAlani.WinHandle)
        ' Bloðu döndür
        Select Case BlokTipi
            Case enBlokTipi.Kare

            Case enBlokTipi.Cizgi
                Select Case DonmeDurumu
                    Case enDonmeDurumu.Kuzey
                        DonmeDurumu = enDonmeDurumu.Dogu
                        Kare1.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
                        Kare3.Yer = New Point(Kare2.Yer.X + Boy, Kare2.Yer.Y)
                        Kare4.Yer = New Point(Kare2.Yer.X + 2 * Boy, Kare2.Yer.Y)
                    Case enDonmeDurumu.Dogu
                        DonmeDurumu = enDonmeDurumu.Kuzey
                        Kare1.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y - Boy)
                        Kare3.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + 2 * Boy)
                End Select

            Case enBlokTipi.J
                Select Case DonmeDurumu
                    Case enDonmeDurumu.Kuzey
                        DonmeDurumu = enDonmeDurumu.Dogu
                        Kare1.Yer = New Point(Kare3.Yer.X + 2 * Boy, Kare3.Yer.Y)
                        Kare2.Yer = New Point(Kare3.Yer.X + Boy, Kare3.Yer.Y)
                        Kare4.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y - Boy)
                    Case enDonmeDurumu.Dogu
                        DonmeDurumu = enDonmeDurumu.Guney
                        Kare1.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + 2 * Boy)
                        Kare2.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare3.Yer.X + Boy, Kare3.Yer.Y)
                    Case enDonmeDurumu.Guney
                        DonmeDurumu = enDonmeDurumu.Bati
                        Kare1.Yer = New Point(Kare3.Yer.X - 2 * Boy, Kare3.Yer.Y)
                        Kare2.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y)
                        Kare4.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
                    Case enDonmeDurumu.Bati
                        DonmeDurumu = enDonmeDurumu.Kuzey
                        Kare1.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y - 2 * Boy)
                        Kare2.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y - Boy)
                        Kare4.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y)
                End Select

            Case enBlokTipi.L
                Select Case DonmeDurumu
                    Case enDonmeDurumu.Kuzey
                        DonmeDurumu = enDonmeDurumu.Dogu
                        Kare1.Yer = New Point(Kare3.Yer.X + 2 * Boy, Kare3.Yer.Y)
                        Kare2.Yer = New Point(Kare3.Yer.X + Boy, Kare3.Yer.Y)
                        Kare4.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
                    Case enDonmeDurumu.Dogu
                        DonmeDurumu = enDonmeDurumu.Guney
                        Kare1.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + 2 * Boy)
                        Kare2.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y)
                    Case enDonmeDurumu.Guney
                        DonmeDurumu = enDonmeDurumu.Bati
                        Kare1.Yer = New Point(Kare3.Yer.X - 2 * Boy, Kare3.Yer.Y)
                        Kare2.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y)
                        Kare4.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y - Boy)
                    Case enDonmeDurumu.Bati
                        DonmeDurumu = enDonmeDurumu.Kuzey
                        Kare1.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y - 2 * Boy)
                        Kare2.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y - Boy)
                        Kare4.Yer = New Point(Kare3.Yer.X + Boy, Kare3.Yer.Y)
                End Select

            Case enBlokTipi.T
                Select Case DonmeDurumu
                    Case enDonmeDurumu.Kuzey
                        DonmeDurumu = enDonmeDurumu.Dogu
                        Kare1.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y - Boy)
                        Kare3.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
                    Case enDonmeDurumu.Dogu
                        DonmeDurumu = enDonmeDurumu.Guney
                        Kare1.Yer = New Point(Kare2.Yer.X + Boy, Kare2.Yer.Y)
                        Kare3.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
                        Kare4.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y - Boy)
                    Case enDonmeDurumu.Guney
                        DonmeDurumu = enDonmeDurumu.Bati
                        Kare1.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + Boy)
                        Kare3.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y - Boy)
                        Kare4.Yer = New Point(Kare2.Yer.X + Boy, Kare2.Yer.Y)
                    Case enDonmeDurumu.Bati
                        DonmeDurumu = enDonmeDurumu.Kuzey
                        Kare1.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
                        Kare3.Yer = New Point(Kare2.Yer.X + Boy, Kare2.Yer.Y)
                        Kare4.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + Boy)
                End Select

            Case enBlokTipi.Z
                Select Case DonmeDurumu
                    Case enDonmeDurumu.Kuzey
                        DonmeDurumu = enDonmeDurumu.Dogu
                        Kare1.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y - Boy)
                        Kare3.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
                    Case enDonmeDurumu.Dogu
                        DonmeDurumu = enDonmeDurumu.Kuzey
                        Kare1.Yer = New Point(Kare2.Yer.X - Boy, Kare2.Yer.Y)
                        Kare3.Yer = New Point(Kare2.Yer.X + Boy, Kare2.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare2.Yer.X, Kare2.Yer.Y + Boy)
                End Select

            Case enBlokTipi.S
                Select Case DonmeDurumu
                    Case enDonmeDurumu.Kuzey
                        DonmeDurumu = enDonmeDurumu.Dogu
                        Kare1.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y - Boy)
                        Kare2.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y)
                        Kare4.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
                    Case enDonmeDurumu.Dogu
                        DonmeDurumu = enDonmeDurumu.Kuzey
                        Kare1.Yer = New Point(Kare3.Yer.X - Boy, Kare3.Yer.Y + Boy)
                        Kare2.Yer = New Point(Kare3.Yer.X, Kare3.Yer.Y + Boy)
                        Kare4.Yer = New Point(Kare3.Yer.X + Boy, Kare3.Yer.Y)
                End Select
        End Select
        ' Dödürdükten sonra bloðun diðer karelerle çarðýþmasýný kontrol et...
        ' eðer çarpýþýyosa eski yere gel...
        If Not (clsOyunAlani.IsEmpty(Kare1.Yer.X / Boy, Kare1.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare2.Yer.X / Boy, Kare2.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare3.Yer.X / Boy, Kare3.Yer.Y / Boy) _
        And clsOyunAlani.IsEmpty(Kare4.Yer.X / Boy, Kare4.Yer.Y / Boy)) Then
            DonmeDurumu = EskiDonmedurumu
            Kare1.Yer = EskiYer1
            Kare2.Yer = EskiYer2
            Kare3.Yer = EskiYer3
            Kare4.Yer = EskiYer4
        End If
        Goster(clsOyunAlani.WinHandle)
    End Sub

    Public Sub Goster(ByVal WinHandle As System.IntPtr)
        Kare1.Goster(WinHandle)
        Kare2.Goster(WinHandle)
        Kare3.Goster(WinHandle)
        Kare4.Goster(WinHandle)
    End Sub

    Public Sub Gizle(ByVal WinHandle As System.IntPtr)
        Kare1.Gizle(WinHandle)
        Kare2.Gizle(WinHandle)
        Kare3.Gizle(WinHandle)
        Kare4.Gizle(WinHandle)
    End Sub
End Class
