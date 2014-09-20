Public Class clsKurtlarAI
    Inherits clsOyunMotoru

    Private RandomYuzde As Integer = 5

    Function SecKurtYonu(ByVal GecerliYer As Point, ByVal GecerliYon As clsAktifObjeler.enYon) As clsAktifObjeler.enYon
        Dim EniyiObje As enOyunObjeleri
        Dim SonrakiObje As enOyunObjeleri

        'bir sonraki objeyi al...
        Select Case GecerliYon
            Case clsAktifObjeler.enYon.Dogu
                SonrakiObje = OyunAlani(GecerliYer.X + 1, GecerliYer.Y)
            Case clsAktifObjeler.enYon.Bati
                SonrakiObje = OyunAlani(GecerliYer.X - 1, GecerliYer.Y)
            Case clsAktifObjeler.enYon.Guney
                SonrakiObje = OyunAlani(GecerliYer.X, GecerliYer.Y + 1)
            Case clsAktifObjeler.enYon.Kuzey
                SonrakiObje = OyunAlani(GecerliYer.X, GecerliYer.Y - 1)
        End Select
        'en d���k de�erlikli obeyi se�.. mantar veya bos...
        EniyiObje = Math.Min(Math.Min(Math.Min(OyunAlani(GecerliYer.X + 1, GecerliYer.Y), OyunAlani(GecerliYer.X - 1, GecerliYer.Y)), _
                                                OyunAlani(GecerliYer.X, GecerliYer.Y + 1)), _
                                                OyunAlani(GecerliYer.X, GecerliYer.Y - 1))
        'e�er ge�erli y�n en iyi y�ne e�itse y�n�n� koru...
        If SonrakiObje = EniyiObje Then
            SecKurtYonu = GecerliYon
        Else
            ' en iyi objenin old�u y�n� se�...
            Select Case EniyiObje
                Case OyunAlani(GecerliYer.X + 1, GecerliYer.Y)
                    SecKurtYonu = clsAktifObjeler.enYon.Dogu
                Case OyunAlani(GecerliYer.X - 1, GecerliYer.Y)
                    SecKurtYonu = clsAktifObjeler.enYon.Bati
                Case OyunAlani(GecerliYer.X, GecerliYer.Y + 1)
                    SecKurtYonu = clsAktifObjeler.enYon.Guney
                Case OyunAlani(GecerliYer.X, GecerliYer.Y - 1)
                    SecKurtYonu = clsAktifObjeler.enYon.Kuzey
            End Select
        End If

        SecKurtYonu = RasgeleYon(GecerliYer, SecKurtYonu)

    End Function

    'Kurdun oyun alan�nda sonsuz d�n�ye girmemesi ve aras�ra y�n�n� de�i�tirmesi i�in...
    Function RasgeleYon(ByVal GecerliYer As Point, ByVal SecilenYon As clsAktifObjeler.enYon) As clsAktifObjeler.enYon
        Dim x As Integer = Rnd(1) * 100
        RasgeleYon = SecilenYon
        If x < RandomYuzde Then
            Select Case SecilenYon
                ' di�er y�nleri dene...
            Case clsAktifObjeler.enYon.Dogu
                    If OyunAlani(GecerliYer.X, GecerliYer.Y + 1) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Guney
                    ElseIf OyunAlani(GecerliYer.X, GecerliYer.Y - 1) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Kuzey
                    ElseIf OyunAlani(GecerliYer.X - 1, GecerliYer.Y) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Bati
                    End If

                Case clsAktifObjeler.enYon.Bati
                    If OyunAlani(GecerliYer.X, GecerliYer.Y + 1) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Guney
                    ElseIf OyunAlani(GecerliYer.X, GecerliYer.Y - 1) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Kuzey
                    ElseIf OyunAlani(GecerliYer.X + 1, GecerliYer.Y) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Dogu
                    End If

                Case clsAktifObjeler.enYon.Kuzey
                    If OyunAlani(GecerliYer.X, GecerliYer.Y + 1) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Guney
                    ElseIf OyunAlani(GecerliYer.X + 1, GecerliYer.Y) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Dogu
                    ElseIf OyunAlani(GecerliYer.X - 1, GecerliYer.Y) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Bati
                    End If

                Case clsAktifObjeler.enYon.Guney
                    If OyunAlani(GecerliYer.X, GecerliYer.Y - 1) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Kuzey
                    ElseIf OyunAlani(GecerliYer.X + 1, GecerliYer.Y) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Dogu
                    ElseIf OyunAlani(GecerliYer.X - 1, GecerliYer.Y) <= enOyunObjeleri.Bos Then
                        RasgeleYon = clsAktifObjeler.enYon.Bati
                    End If

            End Select
        End If
    End Function

End Class
