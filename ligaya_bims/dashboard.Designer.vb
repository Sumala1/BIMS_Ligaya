Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboard
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
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Me.leftNav = New System.Windows.Forms.Panel()
        Me.navLogout = New ligaya_bims.RoundedButton()
        Me.navBackup = New ligaya_bims.RoundedButton()
        Me.navStaffs = New ligaya_bims.RoundedButton()
        Me.navDocs = New ligaya_bims.RoundedButton()
        Me.navCedula = New ligaya_bims.RoundedButton()
        Me.navReports = New ligaya_bims.RoundedButton()
        Me.navResidents = New ligaya_bims.RoundedButton()
        Me.navDashboard = New ligaya_bims.RoundedButton()
        Me.leftHeader = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.topBar = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblAppTitle = New System.Windows.Forms.Label()
        Me.contentHost = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.chartPurokPopulation = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartDemographics = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblChartsTitle = New System.Windows.Forms.Label()
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.dgvDashboardResidents = New System.Windows.Forms.DataGridView()
        Me.chkSelectAllDashboard = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colLastNameDashboard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstNameDashboard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMiddleNameDashboard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMobileNoDashboard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGenderDashboard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDashboardResidentsTitle = New System.Windows.Forms.Label()
        Me.Panel4 = New ligaya_bims.RoundedPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New ligaya_bims.RoundedPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New ligaya_bims.RoundedPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New ligaya_bims.RoundedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelOfficials = New ligaya_bims.RoundedPanel()
        Me.lblOfficialsMore = New System.Windows.Forms.Label()
        Me.lblOfficialsTitle = New System.Windows.Forms.Label()
        Me.lblOfficialsCount = New System.Windows.Forms.Label()
        Me.panelCertificates = New ligaya_bims.RoundedPanel()
        Me.lblCertificatesMore = New System.Windows.Forms.Label()
        Me.lblCertificatesTitle = New System.Windows.Forms.Label()
        Me.lblCertificatesCount = New System.Windows.Forms.Label()
        Me.panelBlotter = New ligaya_bims.RoundedPanel()
        Me.lblBlotterMore = New System.Windows.Forms.Label()
        Me.lblBlotterTitle = New System.Windows.Forms.Label()
        Me.lblBlotterCount = New System.Windows.Forms.Label()
        Me.panelResidents = New ligaya_bims.RoundedPanel()
        Me.lblResidentsMore = New System.Windows.Forms.Label()
        Me.lblResidentsTitle = New System.Windows.Forms.Label()
        Me.lblResidentsCount = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.leftNav.SuspendLayout()
        Me.leftHeader.SuspendLayout()
        Me.topBar.SuspendLayout()
        Me.contentHost.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.panelRight.SuspendLayout()
        CType(Me.chartPurokPopulation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartDemographics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLeft.SuspendLayout()
        CType(Me.dgvDashboardResidents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelOfficials.SuspendLayout()
        Me.panelCertificates.SuspendLayout()
        Me.panelBlotter.SuspendLayout()
        Me.panelResidents.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'leftNav
        '
        Me.leftNav.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.leftNav.Controls.Add(Me.navLogout)
        Me.leftNav.Controls.Add(Me.navBackup)
        Me.leftNav.Controls.Add(Me.navStaffs)
        Me.leftNav.Controls.Add(Me.navDocs)
        Me.leftNav.Controls.Add(Me.navCedula)
        Me.leftNav.Controls.Add(Me.navReports)
        Me.leftNav.Controls.Add(Me.navResidents)
        Me.leftNav.Controls.Add(Me.navDashboard)
        Me.leftNav.Controls.Add(Me.leftHeader)
        Me.leftNav.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftNav.Location = New System.Drawing.Point(0, 0)
        Me.leftNav.Name = "leftNav"
        Me.leftNav.Size = New System.Drawing.Size(202, 861)
        Me.leftNav.TabIndex = 0
        '
        'navLogout
        '
        Me.navLogout.BackColor = System.Drawing.Color.Transparent
        Me.navLogout.BorderRadius = 15
        Me.navLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.navLogout.FlatAppearance.BorderSize = 0
        Me.navLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.navLogout.ForeColor = System.Drawing.Color.IndianRed
        Me.navLogout.Location = New System.Drawing.Point(0, 773)
        Me.navLogout.Name = "navLogout"
        Me.navLogout.Size = New System.Drawing.Size(202, 44)
        Me.navLogout.TabIndex = 8
        Me.navLogout.Text = "  Log Out"
        Me.navLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navLogout.UseVisualStyleBackColor = False
        '
        'navBackup
        '
        Me.navBackup.BackColor = System.Drawing.Color.Transparent
        Me.navBackup.BorderRadius = 15
        Me.navBackup.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.navBackup.FlatAppearance.BorderSize = 0
        Me.navBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navBackup.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navBackup.ForeColor = System.Drawing.Color.Gainsboro
        Me.navBackup.Location = New System.Drawing.Point(0, 817)
        Me.navBackup.Name = "navBackup"
        Me.navBackup.Size = New System.Drawing.Size(202, 44)
        Me.navBackup.TabIndex = 7
        Me.navBackup.Text = "  Backup and Restore"
        Me.navBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navBackup.UseVisualStyleBackColor = False
        '
        'navStaffs
        '
        Me.navStaffs.BackColor = System.Drawing.Color.Transparent
        Me.navStaffs.BorderRadius = 15
        Me.navStaffs.Dock = System.Windows.Forms.DockStyle.Top
        Me.navStaffs.FlatAppearance.BorderSize = 0
        Me.navStaffs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navStaffs.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navStaffs.ForeColor = System.Drawing.Color.Gainsboro
        Me.navStaffs.Location = New System.Drawing.Point(0, 426)
        Me.navStaffs.Name = "navStaffs"
        Me.navStaffs.Size = New System.Drawing.Size(202, 52)
        Me.navStaffs.TabIndex = 6
        Me.navStaffs.Text = "  Staffs"
        Me.navStaffs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navStaffs.UseVisualStyleBackColor = False
        '
        'navDocs
        '
        Me.navDocs.BackColor = System.Drawing.Color.Transparent
        Me.navDocs.BorderRadius = 15
        Me.navDocs.Dock = System.Windows.Forms.DockStyle.Top
        Me.navDocs.FlatAppearance.BorderSize = 0
        Me.navDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navDocs.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navDocs.ForeColor = System.Drawing.Color.Gainsboro
        Me.navDocs.Location = New System.Drawing.Point(0, 382)
        Me.navDocs.Name = "navDocs"
        Me.navDocs.Size = New System.Drawing.Size(202, 44)
        Me.navDocs.TabIndex = 5
        Me.navDocs.Text = "  Certificate Issuance"
        Me.navDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navDocs.UseVisualStyleBackColor = False
        '
        'navCedula
        '
        Me.navCedula.BackColor = System.Drawing.Color.Transparent
        Me.navCedula.BorderRadius = 15
        Me.navCedula.Dock = System.Windows.Forms.DockStyle.Top
        Me.navCedula.FlatAppearance.BorderSize = 0
        Me.navCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navCedula.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navCedula.ForeColor = System.Drawing.Color.Gainsboro
        Me.navCedula.Location = New System.Drawing.Point(0, 338)
        Me.navCedula.Name = "navCedula"
        Me.navCedula.Size = New System.Drawing.Size(202, 44)
        Me.navCedula.TabIndex = 4
        Me.navCedula.Text = "  Cedula Tracker"
        Me.navCedula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navCedula.UseVisualStyleBackColor = False
        '
        'navReports
        '
        Me.navReports.BackColor = System.Drawing.Color.Transparent
        Me.navReports.BorderRadius = 15
        Me.navReports.Dock = System.Windows.Forms.DockStyle.Top
        Me.navReports.FlatAppearance.BorderSize = 0
        Me.navReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navReports.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navReports.ForeColor = System.Drawing.Color.Gainsboro
        Me.navReports.Location = New System.Drawing.Point(0, 294)
        Me.navReports.Name = "navReports"
        Me.navReports.Size = New System.Drawing.Size(202, 44)
        Me.navReports.TabIndex = 3
        Me.navReports.Text = "  Blotter"
        Me.navReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navReports.UseVisualStyleBackColor = False
        '
        'navResidents
        '
        Me.navResidents.BackColor = System.Drawing.Color.Transparent
        Me.navResidents.BorderRadius = 15
        Me.navResidents.Dock = System.Windows.Forms.DockStyle.Top
        Me.navResidents.FlatAppearance.BorderSize = 0
        Me.navResidents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navResidents.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navResidents.ForeColor = System.Drawing.Color.Gainsboro
        Me.navResidents.Location = New System.Drawing.Point(0, 250)
        Me.navResidents.Name = "navResidents"
        Me.navResidents.Size = New System.Drawing.Size(202, 44)
        Me.navResidents.TabIndex = 2
        Me.navResidents.Text = "  Residents"
        Me.navResidents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navResidents.UseVisualStyleBackColor = False
        '
        'navDashboard
        '
        Me.navDashboard.BackColor = System.Drawing.Color.Transparent
        Me.navDashboard.BorderRadius = 15
        Me.navDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.navDashboard.FlatAppearance.BorderSize = 0
        Me.navDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.navDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.navDashboard.ForeColor = System.Drawing.Color.Gainsboro
        Me.navDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navDashboard.Location = New System.Drawing.Point(0, 206)
        Me.navDashboard.Name = "navDashboard"
        Me.navDashboard.Size = New System.Drawing.Size(202, 44)
        Me.navDashboard.TabIndex = 1
        Me.navDashboard.Text = "  Dashboard"
        Me.navDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.navDashboard.UseVisualStyleBackColor = False
        '
        'leftHeader
        '
        Me.leftHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.leftHeader.Controls.Add(Me.Label13)
        Me.leftHeader.Controls.Add(Me.PictureBox9)
        Me.leftHeader.Controls.Add(Me.lblBrand)
        Me.leftHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.leftHeader.Location = New System.Drawing.Point(0, 0)
        Me.leftHeader.Name = "leftHeader"
        Me.leftHeader.Size = New System.Drawing.Size(202, 206)
        Me.leftHeader.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(7, 170)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(189, 21)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Welcome Administrator!"
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = True
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrand.ForeColor = System.Drawing.Color.White
        Me.lblBrand.Location = New System.Drawing.Point(40, 17)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(115, 21)
        Me.lblBrand.TabIndex = 0
        Me.lblBrand.Text = "eLIGAYA BIMS"
        '
        'topBar
        '
        Me.topBar.BackColor = System.Drawing.Color.White
        Me.topBar.Controls.Add(Me.lblWelcome)
        Me.topBar.Controls.Add(Me.lblAppTitle)
        Me.topBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.topBar.Location = New System.Drawing.Point(202, 0)
        Me.topBar.Name = "topBar"
        Me.topBar.Size = New System.Drawing.Size(1222, 57)
        Me.topBar.TabIndex = 1
        '
        'lblWelcome
        '
        Me.lblWelcome.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcome.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(56, Byte), Integer))
        Me.lblWelcome.Location = New System.Drawing.Point(1022, 0)
        Me.lblWelcome.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(200, 57)
        Me.lblWelcome.TabIndex = 1
        Me.lblWelcome.Text = "Administrator   "
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAppTitle
        '
        Me.lblAppTitle.AutoSize = True
        Me.lblAppTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblAppTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblAppTitle.Location = New System.Drawing.Point(16, 13)
        Me.lblAppTitle.Name = "lblAppTitle"
        Me.lblAppTitle.Size = New System.Drawing.Size(103, 21)
        Me.lblAppTitle.TabIndex = 0
        Me.lblAppTitle.Text = "eBaryo v1.1.0"
        '
        'contentHost
        '
        Me.contentHost.BackColor = System.Drawing.Color.White
        Me.contentHost.Controls.Add(Me.TableLayoutPanel1)
        Me.contentHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.contentHost.Location = New System.Drawing.Point(202, 57)
        Me.contentHost.Name = "contentHost"
        Me.contentHost.Padding = New System.Windows.Forms.Padding(12)
        Me.contentHost.Size = New System.Drawing.Size(1222, 804)
        Me.contentHost.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.45576!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.20868!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.21035!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.panelRight, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.panelLeft, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.panelOfficials, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.panelCertificates, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.panelBlotter, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.panelResidents, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1198, 780)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'panelRight
        '
        Me.panelRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.panelRight, 2)
        Me.panelRight.Controls.Add(Me.chartPurokPopulation)
        Me.panelRight.Controls.Add(Me.chartDemographics)
        Me.panelRight.Controls.Add(Me.lblChartsTitle)
        Me.panelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelRight.Location = New System.Drawing.Point(586, 237)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Size = New System.Drawing.Size(609, 540)
        Me.panelRight.TabIndex = 30
        '
        'chartPurokPopulation
        '
        Me.chartPurokPopulation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chartPurokPopulation.Location = New System.Drawing.Point(15, 60)
        Me.chartPurokPopulation.Name = "chartPurokPopulation"
        Series1.Name = "Purok 1"
        Series2.Name = "Purok 2"
        Series3.Name = "Purok 3"
        Series4.Name = "Purok 4"
        Series5.Name = "Purok 5"
        Me.chartPurokPopulation.Series.Add(Series1)
        Me.chartPurokPopulation.Series.Add(Series2)
        Me.chartPurokPopulation.Series.Add(Series3)
        Me.chartPurokPopulation.Series.Add(Series4)
        Me.chartPurokPopulation.Series.Add(Series5)
        Me.chartPurokPopulation.Size = New System.Drawing.Size(583, 197)
        Me.chartPurokPopulation.TabIndex = 2
        Me.chartPurokPopulation.Text = "Purok Population"
        '
        'chartDemographics
        '
        Me.chartDemographics.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "Senior"
        Me.chartDemographics.ChartAreas.Add(ChartArea1)
        Me.chartDemographics.Location = New System.Drawing.Point(15, 263)
        Me.chartDemographics.Name = "chartDemographics"
        Me.chartDemographics.Size = New System.Drawing.Size(583, 236)
        Me.chartDemographics.TabIndex = 1
        Me.chartDemographics.Text = "Demographics"
        '
        'lblChartsTitle
        '
        Me.lblChartsTitle.AutoSize = True
        Me.lblChartsTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblChartsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblChartsTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblChartsTitle.Name = "lblChartsTitle"
        Me.lblChartsTitle.Size = New System.Drawing.Size(199, 30)
        Me.lblChartsTitle.TabIndex = 0
        Me.lblChartsTitle.Text = "Population Charts"
        '
        'panelLeft
        '
        Me.panelLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.panelLeft, 2)
        Me.panelLeft.Controls.Add(Me.dgvDashboardResidents)
        Me.panelLeft.Controls.Add(Me.lblDashboardResidentsTitle)
        Me.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelLeft.Location = New System.Drawing.Point(3, 237)
        Me.panelLeft.Name = "panelLeft"
        Me.panelLeft.Size = New System.Drawing.Size(577, 540)
        Me.panelLeft.TabIndex = 29
        '
        'dgvDashboardResidents
        '
        Me.dgvDashboardResidents.AllowUserToAddRows = False
        Me.dgvDashboardResidents.AllowUserToDeleteRows = False
        Me.dgvDashboardResidents.AllowUserToResizeRows = False
        Me.dgvDashboardResidents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDashboardResidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDashboardResidents.BackgroundColor = System.Drawing.Color.White
        Me.dgvDashboardResidents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDashboardResidents.ColumnHeadersHeight = 45
        Me.dgvDashboardResidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDashboardResidents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelectAllDashboard, Me.colLastNameDashboard, Me.colFirstNameDashboard, Me.colMiddleNameDashboard, Me.colMobileNoDashboard, Me.colGenderDashboard})
        Me.dgvDashboardResidents.EnableHeadersVisualStyles = False
        Me.dgvDashboardResidents.GridColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.dgvDashboardResidents.Location = New System.Drawing.Point(15, 50)
        Me.dgvDashboardResidents.MultiSelect = False
        Me.dgvDashboardResidents.Name = "dgvDashboardResidents"
        Me.dgvDashboardResidents.ReadOnly = True
        Me.dgvDashboardResidents.RowHeadersVisible = False
        Me.dgvDashboardResidents.RowHeadersWidth = 51
        Me.dgvDashboardResidents.RowTemplate.Height = 40
        Me.dgvDashboardResidents.Size = New System.Drawing.Size(545, 449)
        Me.dgvDashboardResidents.TabIndex = 1
        '
        'chkSelectAllDashboard
        '
        Me.chkSelectAllDashboard.HeaderText = ""
        Me.chkSelectAllDashboard.MinimumWidth = 6
        Me.chkSelectAllDashboard.Name = "chkSelectAllDashboard"
        Me.chkSelectAllDashboard.ReadOnly = True
        '
        'colLastNameDashboard
        '
        Me.colLastNameDashboard.HeaderText = "Last Name"
        Me.colLastNameDashboard.MinimumWidth = 6
        Me.colLastNameDashboard.Name = "colLastNameDashboard"
        Me.colLastNameDashboard.ReadOnly = True
        '
        'colFirstNameDashboard
        '
        Me.colFirstNameDashboard.HeaderText = "First Name"
        Me.colFirstNameDashboard.MinimumWidth = 6
        Me.colFirstNameDashboard.Name = "colFirstNameDashboard"
        Me.colFirstNameDashboard.ReadOnly = True
        '
        'colMiddleNameDashboard
        '
        Me.colMiddleNameDashboard.HeaderText = "Middle Name"
        Me.colMiddleNameDashboard.MinimumWidth = 6
        Me.colMiddleNameDashboard.Name = "colMiddleNameDashboard"
        Me.colMiddleNameDashboard.ReadOnly = True
        '
        'colMobileNoDashboard
        '
        Me.colMobileNoDashboard.HeaderText = "Mobile No."
        Me.colMobileNoDashboard.MinimumWidth = 6
        Me.colMobileNoDashboard.Name = "colMobileNoDashboard"
        Me.colMobileNoDashboard.ReadOnly = True
        '
        'colGenderDashboard
        '
        Me.colGenderDashboard.HeaderText = "Gender"
        Me.colGenderDashboard.MinimumWidth = 6
        Me.colGenderDashboard.Name = "colGenderDashboard"
        Me.colGenderDashboard.ReadOnly = True
        '
        'lblDashboardResidentsTitle
        '
        Me.lblDashboardResidentsTitle.AutoSize = True
        Me.lblDashboardResidentsTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDashboardResidentsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lblDashboardResidentsTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblDashboardResidentsTitle.Name = "lblDashboardResidentsTitle"
        Me.lblDashboardResidentsTitle.Size = New System.Drawing.Size(188, 30)
        Me.lblDashboardResidentsTitle.TabIndex = 0
        Me.lblDashboardResidentsTitle.Text = "Recent Residents"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Panel4.Controls.Add(Me.PictureBox5)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(900, 120)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(295, 111)
        Me.Panel4.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(295, 25)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "More info →"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(15, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 17)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Senior Citizens"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(15, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 45)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "11"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PictureBox6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(586, 120)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(308, 111)
        Me.Panel3.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(308, 25)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "More info →"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(15, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 17)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Total PWDs"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(15, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 45)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "11"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox7)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(284, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(296, 111)
        Me.Panel2.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 25)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "More info →"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Active Voters"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 45)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "11"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(275, 111)
        Me.Panel1.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "More info →"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(15, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Households"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 45)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "11"
        '
        'panelOfficials
        '
        Me.panelOfficials.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.panelOfficials.Controls.Add(Me.PictureBox4)
        Me.panelOfficials.Controls.Add(Me.lblOfficialsMore)
        Me.panelOfficials.Controls.Add(Me.lblOfficialsTitle)
        Me.panelOfficials.Controls.Add(Me.lblOfficialsCount)
        Me.panelOfficials.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelOfficials.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelOfficials.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelOfficials.Location = New System.Drawing.Point(900, 3)
        Me.panelOfficials.Name = "panelOfficials"
        Me.panelOfficials.Size = New System.Drawing.Size(295, 111)
        Me.panelOfficials.TabIndex = 24
        '
        'lblOfficialsMore
        '
        Me.lblOfficialsMore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOfficialsMore.BackColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblOfficialsMore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOfficialsMore.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficialsMore.ForeColor = System.Drawing.Color.White
        Me.lblOfficialsMore.Location = New System.Drawing.Point(0, 86)
        Me.lblOfficialsMore.Name = "lblOfficialsMore"
        Me.lblOfficialsMore.Size = New System.Drawing.Size(295, 25)
        Me.lblOfficialsMore.TabIndex = 2
        Me.lblOfficialsMore.Text = "More info →"
        Me.lblOfficialsMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOfficialsTitle
        '
        Me.lblOfficialsTitle.AutoSize = True
        Me.lblOfficialsTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficialsTitle.ForeColor = System.Drawing.Color.White
        Me.lblOfficialsTitle.Location = New System.Drawing.Point(15, 65)
        Me.lblOfficialsTitle.Name = "lblOfficialsTitle"
        Me.lblOfficialsTitle.Size = New System.Drawing.Size(131, 17)
        Me.lblOfficialsTitle.TabIndex = 1
        Me.lblOfficialsTitle.Text = "Cedula Transactions"
        '
        'lblOfficialsCount
        '
        Me.lblOfficialsCount.AutoSize = True
        Me.lblOfficialsCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblOfficialsCount.ForeColor = System.Drawing.Color.White
        Me.lblOfficialsCount.Location = New System.Drawing.Point(15, 15)
        Me.lblOfficialsCount.Name = "lblOfficialsCount"
        Me.lblOfficialsCount.Size = New System.Drawing.Size(38, 45)
        Me.lblOfficialsCount.TabIndex = 0
        Me.lblOfficialsCount.Text = "6"
        '
        'panelCertificates
        '
        Me.panelCertificates.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.panelCertificates.Controls.Add(Me.PictureBox3)
        Me.panelCertificates.Controls.Add(Me.lblCertificatesMore)
        Me.panelCertificates.Controls.Add(Me.lblCertificatesTitle)
        Me.panelCertificates.Controls.Add(Me.lblCertificatesCount)
        Me.panelCertificates.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelCertificates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCertificates.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelCertificates.Location = New System.Drawing.Point(586, 3)
        Me.panelCertificates.Name = "panelCertificates"
        Me.panelCertificates.Size = New System.Drawing.Size(308, 111)
        Me.panelCertificates.TabIndex = 19
        '
        'lblCertificatesMore
        '
        Me.lblCertificatesMore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCertificatesMore.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.lblCertificatesMore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCertificatesMore.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertificatesMore.ForeColor = System.Drawing.Color.White
        Me.lblCertificatesMore.Location = New System.Drawing.Point(0, 86)
        Me.lblCertificatesMore.Name = "lblCertificatesMore"
        Me.lblCertificatesMore.Size = New System.Drawing.Size(308, 25)
        Me.lblCertificatesMore.TabIndex = 2
        Me.lblCertificatesMore.Text = "More info →"
        Me.lblCertificatesMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCertificatesTitle
        '
        Me.lblCertificatesTitle.AutoSize = True
        Me.lblCertificatesTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertificatesTitle.ForeColor = System.Drawing.Color.White
        Me.lblCertificatesTitle.Location = New System.Drawing.Point(15, 65)
        Me.lblCertificatesTitle.Name = "lblCertificatesTitle"
        Me.lblCertificatesTitle.Size = New System.Drawing.Size(77, 17)
        Me.lblCertificatesTitle.TabIndex = 1
        Me.lblCertificatesTitle.Text = "Certificates"
        '
        'lblCertificatesCount
        '
        Me.lblCertificatesCount.AutoSize = True
        Me.lblCertificatesCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblCertificatesCount.ForeColor = System.Drawing.Color.White
        Me.lblCertificatesCount.Location = New System.Drawing.Point(15, 15)
        Me.lblCertificatesCount.Name = "lblCertificatesCount"
        Me.lblCertificatesCount.Size = New System.Drawing.Size(38, 45)
        Me.lblCertificatesCount.TabIndex = 0
        Me.lblCertificatesCount.Text = "7"
        '
        'panelBlotter
        '
        Me.panelBlotter.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.panelBlotter.Controls.Add(Me.PictureBox2)
        Me.panelBlotter.Controls.Add(Me.lblBlotterMore)
        Me.panelBlotter.Controls.Add(Me.lblBlotterTitle)
        Me.panelBlotter.Controls.Add(Me.lblBlotterCount)
        Me.panelBlotter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelBlotter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelBlotter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelBlotter.Location = New System.Drawing.Point(284, 3)
        Me.panelBlotter.Name = "panelBlotter"
        Me.panelBlotter.Size = New System.Drawing.Size(296, 111)
        Me.panelBlotter.TabIndex = 18
        '
        'lblBlotterMore
        '
        Me.lblBlotterMore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBlotterMore.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblBlotterMore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBlotterMore.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlotterMore.ForeColor = System.Drawing.Color.White
        Me.lblBlotterMore.Location = New System.Drawing.Point(0, 86)
        Me.lblBlotterMore.Name = "lblBlotterMore"
        Me.lblBlotterMore.Size = New System.Drawing.Size(296, 25)
        Me.lblBlotterMore.TabIndex = 2
        Me.lblBlotterMore.Text = "More info →"
        Me.lblBlotterMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBlotterTitle
        '
        Me.lblBlotterTitle.AutoSize = True
        Me.lblBlotterTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlotterTitle.ForeColor = System.Drawing.Color.White
        Me.lblBlotterTitle.Location = New System.Drawing.Point(15, 65)
        Me.lblBlotterTitle.Name = "lblBlotterTitle"
        Me.lblBlotterTitle.Size = New System.Drawing.Size(91, 17)
        Me.lblBlotterTitle.TabIndex = 1
        Me.lblBlotterTitle.Text = "Total Blotters"
        '
        'lblBlotterCount
        '
        Me.lblBlotterCount.AutoSize = True
        Me.lblBlotterCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblBlotterCount.ForeColor = System.Drawing.Color.White
        Me.lblBlotterCount.Location = New System.Drawing.Point(15, 15)
        Me.lblBlotterCount.Name = "lblBlotterCount"
        Me.lblBlotterCount.Size = New System.Drawing.Size(38, 45)
        Me.lblBlotterCount.TabIndex = 0
        Me.lblBlotterCount.Text = "2"
        '
        'panelResidents
        '
        Me.panelResidents.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.panelResidents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelResidents.Controls.Add(Me.PictureBox1)
        Me.panelResidents.Controls.Add(Me.lblResidentsMore)
        Me.panelResidents.Controls.Add(Me.lblResidentsTitle)
        Me.panelResidents.Controls.Add(Me.lblResidentsCount)
        Me.panelResidents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panelResidents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelResidents.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelResidents.Location = New System.Drawing.Point(3, 3)
        Me.panelResidents.Name = "panelResidents"
        Me.panelResidents.Size = New System.Drawing.Size(275, 111)
        Me.panelResidents.TabIndex = 17
        '
        'lblResidentsMore
        '
        Me.lblResidentsMore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResidentsMore.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.lblResidentsMore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblResidentsMore.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResidentsMore.ForeColor = System.Drawing.Color.White
        Me.lblResidentsMore.Location = New System.Drawing.Point(0, 86)
        Me.lblResidentsMore.Name = "lblResidentsMore"
        Me.lblResidentsMore.Size = New System.Drawing.Size(275, 25)
        Me.lblResidentsMore.TabIndex = 2
        Me.lblResidentsMore.Text = "More info →"
        Me.lblResidentsMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblResidentsTitle
        '
        Me.lblResidentsTitle.AutoSize = True
        Me.lblResidentsTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResidentsTitle.ForeColor = System.Drawing.Color.White
        Me.lblResidentsTitle.Location = New System.Drawing.Point(15, 65)
        Me.lblResidentsTitle.Name = "lblResidentsTitle"
        Me.lblResidentsTitle.Size = New System.Drawing.Size(102, 17)
        Me.lblResidentsTitle.TabIndex = 1
        Me.lblResidentsTitle.Text = "Total Residents"
        '
        'lblResidentsCount
        '
        Me.lblResidentsCount.AutoSize = True
        Me.lblResidentsCount.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblResidentsCount.ForeColor = System.Drawing.Color.White
        Me.lblResidentsCount.Location = New System.Drawing.Point(15, 15)
        Me.lblResidentsCount.Name = "lblResidentsCount"
        Me.lblResidentsCount.Size = New System.Drawing.Size(56, 45)
        Me.lblResidentsCount.TabIndex = 0
        Me.lblResidentsCount.Text = "11"
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = Global.ligaya_bims.My.Resources.Resources.old
        Me.PictureBox5.Location = New System.Drawing.Point(201, 15)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 7
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = Global.ligaya_bims.My.Resources.Resources.wheelchair
        Me.PictureBox6.Location = New System.Drawing.Point(214, 15)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 8
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.Image = Global.ligaya_bims.My.Resources.Resources.check
        Me.PictureBox7.Location = New System.Drawing.Point(201, 15)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 9
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = Global.ligaya_bims.My.Resources.Resources.house__1_
        Me.PictureBox8.Location = New System.Drawing.Point(183, 15)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 10
        Me.PictureBox8.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.ligaya_bims.My.Resources.Resources.multiple_users_silhouette
        Me.PictureBox4.Location = New System.Drawing.Point(201, 15)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.ligaya_bims.My.Resources.Resources.certificate
        Me.PictureBox3.Location = New System.Drawing.Point(214, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.ligaya_bims.My.Resources.Resources.report
        Me.PictureBox2.Location = New System.Drawing.Point(201, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.ligaya_bims.My.Resources.Resources.multiple_users_silhouette
        Me.PictureBox1.Location = New System.Drawing.Point(183, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.Image = Global.ligaya_bims.My.Resources.Resources.brgy_ligaya_logo_removebg_preview_removebg_preview
        Me.PictureBox9.Location = New System.Drawing.Point(44, 48)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(111, 110)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 1
        Me.PictureBox9.TabStop = False
        '
        'dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1424, 861)
        Me.Controls.Add(Me.contentHost)
        Me.Controls.Add(Me.topBar)
        Me.Controls.Add(Me.leftNav)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.leftNav.ResumeLayout(False)
        Me.leftHeader.ResumeLayout(False)
        Me.leftHeader.PerformLayout()
        Me.topBar.ResumeLayout(False)
        Me.topBar.PerformLayout()
        Me.contentHost.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.panelRight.ResumeLayout(False)
        Me.panelRight.PerformLayout()
        CType(Me.chartPurokPopulation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartDemographics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLeft.ResumeLayout(False)
        Me.panelLeft.PerformLayout()
        CType(Me.dgvDashboardResidents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelOfficials.ResumeLayout(False)
        Me.panelOfficials.PerformLayout()
        Me.panelCertificates.ResumeLayout(False)
        Me.panelCertificates.PerformLayout()
        Me.panelBlotter.ResumeLayout(False)
        Me.panelBlotter.PerformLayout()
        Me.panelResidents.ResumeLayout(False)
        Me.panelResidents.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents leftNav As System.Windows.Forms.Panel
    Friend WithEvents leftHeader As System.Windows.Forms.Panel
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents navDashboard As ligaya_bims.RoundedButton
    Friend WithEvents navResidents As ligaya_bims.RoundedButton
    Friend WithEvents navReports As ligaya_bims.RoundedButton
    Friend WithEvents navCedula As ligaya_bims.RoundedButton
    Friend WithEvents navDocs As ligaya_bims.RoundedButton
    Friend WithEvents navStaffs As ligaya_bims.RoundedButton
    Friend WithEvents navBackup As ligaya_bims.RoundedButton
    Friend WithEvents navLogout As ligaya_bims.RoundedButton
    Friend WithEvents topBar As System.Windows.Forms.Panel
    Friend WithEvents lblAppTitle As System.Windows.Forms.Label
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents contentHost As System.Windows.Forms.Panel
    Friend WithEvents colActionDashboard As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents panelResidents As RoundedPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblResidentsMore As Label
    Friend WithEvents lblResidentsTitle As Label
    Friend WithEvents lblResidentsCount As Label
    Friend WithEvents panelBlotter As RoundedPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblBlotterMore As Label
    Friend WithEvents lblBlotterTitle As Label
    Friend WithEvents lblBlotterCount As Label
    Friend WithEvents panelCertificates As RoundedPanel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblCertificatesMore As Label
    Friend WithEvents lblCertificatesTitle As Label
    Friend WithEvents lblCertificatesCount As Label
    Friend WithEvents panelOfficials As RoundedPanel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents lblOfficialsMore As Label
    Friend WithEvents lblOfficialsTitle As Label
    Friend WithEvents lblOfficialsCount As Label
    Friend WithEvents Panel1 As RoundedPanel
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As RoundedPanel
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As RoundedPanel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As RoundedPanel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents panelLeft As Panel
    Friend WithEvents dgvDashboardResidents As DataGridView
    Friend WithEvents chkSelectAllDashboard As DataGridViewCheckBoxColumn
    Friend WithEvents colLastNameDashboard As DataGridViewTextBoxColumn
    Friend WithEvents colFirstNameDashboard As DataGridViewTextBoxColumn
    Friend WithEvents colMiddleNameDashboard As DataGridViewTextBoxColumn
    Friend WithEvents colMobileNoDashboard As DataGridViewTextBoxColumn
    Friend WithEvents colGenderDashboard As DataGridViewTextBoxColumn
    Friend WithEvents lblDashboardResidentsTitle As Label
    Friend WithEvents panelRight As Panel
    Friend WithEvents chartPurokPopulation As DataVisualization.Charting.Chart
    Friend WithEvents chartDemographics As DataVisualization.Charting.Chart
    Friend WithEvents lblChartsTitle As Label
End Class
