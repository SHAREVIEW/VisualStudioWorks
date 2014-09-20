Module Module1
    Public objOyunMotoru As clsOyunMotoru
    Public WinOyunAlani As frmOyunAlani
    Private objKurtlarAI As New clsKurtlarAI

    Sub MoveKurtlarAI()
        Dim i As Integer
        For i = 0 To objOyunMotoru.KurtSayisi - 1
            If Not objOyunMotoru.objKurtlar(i).IsDead Then
                If objOyunMotoru.objKurtlar(i).IsComputer Then
                    objOyunMotoru.objKurtlar(i).Yon = objKurtlarAI.SecKurtYonu(objOyunMotoru.objKurtlar(i).Yer, objOyunMotoru.objKurtlar(i).Yon)
                End If
            End If
        Next
    End Sub

    Public Sub Yukle()
        WinOyunAlani = New frmOyunAlani
        objOyunMotoru = New clsOyunMotoru(WinOyunAlani.PicOyunAlani.Handle)
        'sprite larý silmek için arkaplaný kopyala...
        clsOyunMotoru.BackgroundImage = WinOyunAlani.PicOyunAlani.Image.Clone
        clsAktifObjeler.Image_Yol = Klasor()
    End Sub

    Public Sub Main()
        WinOyunAlani = New frmOyunAlani
        objOyunMotoru.OyunAlaniOlustur(WinOyunAlani.PicOyunAlani.Handle)
        objOyunMotoru.GameOver = False
        WinOyunAlani.ShowDialog()
    End Sub

    Private Function Klasor() As String
        Dim A As String
        A = Reflection.Assembly.GetExecutingAssembly.Location
        A = Mid(A, 1, InStrRev(A, "\"))
        Return A
    End Function

End Module

