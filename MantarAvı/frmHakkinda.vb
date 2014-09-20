Public Class frmBiz
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
    Friend WithEvents PicTamam As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBiz))
        Me.PicTamam = New System.Windows.Forms.PictureBox
        CType(Me.PicTamam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicTamam
        '
        Me.PicTamam.BackgroundImage = CType(resources.GetObject("PicTamam.BackgroundImage"), System.Drawing.Image)
        Me.PicTamam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicTamam.Location = New System.Drawing.Point(288, 184)
        Me.PicTamam.Name = "PicTamam"
        Me.PicTamam.Size = New System.Drawing.Size(100, 26)
        Me.PicTamam.TabIndex = 0
        Me.PicTamam.TabStop = False
        '
        'frmBiz
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(400, 222)
        Me.ControlBox = False
        Me.Controls.Add(Me.PicTamam)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmBiz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Biz ?"
        CType(Me.PicTamam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PicTamam_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTamam.MouseDown
        If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then Me.Close()
    End Sub

End Class
