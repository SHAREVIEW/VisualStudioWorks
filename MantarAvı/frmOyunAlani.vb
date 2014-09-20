Public Class frmOyunAlani
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PicOyunAlani As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOyunAlani))
        Me.PicOyunAlani = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'PicOyunAlani
        '
        Me.PicOyunAlani.Image = CType(resources.GetObject("PicOyunAlani.Image"), System.Drawing.Image)
        Me.PicOyunAlani.Location = New System.Drawing.Point(0, 0)
        Me.PicOyunAlani.Name = "PicOyunAlani"
        Me.PicOyunAlani.Size = New System.Drawing.Size(375, 375)
        Me.PicOyunAlani.TabIndex = 0
        Me.PicOyunAlani.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 125
        '
        'frmOyunAlani
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 376)
        Me.ControlBox = False
        Me.Controls.Add(Me.PicOyunAlani)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(400, 400)
        Me.Name = "frmOyunAlani"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantar Avý"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim WinOyunBitti As New frmOyunBitti
    Dim WinSplash As New frmSplash

    Private Sub frmOyunAlani_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Right
                If objOyunMotoru.Oyuncu.Yon <> clsAktifObjeler.enYon.Bati Then
                    objOyunMotoru.Oyuncu.Yon = clsAktifObjeler.enYon.Dogu
                End If
            Case Keys.Left
                If objOyunMotoru.Oyuncu.Yon <> clsAktifObjeler.enYon.Dogu Then
                    objOyunMotoru.Oyuncu.Yon = clsAktifObjeler.enYon.Bati
                End If
            Case Keys.Up
                If objOyunMotoru.Oyuncu.Yon <> clsAktifObjeler.enYon.Guney Then
                    objOyunMotoru.Oyuncu.Yon = clsAktifObjeler.enYon.Kuzey
                End If
            Case Keys.Down
                If objOyunMotoru.Oyuncu.Yon <> clsAktifObjeler.enYon.Kuzey Then
                    objOyunMotoru.Oyuncu.Yon = clsAktifObjeler.enYon.Guney
                End If
            Case Keys.P
                objOyunMotoru.Pause = Not objOyunMotoru.Pause
                If objOyunMotoru.Pause Then
                    Me.Text = "Mantar Avý - Devam Etmek için P ye basýn"
                Else
                    Me.Text = "Mantar Avý"
                End If
            Case Keys.Escape
                objOyunMotoru.GameOver = True
        End Select
    End Sub

    Private Sub frmOyunAlani_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PicOyunAlani.Location = New Point(0, 0)
        PicOyunAlani.Size = New Size(objOyunMotoru.Width * clsAktifObjeler.Image_Boy, objOyunMotoru.Height * clsAktifObjeler.Image_Boy)
        Me.ClientSize = PicOyunAlani.Size
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static HalaIslemde As Boolean
        'Daha önceki Tick hala iþlemde ise ise kodun çalýþmasýný engelle...
        If HalaIslemde Then Exit Sub
        HalaIslemde = True

        If Not objOyunMotoru.GameOver Then
            MoveKurtlarAI()
            objOyunMotoru.Render()
        Else
            Timer1.Enabled = False
            WinOyunBitti.ShowDialog()
            WinSplash.Show()
            objOyunMotoru = Nothing
            Yukle()
            Me.Dispose()
        End If

        HalaIslemde = False
    End Sub

    Private Sub frmOyunAlani_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        objOyunMotoru.GameOver = True
    End Sub
End Class
