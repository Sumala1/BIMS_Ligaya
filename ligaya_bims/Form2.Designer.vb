<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.panelLeft = New System.Windows.Forms.Panel()
        Me.btnNewResident = New ligaya_bims.RoundedButton()
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.pnlPic = New System.Windows.Forms.Panel()
        Me.RoundedButton1 = New ligaya_bims.RoundedButton()
        Me.RoundedButton2 = New ligaya_bims.RoundedButton()
        Me.RoundedButton3 = New ligaya_bims.RoundedButton()
        Me.RoundedButton4 = New ligaya_bims.RoundedButton()
        Me.RoundedButton5 = New ligaya_bims.RoundedButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelLeft.SuspendLayout()
        Me.panelRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelLeft
        '
        Me.panelLeft.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.panelLeft.Controls.Add(Me.pnlPic)
        Me.panelLeft.Controls.Add(Me.RoundedButton2)
        Me.panelLeft.Controls.Add(Me.RoundedButton1)
        Me.panelLeft.Controls.Add(Me.btnNewResident)
        Me.panelLeft.Location = New System.Drawing.Point(138, 32)
        Me.panelLeft.Name = "panelLeft"
        Me.panelLeft.Padding = New System.Windows.Forms.Padding(20)
        Me.panelLeft.Size = New System.Drawing.Size(441, 700)
        Me.panelLeft.TabIndex = 2
        '
        'btnNewResident
        '
        Me.btnNewResident.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.btnNewResident.BorderRadius = 15
        Me.btnNewResident.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewResident.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNewResident.ForeColor = System.Drawing.Color.White
        Me.btnNewResident.Location = New System.Drawing.Point(310, 645)
        Me.btnNewResident.Name = "btnNewResident"
        Me.btnNewResident.Size = New System.Drawing.Size(108, 40)
        Me.btnNewResident.TabIndex = 1
        Me.btnNewResident.Text = "Print"
        Me.btnNewResident.UseVisualStyleBackColor = False
        '
        'panelRight
        '
        Me.panelRight.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelRight.BackColor = System.Drawing.Color.White
        Me.panelRight.Controls.Add(Me.Panel1)
        Me.panelRight.Controls.Add(Me.RoundedButton3)
        Me.panelRight.Controls.Add(Me.RoundedButton4)
        Me.panelRight.Controls.Add(Me.RoundedButton5)
        Me.panelRight.Location = New System.Drawing.Point(699, 65)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Size = New System.Drawing.Size(438, 700)
        Me.panelRight.TabIndex = 3
        '
        'pnlPic
        '
        Me.pnlPic.BackColor = System.Drawing.Color.White
        Me.pnlPic.Location = New System.Drawing.Point(0, 0)
        Me.pnlPic.Name = "pnlPic"
        Me.pnlPic.Size = New System.Drawing.Size(441, 631)
        Me.pnlPic.TabIndex = 9
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.RoundedButton1.BorderRadius = 15
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton1.ForeColor = System.Drawing.Color.White
        Me.RoundedButton1.Location = New System.Drawing.Point(167, 645)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(108, 40)
        Me.RoundedButton1.TabIndex = 2
        Me.RoundedButton1.Text = "Save"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'RoundedButton2
        '
        Me.RoundedButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.RoundedButton2.BorderRadius = 15
        Me.RoundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton2.ForeColor = System.Drawing.Color.White
        Me.RoundedButton2.Location = New System.Drawing.Point(23, 645)
        Me.RoundedButton2.Name = "RoundedButton2"
        Me.RoundedButton2.Size = New System.Drawing.Size(108, 40)
        Me.RoundedButton2.TabIndex = 10
        Me.RoundedButton2.Text = "Delete"
        Me.RoundedButton2.UseVisualStyleBackColor = False
        '
        'RoundedButton3
        '
        Me.RoundedButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.RoundedButton3.BorderRadius = 15
        Me.RoundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton3.ForeColor = System.Drawing.Color.White
        Me.RoundedButton3.Location = New System.Drawing.Point(26, 643)
        Me.RoundedButton3.Name = "RoundedButton3"
        Me.RoundedButton3.Size = New System.Drawing.Size(108, 40)
        Me.RoundedButton3.TabIndex = 13
        Me.RoundedButton3.Text = "Delete"
        Me.RoundedButton3.UseVisualStyleBackColor = False
        '
        'RoundedButton4
        '
        Me.RoundedButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.RoundedButton4.BorderRadius = 15
        Me.RoundedButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton4.ForeColor = System.Drawing.Color.White
        Me.RoundedButton4.Location = New System.Drawing.Point(167, 643)
        Me.RoundedButton4.Name = "RoundedButton4"
        Me.RoundedButton4.Size = New System.Drawing.Size(108, 40)
        Me.RoundedButton4.TabIndex = 12
        Me.RoundedButton4.Text = "Save"
        Me.RoundedButton4.UseVisualStyleBackColor = False
        '
        'RoundedButton5
        '
        Me.RoundedButton5.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.RoundedButton5.BorderRadius = 15
        Me.RoundedButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton5.ForeColor = System.Drawing.Color.White
        Me.RoundedButton5.Location = New System.Drawing.Point(306, 643)
        Me.RoundedButton5.Name = "RoundedButton5"
        Me.RoundedButton5.Size = New System.Drawing.Size(108, 40)
        Me.RoundedButton5.TabIndex = 11
        Me.RoundedButton5.Text = "Print"
        Me.RoundedButton5.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 631)
        Me.Panel1.TabIndex = 14
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1399, 810)
        Me.Controls.Add(Me.panelRight)
        Me.Controls.Add(Me.panelLeft)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.panelLeft.ResumeLayout(False)
        Me.panelRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelLeft As Panel
    Friend WithEvents btnNewResident As ligaya_bims.RoundedButton
    Friend WithEvents panelRight As Panel
    Friend WithEvents pnlPic As Panel
    Friend WithEvents RoundedButton2 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton1 As ligaya_bims.RoundedButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RoundedButton3 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton4 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton5 As ligaya_bims.RoundedButton
End Class
