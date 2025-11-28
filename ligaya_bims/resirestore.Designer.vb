Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class resirestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(resirestore))
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.dgvProfiles = New System.Windows.Forms.DataGridView()
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRestore = New System.Windows.Forms.DataGridViewImageColumn()
        Me.pnlPagination = New System.Windows.Forms.Panel()
        Me.btnNext = New ligaya_bims.RoundedButton()
        Me.lblPageNumber = New System.Windows.Forms.Label()
        Me.btnPrevious = New ligaya_bims.RoundedButton()
        Me.lblShowEntries = New System.Windows.Forms.Label()
        Me.pnlContent.SuspendLayout()
        CType(Me.dgvProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPagination.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dgvProfiles)
        Me.pnlContent.Controls.Add(Me.pnlPagination)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlContent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(27, 18, 27, 25)
        Me.pnlContent.Size = New System.Drawing.Size(1651, 706)
        Me.pnlContent.TabIndex = 3
        '
        'dgvProfiles
        '
        Me.dgvProfiles.AllowUserToAddRows = False
        Me.dgvProfiles.AllowUserToDeleteRows = False
        Me.dgvProfiles.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvProfiles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProfiles.BackgroundColor = System.Drawing.Color.White
        Me.dgvProfiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProfiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProfiles.ColumnHeadersHeight = 45
        Me.dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProfiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colFullName, Me.colRestore})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProfiles.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProfiles.EnableHeadersVisualStyles = False
        Me.dgvProfiles.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.dgvProfiles.Location = New System.Drawing.Point(27, 7)
        Me.dgvProfiles.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvProfiles.MultiSelect = False
        Me.dgvProfiles.Name = "dgvProfiles"
        Me.dgvProfiles.ReadOnly = True
        Me.dgvProfiles.RowHeadersVisible = False
        Me.dgvProfiles.RowHeadersWidth = 51
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvProfiles.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProfiles.RowTemplate.Height = 40
        Me.dgvProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProfiles.Size = New System.Drawing.Size(1597, 628)
        Me.dgvProfiles.TabIndex = 0
        '
        'colSelect
        '
        Me.colSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colSelect.HeaderText = "Select"
        Me.colSelect.MinimumWidth = 60
        Me.colSelect.Name = "colSelect"
        Me.colSelect.ReadOnly = True
        Me.colSelect.Width = 80
        '
        'colFullName
        '
        Me.colFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFullName.FillWeight = 56.34518!
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.MinimumWidth = 600
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        '
        'colRestore
        '
        Me.colRestore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colRestore.HeaderText = "Restore"
        Me.colRestore.Image = CType(resources.GetObject("colRestore.Image"), System.Drawing.Image)
        Me.colRestore.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.colRestore.MinimumWidth = 60
        Me.colRestore.Name = "colRestore"
        Me.colRestore.ReadOnly = True
        Me.colRestore.Width = 80
        '
        'pnlPagination
        '
        Me.pnlPagination.Controls.Add(Me.btnNext)
        Me.pnlPagination.Controls.Add(Me.lblPageNumber)
        Me.pnlPagination.Controls.Add(Me.btnPrevious)
        Me.pnlPagination.Controls.Add(Me.lblShowEntries)
        Me.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPagination.Location = New System.Drawing.Point(27, 632)
        Me.pnlPagination.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlPagination.Name = "pnlPagination"
        Me.pnlPagination.Size = New System.Drawing.Size(1597, 49)
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
        Me.btnNext.Location = New System.Drawing.Point(1504, 10)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(80, 31)
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
        Me.lblPageNumber.Location = New System.Drawing.Point(1424, 10)
        Me.lblPageNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPageNumber.Name = "lblPageNumber"
        Me.lblPageNumber.Size = New System.Drawing.Size(40, 31)
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
        Me.btnPrevious.Location = New System.Drawing.Point(1344, 10)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(80, 31)
        Me.btnPrevious.TabIndex = 1
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'lblShowEntries
        '
        Me.lblShowEntries.AutoSize = True
        Me.lblShowEntries.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblShowEntries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblShowEntries.Location = New System.Drawing.Point(0, 16)
        Me.lblShowEntries.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblShowEntries.Name = "lblShowEntries"
        Me.lblShowEntries.Size = New System.Drawing.Size(66, 20)
        Me.lblShowEntries.TabIndex = 0
        Me.lblShowEntries.Text = "Showing"
        '
        'resirestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1651, 706)
        Me.Controls.Add(Me.pnlContent)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "resirestore"
        Me.Text = "reserestore"
        Me.pnlContent.ResumeLayout(False)
        CType(Me.dgvProfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPagination.ResumeLayout(False)
        Me.pnlPagination.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlContent As Panel
    Private WithEvents dgvProfiles As DataGridView
    Friend WithEvents colSelect As DataGridViewCheckBoxColumn
    Friend WithEvents colFullName As DataGridViewTextBoxColumn
    Friend WithEvents colRestore As DataGridViewImageColumn
    Private WithEvents pnlPagination As Panel
    Private WithEvents btnNext As RoundedButton
    Private WithEvents lblPageNumber As Label
    Private WithEvents btnPrevious As RoundedButton
    Private WithEvents lblShowEntries As Label
End Class
