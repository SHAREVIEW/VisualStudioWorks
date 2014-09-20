Public Class frmOyunBitti
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PicTamam As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblOyuncu4Puan As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu3Puan As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu2Puan As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu1Puan As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu4 As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu3 As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu2 As System.Windows.Forms.Label
    Friend WithEvents lblOyuncu1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOyunBitti))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PicTamam = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lblOyuncu4Puan = New System.Windows.Forms.Label
        Me.lblOyuncu3Puan = New System.Windows.Forms.Label
        Me.lblOyuncu2Puan = New System.Windows.Forms.Label
        Me.lblOyuncu1Puan = New System.Windows.Forms.Label
        Me.lblOyuncu4 = New System.Windows.Forms.Label
        Me.lblOyuncu3 = New System.Windows.Forms.Label
        Me.lblOyuncu2 = New System.Windows.Forms.Label
        Me.lblOyuncu1 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicTamam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(248, 48)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PicTamam
        '
        Me.PicTamam.BackColor = System.Drawing.Color.Transparent
        Me.PicTamam.BackgroundImage = CType(resources.GetObject("PicTamam.BackgroundImage"), System.Drawing.Image)
        Me.PicTamam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicTamam.Location = New System.Drawing.Point(88, 224)
        Me.PicTamam.Name = "PicTamam"
        Me.PicTamam.Size = New System.Drawing.Size(100, 26)
        Me.PicTamam.TabIndex = 5
        Me.PicTamam.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(21, 73)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(75, 119)
        Me.PictureBox2.TabIndex = 24
        Me.PictureBox2.TabStop = False
        '
        'lblOyuncu4Puan
        '
        Me.lblOyuncu4Puan.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu4Puan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu4Puan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu4Puan.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu4Puan.Location = New System.Drawing.Point(205, 169)
        Me.lblOyuncu4Puan.Name = "lblOyuncu4Puan"
        Me.lblOyuncu4Puan.Size = New System.Drawing.Size(40, 23)
        Me.lblOyuncu4Puan.TabIndex = 23
        Me.lblOyuncu4Puan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOyuncu3Puan
        '
        Me.lblOyuncu3Puan.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu3Puan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu3Puan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu3Puan.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu3Puan.Location = New System.Drawing.Point(205, 137)
        Me.lblOyuncu3Puan.Name = "lblOyuncu3Puan"
        Me.lblOyuncu3Puan.Size = New System.Drawing.Size(40, 23)
        Me.lblOyuncu3Puan.TabIndex = 22
        Me.lblOyuncu3Puan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOyuncu2Puan
        '
        Me.lblOyuncu2Puan.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu2Puan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu2Puan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu2Puan.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu2Puan.Location = New System.Drawing.Point(205, 105)
        Me.lblOyuncu2Puan.Name = "lblOyuncu2Puan"
        Me.lblOyuncu2Puan.Size = New System.Drawing.Size(40, 23)
        Me.lblOyuncu2Puan.TabIndex = 21
        Me.lblOyuncu2Puan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOyuncu1Puan
        '
        Me.lblOyuncu1Puan.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu1Puan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu1Puan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu1Puan.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu1Puan.Location = New System.Drawing.Point(205, 73)
        Me.lblOyuncu1Puan.Name = "lblOyuncu1Puan"
        Me.lblOyuncu1Puan.Size = New System.Drawing.Size(40, 23)
        Me.lblOyuncu1Puan.TabIndex = 20
        Me.lblOyuncu1Puan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOyuncu4
        '
        Me.lblOyuncu4.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu4.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu4.Location = New System.Drawing.Point(112, 169)
        Me.lblOyuncu4.Name = "lblOyuncu4"
        Me.lblOyuncu4.Size = New System.Drawing.Size(88, 23)
        Me.lblOyuncu4.TabIndex = 19
        Me.lblOyuncu4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOyuncu3
        '
        Me.lblOyuncu3.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu3.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu3.Location = New System.Drawing.Point(112, 137)
        Me.lblOyuncu3.Name = "lblOyuncu3"
        Me.lblOyuncu3.Size = New System.Drawing.Size(88, 23)
        Me.lblOyuncu3.TabIndex = 18
        Me.lblOyuncu3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOyuncu2
        '
        Me.lblOyuncu2.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu2.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu2.Location = New System.Drawing.Point(112, 105)
        Me.lblOyuncu2.Name = "lblOyuncu2"
        Me.lblOyuncu2.Size = New System.Drawing.Size(88, 23)
        Me.lblOyuncu2.TabIndex = 17
        Me.lblOyuncu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOyuncu1
        '
        Me.lblOyuncu1.BackColor = System.Drawing.Color.Transparent
        Me.lblOyuncu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOyuncu1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.lblOyuncu1.ForeColor = System.Drawing.Color.Red
        Me.lblOyuncu1.Location = New System.Drawing.Point(112, 73)
        Me.lblOyuncu1.Name = "lblOyuncu1"
        Me.lblOyuncu1.Size = New System.Drawing.Size(88, 23)
        Me.lblOyuncu1.TabIndex = 16
        Me.lblOyuncu1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmOyunBitti
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(266, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblOyuncu4Puan)
        Me.Controls.Add(Me.lblOyuncu3Puan)
        Me.Controls.Add(Me.lblOyuncu2Puan)
        Me.Controls.Add(Me.lblOyuncu1Puan)
        Me.Controls.Add(Me.lblOyuncu4)
        Me.Controls.Add(Me.lblOyuncu3)
        Me.Controls.Add(Me.lblOyuncu2)
        Me.Controls.Add(Me.lblOyuncu1)
        Me.Controls.Add(Me.PicTamam)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmOyunBitti"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Oyun Bitti"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicTamam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmOyunBitti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblOyuncu1.Text = IIf(objOyunMotoru.objKurtlar(0).IsComputer, "Düþman", "Oyuncu")
        lblOyuncu1Puan.Text = objOyunMotoru.objKurtlar(0).KurtBoyu

        If Not objOyunMotoru.objKurtlar(1) Is Nothing Then
            lblOyuncu2.Text = IIf(objOyunMotoru.objKurtlar(1).IsComputer, "Düþman", "Oyuncu")
            lblOyuncu2Puan.Text = objOyunMotoru.objKurtlar(1).KurtBoyu
        Else
            lblOyuncu2.Text = "-"
            lblOyuncu2Puan.Text = "-"
        End If

        If Not objOyunMotoru.objKurtlar(2) Is Nothing Then
            lblOyuncu3.Text = IIf(objOyunMotoru.objKurtlar(2).IsComputer, "Düþman", "Oyuncu")
            lblOyuncu3Puan.Text = objOyunMotoru.objKurtlar(2).KurtBoyu
        Else
            lblOyuncu3.Text = "-"
            lblOyuncu3Puan.Text = "-"
        End If

        If Not objOyunMotoru.objKurtlar(3) Is Nothing Then
            lblOyuncu4.Text = IIf(objOyunMotoru.objKurtlar(3).IsComputer, "Düþman", "Oyuncu")
            lblOyuncu4Puan.Text = objOyunMotoru.objKurtlar(3).KurtBoyu
        Else
            lblOyuncu4.Text = "-"
            lblOyuncu4Puan.Text = "-"
        End If
    End Sub

    Private Sub PicTamam_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTamam.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then Me.Close()
    End Sub

End Class
