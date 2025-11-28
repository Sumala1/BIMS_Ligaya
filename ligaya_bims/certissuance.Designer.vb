Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class certissuance
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.layoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.layoutHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCreateCertificate = New ligaya_bims.RoundedButton()
        Me.layoutSearch = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New ligaya_bims.RoundedButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.flowActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.RoundedButton5 = New ligaya_bims.RoundedButton()
        Me.RoundedButton4 = New ligaya_bims.RoundedButton()
        Me.RoundedButton3 = New ligaya_bims.RoundedButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.panelRight.SuspendLayout()
        Me.layoutMain.SuspendLayout()
        Me.layoutHeader.SuspendLayout()
        Me.layoutSearch.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flowActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.panelRight, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1580, 1010)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'panelRight
        '
        Me.panelRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.panelRight.Controls.Add(Me.layoutMain)
        Me.panelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelRight.Location = New System.Drawing.Point(4, 4)
        Me.panelRight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Padding = New System.Windows.Forms.Padding(32, 30, 32, 30)
        Me.panelRight.Size = New System.Drawing.Size(1572, 1002)
        Me.panelRight.TabIndex = 4
        '
        'layoutMain
        '
        Me.layoutMain.ColumnCount = 1
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Controls.Add(Me.layoutHeader, 0, 0)
        Me.layoutMain.Controls.Add(Me.layoutSearch, 0, 1)
        Me.layoutMain.Controls.Add(Me.DataGridView1, 0, 2)
        Me.layoutMain.Controls.Add(Me.flowActions, 0, 3)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(32, 30)
        Me.layoutMain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.RowCount = 4
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutMain.Size = New System.Drawing.Size(1508, 942)
        Me.layoutMain.TabIndex = 16
        '
        'layoutHeader
        '
        Me.layoutHeader.ColumnCount = 2
        Me.layoutHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.layoutHeader.Controls.Add(Me.Label2, 0, 0)
        Me.layoutHeader.Controls.Add(Me.btnCreateCertificate, 1, 0)
        Me.layoutHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutHeader.Location = New System.Drawing.Point(0, 0)
        Me.layoutHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.layoutHeader.Name = "layoutHeader"
        Me.layoutHeader.RowCount = 1
        Me.layoutHeader.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutHeader.Size = New System.Drawing.Size(1508, 80)
        Me.layoutHeader.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 12, 21, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1268, 56)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Certificate Issuance"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCreateCertificate
        '
        Me.btnCreateCertificate.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCreateCertificate.AutoSize = True
        Me.btnCreateCertificate.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCreateCertificate.BorderRadius = 15
        Me.btnCreateCertificate.FlatAppearance.BorderSize = 0
        Me.btnCreateCertificate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.btnCreateCertificate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnCreateCertificate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateCertificate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateCertificate.ForeColor = System.Drawing.Color.White
        Me.btnCreateCertificate.Location = New System.Drawing.Point(1293, 15)
        Me.btnCreateCertificate.Margin = New System.Windows.Forms.Padding(0, 15, 0, 15)
        Me.btnCreateCertificate.Name = "btnCreateCertificate"
        Me.btnCreateCertificate.Size = New System.Drawing.Size(215, 49)
        Me.btnCreateCertificate.TabIndex = 10
        Me.btnCreateCertificate.Text = "Create Certificate"
        Me.btnCreateCertificate.UseVisualStyleBackColor = False
        '
        'layoutSearch
        '
        Me.layoutSearch.AutoSize = True
        Me.layoutSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.layoutSearch.ColumnCount = 3
        Me.layoutSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.layoutSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.layoutSearch.Controls.Add(Me.Label3, 0, 0)
        Me.layoutSearch.Controls.Add(Me.TextBox1, 1, 0)
        Me.layoutSearch.Controls.Add(Me.Button1, 2, 0)
        Me.layoutSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutSearch.Location = New System.Drawing.Point(0, 80)
        Me.layoutSearch.Margin = New System.Windows.Forms.Padding(0, 0, 0, 18)
        Me.layoutSearch.Name = "layoutSearch"
        Me.layoutSearch.RowCount = 1
        Me.layoutSearch.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.layoutSearch.Size = New System.Drawing.Size(1508, 48)
        Me.layoutSearch.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 12, 16, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Search:"
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(98, 10)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 10, 16, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1313, 27)
        Me.TextBox1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Button1.BorderRadius = 12
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1443, 6)
        Me.Button1.Margin = New System.Windows.Forms.Padding(16, 6, 0, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 30)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 45
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(201, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(0, 171)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(0, 25, 0, 25)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 40
        Me.DataGridView1.Size = New System.Drawing.Size(1508, 661)
        Me.DataGridView1.TabIndex = 11
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Action"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Last Name"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "First Name"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Middle Name"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Mobile No."
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Gender"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'flowActions
        '
        Me.flowActions.AutoSize = True
        Me.flowActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowActions.Controls.Add(Me.RoundedButton5)
        Me.flowActions.Controls.Add(Me.RoundedButton4)
        Me.flowActions.Controls.Add(Me.RoundedButton3)
        Me.flowActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowActions.Location = New System.Drawing.Point(0, 857)
        Me.flowActions.Margin = New System.Windows.Forms.Padding(0)
        Me.flowActions.Name = "flowActions"
        Me.flowActions.Padding = New System.Windows.Forms.Padding(0, 18, 0, 0)
        Me.flowActions.Size = New System.Drawing.Size(1508, 85)
        Me.flowActions.TabIndex = 3
        Me.flowActions.WrapContents = False
        '
        'RoundedButton5
        '
        Me.RoundedButton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.RoundedButton5.BorderRadius = 15
        Me.RoundedButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton5.ForeColor = System.Drawing.Color.White
        Me.RoundedButton5.Location = New System.Drawing.Point(1348, 36)
        Me.RoundedButton5.Margin = New System.Windows.Forms.Padding(0, 18, 0, 0)
        Me.RoundedButton5.Name = "RoundedButton5"
        Me.RoundedButton5.Size = New System.Drawing.Size(160, 49)
        Me.RoundedButton5.TabIndex = 11
        Me.RoundedButton5.Text = "Print"
        Me.RoundedButton5.UseVisualStyleBackColor = False
        '
        'RoundedButton4
        '
        Me.RoundedButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.RoundedButton4.BorderRadius = 15
        Me.RoundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton4.ForeColor = System.Drawing.Color.White
        Me.RoundedButton4.Location = New System.Drawing.Point(1188, 36)
        Me.RoundedButton4.Margin = New System.Windows.Forms.Padding(20, 18, 0, 0)
        Me.RoundedButton4.Name = "RoundedButton4"
        Me.RoundedButton4.Size = New System.Drawing.Size(160, 49)
        Me.RoundedButton4.TabIndex = 12
        Me.RoundedButton4.Text = "Save"
        Me.RoundedButton4.UseVisualStyleBackColor = False
        '
        'RoundedButton3
        '
        Me.RoundedButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.RoundedButton3.BorderRadius = 15
        Me.RoundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton3.ForeColor = System.Drawing.Color.White
        Me.RoundedButton3.Location = New System.Drawing.Point(1008, 36)
        Me.RoundedButton3.Margin = New System.Windows.Forms.Padding(20, 18, 0, 0)
        Me.RoundedButton3.Name = "RoundedButton3"
        Me.RoundedButton3.Size = New System.Drawing.Size(160, 49)
        Me.RoundedButton3.TabIndex = 13
        Me.RoundedButton3.Text = "Delete"
        Me.RoundedButton3.UseVisualStyleBackColor = False
        '
        'certissuance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1580, 1010)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "certissuance"
        Me.Text = "Certificate Issuance"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.panelRight.ResumeLayout(False)
        Me.layoutMain.ResumeLayout(False)
        Me.layoutMain.PerformLayout()
        Me.layoutHeader.ResumeLayout(False)
        Me.layoutHeader.PerformLayout()
        Me.layoutSearch.ResumeLayout(False)
        Me.layoutSearch.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flowActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents panelRight As Panel
    Friend WithEvents Button1 As RoundedButton
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents btnCreateCertificate As ligaya_bims.RoundedButton
    Friend WithEvents layoutMain As TableLayoutPanel
    Friend WithEvents layoutHeader As TableLayoutPanel
    Friend WithEvents layoutSearch As TableLayoutPanel
    Friend WithEvents flowActions As FlowLayoutPanel
    Friend WithEvents RoundedButton3 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton4 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton5 As ligaya_bims.RoundedButton
End Class
