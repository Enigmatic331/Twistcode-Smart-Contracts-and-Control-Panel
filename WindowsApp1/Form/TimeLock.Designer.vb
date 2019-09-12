<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeLock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnDeploy = New System.Windows.Forms.Button()
        Me.lsConsole = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblBenAddress = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDeploy
        '
        Me.btnDeploy.Location = New System.Drawing.Point(12, 218)
        Me.btnDeploy.Name = "btnDeploy"
        Me.btnDeploy.Size = New System.Drawing.Size(205, 50)
        Me.btnDeploy.TabIndex = 4
        Me.btnDeploy.Text = "Deploy"
        Me.btnDeploy.UseVisualStyleBackColor = True
        '
        'lsConsole
        '
        Me.lsConsole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsConsole.FormattingEnabled = True
        Me.lsConsole.HorizontalScrollbar = True
        Me.lsConsole.ItemHeight = 25
        Me.lsConsole.Location = New System.Drawing.Point(12, 287)
        Me.lsConsole.Name = "lsConsole"
        Me.lsConsole.Size = New System.Drawing.Size(1076, 329)
        Me.lsConsole.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.lblTime)
        Me.GroupBox1.Controls.Add(Me.lblBenAddress)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1076, 156)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Action"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(254, 88)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(537, 31)
        Me.DateTimePicker1.TabIndex = 7
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(254, 38)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(537, 31)
        Me.txtAddress.TabIndex = 6
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(63, 88)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(185, 25)
        Me.lblTime.TabIndex = 5
        Me.lblTime.Text = "Date for Release: "
        '
        'lblBenAddress
        '
        Me.lblBenAddress.AutoSize = True
        Me.lblBenAddress.Location = New System.Drawing.Point(32, 41)
        Me.lblBenAddress.Name = "lblBenAddress"
        Me.lblBenAddress.Size = New System.Drawing.Size(216, 25)
        Me.lblBenAddress.TabIndex = 4
        Me.lblBenAddress.Text = "Beneficiary Address: "
        '
        'TimeLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 638)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lsConsole)
        Me.Controls.Add(Me.btnDeploy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "TimeLock"
        Me.Text = "Time Lock Contract Deployer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDeploy As Button
    Friend WithEvents lsConsole As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblTime As Label
    Friend WithEvents lblBenAddress As Label
End Class
