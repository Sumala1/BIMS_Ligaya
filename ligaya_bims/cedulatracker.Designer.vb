Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cedulatracker
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
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnTransaction = New ligaya_bims.RoundedButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.dgvCedula = New System.Windows.Forms.DataGridView()
        Me.lblShowingEntries = New System.Windows.Forms.Label()
        Me.colAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCTCNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDateIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewImageColumn()
        Me.panelMain.SuspendLayout()
        CType(Me.dgvCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.panelMain.Controls.Add(Me.Label1)
        Me.panelMain.Controls.Add(Me.lblTitle)
        Me.panelMain.Controls.Add(Me.btnTransaction)
        Me.panelMain.Controls.Add(Me.txtSearch)
        Me.panelMain.Controls.Add(Me.cmbFilter)
        Me.panelMain.Controls.Add(Me.dgvCedula)
        Me.panelMain.Controls.Add(Me.lblShowingEntries)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.panelMain.Size = New System.Drawing.Size(1600, 862)
        Me.panelMain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1121, 120)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Search:"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(31, 28)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(299, 54)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Cedula Tracker"
        '
        'btnTransaction
        '
        Me.btnTransaction.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnTransaction.BorderRadius = 15
        Me.btnTransaction.FlatAppearance.BorderSize = 0
        Me.btnTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.btnTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransaction.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTransaction.ForeColor = System.Drawing.Color.White
        Me.btnTransaction.Location = New System.Drawing.Point(31, 105)
        Me.btnTransaction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnTransaction.Name = "btnTransaction"
        Me.btnTransaction.Size = New System.Drawing.Size(200, 49)
        Me.btnTransaction.TabIndex = 1
        Me.btnTransaction.Text = "Transaction"
        Me.btnTransaction.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(1267, 117)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(265, 27)
        Me.txtSearch.TabIndex = 2
        '
        'cmbFilter
        '
        Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFilter.Items.AddRange(New Object() {"CTC Number", "Full Name", "Date Issued"})
        Me.cmbFilter.Location = New System.Drawing.Point(253, 118)
        Me.cmbFilter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(172, 28)
        Me.cmbFilter.TabIndex = 3
        '
        'dgvCedula
        '
        Me.dgvCedula.AllowUserToAddRows = False
        Me.dgvCedula.AllowUserToDeleteRows = False
        Me.dgvCedula.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvCedula.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCedula.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCedula.BackgroundColor = System.Drawing.Color.White
        Me.dgvCedula.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCedula.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCedula.ColumnHeadersHeight = 45
        Me.dgvCedula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCedula.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAction, Me.colCTCNumber, Me.colFullName, Me.colDateIssued, Me.colDelete})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCedula.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCedula.EnableHeadersVisualStyles = False
        Me.dgvCedula.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.dgvCedula.Location = New System.Drawing.Point(31, 230)
        Me.dgvCedula.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvCedula.MultiSelect = False
        Me.dgvCedula.Name = "dgvCedula"
        Me.dgvCedula.ReadOnly = True
        Me.dgvCedula.RowHeadersVisible = False
        Me.dgvCedula.RowHeadersWidth = 51
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvCedula.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCedula.RowTemplate.Height = 40
        Me.dgvCedula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCedula.Size = New System.Drawing.Size(1539, 431)
        Me.dgvCedula.TabIndex = 4
        '
        'lblShowingEntries
        '
        Me.lblShowingEntries.AutoSize = True
        Me.lblShowingEntries.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblShowingEntries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblShowingEntries.Location = New System.Drawing.Point(31, 689)
        Me.lblShowingEntries.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblShowingEntries.Name = "lblShowingEntries"
        Me.lblShowingEntries.Size = New System.Drawing.Size(186, 20)
        Me.lblShowingEntries.TabIndex = 5
        Me.lblShowingEntries.Text = "Showing 1 to 0 of 0 entries"
        '
        'colAction
        '
        Me.colAction.HeaderText = "Action"
        Me.colAction.MinimumWidth = 6
        Me.colAction.Name = "colAction"
        Me.colAction.ReadOnly = True
        Me.colAction.Width = 170
        '
        'colCTCNumber
        '
        Me.colCTCNumber.HeaderText = "CTC Number"
        Me.colCTCNumber.MinimumWidth = 6
        Me.colCTCNumber.Name = "colCTCNumber"
        Me.colCTCNumber.ReadOnly = True
        Me.colCTCNumber.Width = 400
        '
        'colFullName
        '
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.MinimumWidth = 6
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 530
        '
        'colDateIssued
        '
        Me.colDateIssued.HeaderText = "Date Issued"
        Me.colDateIssued.MinimumWidth = 6
        Me.colDateIssued.Name = "colDateIssued"
        Me.colDateIssued.ReadOnly = True
        Me.colDateIssued.Width = 300
        '
        'colDelete
        '
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.colDelete.MinimumWidth = 6
        Me.colDelete.Name = "colDelete"
        Me.colDelete.ReadOnly = True
        Me.colDelete.Width = 130
        '
        'cedulatracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1600, 862)
        Me.Controls.Add(Me.panelMain)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "cedulatracker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cedula Tracker"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelMain.ResumeLayout(False)
        Me.panelMain.PerformLayout()
        CType(Me.dgvCedula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelMain As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnTransaction As ligaya_bims.RoundedButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCedula As System.Windows.Forms.DataGridView
    Friend WithEvents lblShowingEntries As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents colAction As DataGridViewTextBoxColumn
    Friend WithEvents colCTCNumber As DataGridViewTextBoxColumn
    Friend WithEvents colFullName As DataGridViewTextBoxColumn
    Friend WithEvents colDateIssued As DataGridViewTextBoxColumn
    Friend WithEvents colDelete As DataGridViewImageColumn
End Class
