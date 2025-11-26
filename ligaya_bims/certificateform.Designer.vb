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
        Me.certSC = New System.Windows.Forms.PictureBox()
        Me.certCC = New System.Windows.Forms.PictureBox()
        Me.certAnnual = New System.Windows.Forms.PictureBox()
        Me.certResidency = New System.Windows.Forms.PictureBox()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnSave = New ligaya_bims.RoundedButton()
        Me.btnCancel = New ligaya_bims.RoundedButton()
        Me.btnPrint = New ligaya_bims.RoundedButton()
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.panelFormFields = New System.Windows.Forms.Panel()
        Me.cmbCertificateType = New System.Windows.Forms.ComboBox()
        Me.panelLeftHeader = New System.Windows.Forms.Panel()
        Me.panelRightHeader = New System.Windows.Forms.Panel()
        Me.Guna2Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelMain.SuspendLayout()
        Me.panelRight.SuspendLayout()
        Me.pnlPic.SuspendLayout()
        CType(Me.certSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.certCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.certAnnual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.certResidency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelButtons.SuspendLayout()
        Me.panelLeft.SuspendLayout()
        Me.panelFormFields.SuspendLayout()
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
        Me.pnlPic.Controls.Add(Me.certSC)
        Me.pnlPic.Controls.Add(Me.certCC)
        Me.pnlPic.Controls.Add(Me.certAnnual)
        Me.pnlPic.Controls.Add(Me.certResidency)
        Me.pnlPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPic.Location = New System.Drawing.Point(0, 0)
        Me.pnlPic.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlPic.Name = "pnlPic"
        Me.pnlPic.Size = New System.Drawing.Size(1391, 993)
        Me.pnlPic.TabIndex = 4
        '
        'certSC
        '
        Me.certSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.certSC.Image = Global.ligaya_bims.My.Resources.Resources.CSC_2
        Me.certSC.Location = New System.Drawing.Point(0, 0)
        Me.certSC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.certSC.Name = "certSC"
        Me.certSC.Size = New System.Drawing.Size(1391, 993)
        Me.certSC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.certSC.TabIndex = 3
        Me.certSC.TabStop = False
        Me.certSC.Visible = False
        '
        'certCC
        '
        Me.certCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.certCC.Image = Global.ligaya_bims.My.Resources.Resources.CC_21
        Me.certCC.Location = New System.Drawing.Point(0, 0)
        Me.certCC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.certCC.Name = "certCC"
        Me.certCC.Size = New System.Drawing.Size(1391, 993)
        Me.certCC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.certCC.TabIndex = 2
        Me.certCC.TabStop = False
        Me.certCC.Visible = False
        '
        'certAnnual
        '
        Me.certAnnual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.certAnnual.Image = Global.ligaya_bims.My.Resources.Resources.CAI_2
        Me.certAnnual.Location = New System.Drawing.Point(0, 0)
        Me.certAnnual.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.certAnnual.Name = "certAnnual"
        Me.certAnnual.Size = New System.Drawing.Size(1391, 993)
        Me.certAnnual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.certAnnual.TabIndex = 1
        Me.certAnnual.TabStop = False
        Me.certAnnual.Visible = False
        '
        'certResidency
        '
        Me.certResidency.Dock = System.Windows.Forms.DockStyle.Fill
        Me.certResidency.Image = Global.ligaya_bims.My.Resources.Resources.CR_21
        Me.certResidency.Location = New System.Drawing.Point(0, 0)
        Me.certResidency.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.certResidency.Name = "certResidency"
        Me.certResidency.Size = New System.Drawing.Size(1391, 993)
        Me.certResidency.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.certResidency.TabIndex = 0
        Me.certResidency.TabStop = False
        Me.certResidency.Visible = False
        '
        'panelButtons
        '
        Me.panelButtons.BackColor = System.Drawing.Color.White
        Me.panelButtons.Controls.Add(Me.btnSave)
        Me.panelButtons.Controls.Add(Me.btnCancel)
        Me.panelButtons.Controls.Add(Me.btnPrint)
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
        'PrintDocument1
        '
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
        CType(Me.certSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.certCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.certAnnual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.certResidency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelButtons.ResumeLayout(False)
        Me.panelLeft.ResumeLayout(False)
        Me.panelFormFields.ResumeLayout(False)
        Me.panelFormFields.PerformLayout()
        Me.panelRightHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelMain As System.Windows.Forms.Panel
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents panelLeft As System.Windows.Forms.Panel
    Friend WithEvents panelFormFields As System.Windows.Forms.Panel
    Friend WithEvents cmbCertificateType As ComboBox
    Friend WithEvents panelLeftHeader As System.Windows.Forms.Panel
    Friend WithEvents panelRight As System.Windows.Forms.Panel
    Friend WithEvents panelButtons As System.Windows.Forms.Panel
    Friend WithEvents btnSave As ligaya_bims.RoundedButton
    Friend WithEvents btnPrint As ligaya_bims.RoundedButton
    Friend WithEvents panelRightHeader As System.Windows.Forms.Panel
    Friend WithEvents Guna2Panel1 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlPic As System.Windows.Forms.Panel
    Friend WithEvents certResidency As PictureBox
    Friend WithEvents certAnnual As PictureBox
    Friend WithEvents certCC As PictureBox
    Friend WithEvents certSC As PictureBox
    Friend WithEvents btnCancel As ligaya_bims.RoundedButton
    Friend WithEvents Label1 As Label
End Class
