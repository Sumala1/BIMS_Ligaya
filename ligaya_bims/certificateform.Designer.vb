<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class certificateform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(certificateform))
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.panelFormFields = New System.Windows.Forms.Panel()
        Me.GroupBoxStatus = New System.Windows.Forms.GroupBox()
        Me.rbMarried = New System.Windows.Forms.RadioButton()
        Me.rbSingle = New System.Windows.Forms.RadioButton()
        Me.dtpIssuedDate = New System.Windows.Forms.DateTimePicker()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmbCertificateType = New System.Windows.Forms.ComboBox()
        Me.panelLeftHeader = New System.Windows.Forms.Panel()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.pnlPic = New System.Windows.Forms.Panel()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.panelRightHeader = New System.Windows.Forms.Panel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.panelMain.SuspendLayout()
        Me.panelLeft.SuspendLayout()
        Me.panelFormFields.SuspendLayout()
        Me.GroupBoxStatus.SuspendLayout()
        Me.panelLeftHeader.SuspendLayout()
        Me.panelRight.SuspendLayout()
        Me.panelButtons.SuspendLayout()
        Me.panelRightHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.panelLeft)
        Me.panelMain.Controls.Add(Me.panelRight)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Margin = New System.Windows.Forms.Padding(2)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(745, 611)
        Me.panelMain.TabIndex = 0
        '
        'panelLeft
        '
        Me.panelLeft.BackColor = System.Drawing.Color.White
        Me.panelLeft.Controls.Add(Me.panelFormFields)
        Me.panelLeft.Controls.Add(Me.panelLeftHeader)
        Me.panelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeft.Location = New System.Drawing.Point(0, 0)
        Me.panelLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.panelLeft.Name = "panelLeft"
        Me.panelLeft.Size = New System.Drawing.Size(375, 611)
        Me.panelLeft.TabIndex = 0
        '
        'panelFormFields
        '
        Me.panelFormFields.Controls.Add(Me.GroupBoxStatus)
        Me.panelFormFields.Controls.Add(Me.dtpIssuedDate)
        Me.panelFormFields.Controls.Add(Me.txtPurpose)
        Me.panelFormFields.Controls.Add(Me.txtAddress)
        Me.panelFormFields.Controls.Add(Me.txtAge)
        Me.panelFormFields.Controls.Add(Me.txtName)
        Me.panelFormFields.Controls.Add(Me.cmbCertificateType)
        Me.panelFormFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelFormFields.Location = New System.Drawing.Point(0, 41)
        Me.panelFormFields.Margin = New System.Windows.Forms.Padding(2)
        Me.panelFormFields.Name = "panelFormFields"
        Me.panelFormFields.Padding = New System.Windows.Forms.Padding(15, 16, 15, 16)
        Me.panelFormFields.Size = New System.Drawing.Size(375, 570)
        Me.panelFormFields.TabIndex = 1
        '
        'GroupBoxStatus
        '
        Me.GroupBoxStatus.Controls.Add(Me.rbMarried)
        Me.GroupBoxStatus.Controls.Add(Me.rbSingle)
        Me.GroupBoxStatus.Location = New System.Drawing.Point(114, 109)
        Me.GroupBoxStatus.Name = "GroupBoxStatus"
        Me.GroupBoxStatus.Size = New System.Drawing.Size(200, 36)
        Me.GroupBoxStatus.TabIndex = 8
        Me.GroupBoxStatus.TabStop = False
        Me.GroupBoxStatus.Text = "GroupBox1"
        '
        'rbMarried
        '
        Me.rbMarried.AutoSize = True
        Me.rbMarried.Location = New System.Drawing.Point(96, 14)
        Me.rbMarried.Margin = New System.Windows.Forms.Padding(2)
        Me.rbMarried.Name = "rbMarried"
        Me.rbMarried.Size = New System.Drawing.Size(60, 17)
        Me.rbMarried.TabIndex = 4
        Me.rbMarried.Text = "Married"
        Me.rbMarried.UseVisualStyleBackColor = True
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.Checked = True
        Me.rbSingle.Location = New System.Drawing.Point(20, 14)
        Me.rbSingle.Margin = New System.Windows.Forms.Padding(2)
        Me.rbSingle.Name = "rbSingle"
        Me.rbSingle.Size = New System.Drawing.Size(54, 17)
        Me.rbSingle.TabIndex = 3
        Me.rbSingle.TabStop = True
        Me.rbSingle.Text = "Single"
        Me.rbSingle.UseVisualStyleBackColor = True
        '
        'dtpIssuedDate
        '
        Me.dtpIssuedDate.Location = New System.Drawing.Point(22, 244)
        Me.dtpIssuedDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpIssuedDate.Name = "dtpIssuedDate"
        Me.dtpIssuedDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpIssuedDate.TabIndex = 7
        '
        'txtPurpose
        '
        Me.txtPurpose.ForeColor = System.Drawing.Color.Silver
        Me.txtPurpose.Location = New System.Drawing.Point(22, 203)
        Me.txtPurpose.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(301, 20)
        Me.txtPurpose.TabIndex = 6
        Me.txtPurpose.Text = "Purpose/Application"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.SystemColors.Window
        Me.txtAddress.ForeColor = System.Drawing.Color.Silver
        Me.txtAddress.Location = New System.Drawing.Point(22, 162)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(301, 20)
        Me.txtAddress.TabIndex = 5
        Me.txtAddress.Text = "Address"
        '
        'txtAge
        '
        Me.txtAge.ForeColor = System.Drawing.Color.Silver
        Me.txtAge.Location = New System.Drawing.Point(22, 122)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(76, 20)
        Me.txtAge.TabIndex = 2
        Me.txtAge.Text = "Age"
        '
        'txtName
        '
        Me.txtName.ForeColor = System.Drawing.Color.Silver
        Me.txtName.Location = New System.Drawing.Point(22, 81)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(301, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = "Full Name"
        '
        'cmbCertificateType
        '
        Me.cmbCertificateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCertificateType.FormattingEnabled = True
        Me.cmbCertificateType.Items.AddRange(New Object() {"Residency", "Indigency", "Barangay Clearance"})
        Me.cmbCertificateType.Location = New System.Drawing.Point(22, 41)
        Me.cmbCertificateType.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbCertificateType.Name = "cmbCertificateType"
        Me.cmbCertificateType.Size = New System.Drawing.Size(301, 21)
        Me.cmbCertificateType.TabIndex = 0
        '
        'panelLeftHeader
        '
        Me.panelLeftHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.panelLeftHeader.Controls.Add(Me.Guna2Panel2)
        Me.panelLeftHeader.Controls.Add(Me.Panel2)
        Me.panelLeftHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelLeftHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelLeftHeader.Margin = New System.Windows.Forms.Padding(2)
        Me.panelLeftHeader.Name = "panelLeftHeader"
        Me.panelLeftHeader.Size = New System.Drawing.Size(375, 41)
        Me.panelLeftHeader.TabIndex = 0
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Location = New System.Drawing.Point(374, 24)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(200, 100)
        Me.Guna2Panel2.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(371, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 100)
        Me.Panel2.TabIndex = 3
        '
        'panelRight
        '
        Me.panelRight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelRight.Controls.Add(Me.pnlPic)
        Me.panelRight.Controls.Add(Me.panelButtons)
        Me.panelRight.Controls.Add(Me.panelRightHeader)
        Me.panelRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.panelRight.Location = New System.Drawing.Point(370, 0)
        Me.panelRight.Margin = New System.Windows.Forms.Padding(2)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Size = New System.Drawing.Size(375, 611)
        Me.panelRight.TabIndex = 1
        '
        'pnlPic
        '
        Me.pnlPic.Location = New System.Drawing.Point(4, 41)
        Me.pnlPic.Name = "pnlPic"
        Me.pnlPic.Size = New System.Drawing.Size(370, 532)
        Me.pnlPic.TabIndex = 4
        '
        'panelButtons
        '
        Me.panelButtons.Controls.Add(Me.btnPrint)
        Me.panelButtons.Controls.Add(Me.btnPreview)
        Me.panelButtons.Controls.Add(Me.btnPageSetup)
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelButtons.Location = New System.Drawing.Point(0, 570)
        Me.panelButtons.Margin = New System.Windows.Forms.Padding(2)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(375, 41)
        Me.panelButtons.TabIndex = 2
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(262, 8)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 24)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(150, 8)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 24)
        Me.btnPreview.TabIndex = 2
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnPageSetup
        '
        Me.btnPageSetup.Location = New System.Drawing.Point(38, 8)
        Me.btnPageSetup.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(75, 24)
        Me.btnPageSetup.TabIndex = 1
        Me.btnPageSetup.Text = "Page Setup"
        Me.btnPageSetup.UseVisualStyleBackColor = True
        '
        'panelRightHeader
        '
        Me.panelRightHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.panelRightHeader.Controls.Add(Me.Guna2Panel1)
        Me.panelRightHeader.Controls.Add(Me.Panel1)
        Me.panelRightHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelRightHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelRightHeader.Margin = New System.Windows.Forms.Padding(2)
        Me.panelRightHeader.Name = "panelRightHeader"
        Me.panelRightHeader.Size = New System.Drawing.Size(375, 41)
        Me.panelRightHeader.TabIndex = 0
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Location = New System.Drawing.Point(3, 38)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Guna2Panel1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(375, 450)
        Me.Panel1.TabIndex = 3
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'certificateform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 611)
        Me.Controls.Add(Me.panelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "certificateform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Certificate Form"
        Me.panelMain.ResumeLayout(False)
        Me.panelLeft.ResumeLayout(False)
        Me.panelFormFields.ResumeLayout(False)
        Me.panelFormFields.PerformLayout()
        Me.GroupBoxStatus.ResumeLayout(False)
        Me.GroupBoxStatus.PerformLayout()
        Me.panelLeftHeader.ResumeLayout(False)
        Me.panelRight.ResumeLayout(False)
        Me.panelButtons.ResumeLayout(False)
        Me.panelRightHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelMain As System.Windows.Forms.Panel
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents panelLeft As Panel
    Friend WithEvents panelFormFields As Panel
    Friend WithEvents dtpIssuedDate As DateTimePicker
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents rbMarried As RadioButton
    Friend WithEvents rbSingle As RadioButton
    Friend WithEvents txtAge As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents cmbCertificateType As ComboBox
    Friend WithEvents panelLeftHeader As Panel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelRight As Panel
    Friend WithEvents panelButtons As Panel
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnPageSetup As Button
    Friend WithEvents panelRightHeader As Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlPic As Panel
    Friend WithEvents GroupBoxStatus As GroupBox
End Class
