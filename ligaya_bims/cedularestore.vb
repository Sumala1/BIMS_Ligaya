Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class cedularestore
    Private currentPage As Integer = 1
    Private pageSize As Integer = 10
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0

    Public Sub SetAsChildForm()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub cedularestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRestoreIcon()
        LoadRestoreRecords()
    End Sub

    Private Sub SetRestoreIcon()
        If dgvCedula IsNot Nothing AndAlso dgvCedula.Columns.Contains("DataGridViewImageColumn2") Then
            Dim restoreColumn As DataGridViewImageColumn = TryCast(dgvCedula.Columns("DataGridViewImageColumn2"), DataGridViewImageColumn)
            If restoreColumn IsNot Nothing Then
                restoreColumn.Image = IconHelper.GetRestoreIcon()
            End If
        End If
    End Sub

    Private Sub LoadRestoreRecords()
        dgvCedula.Rows.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Get total count
                Dim countSql As String = "SELECT COUNT(*) FROM tbl_cedularestore"
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
                Dim sql As String = $"SELECT ctcnumber, year, placeissued, fullname, address, gender, dateissued, citizenship, placeofbirth, civilstatus, dateofbirth, profession FROM tbl_cedularestore ORDER BY dateissued DESC LIMIT {pageSize} OFFSET {offset}"
                
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim metadata As New CedulaRestoreMetadata()
                            metadata.CtcNumber = If(reader.IsDBNull(0), 0, reader.GetInt32(0))
                            metadata.Year = If(reader.IsDBNull(1), DBNull.Value, CType(reader.GetInt32(1), Object))
                            metadata.PlaceIssued = If(reader.IsDBNull(2), String.Empty, reader.GetString(2))
                            metadata.FullName = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
                            metadata.Address = If(reader.IsDBNull(4), String.Empty, reader.GetString(4))
                            metadata.Gender = If(reader.IsDBNull(5), DBNull.Value, reader.GetString(5))
                            metadata.DateIssued = If(reader.IsDBNull(6), DateTime.MinValue, reader.GetDateTime(6))
                            metadata.Citizenship = If(reader.IsDBNull(7), DBNull.Value, reader.GetString(7))
                            metadata.PlaceOfBirth = If(reader.IsDBNull(8), DBNull.Value, reader.GetString(8))
                            metadata.CivilStatus = If(reader.IsDBNull(9), DBNull.Value, reader.GetString(9))
                            metadata.DateOfBirth = If(reader.IsDBNull(10), DBNull.Value, reader.GetDateTime(10))
                            metadata.Profession = If(reader.IsDBNull(11), DBNull.Value, reader.GetString(11))

                            Dim rowIndex As Integer = dgvCedula.Rows.Add()
                            dgvCedula.Rows(rowIndex).Cells("DataGridViewCheckBoxColumn1").Value = False
                            dgvCedula.Rows(rowIndex).Cells("CTCNumber").Value = metadata.CtcNumber.ToString()
                            dgvCedula.Rows(rowIndex).Cells("DateIssued").Value = metadata.DateIssued.ToString("yyyy-MM-dd")
                            dgvCedula.Rows(rowIndex).Cells("DataGridViewTextBoxColumn1").Value = metadata.FullName
                            dgvCedula.Rows(rowIndex).Tag = metadata
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load restore records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        UpdatePaginationControls()
        UpdateEntriesLabel()
    End Sub


    Private Sub dgvCedula_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCedula.CellContentClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = dgvCedula.Columns("DataGridViewImageColumn2").Index Then
            RestoreRecord(e.RowIndex)
        End If
    End Sub

    Private Sub RestoreRecord(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvCedula.Rows.Count Then Return

        Dim row As DataGridViewRow = dgvCedula.Rows(rowIndex)
        Dim fullName As String = Convert.ToString(row.Cells("DataGridViewTextBoxColumn1").Value)
        Dim metadata As CedulaRestoreMetadata = TryCast(row.Tag, CedulaRestoreMetadata)
        If metadata Is Nothing Then Return

        Dim confirm = MessageBox.Show($"Restore {fullName} to cedula records?", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim insertSql As String = "INSERT INTO tbl_cedulatracker (ctcnumber, year, placeissued, fullname, address, gender, dateissued, citizenship, placeofbirth, civilstatus, dateofbirth, profession) VALUES (@ctcnumber, @year, @placeissued, @fullname, @address, @gender, @dateissued, @citizenship, @placeofbirth, @civilstatus, @dateofbirth, @profession)"

                        Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
                            insertCmd.Parameters.AddWithValue("@ctcnumber", metadata.CtcNumber)
                            insertCmd.Parameters.AddWithValue("@year", metadata.Year)
                            insertCmd.Parameters.AddWithValue("@placeissued", If(String.IsNullOrWhiteSpace(metadata.PlaceIssued), DBNull.Value, metadata.PlaceIssued))
                            insertCmd.Parameters.AddWithValue("@fullname", If(String.IsNullOrWhiteSpace(metadata.FullName), DBNull.Value, metadata.FullName))
                            insertCmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(metadata.Address), DBNull.Value, metadata.Address))
                            insertCmd.Parameters.AddWithValue("@gender", metadata.Gender)
                            insertCmd.Parameters.AddWithValue("@dateissued", metadata.DateIssued)
                            insertCmd.Parameters.AddWithValue("@citizenship", metadata.Citizenship)
                            insertCmd.Parameters.AddWithValue("@placeofbirth", metadata.PlaceOfBirth)
                            insertCmd.Parameters.AddWithValue("@civilstatus", metadata.CivilStatus)
                            insertCmd.Parameters.AddWithValue("@dateofbirth", metadata.DateOfBirth)
                            insertCmd.Parameters.AddWithValue("@profession", metadata.Profession)

                            Dim rowsInserted As Integer = insertCmd.ExecuteNonQuery()
                            If rowsInserted = 0 Then
                                Throw New Exception("Unable to restore record. It may have been removed already.")
                            End If
                        End Using

                        Dim deleteSql As String = "DELETE FROM tbl_cedularestore WHERE ctcnumber = @ctcnumber LIMIT 1"

                        Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
                            deleteCmd.Parameters.AddWithValue("@ctcnumber", metadata.CtcNumber)
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        tran.Commit()
                    Catch
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            ' Reload data after restore (LoadRestoreRecords will handle page adjustment if needed)
            LoadRestoreRecords()
            MessageBox.Show($"Restored {fullName}.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Class CedulaRestoreMetadata
        Public Property CtcNumber As Integer
        Public Property Year As Object
        Public Property PlaceIssued As String
        Public Property FullName As String
        Public Property Address As String
        Public Property Gender As Object
        Public Property DateIssued As DateTime
        Public Property Citizenship As Object
        Public Property PlaceOfBirth As Object
        Public Property CivilStatus As Object
        Public Property DateOfBirth As Object
        Public Property Profession As Object
    End Class
End Class