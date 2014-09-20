Public Class clsOyunMotoru

    Public Width As Integer = 30
    Public Height As Integer = 30
    Public Shared BackgroundImage As Image 'modulde deðer atadýk...
    Private HandleOyunAlani As System.IntPtr

    Private objSusler(4) As clsSusler
    Private objMantarlar As clsMantar
    Public objKurtlar(4) As clsKurtlar
    Public Oyuncu As clsKurtlar

    Private MantarSayisi As Integer = 50
    Public KurtSayisi As Integer = 1

    Public GameOver As Boolean
    Public Pause As Boolean = False

    'çarpýþma belirleme...
    Public Shared OyunAlani(,) As enOyunObjeleri

#Region "Enum ve Özellikler"
    Public Enum enOyunObjeleri
        Mantar = 0
        Bos = 1
        Susler = 2
        Kurtlar = 3
    End Enum

    Public Enum enSize
        Kucuk = 2
        Orta = 1
        Buyuk = 0
    End Enum

    Public Enum enMantar
        Az = 2
        Orta = 1
        Cok = 0
    End Enum

    Private pMantarlar As enMantar = enMantar.Orta
    Private pSize As enSize = enSize.Orta

    Property Size() As enSize
        Get
            Size = pSize
        End Get
        Set(ByVal Value As enSize)
            pSize = Value
            Select Case Value
                Case enSize.Kucuk
                    Width = 20 : Height = 20
                Case enSize.Orta
                    Width = 30 : Height = 30
                Case enSize.Buyuk
                    Width = 40 : Height = 30
            End Select
        End Set
    End Property

    Property Mantar() As enMantar
        Get
            Mantar = pMantarlar
        End Get
        Set(ByVal Value As enMantar)
            pMantarlar = Value
            Select Case Value
                Case enMantar.Az
                    MantarSayisi = 25
                Case enMantar.Orta
                    MantarSayisi = 50
                Case enMantar.Cok
                    MantarSayisi = 90
            End Select

            If Size = enSize.Orta Then
                MantarSayisi *= 2
            ElseIf enSize.Buyuk Then
                MantarSayisi *= 3
            End If
        End Set
    End Property

#End Region

#Region "Kurucular"
    Sub New()
    End Sub

    Public Sub New(ByVal PicHandle As System.IntPtr)
        Dim i, j, x, y As Integer

        ReDim OyunAlani(Width, Height)

        HandleOyunAlani = PicHandle

        'Tüm oyun alanýný boþ olarak belirle...
        For x = 0 To Width - 1
            For y = 0 To Height - 1
                OyunAlani(x, y) = enOyunObjeleri.Bos
            Next
        Next

        Randomize()
        'Dallarý oluþtur
        objSusler(0) = New clsSusler(clsAktifObjeler.enYon.Kuzey, Me.Height) 'dikey dallar
        objSusler(1) = New clsSusler(clsAktifObjeler.enYon.Kuzey, Me.Height)
        objSusler(2) = New clsSusler(clsAktifObjeler.enYon.Dogu, Me.Width - 2) 'yatay dallar (solda ve saðda sus var)...
        objSusler(3) = New clsSusler(clsAktifObjeler.enYon.Dogu, Me.Width - 2)

        Select Case KurtSayisi
            Case 1
                'tek kurt varsa tam ekranýn ortasýnda
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 2), Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, False)
            Case 2
                'iki kurt varsa saðdan,soldan ve aralarýndaki boþluk eþit þekilde ...
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 3), Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, False)
                objKurtlar(1) = New clsKurtlar(Int(Me.Width / 3) * 2, Int(Me.Height) / 2, clsAktifObjeler.enYon.Kuzey, True)
            Case 3
                'üç kurt varsa saðdan,soldan ve aralarýndaki boþluk eþit þekilde ...
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 4), Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, False)
                objKurtlar(1) = New clsKurtlar(Int(Me.Width / 4) * 2, Int(Me.Height) / 2, clsAktifObjeler.enYon.Kuzey, True)
                objKurtlar(2) = New clsKurtlar(Int(Me.Width / 4) * 3, Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, True)
            Case 4
                'dört kurt varsa kare þeklinde ...
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 3), Int(Me.Height) / 3, clsAktifObjeler.enYon.Guney, False)
                objKurtlar(1) = New clsKurtlar(Int(Me.Width / 3), Int(Me.Height) / 3 * 2, clsAktifObjeler.enYon.Dogu, True)
                objKurtlar(2) = New clsKurtlar(Int(Me.Width / 3) * 2, Int(Me.Height) / 3 * 2, clsAktifObjeler.enYon.Kuzey, True)
                objKurtlar(3) = New clsKurtlar(Int(Me.Width / 3) * 2, Int(Me.Height) / 3, clsAktifObjeler.enYon.Bati, True)
        End Select

        Oyuncu = objKurtlar(0)

        'Kurtlarý (kafalarý ve body yi) diziye yerleþtir...
        For i = 0 To KurtSayisi - 1
            OyunAlani(objKurtlar(i).Yer.X, objKurtlar(i).Yer.Y) = enOyunObjeleri.Kurtlar 'kafa için...
            For j = 0 To objKurtlar(i).KurtBoyu - 1
                OyunAlani(objKurtlar(i).KurtBody(j).Yer.X, objKurtlar(i).KurtBody(j).Yer.Y) = enOyunObjeleri.Kurtlar 'body için...
            Next j
        Next i

        'yatay dallarý diziye yerleþtir...
        For x = 0 To Width - 1
            OyunAlani(x, 0) = enOyunObjeleri.Susler
            OyunAlani(x, Height - 1) = enOyunObjeleri.Susler
        Next
        'Dikey dallarý diziye yerleþtir...
        For y = 0 To Height - 1
            OyunAlani(0, y) = enOyunObjeleri.Susler
            OyunAlani(Width - 1, y) = enOyunObjeleri.Susler
        Next

        'mantar objesini oluþtur...
        objMantarlar = New clsMantar

        For i = 0 To MantarSayisi - 1
            'diðer objelerin üstünde mantar oluþturma...
            Do
                x = Int(Rnd(1) * (Me.Width - 2)) + 1
                y = Int(Rnd(1) * (Me.Height - 2)) + 1
            Loop While OyunAlani(x, y) <> enOyunObjeleri.Bos
            OyunAlani(x, y) = enOyunObjeleri.Mantar
        Next

    End Sub

    Sub OyunAlaniOlustur(ByVal PicHandle As System.IntPtr)
        Dim i, j, x, y As Integer

        ReDim OyunAlani(Width, Height)

        HandleOyunAlani = PicHandle

        'Tüm oyun alanýný boþ olarak belirle...
        For x = 0 To Width - 1
            For y = 0 To Height - 1
                OyunAlani(x, y) = enOyunObjeleri.Bos
            Next
        Next

        Randomize()
        'Dallarý oluþtur
        objSusler(0) = New clsSusler(clsAktifObjeler.enYon.Kuzey, Me.Height) 'dikey dallar
        objSusler(1) = New clsSusler(clsAktifObjeler.enYon.Kuzey, Me.Height)
        objSusler(2) = New clsSusler(clsAktifObjeler.enYon.Dogu, Me.Width - 2) 'yatay dallar (solda ve saðda sus var)...
        objSusler(3) = New clsSusler(clsAktifObjeler.enYon.Dogu, Me.Width - 2)

        Select Case KurtSayisi
            Case 1
                'tek kurt varsa tam ekranýn ortasýnda
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 2), Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, False)
            Case 2
                'iki kurt varsa saðdan,soldan ve aralarýndaki boþluk eþit þekilde ...
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 3), Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, False)
                objKurtlar(1) = New clsKurtlar(Int(Me.Width / 3) * 2, Int(Me.Height) / 2, clsAktifObjeler.enYon.Kuzey, True)
            Case 3
                'üç kurt varsa saðdan,soldan ve aralarýndaki boþluk eþit þekilde ...
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 4), Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, False)
                objKurtlar(1) = New clsKurtlar(Int(Me.Width / 4) * 2, Int(Me.Height) / 2, clsAktifObjeler.enYon.Kuzey, True)
                objKurtlar(2) = New clsKurtlar(Int(Me.Width / 4) * 3, Int(Me.Height) / 2, clsAktifObjeler.enYon.Guney, True)
            Case 4
                'dört kurt varsa kare þeklinde ...
                objKurtlar(0) = New clsKurtlar(Int(Me.Width / 3), Int(Me.Height) / 3, clsAktifObjeler.enYon.Guney, False)
                objKurtlar(1) = New clsKurtlar(Int(Me.Width / 3), Int(Me.Height) / 3 * 2, clsAktifObjeler.enYon.Dogu, True)
                objKurtlar(2) = New clsKurtlar(Int(Me.Width / 3) * 2, Int(Me.Height) / 3 * 2, clsAktifObjeler.enYon.Kuzey, True)
                objKurtlar(3) = New clsKurtlar(Int(Me.Width / 3) * 2, Int(Me.Height) / 3, clsAktifObjeler.enYon.Bati, True)
        End Select

        Oyuncu = objKurtlar(0)

        'Kurtlarý (kafalarý ve body yi) diziye yerleþtir...
        For i = 0 To KurtSayisi - 1
            OyunAlani(objKurtlar(i).Yer.X, objKurtlar(i).Yer.Y) = enOyunObjeleri.Kurtlar 'kafa için...
            For j = 0 To objKurtlar(i).KurtBoyu - 1
                OyunAlani(objKurtlar(i).KurtBody(j).Yer.X, objKurtlar(i).KurtBody(j).Yer.Y) = enOyunObjeleri.Kurtlar 'body için...
            Next j
        Next i

        'yatay dallarý diziye yerleþtir...
        For x = 0 To Width - 1
            OyunAlani(x, 0) = enOyunObjeleri.Susler
            OyunAlani(x, Height - 1) = enOyunObjeleri.Susler
        Next
        'Dikey dallarý diziye yerleþtir...
        For y = 0 To Height - 1
            OyunAlani(0, y) = enOyunObjeleri.Susler
            OyunAlani(Width - 1, y) = enOyunObjeleri.Susler
        Next

        'mantar objesini oluþtur...
        objMantarlar = New clsMantar

        For i = 0 To MantarSayisi - 1
            'diðer objelerin üstünde mantar oluþturma...
            Do
                x = Int(Rnd(1) * (Me.Width - 2)) + 1
                y = Int(Rnd(1) * (Me.Height - 2)) + 1
            Loop While OyunAlani(x, y) <> enOyunObjeleri.Bos
            OyunAlani(x, y) = enOyunObjeleri.Mantar
        Next
    End Sub
#End Region

#Region "Fizik"

    Sub TasiKurtlar()
        Dim i As Integer
        Dim artimX As Integer = 0, artimY As Integer = 0

        For i = 0 To KurtSayisi - 1

            Select Case objKurtlar(i).Yon 'kafayý kastediyo...
                Case clsAktifObjeler.enYon.Dogu
                    artimX = 1
                    artimY = 0
                Case clsAktifObjeler.enYon.Bati
                    artimX = -1
                    artimY = 0
                Case clsAktifObjeler.enYon.Kuzey
                    artimX = 0
                    artimY = -1
                Case clsAktifObjeler.enYon.Guney
                    artimX = 0
                    artimY = 1
            End Select

            If Not objKurtlar(i).IsDead Then
                Select Case OyunAlani(objKurtlar(i).Yer.X + artimX, objKurtlar(i).Yer.Y + artimY)
                    Case enOyunObjeleri.Bos
                        objKurtlar(i).MantarYedi = False
                        OyunAlani(objKurtlar(i).KurtBody(objKurtlar(i).KurtBoyu - 1).Yer.X, _
                        objKurtlar(i).KurtBody(objKurtlar(i).KurtBoyu - 1).Yer.Y) = enOyunObjeleri.Bos

                        objKurtlar(i).Tasi(objKurtlar(i).Yer.X + artimX, objKurtlar(i).Yer.Y + artimY, HandleOyunAlani, objKurtlar(i).MantarYedi)
                        ' kurdun silinen parçasýna bos at...
                        ' kafaya için,move dan sonra yer deðiþti...
                        OyunAlani(objKurtlar(i).Yer.X, objKurtlar(i).Yer.Y) = enOyunObjeleri.Kurtlar

                    Case enOyunObjeleri.Mantar
                        ' Mantar sayýsýný azalt...
                        objKurtlar(i).MantarYedi = True
                        MantarSayisi -= 1
                        objKurtlar(i).Ye_ve_Tasi(objKurtlar(i).Yer.X + artimX, objKurtlar(i).Yer.Y + artimY, HandleOyunAlani, objKurtlar(i).MantarYedi)
                        OyunAlani(objKurtlar(i).Yer.X, objKurtlar(i).Yer.Y) = enOyunObjeleri.Kurtlar

                    Case Else
                        KillKurtlar(objKurtlar(i))

                End Select

            End If
        Next
    End Sub

    Sub KillKurtlar(ByVal Kurt As clsKurtlar)
        Dim i As Integer
        Kurt.IsDead = True
        ' kafaya boþ at
        OyunAlani(Kurt.Yer.X, Kurt.Yer.Y) = enOyunObjeleri.Bos
        'kafayý sil..
        Kurt.Sil(HandleOyunAlani)
        'body i sil...
        For i = 0 To Kurt.KurtBoyu - 1
            OyunAlani(Kurt.KurtBody(i).Yer.X, Kurt.KurtBody(i).Yer.Y) = enOyunObjeleri.Bos
            Kurt.KurtBody(i).Sil(HandleOyunAlani)
        Next
    End Sub
#End Region

#Region "Render"
    Sub Render()
        Dim i As Integer
        If Not objOyunMotoru.Pause Then
            TasiKurtlar()
        End If
        'tüm kurtlar öldüyse oyun bitsin...
        GameOver = True
        For i = 0 To KurtSayisi - 1
            If Not objKurtlar(i).IsDead Then GameOver = False
        Next
        'tüm mantarlar yendiyse oyun bitsin...
        If MantarSayisi = 0 Then GameOver = True
        TekrarCiz()
    End Sub

    Sub TekrarCiz()
        Dim i, x, y As Integer

        For x = 0 To Width - 1
            For y = 0 To Height - 1
                If OyunAlani(x, y) = enOyunObjeleri.Mantar Then
                    objMantarlar.Yer = New Point(x, y)
                    objMantarlar.Ciz(HandleOyunAlani)
                End If
            Next
        Next

        'dikey dallar...
        objSusler(0).Ciz(HandleOyunAlani, 0, 0)
        objSusler(1).Ciz(HandleOyunAlani, (Me.Width - 1), 0)
        'yatay dallar...
        objSusler(2).Ciz(HandleOyunAlani, 1, 0)
        objSusler(3).Ciz(HandleOyunAlani, 1, (Me.Height - 1))

        'Tasi ve Ye_ve_Tasi metodlarý kurtlarý çizmesine raðmen tekrar Ciz metodunu kullanmamýzýn nedeni ölü kurtlarý çizdirmemek...
        For i = 0 To KurtSayisi - 1
            If Not objKurtlar(i).IsDead Then
                objKurtlar(i).Ciz(HandleOyunAlani, objKurtlar(i).MantarYedi)
            End If
        Next
    End Sub

#End Region

End Class
