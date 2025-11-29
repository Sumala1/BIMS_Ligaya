Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class blotterrecordsrestore
    Private currentPage As Integer = 1
    Private pageSize As Integer = 10
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0
    Private restoreIcon As Image

    Public Sub SetAsChildForm()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub blotterrecordsrestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRestoreIcon()
        ' Only load records if form is visible to avoid errors when form is hidden
        If Me.Visible Then
            LoadRestoreRecords()
        End If
    End Sub

    Private Sub SetRestoreIcon()
        If dgvBlotterRecords IsNot Nothing AndAlso dgvBlotterRecords.Columns.Contains("colRestore") Then
            restoreIcon = IconHelper.GetRestoreIcon()
            Dim restoreColumn As DataGridViewImageColumn = TryCast(dgvBlotterRecords.Columns("colRestore"), DataGridViewImageColumn)
            If restoreColumn IsNot Nothing Then
                restoreColumn.Image = restoreIcon
            End If
        End If
    End Sub

    Public Sub LoadDataWhenVisible()
        ' This method is called when the form becomes visible
        If Me.Visible Then
            LoadRestoreRecords()
        End If
    End Sub

    Private Sub LoadRestoreRecords()
        dgvBlotterRecords.Rows.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Get total count
                Dim countSql As String = "SELECT COUNT(*) FROM tbl_blotterrestore"
                Using countCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(countSql, conn)
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
                End Using

                ' Calculate total pages
                totalPages = If(totalRecords > 0, CInt(Math.Ceiling(totalRecords / CDbl(pageSize))), 1)

                ' Ensure currentPage is valid
                If totalRecords = 0 Then
                    currentPage = 1
                ElseIf currentPage > totalPages Then
                    currentPage = totalPages
                ElseIf currentPage < 1 Then
                    currentPage = 1
                End If

                ' Load data for current page with LIMIT and OFFSET
                Dim offset As Integer = (currentPage - 1) * pageSize
                Dim sql As String = $"SELECT case_number, complainant_name, complainant_address, type_of_incident, date_time, location_of_incident, involved_person, narrative_incident FROM tbl_blotterrestore ORDER BY case_number DESC LIMIT {pageSize} OFFSET {offset}"
                
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim metadata As New BlotterRestoreMetadata()
                            metadata.CaseNumber = If(reader.IsDBNull(0), 0, reader.GetInt32(0))
                            metadata.ComplainantName = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
                            metadata.ComplainantAddress = If(reader.IsDBNull(2), String.Empty, reader.GetString(2))
                            metadata.TypeOfIncident = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
                            metadata.DateTime = If(reader.IsDBNull(4), DateTime.MinValue, reader.GetDateTime(4))
                            metadata.LocationOfIncident = If(reader.IsDBNull(5), String.Empty, reader.GetString(5))
                            metadata.InvolvedPerson = If(reader.IsDBNull(6), String.Empty, reader.GetString(6))
                            metadata.NarrativeIncident = If(reader.IsDBNull(7), String.Empty, reader.GetString(7))

                            Dim rowIndex As Integer = dgvBlotterRecords.Rows.Add()
                            dgvBlotterRecords.Rows(rowIndex).Cells("CaseNumber").Value = FormatCaseNumberValue(metadata.CaseNumber)
                            dgvBlotterRecords.Rows(rowIndex).Cells("ComplainantName").Value = metadata.ComplainantName
                            dgvBlotterRecords.Rows(rowIndex).Cells("ComplainantAddress").Value = metadata.ComplainantAddress
                            dgvBlotterRecords.Rows(rowIndex).Cells("ComplaintName").Value = metadata.TypeOfIncident
                            dgvBlotterRecords.Rows(rowIndex).Cells("IncidentDate").Value = If(metadata.DateTime <> DateTime.MinValue, metadata.DateTime.ToString("MMM dd, yyyy hh:mm tt"), String.Empty)
                            dgvBlotterRecords.Rows(rowIndex).Cells("LocationOfIncident").Value = metadata.LocationOfIncident
                            dgvBlotterRecords.Rows(rowIndex).Cells("InvolvedPerson").Value = metadata.InvolvedPerson
                            dgvBlotterRecords.Rows(rowIndex).Cells("NarrativeIncident").Value = metadata.NarrativeIncident
                            dgvBlotterRecords.Rows(rowIndex).Cells("colRestore").Value = restoreIcon
                            dgvBlotterRecords.Rows(rowIndex).Tag = metadata
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Only show error if form is visible to avoid errors when form is hidden during initialization
            If Me.Visible Then
                MessageBox.Show("Failed to load restore records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try

        UpdatePaginationControls()
        UpdateEntriesLabel()
    End Sub

    Private Function FormatCaseNumberValue(value As Integer) As String
        If value <= 0 Then
            Return String.Empty
        End If
        Return value.ToString("0000")
    End Function

    Private Sub dgvBlotterRecords_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBlotterRecords.CellContentClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = dgvBlotterRecords.Columns("colRestore").Index Then
            RestoreRecord(e.RowIndex)
        End If
    End Sub

    Private Sub RestoreRecord(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvBlotterRecords.Rows.Count Then Return

        Dim row As DataGridViewRow = dgvBlotterRecords.Rows(rowIndex)
        Dim caseNumber As String = Convert.ToString(row.Cells("CaseNumber").Value)
        Dim metadata As BlotterRestoreMetadata = TryCast(row.Tag, BlotterRestoreMetadata)
        If metadata Is Nothing Then Return

        Dim confirm = MessageBox.Show($"Restore blotter record Case #{caseNumber} to blotter records?", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim insertSql As String = "INSERT INTO tbl_blotter (case_number, complainant_name, complainant_address, type_of_incident, date_time, location_of_incident, involved_person, narrative_incident) VALUES (@case_number, @complainant_name, @complainant_address, @type_of_incident, @date_time, @location_of_incident, @involved_person, @narrative_incident)"

                        Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
                            insertCmd.Parameters.AddWithValue("@case_number", metadata.CaseNumber)
                            insertCmd.Parameters.AddWithValue("@complainant_name", If(String.IsNullOrWhiteSpace(metadata.ComplainantName), DBNull.Value, metadata.ComplainantName))
                            insertCmd.Parameters.AddWithValue("@complainant_address", If(String.IsNullOrWhiteSpace(metadata.ComplainantAddress), DBNull.Value, metadata.ComplainantAddress))
                            insertCmd.Parameters.AddWithValue("@type_of_incident", If(String.IsNullOrWhiteSpace(metadata.TypeOfIncident), DBNull.Value, metadata.TypeOfIncident))
                            insertCmd.Parameters.AddWithValue("@date_time", If(metadata.DateTime = DateTime.MinValue, DBNull.Value, CType(metadata.DateTime, Object)))
                            insertCmd.Parameters.AddWithValue("@location_of_incident", If(String.IsNullOrWhiteSpace(metadata.LocationOfIncident), DBNull.Value, metadata.LocationOfIncident))
                            insertCmd.Parameters.AddWithValue("@involved_person", If(String.IsNullOrWhiteSpace(metadata.InvolvedPerson), DBNull.Value, metadata.InvolvedPerson))
                            insertCmd.Parameters.AddWithValue("@narrative_incident", If(String.IsNullOrWhiteSpace(metadata.NarrativeIncident), DBNull.Value, metadata.NarrativeIncident))

                            Dim rowsInserted As Integer = insertCmd.ExecuteNonQuery()
                            If rowsInserted = 0 Then
                                Throw New Exception("Unable to restore record. It may have been removed already.")
                            End If
                        End Using

                        Dim deleteSql As String = "DELETE FROM tbl_blotterrestore WHERE case_number = @case_number LIMIT 1"

                        Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
                            deleteCmd.Parameters.AddWithValue("@case_number", metadata.CaseNumber)
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        tran.Commit()
                    Catch
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            ' Reload data after restore
            LoadRestoreRecords()
            MessageBox.Show($"Restored Case #{caseNumber}.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to restore record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdatePaginationControls()
        ' Update page number label
        lblPageNumber.Text = currentPage.ToString()

        ' Enable/disable Previous button
        btnPrevious.Enabled = currentPage > 1

        ' Enable/disable Next button
        btnNext.Enabled = currentPage < totalPages

        ' If no records, disable both buttons
        If totalRecords = 0 Then
            btnPrevious.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub UpdateEntriesLabel()
        If totalRecords = 0 Then
            lblShowEntries.Text = "Showing 0 entries"
            Return
        End If

        Dim startRecord As Integer = ((currentPage - 1) * pageSize) + 1
        Dim endRecord As Integer = Math.Min(currentPage * pageSize, totalRecords)

        lblShowEntries.Text = $"Showing {startRecord} to {endRecord} of {totalRecords} entries"
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadRestoreRecords()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadRestoreRecords()
        End If
    End Sub

    Private Sub lblPageNumber_Click(sender As Object, e As EventArgs) Handles lblPageNumber.Click
        ' Page number label is read-only, no action needed
    End Sub

    Private Class BlotterRestoreMetadata
        Public Property CaseNumber As Integer
        Public Property ComplainantName As String
        Public Property ComplainantAddress As String
        Public Property TypeOfIncident As String
        Public Property DateTime As DateTime
        Public Property LocationOfIncident As String
        Public Property InvolvedPerson As String
        Public Property NarrativeIncident As String
    End Class
End Class
