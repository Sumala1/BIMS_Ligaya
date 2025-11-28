<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class blotterrecordsrestore
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlPagination = New System.Windows.Forms.Panel()
        Me.btnNext = New ligaya_bims.RoundedButton()
        Me.lblPageNumber = New System.Windows.Forms.Label()
        Me.btnPrevious = New ligaya_bims.RoundedButton()
        Me.lblShowEntries = New System.Windows.Forms.Label()
        Me.dgvBlotterRecords = New System.Windows.Forms.DataGridView()
        Me.CaseNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComplainantName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComplainantAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComplaintName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncidentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationOfIncident = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvolvedPerson = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NarrativeIncident = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRestore = New System.Windows.Forms.DataGridViewImageColumn()
        Me.pnlContent.SuspendLayout()
        Me.pnlPagination.SuspendLayout()
        CType(Me.dgvBlotterRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dgvBlotterRecords)
        Me.pnlContent.Controls.Add(Me.pnlPagination)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20, 15, 20, 20)
        Me.pnlContent.Size = New System.Drawing.Size(1139, 569)
        Me.pnlContent.TabIndex = 4
        '
        'pnlPagination
        '
        Me.pnlPagination.Controls.Add(Me.btnNext)
        Me.pnlPagination.Controls.Add(Me.lblPageNumber)
        Me.pnlPagination.Controls.Add(Me.btnPrevious)
        Me.pnlPagination.Controls.Add(Me.lblShowEntries)
        Me.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPagination.Location = New System.Drawing.Point(20, 509)
        Me.pnlPagination.Name = "pnlPagination"
        Me.pnlPagination.Size = New System.Drawing.Size(1099, 40)
        Me.pnlPagination.TabIndex = 1
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnNext.BorderRadius = 15
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(1029, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(60, 25)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'lblPageNumber
        '
        Me.lblPageNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPageNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPageNumber.ForeColor = System.Drawing.Color.White
        Me.lblPageNumber.Location = New System.Drawing.Point(969, 8)
        Me.lblPageNumber.Name = "lblPageNumber"
        Me.lblPageNumber.Size = New System.Drawing.Size(30, 25)
        Me.lblPageNumber.TabIndex = 2
        Me.lblPageNumber.Text = "1"
        Me.lblPageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnPrevious.BorderRadius = 15
        Me.btnPrevious.FlatAppearance.BorderSize = 0
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrevious.ForeColor = System.Drawing.Color.White
        Me.btnPrevious.Location = New System.Drawing.Point(909, 8)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(60, 25)
        Me.btnPrevious.TabIndex = 1
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'lblShowEntries
        '
        Me.lblShowEntries.AutoSize = True
        Me.lblShowEntries.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblShowEntries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblShowEntries.Location = New System.Drawing.Point(0, 13)
        Me.lblShowEntries.Name = "lblShowEntries"
        Me.lblShowEntries.Size = New System.Drawing.Size(53, 15)
        Me.lblShowEntries.TabIndex = 0
        Me.lblShowEntries.Text = "Showing"
        '
        'dgvBlotterRecords
        '
        Me.dgvBlotterRecords.AllowUserToAddRows = False
        Me.dgvBlotterRecords.AllowUserToDeleteRows = False
        Me.dgvBlotterRecords.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvBlotterRecords.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBlotterRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBlotterRecords.BackgroundColor = System.Drawing.Color.White
        Me.dgvBlotterRecords.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBlotterRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBlotterRecords.ColumnHeadersHeight = 45
        Me.dgvBlotterRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBlotterRecords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CaseNumber, Me.ComplainantName, Me.ComplainantAddress, Me.ComplaintName, Me.IncidentDate, Me.LocationOfIncident, Me.InvolvedPerson, Me.NarrativeIncident, Me.colRestore})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBlotterRecords.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBlotterRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBlotterRecords.EnableHeadersVisualStyles = False
        Me.dgvBlotterRecords.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.dgvBlotterRecords.Location = New System.Drawing.Point(20, 15)
        Me.dgvBlotterRecords.MultiSelect = False
        Me.dgvBlotterRecords.Name = "dgvBlotterRecords"
        Me.dgvBlotterRecords.ReadOnly = True
        Me.dgvBlotterRecords.RowHeadersVisible = False
        Me.dgvBlotterRecords.RowHeadersWidth = 51
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.dgvBlotterRecords.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBlotterRecords.RowTemplate.Height = 40
        Me.dgvBlotterRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBlotterRecords.Size = New System.Drawing.Size(1099, 494)
        Me.dgvBlotterRecords.TabIndex = 2
        '
        'CaseNumber
        '
        Me.CaseNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.CaseNumber.HeaderText = "Case #"
        Me.CaseNumber.MinimumWidth = 90
        Me.CaseNumber.Name = "CaseNumber"
        Me.CaseNumber.ReadOnly = True
        Me.CaseNumber.Width = 90
        '
        'ComplainantName
        '
        Me.ComplainantName.HeaderText = "Complainant Name"
        Me.ComplainantName.MinimumWidth = 140
        Me.ComplainantName.Name = "ComplainantName"
        Me.ComplainantName.ReadOnly = True
        '
        'ComplainantAddress
        '
        Me.ComplainantAddress.HeaderText = "Complainant Address"
        Me.ComplainantAddress.MinimumWidth = 150
        Me.ComplainantAddress.Name = "ComplainantAddress"
        Me.ComplainantAddress.ReadOnly = True
        '
        'ComplaintName
        '
        Me.ComplaintName.HeaderText = "Complaint Details"
        Me.ComplaintName.MinimumWidth = 160
        Me.ComplaintName.Name = "ComplaintName"
        Me.ComplaintName.ReadOnly = True
        '
        'IncidentDate
        '
        DataGridViewCellStyle3.Format = "MMM dd, yyyy hh:mm tt"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.IncidentDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.IncidentDate.HeaderText = "Incident Date/Time"
        Me.IncidentDate.MinimumWidth = 140
        Me.IncidentDate.Name = "IncidentDate"
        Me.IncidentDate.ReadOnly = True
        '
        'LocationOfIncident
        '
        Me.LocationOfIncident.HeaderText = "Location"
        Me.LocationOfIncident.MinimumWidth = 130
        Me.LocationOfIncident.Name = "LocationOfIncident"
        Me.LocationOfIncident.ReadOnly = True
        '
        'InvolvedPerson
        '
        Me.InvolvedPerson.HeaderText = "Involved Person(s)"
        Me.InvolvedPerson.MinimumWidth = 140
        Me.InvolvedPerson.Name = "InvolvedPerson"
        Me.InvolvedPerson.ReadOnly = True
        '
        'NarrativeIncident
        '
        Me.NarrativeIncident.HeaderText = "Narrative"
        Me.NarrativeIncident.MinimumWidth = 180
        Me.NarrativeIncident.Name = "NarrativeIncident"
        Me.NarrativeIncident.ReadOnly = True
        '
        'colRestore
        '
        Me.colRestore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colRestore.HeaderText = "Restore"
        Me.colRestore.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.colRestore.MinimumWidth = 60
        Me.colRestore.Name = "colRestore"
        Me.colRestore.ReadOnly = True
        Me.colRestore.ToolTipText = "Restore record"
        Me.colRestore.Width = 80
        '
        'blotterrecordsrestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 569)
        Me.Controls.Add(Me.pnlContent)
        Me.Name = "blotterrecordsrestore"
        Me.Text = "blotterrecordsrestore"
        Me.pnlContent.ResumeLayout(False)
        Me.pnlPagination.ResumeLayout(False)
        Me.pnlPagination.PerformLayout()
        CType(Me.dgvBlotterRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlContent As Panel
    Private WithEvents pnlPagination As Panel
    Private WithEvents btnNext As RoundedButton
    Private WithEvents lblPageNumber As Label
    Private WithEvents btnPrevious As RoundedButton
    Private WithEvents lblShowEntries As Label
    Friend WithEvents dgvBlotterRecords As DataGridView
    Friend WithEvents CaseNumber As DataGridViewTextBoxColumn
    Friend WithEvents ComplainantName As DataGridViewTextBoxColumn
    Friend WithEvents ComplainantAddress As DataGridViewTextBoxColumn
    Friend WithEvents ComplaintName As DataGridViewTextBoxColumn
    Friend WithEvents IncidentDate As DataGridViewTextBoxColumn
    Friend WithEvents LocationOfIncident As DataGridViewTextBoxColumn
    Friend WithEvents InvolvedPerson As DataGridViewTextBoxColumn
    Friend WithEvents NarrativeIncident As DataGridViewTextBoxColumn
    Friend WithEvents colRestore As DataGridViewImageColumn
End Class
