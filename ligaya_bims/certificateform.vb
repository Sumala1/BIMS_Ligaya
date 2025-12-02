Imports System.Drawing.Printing

Public Class certificateform
    Public Event CertificateSaved()
    Private certAnnual As New List(Of String)()

    Private Structure TemplateTextField
        Public Sub New(rect As RectangleF, text As String, Optional fontSize As Single = 12.0F, Optional fontStyle As FontStyle = FontStyle.Regular, Optional alignment As StringAlignment = StringAlignment.Center)
            Me.Rect = rect
            Me.Text = text
            Me.FontSize = fontSize
            Me.FontStyle = fontStyle
            Me.Alignment = alignment
        End Sub

        Public Property Rect As RectangleF
        Public Property Text As String
        Public Property FontSize As Single
        Public Property FontStyle As FontStyle
        Public Property Alignment As StringAlignment
    End Structure

    Private Function GetFirstNonEmptyValue(ParamArray controlNames() As String) As String
        For Each controlName As String In controlNames
            Dim value As String = GetPanel2Text(controlName)
            If Not String.IsNullOrWhiteSpace(value) Then
                Return value.Trim()
            End If
        Next
        Return String.Empty
    End Function

    Private Function FitTemplateRectangle(bounds As Rectangle, template As Image) As Rectangle
        If template Is Nothing Then Return bounds

        Dim templateRatio As Single = template.Width / CSng(template.Height)
        Dim boundsRatio As Single = bounds.Width / CSng(bounds.Height)

        If Math.Abs(templateRatio - boundsRatio) < 0.01F Then
            Return bounds
        End If

        If boundsRatio > templateRatio Then
            Dim width As Integer = CInt(bounds.Height * templateRatio)
            Dim left As Integer = bounds.Left + (bounds.Width - width) \ 2
            Return New Rectangle(left, bounds.Top, width, bounds.Height)
        Else
            Dim height As Integer = CInt(bounds.Width / templateRatio)
            Dim top As Integer = bounds.Top + (bounds.Height - height) \ 2
            Return New Rectangle(bounds.Left, top, bounds.Width, height)
        End If
    End Function

    Private Sub DrawTemplateFields(g As Graphics, template As Image, drawRect As Rectangle, fields As IEnumerable(Of TemplateTextField))
        If template Is Nothing Then Return

        Dim scaleX As Single = drawRect.Width / CSng(template.Width)
        Dim scaleY As Single = drawRect.Height / CSng(template.Height)

        For Each field In fields
            Dim value As String = If(field.Text, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(value) Then Continue For

            Dim rect As New RectangleF(
                drawRect.Left + (field.Rect.X * scaleX),
                drawRect.Top + (field.Rect.Y * scaleY),
                Math.Max(1.0F, field.Rect.Width * scaleX),
                Math.Max(1.0F, field.Rect.Height * scaleY)
            )

            Dim avgScale As Single = (scaleX + scaleY) / 2.0F
            Dim desiredFontSize As Single = Math.Max(6.0F, If(field.FontSize > 0, field.FontSize, 12.0F) * avgScale)

            Using fittedFont As Font = CreateFittedFont(g, value, desiredFontSize, field.FontStyle, rect.Size)
                Dim format As New StringFormat() With {
                    .Alignment = field.Alignment,
                    .LineAlignment = StringAlignment.Center,
                    .FormatFlags = StringFormatFlags.NoWrap,
                    .Trimming = StringTrimming.EllipsisCharacter
                }
                g.DrawString(value, fittedFont, Brushes.Black, rect, format)
            End Using
        Next
    End Sub

    Private Function CreateFittedFont(g As Graphics, text As String, startingSize As Single, fontStyle As FontStyle, targetSize As SizeF) As Font
        Dim fontSize As Single = startingSize
        Dim previousFont As Font = Nothing
        Try
            While fontSize >= 6.0F
                previousFont?.Dispose()
                previousFont = New Font("Calibri", fontSize, fontStyle)
                Dim measured As SizeF = g.MeasureString(text, previousFont)
                If measured.Width <= targetSize.Width OrElse fontSize <= 6.0F Then
                    Return CType(previousFont.Clone(), Font)
                End If
                fontSize -= 0.5F
            End While
            Return New Font("Calibri", 6.0F, fontStyle)
        Finally
            previousFont?.Dispose()
        End Try
    End Function
    
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
        Return DateTime.MinValue
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

        ' Normal margins for certificates
        Dim marginSize As Integer = 50 ' 50 pixels margin on all sides
        Dim adjustedBounds As New Rectangle(
            e.PageBounds.Left + marginSize,
            e.PageBounds.Top + marginSize,
            e.PageBounds.Width - (2 * marginSize),
            e.PageBounds.Height - (2 * marginSize)
        )

        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Select Case certType
            Case "Certificate of Annual Income"
                RenderAnnualCertificate(e.Graphics, adjustedBounds)
            Case "Certificate of Residency"
                RenderCertificateOfResidency(e.Graphics, adjustedBounds)
            Case "Certificate of Cohabitation"
                RenderCertificateOfCohabitation(e.Graphics, adjustedBounds)
            Case "Certificate of Senior Citizen"
                RenderCertificateOfSeniorCitizen(e.Graphics, adjustedBounds)
            Case Else
                RenderPlaceholderCertificate(e.Graphics, adjustedBounds, certType)
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

    Private Function DrawAnnualCertificateFromTemplate(g As Graphics, bounds As Rectangle) As Boolean
        Dim template As Image = LoadImageResource("CAI_2")
        If template Is Nothing Then Return False

        g.FillRectangle(Brushes.White, bounds)
        Dim drawRect As Rectangle = FitTemplateRectangle(bounds, template)
        g.DrawImage(template, drawRect)

        Dim applicantName As String = GetFirstNonEmptyValue("txt3", "txtfullname", "txt1")
        If String.IsNullOrWhiteSpace(applicantName) Then
            applicantName = SharedCertificateData.FullName
        End If

        Dim relationship As String = GetFirstNonEmptyValue("txt2", "cmb3", "txtrelationship")
        If String.IsNullOrWhiteSpace(relationship) Then
            relationship = GetStatus()
        End If

        Dim parentName As String = GetFirstNonEmptyValue("txt1", "txtparent")
        Dim purok As String = GetFirstNonEmptyValue("txt4", "txtaddress")
        Dim requester As String = GetFirstNonEmptyValue("txt5", "txtrequester")
        Dim purpose As String = GetFirstNonEmptyValue("txtpurpose", "txtreason", "txt5")

        Dim issuedDate As DateTime = GetPanel2Date("dtpissueddate")
        If issuedDate = DateTime.MinValue Then issuedDate = DateTime.Now
        Dim dayText As String = issuedDate.Day.ToString()
        Dim monthText As String = issuedDate.ToString("MMMM")
        Dim yearText As String = issuedDate.Year.ToString()

        Dim fields As New List(Of TemplateTextField) From {
            New TemplateTextField(New RectangleF(350, 388, 262, 26), applicantName, 12.0F),
            New TemplateTextField(New RectangleF(347, 411, 174, 24), relationship, 11.0F),
            New TemplateTextField(New RectangleF(97, 411, 187, 24), parentName, 11.0F),
            New TemplateTextField(New RectangleF(220, 434, 60, 22), purok, 11.0F),
            New TemplateTextField(New RectangleF(420, 478, 230, 24), applicantName, 11.0F),
            New TemplateTextField(New RectangleF(95, 589, 200, 24), requester, 11.0F),
            New TemplateTextField(New RectangleF(356, 589, 220, 24), purpose, 11.0F),
            New TemplateTextField(New RectangleF(268, 657, 60, 24), dayText, 11.0F),
            New TemplateTextField(New RectangleF(340, 657, 110, 24), monthText, 11.0F),
            New TemplateTextField(New RectangleF(460, 657, 80, 24), yearText, 11.0F)
        }

        DrawTemplateFields(g, template, drawRect, fields)
        Return True
    End Function

    Private Sub RenderAnnualCertificate(g As Graphics, bounds As Rectangle)
        If DrawAnnualCertificateFromTemplate(g, bounds) Then
            Return
        End If

        Dim margin As Integer = 40
        Dim contentWidth As Integer = bounds.Width - (2 * margin)
        Dim currentY As Integer = bounds.Top + margin

        ' Fill background
        g.FillRectangle(Brushes.White, bounds)

        ' Draw shared header for all certificates
        DrawCertificateHeader(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 200 ' Space for header

        ' Draw colored wavy banner
        DrawWavyBanner(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 30

        ' Draw "CERTIFICATION" title (spaced letters, Century Gothic)
        DrawCertificationTitle(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 60

        ' Draw certificate body (includes signature area)
        DrawCertificateAnnualBody(g, bounds.Left + margin, currentY, contentWidth, bounds.Height - currentY - 100)
    End Sub

    Private Sub DrawCertificateAnnualBody(g As Graphics, x As Integer, y As Integer, width As Integer, availableHeight As Integer)
        ' Get data from Panel2 controls or use placeholders
        Dim applicantName As String = GetPanel2Text("txt1")
        If String.IsNullOrWhiteSpace(applicantName) Then
            applicantName = GetPanel2Text("txtfullname")
        End If
        If String.IsNullOrWhiteSpace(applicantName) Then
            applicantName = "________________________________"
        End If

        Dim status As String = GetPanel2Text("cmb3")
        If String.IsNullOrWhiteSpace(status) Then
            status = "________________________________"
        End If

        Dim parentName As String = GetPanel2Text("txt2")
        If String.IsNullOrWhiteSpace(parentName) Then
            parentName = "________________________________"
        End If

        Dim address As String = GetPanel2Text("txt4")
        If String.IsNullOrWhiteSpace(address) Then
            address = GetPanel2Text("txtaddress")
        End If
        If String.IsNullOrWhiteSpace(address) Then
            address = "____"
        End If

        Dim requester As String = GetPanel2Text("txt5")
        If String.IsNullOrWhiteSpace(requester) Then
            requester = "________________________________"
        End If

        Dim purpose As String = GetPanel2Text("txtpurpose")
        If String.IsNullOrWhiteSpace(purpose) Then
            purpose = "________________________________"
        End If

        Dim issuedDate As DateTime = GetPanel2Date("dtpissueddate")
        Dim day As String = "________"
        Dim month As String = "________"
        If issuedDate <> DateTime.MinValue Then
            day = issuedDate.Day.ToString()
            month = issuedDate.ToString("MMMM")
        End If

        ' Paragraph 1: Identity/Residency
        Dim para1 As String = $"This is to certify that {applicantName} is the {status} of {parentName} and a bonafide resident of Purok {address}, Barangay Ligaya, General Santos City."

        ' Paragraph 2: Income
        Dim para2 As String = $"This is to certify further that {applicantName}'s parents have an annual income of not more than Thirty Six Thousand Pesos (P36,000.00)."

        ' Paragraph 3: Purpose
        Dim para3 As String = $"This certification is being issued upon the request of {requester} for {purpose} and for whatever legal purpose it may serve best."

        ' Issuance
        Dim issued As String = $"Issued this {day} day of {month}, at Barangay Hall, Ligaya, General Santos City."

        ' Use standardized body format
        DrawStandardCertificateBody(g, x, y, width, availableHeight, para1, para2, para3, issued)
    End Sub

    Private Sub RenderCertificateOfResidency(g As Graphics, bounds As Rectangle)
        Dim margin As Integer = 40
        Dim contentWidth As Integer = bounds.Width - (2 * margin)
        Dim currentY As Integer = bounds.Top + margin

        ' Fill background
        g.FillRectangle(Brushes.White, bounds)

        ' Draw shared header for all certificates
        DrawCertificateHeader(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 200 ' Space for header

        ' Draw colored wavy banner
        DrawWavyBanner(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 30

        ' Draw "CERTIFICATION" title (spaced letters, Century Gothic)
        DrawCertificationTitle(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 60

        ' Draw certificate body (includes signature area)
        DrawCertificateResidencyBody(g, bounds.Left + margin, currentY, contentWidth, bounds.Height - currentY - 100)
    End Sub

    ' Shared header drawing function for all certificates
    Private Function LoadImageResource(resourceName As String) As Image
        Try
            Dim resourceObj As Object = My.Resources.ResourceManager.GetObject(resourceName)
            If resourceObj IsNot Nothing AndAlso TypeOf resourceObj Is Image Then
                Return DirectCast(resourceObj, Image)
                End If
        Catch
        End Try
        Return Nothing
    End Function

    Private Sub DrawCertificateHeader(g As Graphics, x As Integer, y As Integer, width As Integer)
        Dim imageSize As Integer = 100
        Dim headerHeight As Integer = 120
        Dim centerX As Integer = x + (width \ 2)

        ' Left: Barangay Seal (circular seal) - Screenshot_14
        Try
            Dim barangaySeal As Image = LoadImageResource("Screenshot_14")
            If barangaySeal Is Nothing Then
                barangaySeal = LoadImageResource("brgy_ligaya_logo_removebg_preview_removebg_preview")
            End If

            If barangaySeal IsNot Nothing Then
                g.DrawImage(barangaySeal, x, y, imageSize, imageSize)
            Else
                ' Draw placeholder circle for seal
                Using pen As New Pen(Color.Green, 2)
                    g.DrawEllipse(pen, x, y, imageSize, imageSize)
                End Using
                Using font As New Font("Calibri", 7.0F, FontStyle.Regular)
                    Dim textRect As New RectangleF(x, y + imageSize - 20, imageSize, 20)
                    Dim format As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }
                    g.DrawString("BARANGAY SEAL", font, Brushes.Black, textRect, format)
                End Using
            End If
        Catch
        End Try

        ' Center-Left: BAGONG PILIPINAS Logo (to the right of the seal)
        Try
            Dim bagongPilipinasLogo As Image = LoadImageResource("bagong_pilipinas")
            If bagongPilipinasLogo Is Nothing Then
                bagongPilipinasLogo = LoadImageResource("Screenshot_14")
            End If
            If bagongPilipinasLogo IsNot Nothing Then
                Dim logoSize As Integer = 70
                Dim logoX As Integer = x + imageSize + 15
                Dim logoY As Integer = y + 15
                g.DrawImage(bagongPilipinasLogo, logoX, logoY, logoSize, logoSize)
                ' Draw "BAGONG PILIPINAS" text below logo
                Using font As New Font("Calibri", 8.0F, FontStyle.Bold)
                    Dim textRect As New RectangleF(logoX, logoY + logoSize, logoSize, 12)
                    Dim format As New StringFormat() With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString("BAGONG PILIPINAS", font, Brushes.Black, textRect, format)
                End Using
            End If
        Catch
        End Try

        ' Center: Header text block (positioned to the right of BAGONG PILIPINAS logo)
        Using headerFont As New Font("Calibri", 10.0F, FontStyle.Regular),
              boldHeaderFont As New Font("Calibri", 12.0F, FontStyle.Bold)
            Dim headerFormat As New StringFormat() With {
                .Alignment = StringAlignment.Center,
                .LineAlignment = StringAlignment.Center
            }

            ' Position center text block between BAGONG PILIPINAS and right logo
            Dim headerStartX As Integer = x + imageSize + 100
            Dim headerWidth As Integer = width - (imageSize + 100) - 100
            Dim headerRect As New RectangleF(headerStartX, y, headerWidth, headerHeight)
            
            ' Draw each line separately to apply different formatting
            Dim lineHeight As Single = headerHeight / 6
            Dim currentY As Single = y
            
            ' Republic of the Philippines
            Dim rect1 As New RectangleF(headerStartX, currentY, headerWidth, lineHeight)
            g.DrawString("Republic of the Philippines", headerFont, Brushes.Black, rect1, headerFormat)
            currentY += lineHeight
            
            ' City of General Santos
            Dim rect2 As New RectangleF(headerStartX, currentY, headerWidth, lineHeight)
            g.DrawString("City of General Santos", headerFont, Brushes.Black, rect2, headerFormat)
            currentY += lineHeight
            
            ' BARANGAY LIGAYA (bold, larger)
            Dim rect3 As New RectangleF(headerStartX, currentY, headerWidth, lineHeight)
            g.DrawString("BARANGAY LIGAYA", boldHeaderFont, Brushes.Black, rect3, headerFormat)
            currentY += lineHeight
            
            ' Barangay Hall, Sorilla St., Ligaya, G.S.C
            Dim rect4 As New RectangleF(headerStartX, currentY, headerWidth, lineHeight)
            g.DrawString("Barangay Hall, Sorilla St., Ligaya, G.S.C", headerFont, Brushes.Black, rect4, headerFormat)
            currentY += lineHeight
            
            ' =o0o=
            Dim rect5 As New RectangleF(headerStartX, currentY, headerWidth, lineHeight)
            g.DrawString("=o0o=", headerFont, Brushes.Black, rect5, headerFormat)
            currentY += lineHeight
            
            ' OFFICE OF THE PUNONG BARANGAY (bold)
            Dim rect6 As New RectangleF(headerStartX, currentY, headerWidth, lineHeight)
            g.DrawString("OFFICE OF THE PUNONG BARANGAY", boldHeaderFont, Brushes.Black, rect6, headerFormat)
        End Using

        ' Right: magandang en San! Logo - Screenshot_16
        Try
            Dim magandangLogo As Image = LoadImageResource("Screenshot_16")
            If magandangLogo Is Nothing Then
                magandangLogo = LoadImageResource("brgy_ligaya_logo_removebg_preview_removebg_preview")
            End If

            If magandangLogo IsNot Nothing Then
                Dim logoSize As Integer = 70
                Dim logoX As Integer = x + width - logoSize
                Dim logoY As Integer = y + 15
                g.DrawImage(magandangLogo, logoX, logoY, logoSize, logoSize)
                ' Draw "FACESFACETSPLACES" tagline below logo
                Using font As New Font("Calibri", 6.5F, FontStyle.Regular)
                    Dim textRect As New RectangleF(logoX - 15, logoY + logoSize, logoSize + 30, 12)
                    Dim format As New StringFormat() With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString("FACESFACETSPLACES", font, Brushes.Black, textRect, format)
                End Using
            Else
                ' Placeholder
                Using brush As New SolidBrush(Color.FromArgb(255, 200, 200, 200))
                    g.FillRectangle(brush, x + width - imageSize, y, imageSize, imageSize)
                End Using
                Using font As New Font("Calibri", 8.0F, FontStyle.Regular)
                    Dim textRect As New RectangleF(x + width - imageSize, y + imageSize - 30, imageSize, 30)
                    Dim format As New StringFormat() With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString("magandang en San!", font, Brushes.Black, textRect, format)
                End Using
            End If
        Catch
        End Try
    End Sub

    Private Sub DrawWavyBanner(g As Graphics, x As Integer, y As Integer, width As Integer)
        ' Try to load Screenshot_15 image (line image above CERTIFICATION)
        Try
            Dim bannerImage As Image = LoadImageResource("Screenshot_15")
            If bannerImage IsNot Nothing Then
                ' Draw the image to span the width
                Dim bannerHeight As Integer = CInt(bannerImage.Height * (width / bannerImage.Width))
                g.DrawImage(bannerImage, x, y, width, bannerHeight)
                Return
            End If
        Catch
        End Try

        ' Fallback: Draw multiple wavy lines in different colors
        Dim colors As Color() = {
            Color.FromArgb(255, 255, 192, 203), ' Pink
            Color.FromArgb(255, 173, 216, 230), ' Light Blue
            Color.FromArgb(255, 144, 238, 144), ' Light Green
            Color.FromArgb(255, 211, 211, 211)  ' Light Gray
        }

        Dim lineSpacing As Integer = 3
        Dim amplitude As Integer = 2
        Dim frequency As Single = 0.1F

        For i As Integer = 0 To colors.Length - 1
            Using pen As New Pen(colors(i), 2)
                Dim points As New List(Of PointF)()
                For px As Integer = 0 To width Step 2
                    Dim py As Single = y + (i * lineSpacing) + Math.Sin(px * frequency) * amplitude
                    points.Add(New PointF(x + px, py))
                Next
                If points.Count > 1 Then
                    g.DrawLines(pen, points.ToArray())
                End If
            End Using
        Next
    End Sub

    Private Sub DrawCertificationTitle(g As Graphics, x As Integer, y As Integer, width As Integer)
        Using font As New Font("Segoe UI", 24.0F, FontStyle.Bold)
            Dim title As String = "CERTIFICATION"
            Dim letterSpacing As Single = 15.0F
            Dim centerX As Single = x + (width \ 2)
            Dim titleWidth As Single = (title.Length * letterSpacing)
            Dim startX As Single = centerX - (titleWidth \ 2)

            For i As Integer = 0 To title.Length - 1
                Dim letter As String = title.Substring(i, 1)
                Dim letterX As Single = startX + (i * letterSpacing)
                g.DrawString(letter, font, Brushes.Black, letterX, y)
            Next
        End Using
    End Sub

    Private Sub DrawCertificateResidencyBody(g As Graphics, x As Integer, y As Integer, width As Integer, availableHeight As Integer)
        ' Get data from Panel2 controls
        Dim fullName As String = GetPanel2Text("txt1")
        If String.IsNullOrWhiteSpace(fullName) Then
            fullName = GetPanel2Text("txtfullname")
        End If
        If String.IsNullOrWhiteSpace(fullName) Then
            fullName = "________________________________"
        End If

        ' Civil status is always "married" for Certificate of Residency
        Dim civilStatus As String = "married"

        Dim address As String = GetPanel2Text("txt4")
        If String.IsNullOrWhiteSpace(address) Then
            address = GetPanel2Text("txtaddress")
        End If
        If String.IsNullOrWhiteSpace(address) Then
            address = "____"
        End If

        Dim requester As String = GetPanel2Text("txt5")
        If String.IsNullOrWhiteSpace(requester) Then
            requester = "________________________________"
        End If

        Dim purpose As String = GetPanel2Text("txtpurpose")
        If String.IsNullOrWhiteSpace(purpose) Then
            purpose = "________________________________"
        End If

        Dim issuedDate As DateTime = GetPanel2Date("dtpissueddate")
        Dim day As String = "________"
        Dim month As String = "________"
        If issuedDate <> DateTime.MinValue Then
            day = issuedDate.Day.ToString()
            month = issuedDate.ToString("MMMM")
        End If

        ' Paragraph 1: Identity/Residency
        Dim para1 As String = $"This is to certify that {fullName}, of legal age, {civilStatus}, Filipino, is a bona fide resident of Purok {address}, Barangay Ligaya, General Santos City."

        ' Paragraph 2: Empty (not used for Residency)
        Dim para2 As String = String.Empty

        ' Paragraph 3: Purpose
        Dim para3 As String = $"This certification is being issued upon the request of {requester} for {purpose} and for whatever legal purpose it may serve best."

        ' Issuance
        Dim issued As String = $"Issued this {day} day of {month}, at Barangay Hall, Ligaya, General Santos City."

        ' Use standardized body format
        DrawStandardCertificateBody(g, x, y, width, availableHeight, para1, para2, para3, issued)
    End Sub

    Private Sub DrawSignatureArea(g As Graphics, x As Integer, y As Integer, width As Integer)
        Using font As New Font("Calibri", 11.0F, FontStyle.Bold)
            Dim signatureRect As New RectangleF(x, y, width, 30)
            Dim format As New StringFormat() With {
                .Alignment = StringAlignment.Far,
                .LineAlignment = StringAlignment.Center
            }
            g.DrawString("Punong Barangay", font, Brushes.Black, signatureRect, format)
        End Using
    End Sub

    ' Standardized body format matching the certificate layout exactly as shown in image
    Private Sub DrawStandardCertificateBody(g As Graphics, x As Integer, y As Integer, width As Integer, availableHeight As Integer, para1Text As String, para2Text As String, para3Text As String, issuedText As String)
        Using bodyFont As New Font("Calibri", 11.0F, FontStyle.Regular),
              boldFont As New Font("Calibri", 11.0F, FontStyle.Bold)
            Dim currentY As Single = y
            Dim lineHeight As Single = bodyFont.GetHeight(g) * 1.3F

            ' TO WHOM IT MAY CONCERN:
            g.DrawString("TO WHOM IT MAY CONCERN:", boldFont, Brushes.Black, x, currentY)
            currentY += lineHeight * 2.0F

            ' First Paragraph (Identity/Residency)
            Dim para1Rect As New RectangleF(x, currentY, width, lineHeight * 4)
            Dim para1Format As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near,
                .Trimming = StringTrimming.Word
            }
            g.DrawString(para1Text, bodyFont, Brushes.Black, para1Rect, para1Format)
            Dim para1Size As SizeF = g.MeasureString(para1Text, bodyFont, width, para1Format)
            currentY += para1Size.Height + lineHeight * 1.0F

            ' Second Paragraph (Income) - only for Annual Income certificate
            If Not String.IsNullOrWhiteSpace(para2Text) Then
                Dim para2Rect As New RectangleF(x, currentY, width, lineHeight * 3)
                Dim para2Format As New StringFormat() With {
                    .Alignment = StringAlignment.Near,
                    .LineAlignment = StringAlignment.Near,
                    .Trimming = StringTrimming.Word
                }
                g.DrawString(para2Text, bodyFont, Brushes.Black, para2Rect, para2Format)
                Dim para2Size As SizeF = g.MeasureString(para2Text, bodyFont, width, para2Format)
                currentY += para2Size.Height + lineHeight * 1.0F
            End If

            ' Third Paragraph (Purpose)
            Dim para3Rect As New RectangleF(x, currentY, width, lineHeight * 3)
            Dim para3Format As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near,
                .Trimming = StringTrimming.Word
            }
            g.DrawString(para3Text, bodyFont, Brushes.Black, para3Rect, para3Format)
            Dim para3Size As SizeF = g.MeasureString(para3Text, bodyFont, width, para3Format)
            currentY += para3Size.Height + lineHeight * 1.0F

            ' Issuance Details
            Dim issuedRect As New RectangleF(x, currentY, width, lineHeight * 3)
            Dim issuedFormat As New StringFormat() With {
                .Alignment = StringAlignment.Near,
                .LineAlignment = StringAlignment.Near,
                .Trimming = StringTrimming.Word
            }
            g.DrawString(issuedText, bodyFont, Brushes.Black, issuedRect, issuedFormat)
            Dim issuedSize As SizeF = g.MeasureString(issuedText, bodyFont, width, issuedFormat)
            currentY += issuedSize.Height + lineHeight * 3.0F

            ' Signature Line (right-aligned)
            Using signatureFont As New Font("Calibri", 11.0F, FontStyle.Regular)
                Dim signatureRect As New RectangleF(x, currentY, width, lineHeight)
                Dim signatureFormat As New StringFormat() With {
                    .Alignment = StringAlignment.Far,
                    .LineAlignment = StringAlignment.Center
                }
                g.DrawString("Punong Barangay", signatureFont, Brushes.Black, signatureRect, signatureFormat)
            End Using
        End Using
    End Sub

    ' Certificate of Cohabitation rendering
    Private Sub RenderCertificateOfCohabitation(g As Graphics, bounds As Rectangle)
        Dim margin As Integer = 40
        Dim contentWidth As Integer = bounds.Width - (2 * margin)
        Dim currentY As Integer = bounds.Top + margin

        ' Fill background
        g.FillRectangle(Brushes.White, bounds)

        ' Draw shared header
        DrawCertificateHeader(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 200

        ' Draw wavy banner
        DrawWavyBanner(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 30

        ' Draw CERTIFICATION title
        DrawCertificationTitle(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 60

        ' Draw certificate body
        DrawCertificateCohabitationBody(g, bounds.Left + margin, currentY, contentWidth, bounds.Height - currentY - 100)
    End Sub

    Private Sub DrawCertificateCohabitationBody(g As Graphics, x As Integer, y As Integer, width As Integer, availableHeight As Integer)
        ' Get data from Panel2 controls
        Dim name1 As String = GetPanel2Text("txt1")
        If String.IsNullOrWhiteSpace(name1) Then name1 = "________________________________"

        Dim birthDate1 As String = GetPanel2Text("txt2")
        If String.IsNullOrWhiteSpace(birthDate1) Then birthDate1 = "________________________________"

        Dim name2 As String = GetPanel2Text("txt3")
        If String.IsNullOrWhiteSpace(name2) Then name2 = "________________________________"

        Dim birthDate2 As String = GetPanel2Text("txt4")
        If String.IsNullOrWhiteSpace(birthDate2) Then birthDate2 = "________________________________"

        Dim address As String = GetPanel2Text("txt5")
        If String.IsNullOrWhiteSpace(address) Then address = "____"

        Dim sinceDate As String = GetPanel2Text("txt6")
        If String.IsNullOrWhiteSpace(sinceDate) Then sinceDate = "________________________________"

        Dim issuedDate As DateTime = GetPanel2Date("dtpissueddate")
        Dim day As String = "________"
        Dim month As String = "________"
        If issuedDate <> DateTime.MinValue Then
            day = issuedDate.Day.ToString()
            month = issuedDate.ToString("MMMM")
        End If

        ' Paragraph 1: Cohabitation details
        Dim para1 As String = $"This is to certify that {name1}, born on {birthDate1}, and {name2}, born on {birthDate2}, have been living as a spouse in good faith, taking on all of the tasks and responsibilities that follow with being in the said relationship, cohabiting in the same household at Purok {address}, Barangay Ligaya, General Santos City, and both holding themselves out to the community as spouses since {sinceDate}."

        ' Paragraph 2: Empty (not used for Cohabitation)
        Dim para2 As String = String.Empty

        ' Paragraph 3: Purpose
        Dim para3 As String = "This certification is being issued upon the request of the above named person for Office of the Congress and for whatever legal purpose it may serve best."

        ' Issuance
        Dim issued As String = $"Issued this {day} day of {month}, at Barangay Hall, Ligaya, General Santos City."

        ' Use standardized body format
        DrawStandardCertificateBody(g, x, y, width, availableHeight, para1, para2, para3, issued)
    End Sub

    ' Certificate of Senior Citizen rendering
    Private Sub RenderCertificateOfSeniorCitizen(g As Graphics, bounds As Rectangle)
        Dim margin As Integer = 40
        Dim contentWidth As Integer = bounds.Width - (2 * margin)
        Dim currentY As Integer = bounds.Top + margin

        ' Fill background
        g.FillRectangle(Brushes.White, bounds)

        ' Draw shared header
        DrawCertificateHeader(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 200

        ' Draw wavy banner
        DrawWavyBanner(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 30

        ' Draw CERTIFICATION title
        DrawCertificationTitle(g, bounds.Left + margin, currentY, contentWidth)
        currentY += 60

        ' Draw certificate body (includes signature area)
        DrawCertificateSeniorCitizenBody(g, bounds.Left + margin, currentY, contentWidth, bounds.Height - currentY - 100)
    End Sub

    Private Sub DrawCertificateSeniorCitizenBody(g As Graphics, x As Integer, y As Integer, width As Integer, availableHeight As Integer)
        ' Get data from Panel2 controls
        Dim fullName As String = GetPanel2Text("txt1")
        If String.IsNullOrWhiteSpace(fullName) Then fullName = "________________________________"

        Dim age As String = GetPanel2Text("txt2")
        If String.IsNullOrWhiteSpace(age) Then age = "____"

        Dim birthDate As String = GetPanel2Text("txt3")
        If String.IsNullOrWhiteSpace(birthDate) Then birthDate = "________________________________"

        Dim address As String = GetPanel2Text("txt4")
        If String.IsNullOrWhiteSpace(address) Then address = "____"

        Dim requester As String = GetPanel2Text("txtpurpose")
        If String.IsNullOrWhiteSpace(requester) Then requester = "________________________________"

        Dim purpose As String = "Office of Senior Citizens Affairs (OSCA) Purposes"

        Dim issuedDate As DateTime = GetPanel2Date("dtpissueddate")
        Dim day As String = "________"
        Dim month As String = "________"
        If issuedDate <> DateTime.MinValue Then
            day = issuedDate.Day.ToString()
            month = issuedDate.ToString("MMMM")
        End If

        ' Paragraph 1: Identity/Residency
        Dim para1 As String = $"This is to certify that {fullName}, {age} years old, born on {birthDate}, widow, Filipino, is a resident of Purok {address}, Barangay Ligaya, General Santos City."

        ' Paragraph 2: Empty (not used for Senior Citizen)
        Dim para2 As String = String.Empty

        ' Paragraph 3: Purpose
        Dim para3 As String = $"This certification is being issued upon the request of {requester} for {purpose} and for whatever legal purpose it may serve best."

        ' Issuance
        Dim issued As String = $"Issued this {day} day of {month}, at Barangay Hall, Ligaya, General Santos City."

        ' Use standardized body format
        DrawStandardCertificateBody(g, x, y, width, availableHeight, para1, para2, para3, issued)
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
        
        ' Update preview
        previewControl.InvalidatePreview()
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
        If certType = "Residency" Then
            ' For Residency certificate, invalidate preview to show the template
            previewControl.InvalidatePreview()
        Else
            BuildCertAnnualLines()
            previewControl.InvalidatePreview()
        End If
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





