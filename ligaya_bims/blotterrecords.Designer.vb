Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class blotterrecords
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlDataArea = New System.Windows.Forms.Panel()
        Me.pnlRightTable = New System.Windows.Forms.Panel()
        Me.dgvSchedule = New System.Windows.Forms.DataGridView()
        Me.pnlScheduleActionBackground = New ligaya_bims.RoundedPanel()
        Me.flpScheduleActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAddSchedule = New ligaya_bims.RoundedButton()
        Me.btnEditSchedule = New ligaya_bims.RoundedButton()
        Me.btnDeleteSchedule = New ligaya_bims.RoundedButton()
        Me.btnUpdateSettlementStatus = New ligaya_bims.RoundedButton()
        Me.pnlScheduleButtons = New System.Windows.Forms.Panel()
        Me.lblComplainantVsRespondent = New System.Windows.Forms.Label()
        Me.pnlLeftTable = New System.Windows.Forms.Panel()
        Me.dgvBlotterRecords = New System.Windows.Forms.DataGridView()
        Me.pnlBlotterButtons = New System.Windows.Forms.Panel()
        Me.lblBlotterTitle = New System.Windows.Forms.Label()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.btnAddNew = New ligaya_bims.RoundedButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlDataArea.SuspendLayout()
        Me.pnlRightTable.SuspendLayout()
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlScheduleActionBackground.SuspendLayout()
        Me.flpScheduleActions.SuspendLayout()
        Me.pnlScheduleButtons.SuspendLayout()
        Me.pnlLeftTable.SuspendLayout()
        CType(Me.dgvBlotterRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBlotterButtons.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.pnlDataArea)
        Me.pnlMain.Controls.Add(Me.pnlSearch)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1236, 850)
        Me.pnlMain.TabIndex = 0
        '
        'pnlDataArea
        '
        Me.pnlDataArea.Controls.Add(Me.pnlRightTable)
        Me.pnlDataArea.Controls.Add(Me.pnlLeftTable)
        Me.pnlDataArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataArea.Location = New System.Drawing.Point(0, 60)
        Me.pnlDataArea.Name = "pnlDataArea"
        Me.pnlDataArea.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlDataArea.Size = New System.Drawing.Size(1236, 790)
        Me.pnlDataArea.TabIndex = 2
        '
        'pnlRightTable
        '
        Me.pnlRightTable.Controls.Add(Me.dgvSchedule)
        Me.pnlRightTable.Controls.Add(Me.pnlScheduleActionBackground)
        Me.pnlRightTable.Controls.Add(Me.pnlScheduleButtons)
        Me.pnlRightTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRightTable.Location = New System.Drawing.Point(544, 10)
        Me.pnlRightTable.Name = "pnlRightTable"
        Me.pnlRightTable.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.pnlRightTable.Size = New System.Drawing.Size(672, 770)
        Me.pnlRightTable.TabIndex = 1
        '
        'dgvSchedule
        '
        Me.dgvSchedule.AllowUserToAddRows = False
        Me.dgvSchedule.AllowUserToDeleteRows = False
        Me.dgvSchedule.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvSchedule.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSchedule.BackgroundColor = System.Drawing.Color.White
        Me.dgvSchedule.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSchedule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSchedule.ColumnHeadersHeight = 45
        Me.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSchedule.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSchedule.EnableHeadersVisualStyles = False
        Me.dgvSchedule.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.dgvSchedule.Location = New System.Drawing.Point(10, 60)
        Me.dgvSchedule.MultiSelect = False
        Me.dgvSchedule.Name = "dgvSchedule"
        Me.dgvSchedule.ReadOnly = True
        Me.dgvSchedule.RowHeadersVisible = False
        Me.dgvSchedule.RowHeadersWidth = 51
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvSchedule.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSchedule.RowTemplate.Height = 40
        Me.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSchedule.Size = New System.Drawing.Size(662, 610)
        Me.dgvSchedule.TabIndex = 0
        '
        'pnlScheduleActionBackground
        '
        Me.pnlScheduleActionBackground.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlScheduleActionBackground.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.pnlScheduleActionBackground.BorderRadius = 25
        Me.pnlScheduleActionBackground.BorderThickness = 1
        Me.pnlScheduleActionBackground.Controls.Add(Me.flpScheduleActions)
        Me.pnlScheduleActionBackground.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlScheduleActionBackground.Location = New System.Drawing.Point(10, 670)
        Me.pnlScheduleActionBackground.Name = "pnlScheduleActionBackground"
        Me.pnlScheduleActionBackground.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlScheduleActionBackground.Size = New System.Drawing.Size(662, 100)
        Me.pnlScheduleActionBackground.TabIndex = 4
        '
        'flpScheduleActions
        '
        Me.flpScheduleActions.BackColor = System.Drawing.Color.Transparent
        Me.flpScheduleActions.Controls.Add(Me.btnAddSchedule)
        Me.flpScheduleActions.Controls.Add(Me.btnEditSchedule)
        Me.flpScheduleActions.Controls.Add(Me.btnDeleteSchedule)
        Me.flpScheduleActions.Controls.Add(Me.btnUpdateSettlementStatus)
        Me.flpScheduleActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpScheduleActions.Location = New System.Drawing.Point(15, 15)
        Me.flpScheduleActions.Name = "flpScheduleActions"
        Me.flpScheduleActions.Padding = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.flpScheduleActions.Size = New System.Drawing.Size(632, 70)
        Me.flpScheduleActions.TabIndex = 0
        Me.flpScheduleActions.WrapContents = False
        '
        'btnAddSchedule
        '
        Me.btnAddSchedule.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnAddSchedule.BorderRadius = 15
        Me.btnAddSchedule.FlatAppearance.BorderSize = 0
        Me.btnAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSchedule.ForeColor = System.Drawing.Color.White
        Me.btnAddSchedule.Location = New System.Drawing.Point(10, 10)
        Me.btnAddSchedule.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAddSchedule.Name = "btnAddSchedule"
        Me.btnAddSchedule.Size = New System.Drawing.Size(120, 40)
        Me.btnAddSchedule.TabIndex = 0
        Me.btnAddSchedule.Text = "ADD SCHEDULE"
        Me.btnAddSchedule.UseVisualStyleBackColor = False
        '
        'btnEditSchedule
        '
        Me.btnEditSchedule.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnEditSchedule.BorderRadius = 15
        Me.btnEditSchedule.FlatAppearance.BorderSize = 0
        Me.btnEditSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditSchedule.ForeColor = System.Drawing.Color.White
        Me.btnEditSchedule.Location = New System.Drawing.Point(140, 10)
        Me.btnEditSchedule.Margin = New System.Windows.Forms.Padding(5)
        Me.btnEditSchedule.Name = "btnEditSchedule"
        Me.btnEditSchedule.Size = New System.Drawing.Size(120, 40)
        Me.btnEditSchedule.TabIndex = 1
        Me.btnEditSchedule.Text = "EDIT SCHEDULE"
        Me.btnEditSchedule.UseVisualStyleBackColor = False
        '
        'btnDeleteSchedule
        '
        Me.btnDeleteSchedule.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnDeleteSchedule.BorderRadius = 15
        Me.btnDeleteSchedule.FlatAppearance.BorderSize = 0
        Me.btnDeleteSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSchedule.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteSchedule.ForeColor = System.Drawing.Color.White
        Me.btnDeleteSchedule.Location = New System.Drawing.Point(270, 10)
        Me.btnDeleteSchedule.Margin = New System.Windows.Forms.Padding(5)
        Me.btnDeleteSchedule.Name = "btnDeleteSchedule"
        Me.btnDeleteSchedule.Size = New System.Drawing.Size(120, 40)
        Me.btnDeleteSchedule.TabIndex = 2
        Me.btnDeleteSchedule.Text = "DELETE SCHEDULE"
        Me.btnDeleteSchedule.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDeleteSchedule.UseVisualStyleBackColor = False
        '
        'btnUpdateSettlementStatus
        '
        Me.btnUpdateSettlementStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnUpdateSettlementStatus.BorderRadius = 15
        Me.btnUpdateSettlementStatus.FlatAppearance.BorderSize = 0
        Me.btnUpdateSettlementStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateSettlementStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateSettlementStatus.ForeColor = System.Drawing.Color.White
        Me.btnUpdateSettlementStatus.Location = New System.Drawing.Point(400, 10)
        Me.btnUpdateSettlementStatus.Margin = New System.Windows.Forms.Padding(5)
        Me.btnUpdateSettlementStatus.Name = "btnUpdateSettlementStatus"
        Me.btnUpdateSettlementStatus.Size = New System.Drawing.Size(217, 40)
        Me.btnUpdateSettlementStatus.TabIndex = 3
        Me.btnUpdateSettlementStatus.Text = "UPDATE SETTLEMENT STATUS"
        Me.btnUpdateSettlementStatus.UseVisualStyleBackColor = False
        '
        'pnlScheduleButtons
        '
        Me.pnlScheduleButtons.BackColor = System.Drawing.Color.White
        Me.pnlScheduleButtons.Controls.Add(Me.lblComplainantVsRespondent)
        Me.pnlScheduleButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlScheduleButtons.Location = New System.Drawing.Point(10, 0)
        Me.pnlScheduleButtons.Name = "pnlScheduleButtons"
        Me.pnlScheduleButtons.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.pnlScheduleButtons.Size = New System.Drawing.Size(662, 60)
        Me.pnlScheduleButtons.TabIndex = 1
        '
        'lblComplainantVsRespondent
        '
        Me.lblComplainantVsRespondent.AutoSize = True
        Me.lblComplainantVsRespondent.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComplainantVsRespondent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblComplainantVsRespondent.Location = New System.Drawing.Point(0, 18)
        Me.lblComplainantVsRespondent.Name = "lblComplainantVsRespondent"
        Me.lblComplainantVsRespondent.Size = New System.Drawing.Size(214, 21)
        Me.lblComplainantVsRespondent.TabIndex = 4
        Me.lblComplainantVsRespondent.Text = "Complainant vs Respondent"
        '
        'pnlLeftTable
        '
        Me.pnlLeftTable.Controls.Add(Me.dgvBlotterRecords)
        Me.pnlLeftTable.Controls.Add(Me.pnlBlotterButtons)
        Me.pnlLeftTable.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftTable.Location = New System.Drawing.Point(20, 10)
        Me.pnlLeftTable.Name = "pnlLeftTable"
        Me.pnlLeftTable.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.pnlLeftTable.Size = New System.Drawing.Size(524, 770)
        Me.pnlLeftTable.TabIndex = 0
        '
        'dgvBlotterRecords
        '
        Me.dgvBlotterRecords.AllowUserToAddRows = False
        Me.dgvBlotterRecords.AllowUserToDeleteRows = False
        Me.dgvBlotterRecords.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvBlotterRecords.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBlotterRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBlotterRecords.BackgroundColor = System.Drawing.Color.White
        Me.dgvBlotterRecords.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBlotterRecords.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBlotterRecords.ColumnHeadersHeight = 45
        Me.dgvBlotterRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBlotterRecords.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBlotterRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBlotterRecords.EnableHeadersVisualStyles = False
        Me.dgvBlotterRecords.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.dgvBlotterRecords.Location = New System.Drawing.Point(0, 56)
        Me.dgvBlotterRecords.MultiSelect = False
        Me.dgvBlotterRecords.Name = "dgvBlotterRecords"
        Me.dgvBlotterRecords.ReadOnly = True
        Me.dgvBlotterRecords.RowHeadersVisible = False
        Me.dgvBlotterRecords.RowHeadersWidth = 51
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.dgvBlotterRecords.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBlotterRecords.RowTemplate.Height = 40
        Me.dgvBlotterRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBlotterRecords.Size = New System.Drawing.Size(514, 714)
        Me.dgvBlotterRecords.TabIndex = 0
        '
        'pnlBlotterButtons
        '
        Me.pnlBlotterButtons.BackColor = System.Drawing.Color.White
        Me.pnlBlotterButtons.Controls.Add(Me.lblBlotterTitle)
        Me.pnlBlotterButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBlotterButtons.Location = New System.Drawing.Point(0, 0)
        Me.pnlBlotterButtons.Name = "pnlBlotterButtons"
        Me.pnlBlotterButtons.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.pnlBlotterButtons.Size = New System.Drawing.Size(514, 56)
        Me.pnlBlotterButtons.TabIndex = 1
        '
        'lblBlotterTitle
        '
        Me.lblBlotterTitle.AutoSize = True
        Me.lblBlotterTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlotterTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblBlotterTitle.Location = New System.Drawing.Point(0, 16)
        Me.lblBlotterTitle.Name = "lblBlotterTitle"
        Me.lblBlotterTitle.Size = New System.Drawing.Size(126, 21)
        Me.lblBlotterTitle.TabIndex = 4
        Me.lblBlotterTitle.Text = "Blotter Records"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.Controls.Add(Me.btnAddNew)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Controls.Add(Me.cmbSearchBy)
        Me.pnlSearch.Controls.Add(Me.lblSearchBy)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Padding = New System.Windows.Forms.Padding(20, 15, 20, 10)
        Me.pnlSearch.Size = New System.Drawing.Size(1236, 60)
        Me.pnlSearch.TabIndex = 1
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnAddNew.BorderRadius = 15
        Me.btnAddNew.FlatAppearance.BorderSize = 0
        Me.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNew.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.ForeColor = System.Drawing.Color.White
        Me.btnAddNew.Location = New System.Drawing.Point(23, 12)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(110, 32)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "ADD NEW"
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(908, 17)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(300, 25)
        Me.txtSearch.TabIndex = 2
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSearchBy.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchBy.FormattingEnabled = True
        Me.cmbSearchBy.Items.AddRange(New Object() {"ALL", "Brgy. Case #", "Accusation", "Complainant's Name", "Purok"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(827, 16)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(75, 25)
        Me.cmbSearchBy.TabIndex = 1
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblSearchBy.Location = New System.Drawing.Point(711, 17)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(103, 25)
        Me.lblSearchBy.TabIndex = 0
        Me.lblSearchBy.Text = "Search by:"
        '
        'blotterrecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1236, 850)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "blotterrecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Blotter Records"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlDataArea.ResumeLayout(False)
        Me.pnlRightTable.ResumeLayout(False)
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScheduleActionBackground.ResumeLayout(False)
        Me.flpScheduleActions.ResumeLayout(False)
        Me.pnlScheduleButtons.ResumeLayout(False)
        Me.pnlScheduleButtons.PerformLayout()
        Me.pnlLeftTable.ResumeLayout(False)
        CType(Me.dgvBlotterRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBlotterButtons.ResumeLayout(False)
        Me.pnlBlotterButtons.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlDataArea As Panel
    Friend WithEvents pnlRightTable As Panel
    Friend WithEvents lblComplainantVsRespondent As Label
    Friend WithEvents dgvSchedule As DataGridView
    Friend WithEvents pnlLeftTable As Panel
    Friend WithEvents dgvBlotterRecords As DataGridView
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cmbSearchBy As ComboBox
    Friend WithEvents lblSearchBy As Label
    Friend WithEvents pnlScheduleButtons As Panel
    Friend WithEvents btnUpdateSettlementStatus As RoundedButton
    Friend WithEvents btnDeleteSchedule As RoundedButton
    Friend WithEvents btnEditSchedule As RoundedButton
    Friend WithEvents btnAddSchedule As RoundedButton
    Friend WithEvents pnlScheduleActionBackground As RoundedPanel
    Friend WithEvents flpScheduleActions As FlowLayoutPanel
    Friend WithEvents pnlBlotterButtons As Panel
    Friend WithEvents btnAddNew As RoundedButton
    Friend WithEvents lblBlotterTitle As Label
End Class
