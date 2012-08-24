Public Class Form1
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLabelSource1 As System.Windows.Forms.Label
    Friend WithEvents lblLabelSource2 As System.Windows.Forms.Label
    Friend WithEvents lblLabelSource3 As System.Windows.Forms.Label
    Friend WithEvents lblTextTarget As System.Windows.Forms.Label
    Friend WithEvents lblTextSource1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLabelTarget As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTextSource2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblLabelSource1 = New System.Windows.Forms.Label
        Me.lblLabelSource2 = New System.Windows.Forms.Label
        Me.lblLabelSource3 = New System.Windows.Forms.Label
        Me.lblTextTarget = New System.Windows.Forms.Label
        Me.lblTextSource1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTextSource2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblLabelTarget = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label Sources"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(202, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Label Target"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(202, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Text Target"
        '
        'lblLabelSource1
        '
        Me.lblLabelSource1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblLabelSource1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLabelSource1.Location = New System.Drawing.Point(10, 26)
        Me.lblLabelSource1.Name = "lblLabelSource1"
        Me.lblLabelSource1.Size = New System.Drawing.Size(115, 26)
        Me.lblLabelSource1.TabIndex = 9
        Me.lblLabelSource1.Text = "Apple"
        Me.lblLabelSource1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabelSource2
        '
        Me.lblLabelSource2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblLabelSource2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLabelSource2.Location = New System.Drawing.Point(10, 60)
        Me.lblLabelSource2.Name = "lblLabelSource2"
        Me.lblLabelSource2.Size = New System.Drawing.Size(115, 26)
        Me.lblLabelSource2.TabIndex = 10
        Me.lblLabelSource2.Text = "Banana"
        Me.lblLabelSource2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabelSource3
        '
        Me.lblLabelSource3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblLabelSource3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLabelSource3.Location = New System.Drawing.Point(10, 95)
        Me.lblLabelSource3.Name = "lblLabelSource3"
        Me.lblLabelSource3.Size = New System.Drawing.Size(115, 26)
        Me.lblLabelSource3.TabIndex = 11
        Me.lblLabelSource3.Text = "Orange"
        Me.lblLabelSource3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextTarget
        '
        Me.lblTextTarget.AllowDrop = True
        Me.lblTextTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTextTarget.Location = New System.Drawing.Point(202, 129)
        Me.lblTextTarget.Name = "lblTextTarget"
        Me.lblTextTarget.Size = New System.Drawing.Size(115, 26)
        Me.lblTextTarget.TabIndex = 13
        Me.lblTextTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextSource1
        '
        Me.lblTextSource1.BackColor = System.Drawing.SystemColors.Control
        Me.lblTextSource1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTextSource1.Location = New System.Drawing.Point(10, 146)
        Me.lblTextSource1.Name = "lblTextSource1"
        Me.lblTextSource1.Size = New System.Drawing.Size(115, 26)
        Me.lblTextSource1.TabIndex = 15
        Me.lblTextSource1.Text = "Pine"
        Me.lblTextSource1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Text Sources"
        '
        'lblTextSource2
        '
        Me.lblTextSource2.BackColor = System.Drawing.SystemColors.Control
        Me.lblTextSource2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTextSource2.Location = New System.Drawing.Point(10, 181)
        Me.lblTextSource2.Name = "lblTextSource2"
        Me.lblTextSource2.Size = New System.Drawing.Size(115, 26)
        Me.lblTextSource2.TabIndex = 16
        Me.lblTextSource2.Text = "Ash"
        Me.lblTextSource2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(365, 129)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 192)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'lblLabelTarget
        '
        Me.lblLabelTarget.AllowDrop = True
        Me.lblLabelTarget.BackColor = System.Drawing.Color.White
        Me.lblLabelTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLabelTarget.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblLabelTarget.Image = CType(resources.GetObject("lblLabelTarget.Image"), System.Drawing.Image)
        Me.lblLabelTarget.Location = New System.Drawing.Point(385, 154)
        Me.lblLabelTarget.Name = "lblLabelTarget"
        Me.lblLabelTarget.Size = New System.Drawing.Size(152, 80)
        Me.lblLabelTarget.TabIndex = 18
        Me.lblLabelTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(395, 251)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 50)
        Me.TextBox1.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(660, 333)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblLabelTarget)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTextSource2)
        Me.Controls.Add(Me.lblTextSource1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTextTarget)
        Me.Controls.Add(Me.lblLabelSource3)
        Me.Controls.Add(Me.lblLabelSource2)
        Me.Controls.Add(Me.lblLabelSource1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub lblLabelSource1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLabelSource1.MouseDown
        ' Start a drag.
        lblLabelSource1.DoDragDrop( _
            lblLabelSource1, _
            DragDropEffects.Copy)
    End Sub

    Private Sub lblLabelSource2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLabelSource2.MouseDown
        ' Start a drag.
        lblLabelSource2.DoDragDrop( _
            lblLabelSource2, _
            DragDropEffects.Move)
    End Sub

    Private Sub lblLabelSource3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblLabelSource3.MouseDown
        ' Start a drag.
        lblLabelSource3.DoDragDrop( _
            lblLabelSource3, _
            DragDropEffects.Copy)
    End Sub

    Private Sub lblTextSource1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTextSource1.MouseDown
        ' Start a drag.
        lblTextSource1.DoDragDrop( _
            lblTextSource1.Text, _
            DragDropEffects.Copy)
    End Sub

    Private Sub lblTextSource2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTextSource2.MouseDown
        ' Start a drag.
        lblTextSource2.DoDragDrop( _
            lblTextSource2.Text, _
            DragDropEffects.Copy)
    End Sub

    ' Display the copy effect.
    Private Sub lblLabelTarget_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        ' See if the data includes a Label.
        If e.Data.GetDataPresent(GetType(Label)) Then
            ' There is Label data. Allow copy.
            e.Effect = DragDropEffects.Move

            ' Highlight the control.
            lblLabelTarget.BorderStyle = BorderStyle.FixedSingle
        Else
            ' There is no Label. Prohibit drop.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ' Unhighlight the control.
    Private Sub lblLabelTarget_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblLabelTarget.BorderStyle = BorderStyle.Fixed3D
    End Sub

    ' Perform the drop.
    Private Sub lblLabelTarget_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim lbl As Label = DirectCast( _
            e.Data.GetData(GetType(Label)), Label)
        lblLabelTarget.Text = lbl.Text
        lblLabelTarget.BackColor = lbl.BackColor
        lblLabelTarget.BorderStyle = BorderStyle.Fixed3D
    End Sub

    ' Display the copy effect.
    Private Sub lblTextTarget_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lblTextTarget.DragEnter
        ' See if the data includes text.
        If e.Data.GetDataPresent(DataFormats.Text) Then
            ' There is text. Allow copy.
            e.Effect = DragDropEffects.Copy
        Else
            ' There is no text. Prohibit drop.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lblTextTarget_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lblTextTarget.DragDrop
        lblTextTarget.Text = e.Data.GetData(DataFormats.Text).ToString
    End Sub

    Private Sub lblLabelTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' Dim Label1 As New Label()
        Dim Image1 As Image

        Image1 = Image.FromFile("C:\\work\\source\\test\\howto_net_drag_drop\\resource\\note_43747.jpg")


        ' Set the size of the label to accommodate the bitmap size.

        lblLabelTarget.Size = Image1.Size

        ' Initialize the label control's Image property.

        lblLabelTarget.Image = Image1

    End Sub
End Class
