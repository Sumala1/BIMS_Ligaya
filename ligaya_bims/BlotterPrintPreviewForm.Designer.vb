<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlotterPrintPreviewForm
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
        Me.splitContainer = New System.Windows.Forms.SplitContainer()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.btnPageSetup = New System.Windows.Forms.Button()
        Me.cmbScaling = New System.Windows.Forms.ComboBox()
        Me.lblScaling = New System.Windows.Forms.Label()
        Me.cmbMargins = New System.Windows.Forms.ComboBox()
        Me.lblMargins = New System.Windows.Forms.Label()
        Me.cmbPaperSize = New System.Windows.Forms.ComboBox()
        Me.lblPaperSize = New System.Windows.Forms.Label()
        Me.cmbOrientation = New System.Windows.Forms.ComboBox()
        Me.lblOrientation = New System.Windows.Forms.Label()
        Me.cmbCollated = New System.Windows.Forms.ComboBox()
        Me.lblCollated = New System.Windows.Forms.Label()
        Me.txtPagesTo = New System.Windows.Forms.TextBox()
        Me.lblPagesSeparator = New System.Windows.Forms.Label()
        Me.txtPagesFrom = New System.Windows.Forms.TextBox()
        Me.lblPages = New System.Windows.Forms.Label()
        Me.cmbPrintRange = New System.Windows.Forms.ComboBox()
        Me.lblPrintRange = New System.Windows.Forms.Label()
        Me.btnPrinterProperties = New System.Windows.Forms.Button()
        Me.cmbPrinter = New System.Windows.Forms.ComboBox()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.pnlPreview = New System.Windows.Forms.Panel()
        Me.printPreviewControl = New System.Windows.Forms.PrintPreviewControl()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New ligaya_bims.RoundedButton()
        Me.btnPrint = New ligaya_bims.RoundedButton()
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer.Panel1.SuspendLayout()
        Me.splitContainer.Panel2.SuspendLayout()
        Me.splitContainer.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        Me.pnlPreview.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer
        '
        Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer.Name = "splitContainer"
        '
        'splitContainer.Panel1
        '
        Me.splitContainer.Panel1.Controls.Add(Me.pnlSettings)
        '
        'splitContainer.Panel2
        '
        Me.splitContainer.Panel2.Controls.Add(Me.pnlPreview)
        Me.splitContainer.Panel2.Controls.Add(Me.pnlButtons)
        Me.splitContainer.Size = New System.Drawing.Size(1184, 761)
        Me.splitContainer.SplitterDistance = 420
        Me.splitContainer.TabIndex = 0
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoScroll = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.btnPageSetup)
        Me.pnlSettings.Controls.Add(Me.cmbScaling)
        Me.pnlSettings.Controls.Add(Me.lblScaling)
        Me.pnlSettings.Controls.Add(Me.cmbMargins)
        Me.pnlSettings.Controls.Add(Me.lblMargins)
        Me.pnlSettings.Controls.Add(Me.cmbPaperSize)
        Me.pnlSettings.Controls.Add(Me.lblPaperSize)
        Me.pnlSettings.Controls.Add(Me.cmbOrientation)
        Me.pnlSettings.Controls.Add(Me.lblOrientation)
        Me.pnlSettings.Controls.Add(Me.cmbCollated)
        Me.pnlSettings.Controls.Add(Me.lblCollated)
        Me.pnlSettings.Controls.Add(Me.txtPagesTo)
        Me.pnlSettings.Controls.Add(Me.lblPagesSeparator)
        Me.pnlSettings.Controls.Add(Me.txtPagesFrom)
        Me.pnlSettings.Controls.Add(Me.lblPages)
        Me.pnlSettings.Controls.Add(Me.cmbPrintRange)
        Me.pnlSettings.Controls.Add(Me.lblPrintRange)
        Me.pnlSettings.Controls.Add(Me.btnPrinterProperties)
        Me.pnlSettings.Controls.Add(Me.cmbPrinter)
        Me.pnlSettings.Controls.Add(Me.lblPrinter)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlSettings.Size = New System.Drawing.Size(420, 761)
        Me.pnlSettings.TabIndex = 0
        '
        'btnPageSetup
        '
        Me.btnPageSetup.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnPageSetup.Location = New System.Drawing.Point(240, 365)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(130, 27)
        Me.btnPageSetup.TabIndex = 19
        Me.btnPageSetup.Text = "Page Setup"
        Me.btnPageSetup.UseVisualStyleBackColor = True
        '
        'cmbScaling
        '
        Me.cmbScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbScaling.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbScaling.FormattingEnabled = True
        Me.cmbScaling.Items.AddRange(New Object() {"No Scaling", "Fit Sheet on One Page", "Fit All Columns on One Page", "Fit All Rows on One Page"})
        Me.cmbScaling.Location = New System.Drawing.Point(140, 365)
        Me.cmbScaling.Name = "cmbScaling"
        Me.cmbScaling.Size = New System.Drawing.Size(94, 23)
        Me.cmbScaling.TabIndex = 18
        '
        'lblScaling
        '
        Me.lblScaling.AutoSize = True
        Me.lblScaling.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblScaling.Location = New System.Drawing.Point(22, 368)
        Me.lblScaling.Name = "lblScaling"
        Me.lblScaling.Size = New System.Drawing.Size(52, 15)
        Me.lblScaling.TabIndex = 17
        Me.lblScaling.Text = "Scaling:"
        '
        'cmbMargins
        '
        Me.cmbMargins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMargins.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbMargins.FormattingEnabled = True
        Me.cmbMargins.Items.AddRange(New Object() {"Normal Margins", "Wide Margins", "Narrow Margins", "Custom Margins"})
        Me.cmbMargins.Location = New System.Drawing.Point(140, 322)
        Me.cmbMargins.Name = "cmbMargins"
        Me.cmbMargins.Size = New System.Drawing.Size(230, 23)
        Me.cmbMargins.TabIndex = 16
        '
        'lblMargins
        '
        Me.lblMargins.AutoSize = True
        Me.lblMargins.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMargins.Location = New System.Drawing.Point(22, 325)
        Me.lblMargins.Name = "lblMargins"
        Me.lblMargins.Size = New System.Drawing.Size(62, 15)
        Me.lblMargins.TabIndex = 15
        Me.lblMargins.Text = "Margins:"
        '
        'cmbPaperSize
        '
        Me.cmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaperSize.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPaperSize.FormattingEnabled = True
        Me.cmbPaperSize.Location = New System.Drawing.Point(140, 279)
        Me.cmbPaperSize.Name = "cmbPaperSize"
        Me.cmbPaperSize.Size = New System.Drawing.Size(230, 23)
        Me.cmbPaperSize.TabIndex = 14
        '
        'lblPaperSize
        '
        Me.lblPaperSize.AutoSize = True
        Me.lblPaperSize.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPaperSize.Location = New System.Drawing.Point(22, 282)
        Me.lblPaperSize.Name = "lblPaperSize"
        Me.lblPaperSize.Size = New System.Drawing.Size(72, 15)
        Me.lblPaperSize.TabIndex = 13
        Me.lblPaperSize.Text = "Paper Size:"
        '
        'cmbOrientation
        '
        Me.cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrientation.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbOrientation.FormattingEnabled = True
        Me.cmbOrientation.Items.AddRange(New Object() {"Portrait Orientation", "Landscape Orientation"})
        Me.cmbOrientation.Location = New System.Drawing.Point(140, 236)
        Me.cmbOrientation.Name = "cmbOrientation"
        Me.cmbOrientation.Size = New System.Drawing.Size(230, 23)
        Me.cmbOrientation.TabIndex = 12
        '
        'lblOrientation
        '
        Me.lblOrientation.AutoSize = True
        Me.lblOrientation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOrientation.Location = New System.Drawing.Point(22, 239)
        Me.lblOrientation.Name = "lblOrientation"
        Me.lblOrientation.Size = New System.Drawing.Size(78, 15)
        Me.lblOrientation.TabIndex = 11
        Me.lblOrientation.Text = "Orientation:"
        '
        'cmbCollated
        '
        Me.cmbCollated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCollated.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCollated.FormattingEnabled = True
        Me.cmbCollated.Items.AddRange(New Object() {"Collated", "Uncollated"})
        Me.cmbCollated.Location = New System.Drawing.Point(140, 193)
        Me.cmbCollated.Name = "cmbCollated"
        Me.cmbCollated.Size = New System.Drawing.Size(230, 23)
        Me.cmbCollated.TabIndex = 10
        '
        'lblCollated
        '
        Me.lblCollated.AutoSize = True
        Me.lblCollated.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCollated.Location = New System.Drawing.Point(22, 196)
        Me.lblCollated.Name = "lblCollated"
        Me.lblCollated.Size = New System.Drawing.Size(60, 15)
        Me.lblCollated.TabIndex = 9
        Me.lblCollated.Text = "Collated:"
        '
        'txtPagesTo
        '
        Me.txtPagesTo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPagesTo.Location = New System.Drawing.Point(314, 150)
        Me.txtPagesTo.Name = "txtPagesTo"
        Me.txtPagesTo.Size = New System.Drawing.Size(56, 23)
        Me.txtPagesTo.TabIndex = 8
        '
        'lblPagesSeparator
        '
        Me.lblPagesSeparator.AutoSize = True
        Me.lblPagesSeparator.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPagesSeparator.Location = New System.Drawing.Point(293, 153)
        Me.lblPagesSeparator.Name = "lblPagesSeparator"
        Me.lblPagesSeparator.Size = New System.Drawing.Size(15, 15)
        Me.lblPagesSeparator.TabIndex = 7
        Me.lblPagesSeparator.Text = "to"
        '
        'txtPagesFrom
        '
        Me.txtPagesFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPagesFrom.Location = New System.Drawing.Point(231, 150)
        Me.txtPagesFrom.Name = "txtPagesFrom"
        Me.txtPagesFrom.Size = New System.Drawing.Size(56, 23)
        Me.txtPagesFrom.TabIndex = 6
        '
        'lblPages
        '
        Me.lblPages.AutoSize = True
        Me.lblPages.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPages.Location = New System.Drawing.Point(184, 153)
        Me.lblPages.Name = "lblPages"
        Me.lblPages.Size = New System.Drawing.Size(41, 15)
        Me.lblPages.TabIndex = 5
        Me.lblPages.Text = "Pages:"
        '
        'cmbPrintRange
        '
        Me.cmbPrintRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrintRange.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPrintRange.FormattingEnabled = True
        Me.cmbPrintRange.Items.AddRange(New Object() {"Print Active Sheets", "Print Selection", "Print Entire Workbook"})
        Me.cmbPrintRange.Location = New System.Drawing.Point(140, 107)
        Me.cmbPrintRange.Name = "cmbPrintRange"
        Me.cmbPrintRange.Size = New System.Drawing.Size(230, 23)
        Me.cmbPrintRange.TabIndex = 4
        '
        'lblPrintRange
        '
        Me.lblPrintRange.AutoSize = True
        Me.lblPrintRange.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrintRange.Location = New System.Drawing.Point(22, 110)
        Me.lblPrintRange.Name = "lblPrintRange"
        Me.lblPrintRange.Size = New System.Drawing.Size(77, 15)
        Me.lblPrintRange.TabIndex = 3
        Me.lblPrintRange.Text = "Print Range:"
        '
        'btnPrinterProperties
        '
        Me.btnPrinterProperties.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnPrinterProperties.Location = New System.Drawing.Point(249, 64)
        Me.btnPrinterProperties.Name = "btnPrinterProperties"
        Me.btnPrinterProperties.Size = New System.Drawing.Size(121, 27)
        Me.btnPrinterProperties.TabIndex = 2
        Me.btnPrinterProperties.Text = "Printer Properties"
        Me.btnPrinterProperties.UseVisualStyleBackColor = True
        '
        'cmbPrinter
        '
        Me.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbPrinter.FormattingEnabled = True
        Me.cmbPrinter.Location = New System.Drawing.Point(140, 21)
        Me.cmbPrinter.Name = "cmbPrinter"
        Me.cmbPrinter.Size = New System.Drawing.Size(230, 23)
        Me.cmbPrinter.TabIndex = 1
        '
        'lblPrinter
        '
        Me.lblPrinter.AutoSize = True
        Me.lblPrinter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrinter.Location = New System.Drawing.Point(22, 24)
        Me.lblPrinter.Name = "lblPrinter"
        Me.lblPrinter.Size = New System.Drawing.Size(51, 15)
        Me.lblPrinter.TabIndex = 0
        Me.lblPrinter.Text = "Printer:"
        '
        'pnlPreview
        '
        Me.pnlPreview.BackColor = System.Drawing.Color.LightGray
        Me.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreview.Location = New System.Drawing.Point(0, 0)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(760, 711)
        Me.pnlPreview.TabIndex = 1
        Me.pnlPreview.Controls.Add(Me.printPreviewControl)
        '
        'printPreviewControl
        '
        Me.printPreviewControl.AutoZoom = False
        Me.printPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.printPreviewControl.Location = New System.Drawing.Point(0, 0)
        Me.printPreviewControl.Name = "printPreviewControl"
        Me.printPreviewControl.Size = New System.Drawing.Size(760, 711)
        Me.printPreviewControl.TabIndex = 0
        Me.printPreviewControl.Zoom = 1.0R
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnPrint)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 711)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlButtons.Size = New System.Drawing.Size(760, 50)
        Me.pnlButtons.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.BorderRadius = 15
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(630, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnPrint.BorderRadius = 15
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(524, 10)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 30)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'BlotterPrintPreviewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.splitContainer)
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.Name = "BlotterPrintPreviewForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Blotter Record"
        Me.splitContainer.Panel1.ResumeLayout(False)
        Me.splitContainer.Panel2.ResumeLayout(False)
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer.ResumeLayout(False)
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlPreview.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents splitContainer As SplitContainer
    Friend WithEvents pnlSettings As Panel
    Friend WithEvents pnlPreview As Panel
    Friend WithEvents printPreviewControl As PrintPreviewControl
    Friend WithEvents btnPrinterProperties As Button
    Friend WithEvents cmbPrinter As ComboBox
    Friend WithEvents lblPrinter As Label
    Friend WithEvents cmbPrintRange As ComboBox
    Friend WithEvents lblPrintRange As Label
    Friend WithEvents txtPagesTo As TextBox
    Friend WithEvents lblPagesSeparator As Label
    Friend WithEvents txtPagesFrom As TextBox
    Friend WithEvents lblPages As Label
    Friend WithEvents cmbCollated As ComboBox
    Friend WithEvents lblCollated As Label
    Friend WithEvents cmbOrientation As ComboBox
    Friend WithEvents lblOrientation As Label
    Friend WithEvents cmbPaperSize As ComboBox
    Friend WithEvents lblPaperSize As Label
    Friend WithEvents cmbMargins As ComboBox
    Friend WithEvents lblMargins As Label
    Friend WithEvents cmbScaling As ComboBox
    Friend WithEvents lblScaling As Label
    Friend WithEvents btnPageSetup As Button
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnCancel As ligaya_bims.RoundedButton
    Friend WithEvents btnPrint As ligaya_bims.RoundedButton
End Class

