<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TokenDistributor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TokenDistributor))
        Me.btnDeploy = New System.Windows.Forms.Button()
        Me.lsConsole = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtfile = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.rbBulkTransfer = New System.Windows.Forms.RadioButton()
        Me.rbSingleTransfer = New System.Windows.Forms.RadioButton()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDeploy
        '
        Me.btnDeploy.Location = New System.Drawing.Point(12, 468)
        Me.btnDeploy.Name = "btnDeploy"
        Me.btnDeploy.Size = New System.Drawing.Size(236, 50)
        Me.btnDeploy.TabIndex = 12
        Me.btnDeploy.Text = "Transfer"
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
        Me.lsConsole.Location = New System.Drawing.Point(12, 536)
        Me.lsConsole.Name = "lsConsole"
        Me.lsConsole.Size = New System.Drawing.Size(1198, 329)
        Me.lsConsole.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Deployed Token Address:"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(287, 22)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(547, 31)
        Me.txtAddress.TabIndex = 1
        Me.txtAddress.Text = "<pending deployment>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtfile)
        Me.GroupBox1.Controls.Add(Me.btnSelect)
        Me.GroupBox1.Controls.Add(Me.rbBulkTransfer)
        Me.GroupBox1.Controls.Add(Me.rbSingleTransfer)
        Me.GroupBox1.Controls.Add(Me.txtTo)
        Me.GroupBox1.Controls.Add(Me.txtNum)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1198, 333)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Action"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 25)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Select CSV File:"
        '
        'txtfile
        '
        Me.txtfile.Location = New System.Drawing.Point(114, 279)
        Me.txtfile.Name = "txtfile"
        Me.txtfile.ReadOnly = True
        Me.txtfile.Size = New System.Drawing.Size(732, 31)
        Me.txtfile.TabIndex = 10
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(852, 277)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(47, 42)
        Me.btnSelect.TabIndex = 11
        Me.btnSelect.Text = "..."
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'rbBulkTransfer
        '
        Me.rbBulkTransfer.AutoSize = True
        Me.rbBulkTransfer.Location = New System.Drawing.Point(39, 196)
        Me.rbBulkTransfer.Name = "rbBulkTransfer"
        Me.rbBulkTransfer.Size = New System.Drawing.Size(171, 29)
        Me.rbBulkTransfer.TabIndex = 8
        Me.rbBulkTransfer.TabStop = True
        Me.rbBulkTransfer.Text = "Bulk Transfer"
        Me.rbBulkTransfer.UseVisualStyleBackColor = True
        '
        'rbSingleTransfer
        '
        Me.rbSingleTransfer.AutoSize = True
        Me.rbSingleTransfer.Location = New System.Drawing.Point(39, 44)
        Me.rbSingleTransfer.Name = "rbSingleTransfer"
        Me.rbSingleTransfer.Size = New System.Drawing.Size(189, 29)
        Me.rbSingleTransfer.TabIndex = 3
        Me.rbSingleTransfer.TabStop = True
        Me.rbSingleTransfer.Text = "Single Transfer"
        Me.rbSingleTransfer.UseVisualStyleBackColor = True
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(299, 92)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(547, 31)
        Me.txtTo.TabIndex = 5
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(299, 137)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(279, 31)
        Me.txtNum.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Amount:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Address To Send:"
        '
        'TokenDistributor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 883)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lsConsole)
        Me.Controls.Add(Me.btnDeploy)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TokenDistributor"
        Me.Text = "TwistCode Token Distributor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDeploy As Button
    Friend WithEvents lsConsole As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSelect As Button
    Friend WithEvents rbBulkTransfer As RadioButton
    Friend WithEvents rbSingleTransfer As RadioButton
    Friend WithEvents txtTo As TextBox
    Friend WithEvents txtNum As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtfile As TextBox
End Class
