Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class certificateform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(certificateform))
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.pnlPic = New System.Windows.Forms.Panel()
        Me.previewControl = New System.Windows.Forms.PrintPreviewControl()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnPreview = New ligaya_bims.RoundedButton()
        Me.btnSave = New ligaya_bims.RoundedButton()
        Me.btnCancel = New ligaya_bims.RoundedButton()
        Me.btnPrint = New ligaya_bims.RoundedButton()
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.panelFormFields = New System.Windows.Forms.Panel()
        Me.layoutFields = New System.Windows.Forms.TableLayoutPanel()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtParent = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtRequester = New System.Windows.Forms.TextBox()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.txtDay = New System.Windows.Forms.TextBox()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.cmbCertificateType = New System.Windows.Forms.ComboBox()
        Me.panelLeftHeader = New System.Windows.Forms.Panel()
        Me.panelRightHeader = New System.Windows.Forms.Panel()
        Me.Guna2Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.doc = New System.Drawing.Printing.PrintDocument()
        Me.previewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelMain.SuspendLayout()
        Me.panelRight.SuspendLayout()
        Me.pnlPic.SuspendLayout()
        Me.panelButtons.SuspendLayout()
        Me.panelLeft.SuspendLayout()
        Me.panelFormFields.SuspendLayout()
        Me.layoutFields.SuspendLayout()
        Me.panelRightHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.White
        Me.panelMain.Controls.Add(Me.panelRight)
        Me.panelMain.Controls.Add(Me.panelLeft)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(1924, 1055)
        Me.panelMain.TabIndex = 0
        '
        'panelRight
        '
        Me.panelRight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelRight.Controls.Add(Me.pnlPic)
        Me.panelRight.Controls.Add(Me.panelButtons)
        Me.panelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelRight.Location = New System.Drawing.Point(533, 0)
        Me.panelRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panelRight.MinimumSize = New System.Drawing.Size(667, 0)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Size = New System.Drawing.Size(1391, 1055)
        Me.panelRight.TabIndex = 1
        '
        'pnlPic
        '
        Me.pnlPic.BackColor = System.Drawing.Color.White
        Me.pnlPic.Controls.Add(Me.previewControl)
        Me.pnlPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPic.Location = New System.Drawing.Point(0, 0)
        Me.pnlPic.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlPic.Name = "pnlPic"
        Me.pnlPic.Size = New System.Drawing.Size(1391, 993)
        Me.pnlPic.TabIndex = 4
        '
        'previewControl
        '
        Me.previewControl.BackColor = System.Drawing.Color.White
        Me.previewControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.previewControl.Document = Me.doc
        Me.previewControl.Location = New System.Drawing.Point(0, 0)
        Me.previewControl.Margin = New System.Windows.Forms.Padding(4)
        Me.previewControl.Name = "previewControl"
        Me.previewControl.Size = New System.Drawing.Size(1391, 993)
        Me.previewControl.TabIndex = 4
        Me.previewControl.Zoom = 1.0R
        'panelButtons
        '
        Me.panelButtons.BackColor = System.Drawing.Color.White
        Me.panelButtons.Controls.Add(Me.btnPreview)
        Me.panelButtons.Controls.Add(Me.btnSave)
        Me.panelButtons.Controls.Add(Me.btnCancel)
        Me.panelButtons.Controls.Add(Me.btnPrint)
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnPreview.BorderRadius = 15
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPreview.ForeColor = System.Drawing.Color.White
        Me.btnPreview.Location = New System.Drawing.Point(135, 12)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(133, 37)
        Me.btnPreview.TabIndex = 3
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        Me.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelButtons.Location = New System.Drawing.Point(0, 993)
        Me.panelButtons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(1391, 62)
        Me.panelButtons.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.btnSave.BorderRadius = 15
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(297, 12)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(133, 37)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnCancel.BorderRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(457, 12)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(133, 37)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.btnPrint.BorderRadius = 15
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(617, 12)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(133, 37)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'panelLeft
        '
        Me.panelLeft.BackColor = System.Drawing.Color.White
        Me.panelLeft.Controls.Add(Me.panelFormFields)
        Me.panelLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelLeft.Location = New System.Drawing.Point(0, 0)
        Me.panelLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panelLeft.MinimumSize = New System.Drawing.Size(467, 0)
        Me.panelLeft.Name = "panelLeft"
        Me.panelLeft.Size = New System.Drawing.Size(533, 1055)
        Me.panelLeft.TabIndex = 0
        '
        'panelFormFields
        '
        Me.panelFormFields.BackColor = System.Drawing.Color.White
        Me.panelFormFields.Controls.Add(Me.layoutFields)
        Me.panelFormFields.Controls.Add(Me.Label1)
        Me.panelFormFields.Controls.Add(Me.cmbCertificateType)
        Me.panelFormFields.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelFormFields.Location = New System.Drawing.Point(0, 0)
        Me.panelFormFields.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panelFormFields.Name = "panelFormFields"
        Me.panelFormFields.Padding = New System.Windows.Forms.Padding(20, 20, 20, 20)
        Me.panelFormFields.Size = New System.Drawing.Size(533, 1055)
        Me.panelFormFields.TabIndex = 1
        '
        'layoutFields
        '
        Me.layoutFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.layoutFields.AutoSize = True
        Me.layoutFields.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.layoutFields.ColumnCount = 2
        Me.layoutFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.layoutFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutFields.Controls.Add(Me.txtName, 1, 0)
        Me.layoutFields.Controls.Add(Me.txtStatus, 1, 1)
        Me.layoutFields.Controls.Add(Me.txtParent, 1, 2)
        Me.layoutFields.Controls.Add(Me.txtAddress, 1, 3)
        Me.layoutFields.Controls.Add(Me.txtRequester, 1, 4)
        Me.layoutFields.Controls.Add(Me.txtPurpose, 1, 5)
        Me.layoutFields.Controls.Add(Me.txtDay, 1, 6)
        Me.layoutFields.Controls.Add(Me.txtMonth, 1, 7)
        Me.layoutFields.Controls.Add(Me.txtYear, 1, 8)
        Dim lblName As New System.Windows.Forms.Label()
        lblName.AutoSize = True
        lblName.Text = "Full Name:"
        lblName.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblName, 0, 0)
        Dim lblStatus As New System.Windows.Forms.Label()
        lblStatus.AutoSize = True
        lblStatus.Text = "Status:"
        lblStatus.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblStatus, 0, 1)
        Dim lblParent As New System.Windows.Forms.Label()
        lblParent.AutoSize = True
        lblParent.Text = "Parent:"
        lblParent.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblParent, 0, 2)
        Dim lblAddress As New System.Windows.Forms.Label()
        lblAddress.AutoSize = True
        lblAddress.Text = "Address:"
        lblAddress.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblAddress, 0, 3)
        Dim lblRequester As New System.Windows.Forms.Label()
        lblRequester.AutoSize = True
        lblRequester.Text = "Requester:"
        lblRequester.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblRequester, 0, 4)
        Dim lblPurpose As New System.Windows.Forms.Label()
        lblPurpose.AutoSize = True
        lblPurpose.Text = "Purpose:"
        lblPurpose.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblPurpose, 0, 5)
        Dim lblDay As New System.Windows.Forms.Label()
        lblDay.AutoSize = True
        lblDay.Text = "Day:"
        lblDay.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblDay, 0, 6)
        Dim lblMonth As New System.Windows.Forms.Label()
        lblMonth.AutoSize = True
        lblMonth.Text = "Month:"
        lblMonth.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblMonth, 0, 7)
        Dim lblYear As New System.Windows.Forms.Label()
        lblYear.AutoSize = True
        lblYear.Text = "Year:"
        lblYear.Margin = New System.Windows.Forms.Padding(0, 6, 8, 0)
        Me.layoutFields.Controls.Add(lblYear, 0, 8)
        Me.layoutFields.Location = New System.Drawing.Point(29, 130)
        Me.layoutFields.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.layoutFields.Name = "layoutFields"
        Me.layoutFields.RowCount = 9
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutFields.Size = New System.Drawing.Size(475, 252)
        Me.layoutFields.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.Location = New System.Drawing.Point(139, 3)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(333, 22)
        Me.txtName.TabIndex = 0
        '
        'txtStatus
        '
        Me.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStatus.Location = New System.Drawing.Point(139, 38)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(333, 22)
        Me.txtStatus.TabIndex = 1
        '
        'txtParent
        '
        Me.txtParent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtParent.Location = New System.Drawing.Point(139, 73)
        Me.txtParent.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtParent.Name = "txtParent"
        Me.txtParent.Size = New System.Drawing.Size(333, 22)
        Me.txtParent.TabIndex = 2
        '
        'txtAddress
        '
        Me.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAddress.Location = New System.Drawing.Point(139, 108)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(333, 22)
        Me.txtAddress.TabIndex = 3
        '
        'txtRequester
        '
        Me.txtRequester.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRequester.Location = New System.Drawing.Point(139, 143)
        Me.txtRequester.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtRequester.Name = "txtRequester"
        Me.txtRequester.Size = New System.Drawing.Size(333, 22)
        Me.txtRequester.TabIndex = 4
        '
        'txtPurpose
        '
        Me.txtPurpose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPurpose.Location = New System.Drawing.Point(139, 178)
        Me.txtPurpose.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(333, 22)
        Me.txtPurpose.TabIndex = 5
        '
        'txtDay
        '
        Me.txtDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDay.Location = New System.Drawing.Point(139, 213)
        Me.txtDay.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(333, 22)
        Me.txtDay.TabIndex = 6
        '
        'txtMonth
        '
        Me.txtMonth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMonth.Location = New System.Drawing.Point(139, 248)
        Me.txtMonth.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(333, 22)
        Me.txtMonth.TabIndex = 7
        '
        'txtYear
        '
        Me.txtYear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtYear.Location = New System.Drawing.Point(139, 283)
        Me.txtYear.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(333, 22)
        Me.txtYear.TabIndex = 8
        '
        'cmbCertificateType
        '
        Me.cmbCertificateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCertificateType.FormattingEnabled = True
        Me.cmbCertificateType.Items.AddRange(New Object() {"Certificate of Residency", "Certificate of Annual Income", "Certificate of Cohabitation", "Certificate of Senior Citizen"})
        Me.cmbCertificateType.Location = New System.Drawing.Point(29, 80)
        Me.cmbCertificateType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCertificateType.Name = "cmbCertificateType"
        Me.cmbCertificateType.Size = New System.Drawing.Size(400, 24)
        Me.cmbCertificateType.TabIndex = 0
        '
        'panelLeftHeader
        '
        Me.panelLeftHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelLeftHeader.Name = "panelLeftHeader"
        Me.panelLeftHeader.Size = New System.Drawing.Size(200, 100)
        Me.panelLeftHeader.TabIndex = 0
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
        'doc
        '
        '
        'previewDialog
        '
        Me.previewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.previewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.previewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.previewDialog.Document = Me.doc
        Me.previewDialog.Enabled = True
        Me.previewDialog.Icon = CType(resources.GetObject("previewDialog.Icon"), System.Drawing.Icon)
        Me.previewDialog.Name = "previewDialog"
        Me.previewDialog.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Certificate:"
        '
        'certificateform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.panelMain)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(1594, 974)
        Me.Name = "certificateform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Certificate Form"
        Me.panelMain.ResumeLayout(False)
        Me.panelRight.ResumeLayout(False)
        Me.pnlPic.ResumeLayout(False)
        Me.panelButtons.ResumeLayout(False)
        Me.panelLeft.ResumeLayout(False)
        Me.panelFormFields.ResumeLayout(False)
        Me.panelFormFields.PerformLayout()
        Me.panelRightHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelMain As System.Windows.Forms.Panel
    Friend WithEvents doc As System.Drawing.Printing.PrintDocument
    Friend WithEvents previewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents panelLeft As System.Windows.Forms.Panel
    Friend WithEvents panelFormFields As System.Windows.Forms.Panel
    Friend WithEvents cmbCertificateType As ComboBox
    Friend WithEvents panelLeftHeader As System.Windows.Forms.Panel
    Friend WithEvents panelRight As System.Windows.Forms.Panel
    Friend WithEvents panelButtons As System.Windows.Forms.Panel
    Friend WithEvents btnPreview As ligaya_bims.RoundedButton
    Friend WithEvents btnSave As ligaya_bims.RoundedButton
    Friend WithEvents btnPrint As ligaya_bims.RoundedButton
    Friend WithEvents panelRightHeader As System.Windows.Forms.Panel
    Friend WithEvents Guna2Panel1 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlPic As System.Windows.Forms.Panel
    Friend WithEvents previewControl As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents btnCancel As ligaya_bims.RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents layoutFields As TableLayoutPanel
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents txtParent As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtRequester As TextBox
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents txtDay As TextBox
    Friend WithEvents txtMonth As TextBox
    Friend WithEvents txtYear As TextBox
End Class

