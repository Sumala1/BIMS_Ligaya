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
        Me.panelRight = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RoundedButton3 = New ligaya_bims.RoundedButton()
        Me.RoundedButton4 = New ligaya_bims.RoundedButton()
        Me.RoundedButton5 = New ligaya_bims.RoundedButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.panelRight.SuspendLayout()
        Me.SuspendLayout()
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
        Me.panelRight.Location = New System.Drawing.Point(932, 80)
        Me.panelRight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelRight.Name = "panelRight"
        Me.panelRight.Size = New System.Drawing.Size(584, 862)
        Me.panelRight.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 777)
        Me.Panel1.TabIndex = 14
        '
        'RoundedButton3
        '
        Me.RoundedButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.RoundedButton3.BorderRadius = 15
        Me.RoundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RoundedButton3.ForeColor = System.Drawing.Color.White
        Me.RoundedButton3.Location = New System.Drawing.Point(35, 791)
        Me.RoundedButton3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedButton3.Name = "RoundedButton3"
        Me.RoundedButton3.Size = New System.Drawing.Size(144, 49)
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
        Me.RoundedButton4.Location = New System.Drawing.Point(223, 791)
        Me.RoundedButton4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedButton4.Name = "RoundedButton4"
        Me.RoundedButton4.Size = New System.Drawing.Size(144, 49)
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
        Me.RoundedButton5.Location = New System.Drawing.Point(408, 791)
        Me.RoundedButton5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RoundedButton5.Name = "RoundedButton5"
        Me.RoundedButton5.Size = New System.Drawing.Size(144, 49)
        Me.RoundedButton5.TabIndex = 11
        Me.RoundedButton5.Text = "Print"
        Me.RoundedButton5.UseVisualStyleBackColor = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1865, 997)
        Me.Controls.Add(Me.panelRight)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.panelRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelRight As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RoundedButton3 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton4 As ligaya_bims.RoundedButton
    Friend WithEvents RoundedButton5 As ligaya_bims.RoundedButton
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
