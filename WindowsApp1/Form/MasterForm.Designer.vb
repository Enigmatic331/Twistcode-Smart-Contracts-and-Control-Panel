<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btntokenDistribute = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btndeployToken = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btntimelockContract = New System.Windows.Forms.Button()
        Me.lblNetwork = New System.Windows.Forms.Label()
        Me.cmbNetwork = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btntokenDistribute)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 286)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 119)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manual Token Distribution"
        '
        'btntokenDistribute
        '
        Me.btntokenDistribute.Location = New System.Drawing.Point(39, 44)
        Me.btntokenDistribute.Name = "btntokenDistribute"
        Me.btntokenDistribute.Size = New System.Drawing.Size(468, 45)
        Me.btntokenDistribute.TabIndex = 0
        Me.btntokenDistribute.Text = "Run"
        Me.btntokenDistribute.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btndeployToken)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 107)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 119)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Deploy Twistcode Token (Disabled If Deployed)"
        '
        'btndeployToken
        '
        Me.btndeployToken.Location = New System.Drawing.Point(37, 44)
        Me.btndeployToken.Name = "btndeployToken"
        Me.btndeployToken.Size = New System.Drawing.Size(470, 45)
        Me.btndeployToken.TabIndex = 0
        Me.btndeployToken.Text = "Run"
        Me.btndeployToken.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btntimelockContract)
        Me.GroupBox3.Location = New System.Drawing.Point(27, 485)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(544, 119)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Deploy Timelock Contract"
        '
        'btntimelockContract
        '
        Me.btntimelockContract.Location = New System.Drawing.Point(39, 44)
        Me.btntimelockContract.Name = "btntimelockContract"
        Me.btntimelockContract.Size = New System.Drawing.Size(468, 45)
        Me.btntimelockContract.TabIndex = 0
        Me.btntimelockContract.Text = "Run"
        Me.btntimelockContract.UseVisualStyleBackColor = True
        '
        'lblNetwork
        '
        Me.lblNetwork.AutoSize = True
        Me.lblNetwork.Location = New System.Drawing.Point(22, 25)
        Me.lblNetwork.Name = "lblNetwork"
        Me.lblNetwork.Size = New System.Drawing.Size(96, 25)
        Me.lblNetwork.TabIndex = 11
        Me.lblNetwork.Text = "Network:"
        '
        'cmbNetwork
        '
        Me.cmbNetwork.FormattingEnabled = True
        Me.cmbNetwork.Location = New System.Drawing.Point(144, 22)
        Me.cmbNetwork.Name = "cmbNetwork"
        Me.cmbNetwork.Size = New System.Drawing.Size(247, 33)
        Me.cmbNetwork.TabIndex = 12
        '
        'MasterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 638)
        Me.Controls.Add(Me.lblNetwork)
        Me.Controls.Add(Me.cmbNetwork)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "MasterForm"
        Me.Text = "TwistCode Control Panel"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btntokenDistribute As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btndeployToken As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btntimelockContract As Button
    Friend WithEvents lblNetwork As Label
    Friend WithEvents cmbNetwork As ComboBox
End Class
