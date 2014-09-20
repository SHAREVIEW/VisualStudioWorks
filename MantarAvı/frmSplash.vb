Public Class frmSplash
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
    Friend WithEvents PicBasla As System.Windows.Forms.PictureBox
    Friend WithEvents PicAyarlar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PicYardim As System.Windows.Forms.PictureBox
    Friend WithEvents PicHakkinda As System.Windows.Forms.PictureBox
    Friend WithEvents PicCikis As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.PicBasla = New System.Windows.Forms.PictureBox
        Me.PicAyarlar = New System.Windows.Forms.PictureBox
        Me.PicYardim = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PicCikis = New System.Windows.Forms.PictureBox
        Me.PicHakkinda = New System.Windows.Forms.PictureBox
        CType(Me.PicBasla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicAyarlar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicYardim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCikis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicHakkinda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicBasla
        '
        Me.PicBasla.BackColor = System.Drawing.Color.Transparent
        Me.PicBasla.BackgroundImage = CType(resources.GetObject("PicBasla.BackgroundImage"), System.Drawing.Image)
        Me.PicBasla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicBasla.Location = New System.Drawing.Point(16, 136)
        Me.PicBasla.Name = "PicBasla"
        Me.PicBasla.Size = New System.Drawing.Size(100, 26)
        Me.PicBasla.TabIndex = 6
        Me.PicBasla.TabStop = False
        '
        'PicAyarlar
        '
        Me.PicAyarlar.BackColor = System.Drawing.Color.Transparent
        Me.PicAyarlar.BackgroundImage = CType(resources.GetObject("PicAyarlar.BackgroundImage"), System.Drawing.Image)
        Me.PicAyarlar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicAyarlar.Location = New System.Drawing.Point(16, 176)
        Me.PicAyarlar.Name = "PicAyarlar"
        Me.PicAyarlar.Size = New System.Drawing.Size(100, 26)
        Me.PicAyarlar.TabIndex = 7
        Me.PicAyarlar.TabStop = False
        '
        'PicYardim
        '
        Me.PicYardim.BackColor = System.Drawing.Color.Transparent
        Me.PicYardim.BackgroundImage = CType(resources.GetObject("PicYardim.BackgroundImage"), System.Drawing.Image)
        Me.PicYardim.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicYardim.Location = New System.Drawing.Point(16, 216)
        Me.PicYardim.Name = "PicYardim"
        Me.PicYardim.Size = New System.Drawing.Size(100, 26)
        Me.PicYardim.TabIndex = 8
        Me.PicYardim.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(32, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(312, 72)
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'PicCikis
        '
        Me.PicCikis.BackColor = System.Drawing.Color.Transparent
        Me.PicCikis.BackgroundImage = CType(resources.GetObject("PicCikis.BackgroundImage"), System.Drawing.Image)
        Me.PicCikis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicCikis.Location = New System.Drawing.Point(16, 296)
        Me.PicCikis.Name = "PicCikis"
        Me.PicCikis.Size = New System.Drawing.Size(100, 26)
        Me.PicCikis.TabIndex = 11
        Me.PicCikis.TabStop = False
        '
        'PicHakkinda
        '
        Me.PicHakkinda.BackColor = System.Drawing.Color.Transparent
        Me.PicHakkinda.BackgroundImage = CType(resources.GetObject("PicHakkinda.BackgroundImage"), System.Drawing.Image)
        Me.PicHakkinda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicHakkinda.Location = New System.Drawing.Point(16, 256)
        Me.PicHakkinda.Name = "PicHakkinda"
        Me.PicHakkinda.Size = New System.Drawing.Size(100, 26)
        Me.PicHakkinda.TabIndex = 10
        Me.PicHakkinda.TabStop = False
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(378, 400)
        Me.ControlBox = False
        Me.Controls.Add(Me.PicCikis)
        Me.Controls.Add(Me.PicHakkinda)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PicYardim)
        Me.Controls.Add(Me.PicAyarlar)
        Me.Controls.Add(Me.PicBasla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(350, 350)
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantar Avý"
        CType(Me.PicBasla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicAyarlar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicYardim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCikis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicHakkinda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Module1.Yukle()
    End Sub

#Region "Butonlar"
    Private Sub PicBasla_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicBasla.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
            Me.Hide()
            Module1.Main()
        End If
    End Sub

    Private Sub PicAyarlar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicAyarlar.MouseDown
        Dim WinAyarlar As New frmAyarlar
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then WinAyarlar.ShowDialog()
    End Sub

    Private Sub PicYardim_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicYardim.MouseDown
        Dim WinYardim As New frmYardim
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then WinYardim.ShowDialog()
    End Sub

    Private Sub PicCikis_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCikis.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then End
    End Sub

    Private Sub PicHakkinda_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicHakkinda.MouseDown
        Dim WinHakkinda As New frmBiz
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then WinHakkinda.ShowDialog()
    End Sub
#End Region
End Class
