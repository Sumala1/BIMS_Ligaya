Imports System.Drawing.Printing

Public Class certificateform
    Public Event CertificateSaved()
    Private certAnnual As New List(Of String)()
    
    Private Sub SetBaseFieldsVisible(isVisible As Boolean)
        ' Base fields have been removed - form now uses Panel2 controls dynamically
        ' This method is kept for compatibility but no longer needs to do anything
    End Sub


    Private Sub certificateform_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Clean up persistent forms when main form is closed
        CertificateFormManager.DisposeAllForms()
    End Sub

    ' Database methods
    Private Function ValidateFormData() As Boolean
        ' Minimal validation: ensure a certificate type is selected
        If cmbCertificateType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a certificate type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCertificateType.Focus()
            Return False
        End If
        Return True
    End Function

    ' Base status controls are removed from UI; try to infer from Panel2 controls when available
    Private Function GetStatus() As String
        Dim cmb As ComboBox = TryCast(FindPanel2Control("cmb3"), ComboBox)
        If cmb IsNot Nothing AndAlso cmb.SelectedItem IsNot Nothing Then
            Return cmb.SelectedItem.ToString()
        End If
        Return String.Empty
    End Function

    Private Function FindPanel2Control(name As String) As Control
        For Each ctrl As Control In panelFormFields.Controls
            If String.Equals(ctrl.Name, name, StringComparison.OrdinalIgnoreCase) Then
                Return ctrl
            End If
        Next
        Return Nothing
    End Function

    Private Function GetPanel2Text(name As String) As String
        Dim c As Control = FindPanel2Control(name)
        If TypeOf c Is TextBox Then
            Return DirectCast(c, TextBox).Text
        ElseIf TypeOf c Is ComboBox Then
            Dim cb = DirectCast(c, ComboBox)
            Return If(cb.SelectedItem IsNot Nothing, cb.SelectedItem.ToString(), String.Empty)
        End If
        Return String.Empty
    End Function

    Private Function GetPanel2Date(name As String) As DateTime
        Dim c As Control = FindPanel2Control(name)
        If TypeOf c Is DateTimePicker Then
            Return DirectCast(c, DateTimePicker).Value
        End If
        Return DateTime.Now
    End Function

    Private Function SaveCertificateToDatabase() As Boolean
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Use INSERT IGNORE or check for duplicates first to avoid duplicate entry errors
                ' Alternatively, use INSERT ... ON DUPLICATE KEY UPDATE if you want to update existing records
                Dim sql As String = "INSERT INTO tbl_certificate (certificate, fullname, age, status, address, purpose, issuedon) VALUES (@certificate, @fullname, @age, @status, @address, @purpose, @issuedon)"

                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Dim certificateType As String = If(cmbCertificateType.SelectedItem IsNot Nothing, cmbCertificateType.SelectedItem.ToString(), "")
                    If String.IsNullOrWhiteSpace(certificateType) Then
                        MessageBox.Show("Please select a certificate type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                    
                    cmd.Parameters.AddWithValue("@certificate", certificateType)
                    ' Try to source values from Panel2 standard names, fallback to shared data/empty
                    Dim fullName As String = GetPanel2Text("txt1")
                    If String.IsNullOrWhiteSpace(fullName) Then fullName = GetPanel2Text("txtfullname")
                    If String.IsNullOrWhiteSpace(fullName) Then fullName = SharedCertificateData.FullName
                    
                    Dim ageText As String = GetPanel2Text("txt6")
                    If String.IsNullOrWhiteSpace(ageText) Then ageText = GetPanel2Text("txtage")
                    Dim ageVal As Integer = 0
                    Integer.TryParse(ageText, ageVal)
                    
                    Dim addressVal As String = GetPanel2Text("txt4")
                    If String.IsNullOrWhiteSpace(addressVal) Then addressVal = GetPanel2Text("txtaddress")
                    If String.IsNullOrWhiteSpace(addressVal) Then addressVal = SharedCertificateData.Address
                    
                    Dim purposeVal As String = GetPanel2Text("txt5")
                    If String.IsNullOrWhiteSpace(purposeVal) Then purposeVal = GetPanel2Text("txtpurpose")
                    If String.IsNullOrWhiteSpace(purposeVal) Then purposeVal = SharedCertificateData.Purpose
                    
                    Dim issuedOn As DateTime = GetPanel2Date("dtpissueddate")
                    If issuedOn = DateTime.MinValue Then issuedOn = DateTime.Now

                    cmd.Parameters.AddWithValue("@fullname", If(String.IsNullOrWhiteSpace(fullName), String.Empty, fullName))
                    cmd.Parameters.AddWithValue("@age", ageVal)
                    cmd.Parameters.AddWithValue("@status", GetStatus())
                    cmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(addressVal), String.Empty, addressVal))
                    cmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrWhiteSpace(purposeVal), String.Empty, purposeVal))
                    cmd.Parameters.AddWithValue("@issuedon", issuedOn)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        RaiseEvent CertificateSaved()
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            If ex.Number = 1062 Then
                ' Duplicate entry - allow user to proceed or update existing record
                Dim result As DialogResult = MessageBox.Show(
                    "A certificate with similar information already exists in the database." & vbCrLf &
                    "Would you like to save this as a new certificate anyway? (This may require database administrator assistance)", 
                    "Duplicate Entry", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question)
                
                If result = DialogResult.Yes Then
                    ' Try to insert with a unique identifier or timestamp to make it unique
                    Try
                        Using conn2 As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                            conn2.Open()
                            ' Add timestamp or unique identifier to make it different
                            Dim sql2 As String = "INSERT INTO tbl_certificate (certificate, fullname, age, status, address, purpose, issuedon) VALUES (@certificate, @fullname, @age, @status, @address, @purpose, @issuedon)"
                            Using cmd2 As New Global.MySql.Data.MySqlClient.MySqlCommand(sql2, conn2)
                                Dim certificateType As String = If(cmbCertificateType.SelectedItem IsNot Nothing, cmbCertificateType.SelectedItem.ToString(), "")
                                Dim fullName As String = GetPanel2Text("txt1")
                                If String.IsNullOrWhiteSpace(fullName) Then fullName = GetPanel2Text("txtfullname")
                                Dim ageText As String = GetPanel2Text("txt6")
                                Dim ageVal As Integer = 0
                                Integer.TryParse(ageText, ageVal)
                                Dim addressVal As String = GetPanel2Text("txt4")
                                Dim purposeVal As String = GetPanel2Text("txt5")
                                Dim issuedOn As DateTime = GetPanel2Date("dtpissueddate")
                                If issuedOn = DateTime.MinValue Then issuedOn = DateTime.Now

                                cmd2.Parameters.AddWithValue("@certificate", certificateType)
                                cmd2.Parameters.AddWithValue("@fullname", If(String.IsNullOrWhiteSpace(fullName), String.Empty, fullName))
                                cmd2.Parameters.AddWithValue("@age", ageVal)
                                cmd2.Parameters.AddWithValue("@status", GetStatus())
                                cmd2.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(addressVal), String.Empty, addressVal))
                                cmd2.Parameters.AddWithValue("@purpose", If(String.IsNullOrWhiteSpace(purposeVal), String.Empty, purposeVal))
                                cmd2.Parameters.AddWithValue("@issuedon", issuedOn)
                                cmd2.ExecuteNonQuery()
                                RaiseEvent CertificateSaved()
                                Return True
                            End Using
                        End Using
                    Catch ex2 As Exception
                        MessageBox.Show("Unable to save certificate. The database may have a unique constraint that prevents duplicate entries. Please contact the database administrator.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
                Return False
            Else
                MessageBox.Show("Database Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show("Error saving certificate to database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub ClearForm()
        ' Clear form fields
        cmbCertificateType.SelectedIndex = -1

        ' Clear Panel2 controls
        ClearPanel2Controls()

        ' Clear shared data
        SharedCertificateData.ClearData()

        ' Refresh preview area
        certAnnual.Clear()
        previewControl.InvalidatePreview()
    End Sub





    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Validate form data first
        If Not ValidateFormData() Then Return

        ' Save to database
        If Not SaveCertificateToDatabase() Then
            MessageBox.Show("Failed to save certificate data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        BuildCertAnnualLines()
        previewControl.InvalidatePreview()
        ShowPreviewDialog()

        ' Optional: clear after preview closes
        Dim result As DialogResult = MessageBox.Show("Finished printing? Clear the form for the next entry?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then ClearForm()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If Not ValidateFormData() Then Return
        BuildCertAnnualLines()
        previewControl.InvalidatePreview()
        ShowPreviewDialog()
    End Sub

    Private Sub ShowPreviewDialog()
        previewDialog.Document = doc
        previewDialog.StartPosition = FormStartPosition.CenterScreen
        previewDialog.WindowState = FormWindowState.Maximized
        Try
            With previewDialog.PrintPreviewControl
                .AutoZoom = True
                .UseAntiAlias = True
                .Zoom = 1.0R
            End With
        Catch
        End Try
        previewDialog.ShowDialog()
    End Sub

    Private Sub doc_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles doc.PrintPage
        Dim certType As String = If(cmbCertificateType.SelectedItem IsNot Nothing, cmbCertificateType.SelectedItem.ToString(), String.Empty)
        If String.IsNullOrWhiteSpace(certType) Then
            e.Cancel = True
            Return
        End If

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Select Case certType
            Case "Certificate of Annual Income"
                BuildCertAnnualLines()
                RenderAnnualCertificate(e.Graphics, e.MarginBounds)
            Case Else
                RenderPlaceholderCertificate(e.Graphics, e.MarginBounds, certType)
        End Select

        e.HasMorePages = False
    End Sub

    Private Sub BuildCertAnnualLines()
        certAnnual.Clear()

        If cmbCertificateType.SelectedItem Is Nothing OrElse
           Not cmbCertificateType.SelectedItem.ToString().Equals("Certificate of Annual Income", StringComparison.OrdinalIgnoreCase) Then
            Return
        End If

        Dim residentName As String = ValueOrPlaceholder(txtName, 30)
        Dim status As String = ValueOrPlaceholder(txtStatus, 26)
        Dim parent As String = ValueOrPlaceholder(txtParent, 21)
        Dim address As String = ValueOrPlaceholder(txtAddress, 13)
        Dim requester As String = ValueOrPlaceholder(txtRequester, 25)
        Dim purpose As String = ValueOrPlaceholder(txtPurpose, 34)
        Dim dayText As String = ValueOrPlaceholder(txtDay, 6)
        Dim monthText As String = ValueOrPlaceholder(txtMonth, 6)
        Dim yearText As String = ValueOrPlaceholder(txtYear, 11)

        certAnnual.AddRange({
            "TO WHOM IT MAY CONCERN:",
            String.Empty,
            $"This is to certify that {residentName} is the {status} of {parent} and a bonafide resident of {address}, Barangay Ligaya, General Santos City.",
            String.Empty,
            $"This is to certify further that {residentName}’s parents have an annual income of not more than Thirty Six Thousand Pesos (P36,000.00).",
            String.Empty,
            $"This certification is being issued upon the request of {requester} for {purpose} and for whatever legal purpose it may serve best.",
            String.Empty,
            $"Issued this {dayText} day of {monthText} {yearText} at Barangay Hall, Ligaya, General Santos City.",
            String.Empty
        })
    End Sub

    Private Function ValueOrPlaceholder(input As TextBox, placeholderLength As Integer) As String
        Dim placeholder As String = New String("_"c, Math.Max(placeholderLength, 3))
        If input Is Nothing Then Return placeholder

        Dim value As String = input.Text.Trim()
        Return If(String.IsNullOrWhiteSpace(value), placeholder, value)
    End Function

    Private Sub RenderAnnualCertificate(g As Graphics, bounds As Rectangle)
        If certAnnual Is Nothing OrElse certAnnual.Count = 0 Then
            BuildCertAnnualLines()
        End If

        Using headerFont As New Font("Times New Roman", 14.0F, FontStyle.Bold),
              bodyFont As New Font("Times New Roman", 12.0F, FontStyle.Regular),
              signatureFont As New Font("Times New Roman", 12.0F, FontStyle.Bold)

            Dim y As Single = bounds.Top
            Dim indentPixels As Single = 40.0F

            For Each line In certAnnual
                Dim fontToUse As Font = If(line.StartsWith("TO WHOM", StringComparison.OrdinalIgnoreCase), headerFont, bodyFont)
                Dim lineHeight As Single = fontToUse.GetHeight(g) * 1.3F

                If String.IsNullOrWhiteSpace(line) Then
                    y += lineHeight / 2
                    Continue For
                End If

                Dim layout As New RectangleF(bounds.Left, y, bounds.Width, lineHeight)
                Dim format As New StringFormat() With {
                    .Alignment = StringAlignment.Near,
                    .LineAlignment = StringAlignment.Near
                }

                If line.StartsWith("This", StringComparison.OrdinalIgnoreCase) Then
                    layout.X += indentPixels
                    layout.Width -= indentPixels
                End If

                g.DrawString(line, fontToUse, Brushes.Black, layout, format)
                y += lineHeight
            Next

            Dim signatureRect As New RectangleF(bounds.Left, bounds.Bottom - signatureFont.GetHeight(g) * 2, bounds.Width, signatureFont.GetHeight(g) * 2)
            Dim signatureFormat As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
            g.DrawString("Punong Barangay", signatureFont, Brushes.Black, signatureRect, signatureFormat)
        End Using
    End Sub

    Private Sub RenderPlaceholderCertificate(g As Graphics, bounds As Rectangle, certType As String)
        Using font As New Font("Segoe UI", 12.0F, FontStyle.Italic)
            Dim message As String = $"Print preview for ""{certType}"" is not yet available."
            Dim layout As New RectangleF(bounds.Left, bounds.Top, bounds.Width, bounds.Height)
            Dim format As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
            g.DrawString(message, font, Brushes.Gray, layout, format)
        End Using
    End Sub


    Private Sub PrintPreviewControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub certificateform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No runtime Save/Cancel injection; rely on existing designer buttons
        ' Hide base fields by default; we now use certificate-specific Panel2 controls
        SetBaseFieldsVisible(False)
    End Sub

    Private Sub panelRight_Paint(sender As Object, e As PaintEventArgs) Handles panelRight.Paint

    End Sub


    Private Sub pnlPic_Paint(sender As Object, e As PaintEventArgs) Handles pnlPic.Paint

    End Sub

    Private Sub cmbCertificateType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCertificateType.SelectedIndexChanged
        ' Clear existing Panel2 controls
        ClearPanel2Controls()

        ' Show the appropriate picturebox and load Panel2 based on selection
        Dim selected As String = If(cmbCertificateType.SelectedItem, "").ToString()

        If selected = "Certificate of Residency" Then
            LoadPanel2Controls("Residency")
        ElseIf selected = "Certificate of Annual Income" Then
            LoadPanel2Controls("Annual")
        ElseIf selected = "Certificate of Cohabitation" Then
            LoadPanel2Controls("CC")
        ElseIf selected = "Certificate of Senior Citizen" Then
            LoadPanel2Controls("SC")
        End If

        ' Hide the base fields once a certificate type is chosen
        SetBaseFieldsVisible(False)
    End Sub

    Private Sub ClearPanel2Controls()
        ' Remove all dynamically added controls (keep only the original form controls)
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl As Control In panelFormFields.Controls
            ' Keep original controls: combobox only (base fields removed, now using Panel2)
            If Not (ctrl Is cmbCertificateType) Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl As Control In controlsToRemove
            panelFormFields.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next
        ' Ensure base fields are visible when nothing is selected / after clear
        If cmbCertificateType.SelectedIndex = -1 Then
            SetBaseFieldsVisible(True)
        End If
    End Sub

    Private Sub LoadPanel2Controls(certType As String)
        Try
            ' Get the appropriate certificate form
            Dim certForm As Form = Nothing
            Select Case certType
                Case "Residency"
                    certForm = CertificateFormManager.GetResidencyForm()
                Case "Annual"
                    certForm = CertificateFormManager.GetAnnualForm()
                Case "CC"
                    certForm = CertificateFormManager.GetCCForm()
                Case "SC"
                    certForm = CertificateFormManager.GetSCForm()
            End Select

            If certForm Is Nothing Then Return

            ' Find Panel2 in the certificate form
            Dim sourcePanel2 As Panel = Nothing
            For Each ctrl As Control In certForm.Controls
                If TypeOf ctrl Is Panel AndAlso ctrl.Name = "Panel2" Then
                    sourcePanel2 = DirectCast(ctrl, Panel)
                    Exit For
                End If
            Next

            If sourcePanel2 Is Nothing Then Return

            ' Calculate starting Y position (after combobox and spacing)
            Dim startY As Integer = cmbCertificateType.Bottom + 20
            Dim minY As Integer = Integer.MaxValue

            ' Find the minimum Y position in source Panel2 to preserve relative positioning
            For Each ctrl As Control In sourcePanel2.Controls
                If ctrl.Top < minY Then minY = ctrl.Top
            Next

            ' Clone all controls from Panel2 to panelFormFields, preserving their relative positions
            ' Sort controls by their Y position to maintain order (manual sort to avoid LINQ dependency issues)
            Dim sortedControls As New List(Of Control)
            For Each ctrl As Control In sourcePanel2.Controls
                sortedControls.Add(ctrl)
            Next
            ' Manual bubble sort by Y position, then X position
            For i As Integer = 0 To sortedControls.Count - 2
                For j As Integer = i + 1 To sortedControls.Count - 1
                    If sortedControls(i).Top > sortedControls(j).Top OrElse
                       (sortedControls(i).Top = sortedControls(j).Top AndAlso sortedControls(i).Left > sortedControls(j).Left) Then
                        Dim temp As Control = sortedControls(i)
                        sortedControls(i) = sortedControls(j)
                        sortedControls(j) = temp
                    End If
                Next
            Next

            ' Clone controls maintaining their relative layout
            For Each sourceCtrl As Control In sortedControls
                Dim clonedCtrl As Control = CloneControl(sourceCtrl)
                If clonedCtrl IsNot Nothing Then
                    ' Preserve relative position from source Panel2
                    Dim relativeY As Integer = sourceCtrl.Top - minY
                    Dim newY As Integer = startY + relativeY

                    ' Position relative to panelFormFields left edge (align with combobox)
                    clonedCtrl.Location = New Point(cmbCertificateType.Left, newY)
                    
                    ' Make textboxes editable
                    If TypeOf clonedCtrl Is TextBox Then
                        Dim txt As TextBox = DirectCast(clonedCtrl, TextBox)
                        txt.ReadOnly = False
                        txt.BackColor = Color.White
                        ' Wire up event handler to update preview
                        AddHandler txt.TextChanged, AddressOf Panel2Control_TextChanged
                    ElseIf TypeOf clonedCtrl Is DateTimePicker Then
                        Dim dtp As DateTimePicker = DirectCast(clonedCtrl, DateTimePicker)
                        dtp.Enabled = True
                        AddHandler dtp.ValueChanged, AddressOf Panel2Control_TextChanged
                    ElseIf TypeOf clonedCtrl Is ComboBox Then
                        Dim cmb As ComboBox = DirectCast(clonedCtrl, ComboBox)
                        cmb.Enabled = True
                        AddHandler cmb.SelectedIndexChanged, AddressOf Panel2Control_TextChanged
                    End If

                    panelFormFields.Controls.Add(clonedCtrl)
                End If
            Next

            ' Update preview after loading Panel2 controls
            BuildCertAnnualLines()
            previewControl.InvalidatePreview()
        Catch ex As Exception
            MessageBox.Show("Error loading certificate form controls: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CloneControl(source As Control) As Control
        Try
            If TypeOf source Is TextBox Then
                Dim src As TextBox = DirectCast(source, TextBox)
                Dim clone As New TextBox()
                clone.Name = src.Name
                clone.Text = src.Text
                clone.Size = src.Size
                clone.Font = src.Font
                clone.Location = src.Location
                clone.BackColor = src.BackColor
                clone.ForeColor = src.ForeColor
                Return clone
            ElseIf TypeOf source Is Label Then
                Dim src As Label = DirectCast(source, Label)
                Dim clone As New Label()
                clone.Name = src.Name
                clone.Text = src.Text
                clone.Size = src.Size
                clone.Font = src.Font
                clone.ForeColor = src.ForeColor
                clone.AutoSize = src.AutoSize
                clone.Location = src.Location
                Return clone
            ElseIf TypeOf source Is DateTimePicker Then
                Dim src As DateTimePicker = DirectCast(source, DateTimePicker)
                Dim clone As New DateTimePicker()
                clone.Name = src.Name
                clone.Value = src.Value
                clone.Format = src.Format
                clone.Size = src.Size
                clone.Font = src.Font
                clone.Location = src.Location
                Return clone
            ElseIf TypeOf source Is ComboBox Then
                Dim src As ComboBox = DirectCast(source, ComboBox)
                Dim clone As New ComboBox()
                clone.Name = src.Name
                clone.DropDownStyle = src.DropDownStyle
                clone.Items.AddRange(src.Items.Cast(Of Object)().ToArray())
                clone.Size = src.Size
                clone.Font = src.Font
                clone.Location = src.Location
                If src.SelectedIndex >= 0 Then
                    clone.SelectedIndex = src.SelectedIndex
                End If
                Return clone
            End If
        Catch ex As Exception
            ' Return Nothing if cloning fails
        End Try
        Return Nothing
    End Function

    Private Sub Panel2Control_TextChanged(sender As Object, e As EventArgs)
        BuildCertAnnualLines()
        previewControl.InvalidatePreview()
    End Sub

    Private Sub UpdatePreviewFromPanel2()
        ' Legacy overlay removed; PrintPreviewControl now reflects PrintDocument output.
    End Sub

    Private Sub panelRightHeader_Paint(sender As Object, e As PaintEventArgs) Handles panelRightHeader.Paint

    End Sub

    ' Base form field event handlers removed - form now uses Panel2 controls dynamically
    ' All event handling is done through Panel2Control_TextChanged handlers

    Private Sub panelButtons_Paint(sender As Object, e As PaintEventArgs) Handles panelButtons.Paint

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Clear the form and close
        ClearForm()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate form data first
        If Not ValidateFormData() Then Return

        ' Save to database
        If Not SaveCertificateToDatabase() Then
            MessageBox.Show("Failed to save certificate data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Generate PDF
        Try
            Dim pdfSaved As Boolean = SaveCertificateAsPdf()
            If pdfSaved Then
                MessageBox.Show("Certificate saved as PDF successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Ask if user wants to clear the form
                Dim result As DialogResult = MessageBox.Show("Clear the form for the next entry?", "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    ClearForm()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating PDF: " & ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SaveCertificateAsPdf() As Boolean
        Dim certType As String = If(cmbCertificateType.SelectedItem IsNot Nothing, cmbCertificateType.SelectedItem.ToString(), "").Trim()
        If String.IsNullOrWhiteSpace(certType) Then
            MessageBox.Show("Select a certificate type before saving.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim pdfPrinterName As String = Nothing
        For Each printer As String In Printing.PrinterSettings.InstalledPrinters
            If printer.Equals("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase) Then
                pdfPrinterName = printer
                Exit For
            End If
        Next

        If String.IsNullOrWhiteSpace(pdfPrinterName) Then
            MessageBox.Show("Microsoft Print to PDF printer is not available on this system.", "Printer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF files (*.pdf)|*.pdf"
            saveDialog.Title = "Save Certificate as PDF"
            saveDialog.FileName = $"{certType.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmmss}.pdf"

            If saveDialog.ShowDialog() <> DialogResult.OK Then
                Return False
            End If

            Dim originalController As Printing.PrintController = doc.PrintController
            Dim originalSettings As Printing.PrinterSettings = CType(doc.PrinterSettings.Clone(), Printing.PrinterSettings)

            Try
                Dim pdfSettings As New Printing.PrinterSettings()
                pdfSettings.PrinterName = pdfPrinterName
                pdfSettings.PrintToFile = True
                pdfSettings.PrintFileName = saveDialog.FileName
                pdfSettings.DefaultPageSettings.Margins = originalSettings.DefaultPageSettings.Margins
                pdfSettings.DefaultPageSettings.Landscape = originalSettings.DefaultPageSettings.Landscape

                doc.PrintController = New Printing.StandardPrintController()
                doc.PrinterSettings = pdfSettings
                doc.Print()
                Return True
            Finally
                doc.PrintController = originalController
                doc.PrinterSettings = originalSettings
            End Try
        End Using
    End Function

End Class





