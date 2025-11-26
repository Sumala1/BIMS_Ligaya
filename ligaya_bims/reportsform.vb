Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports System.Linq

Partial Class reportsform
    Public Event IncidentSubmitted()
    Private lastGeneratedCaseNumber As String = String.Empty

    Public Sub New()
        InitializeComponent()
        ApplyFixedWindowBounds()
    End Sub

    Private Sub ApplyFixedWindowBounds()
        If Me.FormBorderStyle <> FormBorderStyle.None AndAlso Me.TopLevel Then
            Dim currentSize As Size = Me.Size
            Me.MinimumSize = currentSize
            Me.MaximumSize = currentSize
        End If
    End Sub

    ' Method to handle when form is displayed as child form in dashboard
    Public Sub SetAsChildForm()
        ' Ensure the form is properly configured for child display
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
        Me.MinimumSize = Size.Empty
        Me.MaximumSize = Size.Empty
    End Sub

    Private Function ValidateIncidentFields() As Boolean
        If String.IsNullOrWhiteSpace(txtComplainantName.Text) Then
            MessageBox.Show("Please enter the complainant's name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComplainantName.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtComplainantAddress.Text) Then
            MessageBox.Show("Please enter the complainant's address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtComplainantAddress.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtTypeOfIncident.Text) Then
            MessageBox.Show("Please specify the type of incident.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTypeOfIncident.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtExactLocation.Text) Then
            MessageBox.Show("Please provide the incident location.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtExactLocation.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtNarrative.Text) Then
            MessageBox.Show("Please provide the incident narrative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNarrative.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function GenerateCaseNumber() As String
        Return $"B-{DateTime.Now:yyyyMMddHHmmss}"
    End Function

    Private Function SaveIncidentToDatabase() As Boolean
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "INSERT INTO tbl_blotter (case_number, accusation, complainant_name, purok) VALUES (@caseNumber, @accusation, @complainant, @purok)"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    lastGeneratedCaseNumber = GenerateCaseNumber()
                    cmd.Parameters.AddWithValue("@caseNumber", lastGeneratedCaseNumber)
                    cmd.Parameters.AddWithValue("@accusation", txtTypeOfIncident.Text.Trim())
                    cmd.Parameters.AddWithValue("@complainant", txtComplainantName.Text.Trim())
                    cmd.Parameters.AddWithValue("@purok", txtComplainantAddress.Text.Trim())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show("Error saving incident: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function SaveIncidentAsPdf() As Boolean
        Dim pdfPrinterName As String = Printing.PrinterSettings.InstalledPrinters.Cast(Of String)().FirstOrDefault(Function(p) p.Equals("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase))
        If String.IsNullOrWhiteSpace(pdfPrinterName) Then
            MessageBox.Show("Microsoft Print to PDF printer is not available on this system.", "Printer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf"
            saveDialog.Title = "Save Incident Report as PDF"
            Dim safeIncidentName As String = If(String.IsNullOrWhiteSpace(txtTypeOfIncident.Text), "Incident", txtTypeOfIncident.Text.Trim().Replace(" ", "_"))
            saveDialog.FileName = $"{safeIncidentName}_{DateTime.Now:yyyyMMddHHmmss}.pdf"

            If saveDialog.ShowDialog() <> DialogResult.OK Then
                Return False
            End If

            Dim originalController As PrintController = PrintDocument1.PrintController
            Dim originalSettings As Printing.PrinterSettings = CType(PrintDocument1.PrinterSettings.Clone(), Printing.PrinterSettings)

            Try
                Dim pdfSettings As New Printing.PrinterSettings()
                pdfSettings.PrinterName = pdfPrinterName
                pdfSettings.PrintToFile = True
                pdfSettings.PrintFileName = saveDialog.FileName

                PrintDocument1.PrintController = New StandardPrintController()
                PrintDocument1.PrinterSettings = pdfSettings
                PrintDocument1.Print()
                Return True
            Finally
                PrintDocument1.PrintController = originalController
                PrintDocument1.PrinterSettings = originalSettings
            End Try
        End Using
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSavePdf_Click(sender As Object, e As EventArgs) Handles btnSavePdf.Click
        If Not ValidateIncidentFields() Then Return
        Try
            If SaveIncidentAsPdf() Then
                MessageBox.Show("Incident report saved as PDF.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If Not ValidateIncidentFields() Then Return
        If SaveIncidentToDatabase() Then
            MessageBox.Show($"Incident saved successfully. Generated Case #: {lastGeneratedCaseNumber}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RaiseEvent IncidentSubmitted()
            Me.Close()
        End If
    End Sub

    Private Sub reportsform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date/time values
        dtpFrom.Value = DateTime.Now.AddHours(-1)
        dtpTo.Value = DateTime.Now
        ApplyFixedWindowBounds()
        ' Hide extra buttons to merge preview and print

    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        PrintDocument1.DefaultPageSettings.Margins = New Printing.Margins(0, 0, 0, 0)
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim pageRect As Rectangle = e.PageBounds
        Dim margin As Integer = 50

        ' Fill white background
        g.FillRectangle(Brushes.White, pageRect)

        ' Draw the exact form layout as shown in the image
        DrawIncidentReportForm(g, pageRect, margin)

        e.HasMorePages = False
    End Sub

    Private Sub DrawIncidentReportForm(g As Graphics, pageRect As Rectangle, margin As Integer)
        Try
            Dim pageWidth As Integer = pageRect.Width - (2 * margin)
            Dim currentY As Integer = margin + 20 ' Add some top margin

            ' Create a proper header section
            Dim headerSectionHeight As Integer = 150

            ' Draw logo at the top left
            Dim logoSize As Integer = 120
            Dim logoRect As New Rectangle(margin + 50, currentY, logoSize, logoSize)

            ' Draw the barangay logo (if available)
            Try
                Dim logoObj As Object = My.Resources.ResourceManager.GetObject("brgy_ligaya_logo")
                If logoObj IsNot Nothing AndAlso TypeOf logoObj Is Bitmap Then
                    Dim logo As Bitmap = DirectCast(logoObj, Bitmap)
                    g.DrawImage(logo, logoRect)
                Else
                    ' If logo not available, draw a placeholder circle with red border
                    g.FillEllipse(Brushes.White, logoRect)
                    g.DrawEllipse(New Pen(Color.Red, 2), logoRect)
                    g.DrawString("OFFICIAL SEAL", New Font("Arial", 10, FontStyle.Bold), Brushes.Black,
                                New PointF(logoRect.X + 15, logoRect.Y + 50))
                End If
            Catch ex As Exception
                ' If logo not available, draw a placeholder circle with red border
                g.FillEllipse(Brushes.White, logoRect)
                g.DrawEllipse(New Pen(Color.Red, 2), logoRect)
                g.DrawString("OFFICIAL SEAL", New Font("Arial", 10, FontStyle.Bold), Brushes.Black,
                            New PointF(logoRect.X + 15, logoRect.Y + 50))
            End Try

            ' Draw header text - properly centered in the page
            Dim headerFont As New Font("Arial", 12, FontStyle.Bold)
            Dim subHeaderFont As New Font("Arial", 11, FontStyle.Regular)
            Dim centerFormat As New StringFormat() With {.Alignment = StringAlignment.Center}

            ' Center all text in the entire page width for better alignment
            Dim headerY As Integer = currentY + 10

            ' Republic of the Philippines
            g.DrawString("Republic of the Philippines", subHeaderFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)
            headerY += 25

            ' GENERAL SANTOS CITY
            g.DrawString("GENERAL SANTOS CITY", headerFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)
            headerY += 25

            ' BARANGAY LIGAYA
            g.DrawString("BARANGAY LIGAYA", headerFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)
            headerY += 30

            ' -oo0oo-
            g.DrawString("-oo0oo-", subHeaderFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)

            ' Update current Y position after header section
            currentY += headerSectionHeight

            ' Draw title - centered on the entire page with more emphasis
            Dim titleFont As New Font("Arial", 14, FontStyle.Bold)
            g.DrawString("INCIDENT REPORT FORM", titleFont, Brushes.Black,
                         New RectangleF(margin, currentY, pageWidth, 30), centerFormat)
            currentY += 50

            ' Draw form fields
            Dim fieldFont As New Font("Arial", 9, FontStyle.Regular)
            Dim fieldLabelFont As New Font("Arial", 9, FontStyle.Bold)
            Dim fieldHeight As Integer = 80
            Dim pen As New Pen(Color.Black, 1)

            Dim infoFieldHeight As Integer = 60

            ' Complainant Name field
            Dim fieldRect As New Rectangle(margin, currentY, pageWidth, infoFieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Complainant's Name", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(txtComplainantName.Text, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, infoFieldHeight - 30))
            currentY += infoFieldHeight

            ' Complainant Address field
            fieldRect = New Rectangle(margin, currentY, pageWidth, infoFieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Complainant's Address", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(txtComplainantAddress.Text, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, infoFieldHeight - 30))
            currentY += infoFieldHeight

            ' Type of Incident field
            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Type of Incident (curfew hours, ordinance related to COVID-19, etc)", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(txtTypeOfIncident.Text, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            ' Inclusive Dates field
            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Inclusive Dates and Time of Incident", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(String.Format("{0} - {1}", dtpFrom.Value.ToString("MMMM dd, yyyy  hh:mm tt"),
                                      dtpTo.Value.ToString("MMMM dd, yyyy  hh:mm tt")),
                         fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            ' Exact Location field
            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Exact Location of Incident (road, zone, barangay, etc.)", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(txtExactLocation.Text, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            ' Involved Person field
            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Involved Person/Specific Identification (Name, Age, Gender, Address, Position/Designation)",
                         fieldLabelFont, Brushes.Black, New PointF(margin + 5, currentY + 5))
            g.DrawString(txtInvolved.Text, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            ' Narrative Details field
            Dim narrativeHeight As Integer = 120
            fieldRect = New Rectangle(margin, currentY, pageWidth, narrativeHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Narrative Details of Incident (description how the incident happened, others)",
                         fieldLabelFont, Brushes.Black, New PointF(margin + 5, currentY + 5))
            g.DrawString(txtNarrative.Text, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, narrativeHeight - 30))

        Catch ex As Exception
            ' If drawing fails, show error message
            Dim errorFont As New Font("Arial", 12, FontStyle.Regular)
            g.DrawString("Error creating preview: " & ex.Message, errorFont, Brushes.Red, New RectangleF(margin, margin, pageRect.Width - 2 * margin, 100))
        End Try
    End Sub

    ' SplitTextIntoLines function has been removed as it's no longer needed

    Private Shared Function ScaleRect(container As Rectangle, relX As Single, relY As Single, relW As Single, relH As Single) As RectangleF
        Dim x As Single = container.X + container.Width * relX
        Dim y As Single = container.Y + container.Height * relY
        Dim w As Single = container.Width * relW
        Dim h As Single = container.Height * relH
        Return New RectangleF(x, y, w, h)
    End Function

    Private Sub btnPreview_Click(sender As Object, e As EventArgs)
        Try
            ' Configure the print preview dialog
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen

            ' Show the print preview dialog
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error showing print preview: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs)
        ' Merged flow: show preview dialog which has built-in print button
        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error showing print preview: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPageSetup_Click(sender As Object, e As EventArgs)
        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.ShowDialog()
    End Sub

    Protected Overrides Sub Finalize()
        ' Clean up resources if needed
        MyBase.Finalize()
    End Sub

    Private Sub txtTypeOfIncident_TextChanged(sender As Object, e As EventArgs) Handles txtTypeOfIncident.TextChanged

    End Sub
End Class

