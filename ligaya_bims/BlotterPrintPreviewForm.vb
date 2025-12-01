Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Text
Imports System.IO

Public Structure BlotterRecordData
    Public CaseNumber As String
    Public ComplainantName As String
    Public ComplainantAddress As String
    Public TypeOfIncident As String
    Public IncidentDate As DateTime?
    Public Location As String
    Public InvolvedPerson As String
    Public Narrative As String
End Structure

Public Partial Class BlotterPrintPreviewForm
    Private blotterData As BlotterRecordData
    Private ReadOnly availablePaperSizes As New List(Of PaperSize)()
    Private printDocument As PrintDocument
    Private printDialog As PrintDialog
    Private pageSetupDialog As PageSetupDialog

    Public Sub New()
        Me.New(New BlotterRecordData())
    End Sub

    Public Sub New(data As BlotterRecordData)
        blotterData = data
        InitializeComponent()
        InitializePrintingInfrastructure()
        InitializeDefaultSelections()
        LoadPrinters()
        SetupPageSettings()
    End Sub

    Private Sub InitializePrintingInfrastructure()
        printDocument = New PrintDocument() With {
            .DocumentName = "Incident Report Form"
        }
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        AddHandler printDocument.BeginPrint, AddressOf PrintDocument_BeginPrint

        printPreviewControl.Document = printDocument
        printPreviewControl.AutoZoom = False
        printPreviewControl.Zoom = 1.0R
        printPreviewControl.UseAntiAlias = True

        printDialog = New PrintDialog() With {
            .Document = printDocument,
            .UseEXDialog = True
        }

        pageSetupDialog = New PageSetupDialog() With {
            .Document = printDocument
        }
    End Sub

    Private Sub InitializeDefaultSelections()
        If cmbPrintRange.Items.Count > 0 Then cmbPrintRange.SelectedIndex = 0
        If cmbCollated.Items.Count > 0 Then cmbCollated.SelectedIndex = 0
        If cmbOrientation.Items.Count > 0 Then cmbOrientation.SelectedIndex = 0
        If cmbMargins.Items.Count > 0 Then cmbMargins.SelectedIndex = 0
        If cmbScaling.Items.Count > 0 Then cmbScaling.SelectedIndex = 0

        txtPagesFrom.Text = "1"
        txtPagesTo.Text = "1"
    End Sub

    Private Sub LoadPrinters()
        cmbPrinter.Items.Clear()
        For Each printerName As String In PrinterSettings.InstalledPrinters
            cmbPrinter.Items.Add(printerName)
        Next

        If cmbPrinter.Items.Count > 0 Then
            Try
                Dim defaultPrinter As New PrinterSettings()
                Dim defaultIndex As Integer = cmbPrinter.Items.IndexOf(defaultPrinter.PrinterName)
                cmbPrinter.SelectedIndex = If(defaultIndex >= 0, defaultIndex, 0)
            Catch
                cmbPrinter.SelectedIndex = 0
            End Try
        End If
    End Sub

    Private Sub SetupPageSettings()
        If printDocument Is Nothing OrElse printDocument.PrinterSettings Is Nothing Then
            Return
        End If

        cmbPaperSize.Items.Clear()
        availablePaperSizes.Clear()

        Try
            For Each paperSize As PaperSize In printDocument.PrinterSettings.PaperSizes
                availablePaperSizes.Add(paperSize)
                cmbPaperSize.Items.Add(paperSize.PaperName)
            Next
        Catch
            ' Ignore printer-specific failures, user can pick later.
        End Try

        If cmbPaperSize.Items.Count > 0 Then
            Dim preferredIndex As Integer = -1
            For i As Integer = 0 To cmbPaperSize.Items.Count - 1
                Dim name = cmbPaperSize.Items(i).ToString()
                If name.IndexOf("Letter", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                   name.IndexOf("Executive", StringComparison.OrdinalIgnoreCase) >= 0 Then
                    preferredIndex = i
                    Exit For
                End If
            Next
            cmbPaperSize.SelectedIndex = If(preferredIndex >= 0, preferredIndex, 0)
        End If
    End Sub

    Private Sub cmbPrinter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrinter.SelectedIndexChanged
        If cmbPrinter.SelectedItem Is Nothing OrElse printDocument Is Nothing Then
            Return
        End If

        printDocument.PrinterSettings.PrinterName = cmbPrinter.SelectedItem.ToString()
        SetupPageSettings()
        printPreviewControl.InvalidatePreview()
    End Sub

    Private Sub cmbOrientation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrientation.SelectedIndexChanged
        If printDocument Is Nothing Then
            Return
        End If

        printDocument.DefaultPageSettings.Landscape = (cmbOrientation.SelectedIndex = 1)
        printPreviewControl.InvalidatePreview()
    End Sub

    Private Sub cmbPaperSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaperSize.SelectedIndexChanged
        If printDocument Is Nothing Then Return
        Dim index As Integer = cmbPaperSize.SelectedIndex
        If index < 0 OrElse index >= availablePaperSizes.Count Then Return

        printDocument.DefaultPageSettings.PaperSize = availablePaperSizes(index)
        printPreviewControl.InvalidatePreview()
    End Sub

    Private Sub cmbMargins_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMargins.SelectedIndexChanged
        If printDocument Is Nothing Then Return

        Dim newMargins As Margins
        Select Case cmbMargins.SelectedIndex
            Case 0 ' Normal
                newMargins = New Margins(50, 50, 50, 50)
            Case 1 ' Wide
                newMargins = New Margins(100, 100, 80, 80)
            Case 2 ' Narrow
                newMargins = New Margins(25, 25, 25, 25)
            Case 3 ' Custom
                If pageSetupDialog IsNot Nothing AndAlso pageSetupDialog.Document IsNot Nothing Then
                    If pageSetupDialog.ShowDialog(Me) = DialogResult.OK Then
                        printPreviewControl.InvalidatePreview()
                    End If
                    Return
                Else
                    Return
                End If
            Case Else
                Return
        End Select

        printDocument.DefaultPageSettings.Margins = newMargins
        printPreviewControl.InvalidatePreview()
    End Sub

    Private Sub cmbScaling_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbScaling.SelectedIndexChanged
        Select Case cmbScaling.SelectedIndex
            Case 0 ' No Scaling
                printPreviewControl.Zoom = 1.0R
            Case 1 ' Fit Sheet
                printPreviewControl.Zoom = 0.9R
            Case 2 ' Fit Columns
                printPreviewControl.Zoom = 0.85R
            Case 3 ' Fit Rows
                printPreviewControl.Zoom = 0.8R
        End Select
    End Sub

    Private Sub cmbCollated_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCollated.SelectedIndexChanged
        If printDocument Is Nothing Then Return
        printDocument.PrinterSettings.Collate = (cmbCollated.SelectedIndex = 0)
    End Sub

    Private Sub cmbPrintRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrintRange.SelectedIndexChanged
        UpdatePageRangeSettings()
    End Sub

    Private Sub txtPagesFrom_TextChanged(sender As Object, e As EventArgs) Handles txtPagesFrom.TextChanged
        UpdatePageRangeSettings()
    End Sub

    Private Sub txtPagesTo_TextChanged(sender As Object, e As EventArgs) Handles txtPagesTo.TextChanged
        UpdatePageRangeSettings()
    End Sub

    Private Sub UpdatePageRangeSettings()
        If printDocument Is Nothing Then Return

        Dim settings = printDocument.PrinterSettings
        If settings Is Nothing Then Return

        Select Case cmbPrintRange.SelectedIndex
            Case 0
                settings.PrintRange = PrintRange.AllPages
            Case 1
                settings.PrintRange = PrintRange.Selection
            Case Else
                settings.PrintRange = PrintRange.SomePages
        End Select

        Dim fromPage As Integer
        Dim toPage As Integer
        Dim hasFrom = Integer.TryParse(txtPagesFrom.Text, fromPage)
        Dim hasTo = Integer.TryParse(txtPagesTo.Text, toPage)

        If Not hasFrom Then fromPage = 1
        If Not hasTo Then toPage = Math.Max(fromPage, 1)
        If toPage < fromPage Then toPage = fromPage

        settings.MinimumPage = 1
        settings.MaximumPage = Math.Max(toPage, 1)
        settings.FromPage = fromPage
        settings.ToPage = toPage

        printPreviewControl.InvalidatePreview()
    End Sub

    Private Sub btnPrinterProperties_Click(sender As Object, e As EventArgs) Handles btnPrinterProperties.Click
        If printDialog Is Nothing Then
            Return
        End If

        Try
            If printDialog.ShowDialog(Me) = DialogResult.OK Then
                SetupPageSettings()
                printPreviewControl.InvalidatePreview()
            End If
        Catch ex As Exception
            MessageBox.Show(Me, $"Error accessing printer properties: {ex.Message}", "Print", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPageSetup_Click(sender As Object, e As EventArgs) Handles btnPageSetup.Click
        If pageSetupDialog Is Nothing Then
            Return
        End If

        pageSetupDialog.ShowDialog(Me)
        SetupPageSettings()
        printPreviewControl.InvalidatePreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If printDialog Is Nothing Then
            Return
        End If

        If printDialog.ShowDialog(Me) = DialogResult.OK Then
            printDocument.Print()
            MessageBox.Show(Me, "Print job sent successfully.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub PrintDocument_BeginPrint(sender As Object, e As PrintEventArgs)
        If printDocument Is Nothing Then
            Return
        End If

        If String.IsNullOrWhiteSpace(printDocument.PrinterSettings.PrinterName) AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
            printDocument.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters(0)
        End If

        printDocument.DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)
        printDocument.DefaultPageSettings.Landscape = (cmbOrientation.SelectedIndex = 1)
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        If g Is Nothing Then
            e.Cancel = True
            Return
        End If

        Try
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            Dim pageRect As Rectangle = e.PageBounds
            Dim margin As Integer = 50

            g.FillRectangle(Brushes.White, pageRect)
            DrawIncidentReportForm(g, pageRect, margin)
            e.HasMorePages = False
        Catch ex As Exception
            Dim errorFont As New Font("Arial", 12, FontStyle.Regular)
            g.DrawString($"Error rendering preview: {ex.Message}", errorFont, Brushes.Red, New PointF(50, 50))
        End Try
    End Sub

    Private Sub DrawIncidentReportForm(g As Graphics, pageRect As Rectangle, margin As Integer)
        Try
            Dim pageWidth As Integer = pageRect.Width - (2 * margin)
            Dim currentY As Integer = margin + 20
            Dim headerSectionHeight As Integer = 150

            Dim logoSize As Integer = 120
            Dim logoRect As New Rectangle(margin + 50, currentY, logoSize, logoSize)

            Try
                Dim logo As Image = Nothing
                Try
                    logo = Global.ligaya_bims.My.Resources.Resources.brgy_ligaya_logo
                Catch
                    Dim logoObj As Object = My.Resources.ResourceManager.GetObject("brgy_ligaya_logo")
                    If TypeOf logoObj Is Bitmap Then
                        logo = DirectCast(logoObj, Bitmap)
                    End If
                End Try

                If logo IsNot Nothing Then
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                    g.DrawImage(logo, logoRect)
                Else
                    Dim possiblePaths As New List(Of String)()
                    Dim assemblyPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                    If Not String.IsNullOrEmpty(assemblyPath) Then
                        possiblePaths.Add(Path.Combine(assemblyPath, "Resources", "brgy.ligaya_logo-removebg-preview.png"))
                        possiblePaths.Add(Path.Combine(assemblyPath, "Resources", "brgy.ligaya_logo-removebg-preview-removebg-preview.png"))
                    End If
                    possiblePaths.Add(Path.Combine(Application.StartupPath, "Resources", "brgy.ligaya_logo-removebg-preview.png"))
                    possiblePaths.Add(Path.Combine(Application.StartupPath, "Resources", "brgy.ligaya_logo-removebg-preview-removebg-preview.png"))

                    For Each path In possiblePaths
                        If File.Exists(path) Then
                            Using logoFromFile As Image = Image.FromFile(path)
                                g.DrawImage(logoFromFile, logoRect)
                            End Using
                            Exit For
                        End If
                    Next
                End If
            Catch
                g.FillEllipse(Brushes.White, logoRect)
                g.DrawEllipse(New Pen(Color.Red, 2), logoRect)
                Dim sealFont As New Font("Arial", 10, FontStyle.Bold)
                g.DrawString("OFFICIAL SEAL", sealFont, Brushes.Black, New PointF(logoRect.X + 15, logoRect.Y + 50))
            End Try

            Dim headerFont As New Font("Segoe UI", 13, FontStyle.Bold)
            Dim subHeaderFont As New Font("Segoe UI", 12, FontStyle.Regular)
            Dim centerFormat As New StringFormat() With {.Alignment = StringAlignment.Center}
            Dim headerY As Integer = currentY + 10

            g.DrawString("Republic of the Philippines", subHeaderFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)
            headerY += 25
            g.DrawString("GENERAL SANTOS CITY", headerFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)
            headerY += 25
            g.DrawString("BARANGAY LIGAYA", headerFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)
            headerY += 30
            g.DrawString("-oo0oo-", subHeaderFont, Brushes.Black,
                         New RectangleF(margin, headerY, pageWidth, 20), centerFormat)

            currentY += headerSectionHeight

            Dim titleFont As New Font("Segoe UI", 16, FontStyle.Bold)
            g.DrawString("INCIDENT REPORT FORM", titleFont, Brushes.Black,
                         New RectangleF(margin, currentY, pageWidth, 30), centerFormat)
            currentY += 60

            Dim fieldFont As New Font("Segoe UI", 10, FontStyle.Regular)
            Dim fieldLabelFont As New Font("Segoe UI", 10, FontStyle.Bold)
            Dim fieldHeight As Integer = 80
            Dim infoFieldHeight As Integer = 60
            Dim pen As New Pen(Color.Black, 1)

            Dim fieldRect As Rectangle
            fieldRect = New Rectangle(margin, currentY, pageWidth, infoFieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Complainant's Name", fieldLabelFont, Brushes.Black, New PointF(margin + 5, currentY + 5))
            g.DrawString(blotterData.ComplainantName, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, infoFieldHeight - 30))
            currentY += infoFieldHeight

            fieldRect = New Rectangle(margin, currentY, pageWidth, infoFieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Complainant's Address", fieldLabelFont, Brushes.Black, New PointF(margin + 5, currentY + 5))
            g.DrawString(blotterData.ComplainantAddress, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, infoFieldHeight - 30))
            currentY += infoFieldHeight

            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Type of Incident (curfew hours, ordinance related to COVID-19, etc)", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(blotterData.TypeOfIncident, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Inclusive Dates and Time of Incident", fieldLabelFont, Brushes.Black, New PointF(margin + 5, currentY + 5))
            Dim dateTimeText As String = String.Empty
            If blotterData.IncidentDate.HasValue Then
                dateTimeText = blotterData.IncidentDate.Value.ToString("MMMM dd, yyyy  hh:mm tt")
            End If
            g.DrawString(dateTimeText, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Exact Location of Incident (road, zone, barangay, etc.)", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(blotterData.Location, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            fieldRect = New Rectangle(margin, currentY, pageWidth, fieldHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Involved Person/Specific Identification (Name, Age, Gender, Address, Position/Designation)", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(blotterData.InvolvedPerson, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, fieldHeight - 30))
            currentY += fieldHeight

            Dim narrativeHeight As Integer = 120
            fieldRect = New Rectangle(margin, currentY, pageWidth, narrativeHeight)
            g.DrawRectangle(pen, fieldRect)
            g.DrawString("Narrative Details of Incident (description how the incident happened, others)", fieldLabelFont, Brushes.Black,
                         New PointF(margin + 5, currentY + 5))
            g.DrawString(blotterData.Narrative, fieldFont, Brushes.Black,
                         New RectangleF(margin + 5, currentY + 25, pageWidth - 10, narrativeHeight - 30))
        Catch ex As Exception
            Dim errorFont As New Font("Arial", 12, FontStyle.Regular)
            g.DrawString($"Error creating preview: {ex.Message}", errorFont, Brushes.Red,
                         New RectangleF(margin, margin, pageRect.Width - 2 * margin, 100))
        End Try
    End Sub
End Class

