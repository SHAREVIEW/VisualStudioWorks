Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim GecerliBlok As clsBlok
    Dim SonrakiBlok As clsBlok
    Dim TekrarCiz As Boolean

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
    Friend WithEvents PicBackground As System.Windows.Forms.PictureBox
    Friend WithEvents cmdBasla As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblPuan As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picSonraki As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.PicBackground = New System.Windows.Forms.PictureBox
        Me.cmdBasla = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblPuan = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.picSonraki = New System.Windows.Forms.PictureBox
        CType(Me.PicBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSonraki, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicBackground
        '
        Me.PicBackground.BackColor = System.Drawing.Color.Black
        Me.PicBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBackground.Location = New System.Drawing.Point(112, 0)
        Me.PicBackground.Name = "PicBackground"
        Me.PicBackground.Size = New System.Drawing.Size(160, 300)
        Me.PicBackground.TabIndex = 0
        Me.PicBackground.TabStop = False
        '
        'cmdBasla
        '
        Me.cmdBasla.Location = New System.Drawing.Point(16, 136)
        Me.cmdBasla.Name = "cmdBasla"
        Me.cmdBasla.Size = New System.Drawing.Size(75, 23)
        Me.cmdBasla.TabIndex = 1
        Me.cmdBasla.Text = "Baþla"
        '
        'Timer1
        '
        Me.Timer1.Interval = 400
        '
        'lblPuan
        '
        Me.lblPuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPuan.Location = New System.Drawing.Point(3, 24)
        Me.lblPuan.Name = "lblPuan"
        Me.lblPuan.Size = New System.Drawing.Size(100, 23)
        Me.lblPuan.TabIndex = 2
        Me.lblPuan.Text = "0"
        Me.lblPuan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Puan"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picSonraki
        '
        Me.picSonraki.BackColor = System.Drawing.Color.Black
        Me.picSonraki.Location = New System.Drawing.Point(17, 64)
        Me.picSonraki.Name = "picSonraki"
        Me.picSonraki.Size = New System.Drawing.Size(72, 60)
        Me.picSonraki.TabIndex = 4
        Me.picSonraki.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(272, 301)
        Me.Controls.Add(Me.picSonraki)
        Me.Controls.Add(Me.lblPuan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdBasla)
        Me.Controls.Add(Me.PicBackground)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Tetris"
        CType(Me.PicBackground, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSonraki, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsOyunAlani.Backcolor = PicBackground.BackColor
        clsOyunAlani.WinHandle = PicBackground.Handle
        clsOyunAlani.picOyunAlani = PicBackground
    End Sub

    Private Sub cmdBasla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBasla.Click
        GecerliBlok = New clsBlok(New Point(60, 0))
        GecerliBlok.Goster(PicBackground.Handle)

        Timer1.Enabled = True
        cmdBasla.Enabled = False

        SonrakiBlok = New clsBlok(New Point(20, 10))
        SonrakiBlok.Goster(picSonraki.Handle)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Right
                GecerliBlok.Sag()
            Case Keys.Left
                GecerliBlok.Sol()
            Case Keys.Down
                GecerliBlok.Asagi()
            Case Keys.Up
                GecerliBlok.Dondur()
            Case Keys.Escape
                Me.Close()
            Case Keys.P
                Timer1.Enabled = Not Timer1.Enabled
                If Timer1.Enabled Then
                    Me.Text = "Tetris"
                Else
                    Me.Text = "Tetris - Devam Etmek için P ye basýn"
                End If
        End Select
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static HalaIslemde As Boolean = False
        Dim SilinenSatir As Integer
        'kodun önceki tik gelmden önce çalýþmasýný engeller...
        If HalaIslemde Then Exit Sub
        HalaIslemde = True
        'bloðun düþmesini kontrol eder...
        If Not GecerliBlok.Asagi Then
            'oyun bitti mi?
            If GecerliBlok.Top = 0 Then
                Timer1.Enabled = False
                cmdBasla.Enabled = True
                MessageBox.Show("Oyun Bitti", "Tetris", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            GecerliBlok.Asagi()

            'eðer silinen satýr varsa skoru artýr...
            SilinenSatir = clsOyunAlani.CizgiKontrol
            'oyun alanini temizle
            If SilinenSatir > 0 Then
                PicBackground.Invalidate()
                Application.DoEvents()
                clsOyunAlani.TekrarCiz()
            End If
            lblPuan.Text += 100 * SilinenSatir
            'bloðu bellekten çýkar...
            GecerliBlok = Nothing
            'yeni blok oluþtur...
            GecerliBlok = New clsBlok(New Point(clsOyunAlani.Boy * 6, 0), SonrakiBlok.BlokTipi)
            GecerliBlok.Goster(PicBackground.Handle)

            SonrakiBlok.Gizle(picSonraki.Handle)
            SonrakiBlok = Nothing
            SonrakiBlok = New clsBlok(New Point(20, 10))
            SonrakiBlok.Goster(picSonraki.Handle)
        End If
        HalaIslemde = False
    End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'pencere yeniden focus landýðýnda meydana gelir...
        clsOyunAlani.TekrarCiz()
    End Sub
End Class
