Public Class clsKurtBody
    Inherits clsAktifObjeler

    Sub New(ByVal IsComputer As Boolean)
        MyBase.new(Image_Yol & "resimler\" & IIf(IsComputer, "", "Oyuncu") & "KurtBody.gif")
    End Sub
End Class
