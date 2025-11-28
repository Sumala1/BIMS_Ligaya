Public Class BackupRestore
    Private currentView As String = "Resident" ' Default view
    Private residentRestoreForm As resirestore
    Private cedulaRestoreForm As cedularestore
    Private certRestoreForm As certrestore
    Private blotterRecordsRestoreForm As blotterrecordsrestore

    Public Sub New()
        InitializeComponent()
        InitializeChildForms()
    End Sub

    Public Sub SetAsChildForm()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub InitializeChildForms()
        ' Initialize resident restore form
        residentRestoreForm = New resirestore()
        residentRestoreForm.SetAsChildForm()
        residentRestoreForm.TopLevel = False
        residentRestoreForm.FormBorderStyle = FormBorderStyle.None
        residentRestoreForm.Dock = DockStyle.Fill
        residentRestoreForm.Visible = False
        pnlContent.Controls.Add(residentRestoreForm)
        residentRestoreForm.Show()

        ' Initialize cedula restore form
        cedulaRestoreForm = New cedularestore()
        cedulaRestoreForm.SetAsChildForm()
        cedulaRestoreForm.TopLevel = False
        cedulaRestoreForm.FormBorderStyle = FormBorderStyle.None
        cedulaRestoreForm.Dock = DockStyle.Fill
        cedulaRestoreForm.Visible = False
        pnlContent.Controls.Add(cedulaRestoreForm)
        cedulaRestoreForm.Show()

        ' Initialize certificate restore form
        certRestoreForm = New certrestore()
        certRestoreForm.SetAsChildForm()
        certRestoreForm.TopLevel = False
        certRestoreForm.FormBorderStyle = FormBorderStyle.None
        certRestoreForm.Dock = DockStyle.Fill
        certRestoreForm.Visible = False
        pnlContent.Controls.Add(certRestoreForm)
        certRestoreForm.Show()

        ' Initialize blotter records restore form
        blotterRecordsRestoreForm = New blotterrecordsrestore()
        blotterRecordsRestoreForm.SetAsChildForm()
        blotterRecordsRestoreForm.TopLevel = False
        blotterRecordsRestoreForm.FormBorderStyle = FormBorderStyle.None
        blotterRecordsRestoreForm.Dock = DockStyle.Fill
        blotterRecordsRestoreForm.Visible = False
        pnlContent.Controls.Add(blotterRecordsRestoreForm)
        blotterRecordsRestoreForm.Show()
    End Sub

    Private Sub BackupRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowResidentView()
    End Sub

    Private Sub btnResident_Click(sender As Object, e As EventArgs) Handles btnResident.Click
        currentView = "Resident"
        ShowResidentView()
    End Sub

    Private Sub btnCedula_Click(sender As Object, e As EventArgs) Handles btnCedula.Click
        currentView = "Cedula"
        ShowCedulaView()
    End Sub

    Private Sub btnCertificate_Click(sender As Object, e As EventArgs) Handles btnCertificate.Click
        currentView = "Certificate"
        ShowCertificateView()
    End Sub

    Private Sub ShowResidentView()
        ' Hide other forms
        If cedulaRestoreForm IsNot Nothing Then cedulaRestoreForm.Visible = False
        If certRestoreForm IsNot Nothing Then certRestoreForm.Visible = False
        If blotterRecordsRestoreForm IsNot Nothing Then blotterRecordsRestoreForm.Visible = False

        ' Show resident restore form
        If residentRestoreForm IsNot Nothing Then
            residentRestoreForm.Visible = True
            residentRestoreForm.BringToFront()
        End If
    End Sub

    Private Sub ShowCedulaView()
        ' Hide other forms
        If residentRestoreForm IsNot Nothing Then residentRestoreForm.Visible = False
        If certRestoreForm IsNot Nothing Then certRestoreForm.Visible = False
        If blotterRecordsRestoreForm IsNot Nothing Then blotterRecordsRestoreForm.Visible = False

        ' Show cedula restore form
        If cedulaRestoreForm IsNot Nothing Then
            cedulaRestoreForm.Visible = True
            cedulaRestoreForm.BringToFront()
        End If
    End Sub

    Private Sub ShowCertificateView()
        ' Hide other forms
        If residentRestoreForm IsNot Nothing Then residentRestoreForm.Visible = False
        If cedulaRestoreForm IsNot Nothing Then cedulaRestoreForm.Visible = False
        If blotterRecordsRestoreForm IsNot Nothing Then blotterRecordsRestoreForm.Visible = False

        ' Show certificate restore form
        If certRestoreForm IsNot Nothing Then
            certRestoreForm.Visible = True
            certRestoreForm.BringToFront()
        End If
    End Sub

    Private Sub ShowBlotterRecordsView()
        ' Hide other forms
        If residentRestoreForm IsNot Nothing Then residentRestoreForm.Visible = False
        If cedulaRestoreForm IsNot Nothing Then cedulaRestoreForm.Visible = False
        If certRestoreForm IsNot Nothing Then certRestoreForm.Visible = False

        ' Show blotter records restore form
        If blotterRecordsRestoreForm IsNot Nothing Then
            blotterRecordsRestoreForm.Visible = True
            blotterRecordsRestoreForm.BringToFront()
        End If
    End Sub


    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Try
            ' Let user choose where to save the backup file
            Using saveDialog As New SaveFileDialog()
                saveDialog.Filter = "ZIP Files (*.zip)|*.zip"
                saveDialog.FileName = $"BIMS_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.zip"
                saveDialog.Title = "Save Backup File"

                If saveDialog.ShowDialog() <> DialogResult.OK Then
                    Return
                End If

                Dim zipFilePath As String = saveDialog.FileName
                Dim tempDir As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"BIMS_Backup_{Guid.NewGuid()}")

                Try
                    ' Create temporary directory for CSV files
                    System.IO.Directory.CreateDirectory(tempDir)

                    ' Show progress
                    Me.Cursor = Cursors.WaitCursor
                    btnBackup.Enabled = False

                    ' List of all tables to backup
                    Dim tables As New List(Of String) From {
                        "tbl_residentinfo",
                        "tbl_residentrestore",
                        "tbl_certificate",
                        "tbl_certrestore",
                        "tbl_cedulatracker",
                        "tbl_cedularestore",
                        "tbl_login"
                    }

                    ' Export each table to CSV
                    Dim exportedTables As New List(Of String)()
                    For Each tableName As String In tables
                        Try
                            Dim csvPath As String = System.IO.Path.Combine(tempDir, $"{tableName}.csv")
                            ExportTableToCsv(tableName, csvPath)
                            exportedTables.Add(tableName)
                        Catch ex As Exception
                            ' Log error but continue with other tables
                            System.Diagnostics.Debug.WriteLine($"Failed to export {tableName}: {ex.Message}")
                        End Try
                    Next

                    If exportedTables.Count = 0 Then
                        MessageBox.Show("No tables were exported. Please check database connection.", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Create ZIP file
                    If System.IO.File.Exists(zipFilePath) Then
                        System.IO.File.Delete(zipFilePath)
                    End If

                    System.IO.Compression.ZipFile.CreateFromDirectory(tempDir, zipFilePath)

                    MessageBox.Show($"Backup completed successfully!{vbCrLf}{vbCrLf}Exported {exportedTables.Count} table(s):{vbCrLf}{String.Join(vbCrLf, exportedTables)}{vbCrLf}{vbCrLf}Saved to:{vbCrLf}{zipFilePath}",
                                    "Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Open the folder containing the backup file
                    Try
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,""{zipFilePath}""")
                    Catch
                        ' If explorer fails, just open the folder
                        System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(zipFilePath))
                    End Try

                Finally
                    ' Clean up temporary directory
                    Try
                        If System.IO.Directory.Exists(tempDir) Then
                            System.IO.Directory.Delete(tempDir, True)
                        End If
                    Catch
                        ' Ignore cleanup errors
                    End Try

                    Me.Cursor = Cursors.Default
                    btnBackup.Enabled = True
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show($"Backup failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            btnBackup.Enabled = True
        End Try
    End Sub

    Private Sub ExportTableToCsv(tableName As String, outputPath As String)
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = $"SELECT * FROM {tableName}"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        Using writer As New System.IO.StreamWriter(outputPath, False, System.Text.Encoding.UTF8)
                            ' Write headers
                            Dim headers As New List(Of String)()
                            For i As Integer = 0 To reader.FieldCount - 1
                                headers.Add(reader.GetName(i))
                            Next
                            writer.WriteLine(String.Join(",", headers.Select(Function(h) EscapeCsvField(h))))

                            ' Write rows
                            While reader.Read()
                                Dim values As New List(Of String)()
                                For i As Integer = 0 To reader.FieldCount - 1
                                    If reader.IsDBNull(i) Then
                                        values.Add("")
                                    Else
                                        Dim value As String = reader.GetValue(i).ToString()
                                        values.Add(EscapeCsvField(value))
                                    End If
                                Next
                                writer.WriteLine(String.Join(",", values))
                            End While
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"Failed to export {tableName}: {ex.Message}")
        End Try
    End Sub

    Private Function EscapeCsvField(field As String) As String
        If String.IsNullOrEmpty(field) Then Return ""

        ' If field contains comma, quote, or newline, wrap in quotes and escape quotes
        If field.Contains(",") OrElse field.Contains("""") OrElse field.Contains(vbCrLf) OrElse field.Contains(vbCr) OrElse field.Contains(vbLf) Then
            Return """" & field.Replace("""", """""") & """"
        End If

        Return field
    End Function

    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint

    End Sub

    Private Sub btnBlotterRecords_Click(sender As Object, e As EventArgs) Handles btnBlotterRecords.Click
        currentView = "BlotterRecords"
        ShowBlotterRecordsView()
    End Sub
End Class