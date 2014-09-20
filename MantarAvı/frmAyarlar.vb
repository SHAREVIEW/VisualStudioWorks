Public Class frmAyarlar
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
    Friend WithEvents NumKurtlar As System.Windows.Forms.NumericUpDown
    Friend WithEvents DomMantarlar As System.Windows.Forms.DomainUpDown
    Friend WithEvents DomOyunAlani As System.Windows.Forms.DomainUpDown
    Friend WithEvents PicTamam As System.Windows.Forms.PictureBox
    Friend WithEvents Piciptal As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAyarlar))
        Me.NumKurtlar = New System.Windows.Forms.NumericUpDown
        Me.DomOyunAlani = New System.Windows.Forms.DomainUpDown
        Me.DomMantarlar = New System.Windows.Forms.DomainUpDown
        Me.PicTamam = New System.Windows.Forms.PictureBox
        Me.Piciptal = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.NumKurtlar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumKurtlar
        '
        Me.NumKurtlar.BackColor = System.Drawing.Color.Green
        Me.NumKurtlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumKurtlar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumKurtlar.ForeColor = System.Drawing.Color.White
        Me.NumKurtlar.Location = New System.Drawing.Point(104, 16)
        Me.NumKurtlar.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NumKurtlar.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumKurtlar.Name = "NumKurtlar"
        Me.NumKurtlar.Size = New System.Drawing.Size(32, 22)
        Me.NumKurtlar.TabIndex = 3
        Me.NumKurtlar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumKurtlar.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'DomOyunAlani
        '
        Me.DomOyunAlani.BackColor = System.Drawing.Color.Green
        Me.DomOyunAlani.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DomOyunAlani.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DomOyunAlani.ForeColor = System.Drawing.Color.White
        Me.DomOyunAlani.Items.Add("Büyük")
        Me.DomOyunAlani.Items.Add("Orta")
        Me.DomOyunAlani.Items.Add("Küçük")
        Me.DomOyunAlani.Location = New System.Drawing.Point(104, 72)
        Me.DomOyunAlani.Name = "DomOyunAlani"
        Me.DomOyunAlani.SelectedIndex = 2
        Me.DomOyunAlani.Size = New System.Drawing.Size(104, 22)
        Me.DomOyunAlani.TabIndex = 5
        Me.DomOyunAlani.Text = "Küçük"
        '
        'DomMantarlar
        '
        Me.DomMantarlar.BackColor = System.Drawing.Color.Green
        Me.DomMantarlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DomMantarlar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DomMantarlar.ForeColor = System.Drawing.Color.White
        Me.DomMantarlar.Items.Add("Çok")
        Me.DomMantarlar.Items.Add("Orta")
        Me.DomMantarlar.Items.Add("Az")
        Me.DomMantarlar.Location = New System.Drawing.Point(104, 40)
        Me.DomMantarlar.Name = "DomMantarlar"
        Me.DomMantarlar.SelectedIndex = 1
        Me.DomMantarlar.Size = New System.Drawing.Size(104, 22)
        Me.DomMantarlar.TabIndex = 8
        Me.DomMantarlar.Text = "Orta"
        '
        'PicTamam
        '
        Me.PicTamam.BackgroundImage = CType(resources.GetObject("PicTamam.BackgroundImage"), System.Drawing.Image)
        Me.PicTamam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicTamam.Location = New System.Drawing.Point(224, 8)
        Me.PicTamam.Name = "PicTamam"
        Me.PicTamam.Size = New System.Drawing.Size(100, 26)
        Me.PicTamam.TabIndex = 9
        Me.PicTamam.TabStop = False
        '
        'Piciptal
        '
        Me.Piciptal.BackgroundImage = CType(resources.GetObject("Piciptal.BackgroundImage"), System.Drawing.Image)
        Me.Piciptal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Piciptal.Location = New System.Drawing.Point(224, 40)
        Me.Piciptal.Name = "Piciptal"
        Me.Piciptal.Size = New System.Drawing.Size(100, 26)
        Me.Piciptal.TabIndex = 10
        Me.Piciptal.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 80)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'frmAyarlar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(328, 104)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Piciptal)
        Me.Controls.Add(Me.PicTamam)
        Me.Controls.Add(Me.DomMantarlar)
        Me.Controls.Add(Me.DomOyunAlani)
        Me.Controls.Add(Me.NumKurtlar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(400, 400)
        Me.Name = "frmAyarlar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ayarlar"
        CType(Me.NumKurtlar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAyar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumKurtlar.Value = objOyunMotoru.KurtSayisi
        DomMantarlar.SelectedIndex = objOyunMotoru.Mantar
        DomOyunAlani.SelectedIndex = objOyunMotoru.Size
    End Sub

    Private Sub NumKurtlar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumKurtlar.KeyPress, DomMantarlar.KeyPress, DomOyunAlani.KeyPress
        e.Handled = True
    End Sub

    Private Sub PicTamam_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTamam.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
            objOyunMotoru.KurtSayisi = NumKurtlar.Value
            objOyunMotoru.Mantar = DomMantarlar.SelectedIndex
            objOyunMotoru.Size = DomOyunAlani.SelectedIndex
            Me.Close()
        End If
    End Sub

    Private Sub Piciptal_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Piciptal.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then Me.Close()
    End Sub
End Class
