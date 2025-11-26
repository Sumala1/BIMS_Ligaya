Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reportsform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reportsform))
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.lblComplainantAddress = New System.Windows.Forms.Label()
        Me.txtComplainantAddress = New System.Windows.Forms.TextBox()
        Me.lblComplainantName = New System.Windows.Forms.Label()
        Me.txtComplainantName = New System.Windows.Forms.TextBox()
        Me.lblTypeOfIncident = New System.Windows.Forms.Label()
        Me.txtTypeOfIncident = New System.Windows.Forms.TextBox()
        Me.lblInclusive = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.lblExactLocation = New System.Windows.Forms.Label()
        Me.txtExactLocation = New System.Windows.Forms.TextBox()
        Me.lblInvolved = New System.Windows.Forms.Label()
        Me.txtInvolved = New System.Windows.Forms.TextBox()
        Me.lblNarrative = New System.Windows.Forms.Label()
        Me.txtNarrative = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New ligaya_bims.RoundedButton()
        Me.btnSavePdf = New ligaya_bims.RoundedButton()
        Me.btnCancel = New ligaya_bims.RoundedButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.panelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.panelMain.Controls.Add(Me.lblComplainantAddress)
        Me.panelMain.Controls.Add(Me.txtComplainantAddress)
        Me.panelMain.Controls.Add(Me.lblComplainantName)
        Me.panelMain.Controls.Add(Me.txtComplainantName)
        Me.panelMain.Controls.Add(Me.lblTypeOfIncident)
        Me.panelMain.Controls.Add(Me.txtTypeOfIncident)
        Me.panelMain.Controls.Add(Me.lblInclusive)
        Me.panelMain.Controls.Add(Me.dtpFrom)
        Me.panelMain.Controls.Add(Me.dtpTo)
        Me.panelMain.Controls.Add(Me.lblExactLocation)
        Me.panelMain.Controls.Add(Me.txtExactLocation)
        Me.panelMain.Controls.Add(Me.lblInvolved)
        Me.panelMain.Controls.Add(Me.txtInvolved)
        Me.panelMain.Controls.Add(Me.lblNarrative)
        Me.panelMain.Controls.Add(Me.txtNarrative)
        Me.panelMain.Controls.Add(Me.btnSubmit)
        Me.panelMain.Controls.Add(Me.btnSavePdf)
        Me.panelMain.Controls.Add(Me.btnCancel)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Padding = New System.Windows.Forms.Padding(10)
        Me.panelMain.Size = New System.Drawing.Size(600, 560)
        Me.panelMain.TabIndex = 0
        '
        'lblComplainantAddress
        '
        Me.lblComplainantAddress.AutoSize = True
        Me.lblComplainantAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblComplainantAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblComplainantAddress.Location = New System.Drawing.Point(35, 66)
        Me.lblComplainantAddress.Name = "lblComplainantAddress"
        Me.lblComplainantAddress.Size = New System.Drawing.Size(131, 15)
        Me.lblComplainantAddress.TabIndex = 0
        Me.lblComplainantAddress.Text = "Complainant's Address"
        '
        'txtComplainantAddress
        '
        Me.txtComplainantAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComplainantAddress.Location = New System.Drawing.Point(37, 84)
        Me.txtComplainantAddress.Name = "txtComplainantAddress"
        Me.txtComplainantAddress.Size = New System.Drawing.Size(525, 20)
        Me.txtComplainantAddress.TabIndex = 2
        '
        'lblComplainantName
        '
        Me.lblComplainantName.AutoSize = True
        Me.lblComplainantName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblComplainantName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblComplainantName.Location = New System.Drawing.Point(35, 14)
        Me.lblComplainantName.Name = "lblComplainantName"
        Me.lblComplainantName.Size = New System.Drawing.Size(120, 15)
        Me.lblComplainantName.TabIndex = 0
        Me.lblComplainantName.Text = "Complainant's Name"
        '
        'txtComplainantName
        '
        Me.txtComplainantName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComplainantName.Location = New System.Drawing.Point(37, 32)
        Me.txtComplainantName.Name = "txtComplainantName"
        Me.txtComplainantName.Size = New System.Drawing.Size(525, 20)
        Me.txtComplainantName.TabIndex = 1
        '
        'lblTypeOfIncident
        '
        Me.lblTypeOfIncident.AutoSize = True
        Me.lblTypeOfIncident.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTypeOfIncident.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblTypeOfIncident.Location = New System.Drawing.Point(35, 118)
        Me.lblTypeOfIncident.Name = "lblTypeOfIncident"
        Me.lblTypeOfIncident.Size = New System.Drawing.Size(97, 15)
        Me.lblTypeOfIncident.TabIndex = 0
        Me.lblTypeOfIncident.Text = "Type of Incident"
        '
        'txtTypeOfIncident
        '
        Me.txtTypeOfIncident.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTypeOfIncident.Location = New System.Drawing.Point(37, 136)
        Me.txtTypeOfIncident.Name = "txtTypeOfIncident"
        Me.txtTypeOfIncident.Size = New System.Drawing.Size(525, 20)
        Me.txtTypeOfIncident.TabIndex = 3
        '
        'lblInclusive
        '
        Me.lblInclusive.AutoSize = True
        Me.lblInclusive.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInclusive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblInclusive.Location = New System.Drawing.Point(35, 166)
        Me.lblInclusive.Name = "lblInclusive"
        Me.lblInclusive.Size = New System.Drawing.Size(198, 15)
        Me.lblInclusive.TabIndex = 0
        Me.lblInclusive.Text = "Inclusive Date and Time (From-To)"
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMMM dd, yyyy  hh:mm tt"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(37, 182)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(206, 20)
        Me.dtpFrom.TabIndex = 4
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMMM dd, yyyy  hh:mm tt"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(248, 182)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(206, 20)
        Me.dtpTo.TabIndex = 5
        '
        'lblExactLocation
        '
        Me.lblExactLocation.AutoSize = True
        Me.lblExactLocation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblExactLocation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblExactLocation.Location = New System.Drawing.Point(35, 214)
        Me.lblExactLocation.Name = "lblExactLocation"
        Me.lblExactLocation.Size = New System.Drawing.Size(151, 15)
        Me.lblExactLocation.TabIndex = 0
        Me.lblExactLocation.Text = "Exact Location of Incident"
        '
        'txtExactLocation
        '
        Me.txtExactLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExactLocation.Location = New System.Drawing.Point(37, 230)
        Me.txtExactLocation.Name = "txtExactLocation"
        Me.txtExactLocation.Size = New System.Drawing.Size(525, 20)
        Me.txtExactLocation.TabIndex = 6
        '
        'lblInvolved
        '
        Me.lblInvolved.AutoSize = True
        Me.lblInvolved.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInvolved.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblInvolved.Location = New System.Drawing.Point(35, 266)
        Me.lblInvolved.Name = "lblInvolved"
        Me.lblInvolved.Size = New System.Drawing.Size(146, 15)
        Me.lblInvolved.TabIndex = 0
        Me.lblInvolved.Text = "Involved Person / Details"
        '
        'txtInvolved
        '
        Me.txtInvolved.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvolved.Location = New System.Drawing.Point(37, 282)
        Me.txtInvolved.Name = "txtInvolved"
        Me.txtInvolved.Size = New System.Drawing.Size(525, 20)
        Me.txtInvolved.TabIndex = 7
        '
        'lblNarrative
        '
        Me.lblNarrative.AutoSize = True
        Me.lblNarrative.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNarrative.ForeColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.lblNarrative.Location = New System.Drawing.Point(35, 318)
        Me.lblNarrative.Name = "lblNarrative"
        Me.lblNarrative.Size = New System.Drawing.Size(124, 15)
        Me.lblNarrative.TabIndex = 0
        Me.lblNarrative.Text = "Narrative of Incident"
        '
        'txtNarrative
        '
        Me.txtNarrative.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNarrative.Location = New System.Drawing.Point(37, 334)
        Me.txtNarrative.Multiline = True
        Me.txtNarrative.Name = "txtNarrative"
        Me.txtNarrative.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNarrative.Size = New System.Drawing.Size(525, 160)
        Me.txtNarrative.TabIndex = 8
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnSubmit.BorderRadius = 15
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(435, 510)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(94, 26)
        Me.btnSubmit.TabIndex = 11
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'btnSavePdf
        '
        Me.btnSavePdf.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSavePdf.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.btnSavePdf.BorderRadius = 15
        Me.btnSavePdf.FlatAppearance.BorderSize = 0
        Me.btnSavePdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnSavePdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.btnSavePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePdf.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSavePdf.ForeColor = System.Drawing.Color.White
        Me.btnSavePdf.Location = New System.Drawing.Point(248, 510)
        Me.btnSavePdf.Name = "btnSavePdf"
        Me.btnSavePdf.Size = New System.Drawing.Size(110, 26)
        Me.btnSavePdf.TabIndex = 10
        Me.btnSavePdf.Text = "Save as PDF"
        Me.btnSavePdf.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.BorderRadius = 15
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(69, 510)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 26)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
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
        Me.PrintDialog1.UseEXDialog = True
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Word Documents|*.docx|All Files|*.*"
        '
        'reportsform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 560)
        Me.Controls.Add(Me.panelMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "reportsform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reports"
        Me.panelMain.ResumeLayout(False)
        Me.panelMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelMain As System.Windows.Forms.Panel
	Friend WithEvents lblComplainantName As System.Windows.Forms.Label
	Friend WithEvents txtComplainantName As System.Windows.Forms.TextBox
	Friend WithEvents lblComplainantAddress As System.Windows.Forms.Label
	Friend WithEvents txtComplainantAddress As System.Windows.Forms.TextBox
	Friend WithEvents lblTypeOfIncident As System.Windows.Forms.Label
	Friend WithEvents txtTypeOfIncident As System.Windows.Forms.TextBox
	Friend WithEvents lblInclusive As System.Windows.Forms.Label
	Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
	Friend WithEvents lblExactLocation As System.Windows.Forms.Label
	Friend WithEvents txtExactLocation As System.Windows.Forms.TextBox
	Friend WithEvents lblInvolved As System.Windows.Forms.Label
	Friend WithEvents txtInvolved As System.Windows.Forms.TextBox
	Friend WithEvents lblNarrative As System.Windows.Forms.Label
	Friend WithEvents txtNarrative As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As ligaya_bims.RoundedButton
    Friend WithEvents btnSavePdf As ligaya_bims.RoundedButton
Friend WithEvents btnSubmit As ligaya_bims.RoundedButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    


End Class
