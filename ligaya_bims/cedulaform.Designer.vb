Imports ligaya_bims

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cedulaform
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblCTC = New System.Windows.Forms.Label()
        Me.txtCTC = New System.Windows.Forms.TextBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblPlace = New System.Windows.Forms.Label()
        Me.txtPlace = New System.Windows.Forms.TextBox()
        Me.lblFullname = New System.Windows.Forms.Label()
        Me.txtFullname = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.lblIssued = New System.Windows.Forms.Label()
        Me.dtpIssued = New System.Windows.Forms.DateTimePicker()
        Me.lblCitizenship = New System.Windows.Forms.Label()
        Me.txtCitizenship = New System.Windows.Forms.TextBox()
        Me.lblPlaceOfBirth = New System.Windows.Forms.Label()
        Me.txtPlaceOfBirth = New System.Windows.Forms.TextBox()
        Me.lblCivilStatus = New System.Windows.Forms.Label()
        Me.cmbCivilStatus = New System.Windows.Forms.ComboBox()
        Me.lblDateOfBirth = New System.Windows.Forms.Label()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.lblProfession = New System.Windows.Forms.Label()
        Me.txtProfession = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New ligaya_bims.RoundedButton()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(152, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Cedula Form"
        '
        'lblCTC
        '
        Me.lblCTC.AutoSize = True
        Me.lblCTC.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblCTC.Location = New System.Drawing.Point(30, 70)
        Me.lblCTC.Name = "lblCTC"
        Me.lblCTC.Size = New System.Drawing.Size(82, 17)
        Me.lblCTC.TabIndex = 1
        Me.lblCTC.Text = "CTC Number"
        '
        'txtCTC
        '
        Me.txtCTC.BackColor = System.Drawing.Color.White
        Me.txtCTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCTC.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCTC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtCTC.Location = New System.Drawing.Point(30, 92)
        Me.txtCTC.Name = "txtCTC"
        Me.txtCTC.Size = New System.Drawing.Size(280, 25)
        Me.txtCTC.TabIndex = 2
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblYear.Location = New System.Drawing.Point(30, 130)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(33, 17)
        Me.lblYear.TabIndex = 3
        Me.lblYear.Text = "Year"
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlace.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblPlace.Location = New System.Drawing.Point(30, 190)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(89, 17)
        Me.lblPlace.TabIndex = 5
        Me.lblPlace.Text = "Place Of Issue"
        '
        'txtPlace
        '
        Me.txtPlace.BackColor = System.Drawing.Color.White
        Me.txtPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlace.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlace.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtPlace.Location = New System.Drawing.Point(30, 212)
        Me.txtPlace.Name = "txtPlace"
        Me.txtPlace.Size = New System.Drawing.Size(280, 25)
        Me.txtPlace.TabIndex = 6
        '
        'lblFullname
        '
        Me.lblFullname.AutoSize = True
        Me.lblFullname.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblFullname.Location = New System.Drawing.Point(30, 250)
        Me.lblFullname.Name = "lblFullname"
        Me.lblFullname.Size = New System.Drawing.Size(59, 17)
        Me.lblFullname.TabIndex = 7
        Me.lblFullname.Text = "Fullname"
        '
        'txtFullname
        '
        Me.txtFullname.BackColor = System.Drawing.Color.White
        Me.txtFullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullname.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtFullname.Location = New System.Drawing.Point(30, 272)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(280, 25)
        Me.txtFullname.TabIndex = 8
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblAddress.Location = New System.Drawing.Point(30, 310)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(56, 17)
        Me.lblAddress.TabIndex = 9
        Me.lblAddress.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtAddress.Location = New System.Drawing.Point(30, 332)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(280, 25)
        Me.txtAddress.TabIndex = 10
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblGender.Location = New System.Drawing.Point(30, 370)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(51, 17)
        Me.lblGender.TabIndex = 11
        Me.lblGender.Text = "Gender"
        '
        'cmbGender
        '
        Me.cmbGender.BackColor = System.Drawing.Color.White
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cmbGender.Location = New System.Drawing.Point(30, 392)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(280, 25)
        Me.cmbGender.TabIndex = 12
        '
        'lblIssued
        '
        Me.lblIssued.AutoSize = True
        Me.lblIssued.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssued.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblIssued.Location = New System.Drawing.Point(340, 70)
        Me.lblIssued.Name = "lblIssued"
        Me.lblIssued.Size = New System.Drawing.Size(76, 17)
        Me.lblIssued.TabIndex = 13
        Me.lblIssued.Text = "Date Issued"
        '
        'dtpIssued
        '
        Me.dtpIssued.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dtpIssued.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.dtpIssued.CalendarTitleForeColor = System.Drawing.Color.White
        Me.dtpIssued.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpIssued.Location = New System.Drawing.Point(340, 92)
        Me.dtpIssued.Name = "dtpIssued"
        Me.dtpIssued.Size = New System.Drawing.Size(240, 25)
        Me.dtpIssued.TabIndex = 14
        '
        'lblCitizenship
        '
        Me.lblCitizenship.AutoSize = True
        Me.lblCitizenship.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCitizenship.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblCitizenship.Location = New System.Drawing.Point(340, 130)
        Me.lblCitizenship.Name = "lblCitizenship"
        Me.lblCitizenship.Size = New System.Drawing.Size(70, 17)
        Me.lblCitizenship.TabIndex = 15
        Me.lblCitizenship.Text = "Citizenship"
        '
        'txtCitizenship
        '
        Me.txtCitizenship.BackColor = System.Drawing.Color.White
        Me.txtCitizenship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCitizenship.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCitizenship.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtCitizenship.Location = New System.Drawing.Point(340, 152)
        Me.txtCitizenship.Name = "txtCitizenship"
        Me.txtCitizenship.Size = New System.Drawing.Size(240, 25)
        Me.txtCitizenship.TabIndex = 16
        '
        'lblPlaceOfBirth
        '
        Me.lblPlaceOfBirth.AutoSize = True
        Me.lblPlaceOfBirth.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlaceOfBirth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblPlaceOfBirth.Location = New System.Drawing.Point(340, 190)
        Me.lblPlaceOfBirth.Name = "lblPlaceOfBirth"
        Me.lblPlaceOfBirth.Size = New System.Drawing.Size(86, 17)
        Me.lblPlaceOfBirth.TabIndex = 17
        Me.lblPlaceOfBirth.Text = "Place Of Birth"
        '
        'txtPlaceOfBirth
        '
        Me.txtPlaceOfBirth.BackColor = System.Drawing.Color.White
        Me.txtPlaceOfBirth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlaceOfBirth.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaceOfBirth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtPlaceOfBirth.Location = New System.Drawing.Point(340, 212)
        Me.txtPlaceOfBirth.Name = "txtPlaceOfBirth"
        Me.txtPlaceOfBirth.Size = New System.Drawing.Size(240, 25)
        Me.txtPlaceOfBirth.TabIndex = 18
        '
        'lblCivilStatus
        '
        Me.lblCivilStatus.AutoSize = True
        Me.lblCivilStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCivilStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblCivilStatus.Location = New System.Drawing.Point(340, 250)
        Me.lblCivilStatus.Name = "lblCivilStatus"
        Me.lblCivilStatus.Size = New System.Drawing.Size(70, 17)
        Me.lblCivilStatus.TabIndex = 19
        Me.lblCivilStatus.Text = "Civil Status"
        '
        'cmbCivilStatus
        '
        Me.cmbCivilStatus.BackColor = System.Drawing.Color.White
        Me.cmbCivilStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCivilStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCivilStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCivilStatus.FormattingEnabled = True
        Me.cmbCivilStatus.Items.AddRange(New Object() {"Single", "Married", "Widowed", "Divorced", "Separated"})
        Me.cmbCivilStatus.Location = New System.Drawing.Point(340, 272)
        Me.cmbCivilStatus.Name = "cmbCivilStatus"
        Me.cmbCivilStatus.Size = New System.Drawing.Size(240, 25)
        Me.cmbCivilStatus.TabIndex = 20
        '
        'lblDateOfBirth
        '
        Me.lblDateOfBirth.AutoSize = True
        Me.lblDateOfBirth.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblDateOfBirth.Location = New System.Drawing.Point(340, 310)
        Me.lblDateOfBirth.Name = "lblDateOfBirth"
        Me.lblDateOfBirth.Size = New System.Drawing.Size(83, 17)
        Me.lblDateOfBirth.TabIndex = 21
        Me.lblDateOfBirth.Text = "Date Of Birth"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dtpDateOfBirth.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.dtpDateOfBirth.CalendarTitleForeColor = System.Drawing.Color.White
        Me.dtpDateOfBirth.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(340, 332)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(240, 25)
        Me.dtpDateOfBirth.TabIndex = 22
        '
        'lblProfession
        '
        Me.lblProfession.AutoSize = True
        Me.lblProfession.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.lblProfession.Location = New System.Drawing.Point(340, 370)
        Me.lblProfession.Name = "lblProfession"
        Me.lblProfession.Size = New System.Drawing.Size(194, 17)
        Me.lblProfession.TabIndex = 23
        Me.lblProfession.Text = "Profession/Occupation/Business"
        '
        'txtProfession
        '
        Me.txtProfession.BackColor = System.Drawing.Color.White
        Me.txtProfession.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProfession.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProfession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.txtProfession.Location = New System.Drawing.Point(340, 392)
        Me.txtProfession.Name = "txtProfession"
        Me.txtProfession.Size = New System.Drawing.Size(240, 25)
        Me.txtProfession.TabIndex = 24
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSubmit.BorderRadius = 8
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(30, 440)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(140, 38)
        Me.btnSubmit.TabIndex = 25
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'cmbYear
        '
        Me.cmbYear.BackColor = System.Drawing.Color.White
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbYear.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Items.AddRange(New Object() {"2027", "2026", "2025", "2024", "2023"})
        Me.cmbYear.Location = New System.Drawing.Point(30, 150)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(280, 25)
        Me.cmbYear.TabIndex = 26
        '
        'cedulaform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(600, 500)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtProfession)
        Me.Controls.Add(Me.lblProfession)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.lblDateOfBirth)
        Me.Controls.Add(Me.cmbCivilStatus)
        Me.Controls.Add(Me.lblCivilStatus)
        Me.Controls.Add(Me.txtPlaceOfBirth)
        Me.Controls.Add(Me.lblPlaceOfBirth)
        Me.Controls.Add(Me.txtCitizenship)
        Me.Controls.Add(Me.lblCitizenship)
        Me.Controls.Add(Me.dtpIssued)
        Me.Controls.Add(Me.lblIssued)
        Me.Controls.Add(Me.cmbGender)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.txtFullname)
        Me.Controls.Add(Me.lblFullname)
        Me.Controls.Add(Me.txtPlace)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.txtCTC)
        Me.Controls.Add(Me.lblCTC)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cedulaform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cedula Transaction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblCTC As System.Windows.Forms.Label
    Friend WithEvents txtCTC As System.Windows.Forms.TextBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents txtPlace As System.Windows.Forms.TextBox
    Friend WithEvents lblFullname As System.Windows.Forms.Label
    Friend WithEvents txtFullname As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblIssued As System.Windows.Forms.Label
    Friend WithEvents dtpIssued As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCitizenship As System.Windows.Forms.Label
    Friend WithEvents txtCitizenship As System.Windows.Forms.TextBox
    Friend WithEvents lblPlaceOfBirth As System.Windows.Forms.Label
    Friend WithEvents txtPlaceOfBirth As System.Windows.Forms.TextBox
    Friend WithEvents lblCivilStatus As System.Windows.Forms.Label
    Friend WithEvents cmbCivilStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateOfBirth As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProfession As System.Windows.Forms.Label
    Friend WithEvents txtProfession As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As ligaya_bims.RoundedButton
    Friend WithEvents cmbYear As ComboBox
End Class
