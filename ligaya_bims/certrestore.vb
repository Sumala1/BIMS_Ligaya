Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class certrestore
    Private currentPage As Integer = 1
    Private pageSize As Integer = 10
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0

    Public Sub SetAsChildForm()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub certrestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRestoreIcon()
        LoadRestoreRecords()
    End Sub

    Private Sub SetRestoreIcon()
        If dgvCert IsNot Nothing AndAlso dgvCert.Columns.Contains("colRestore") Then
            Dim restoreColumn As DataGridViewImageColumn = TryCast(dgvCert.Columns("colRestore"), DataGridViewImageColumn)
            If restoreColumn IsNot Nothing Then
                restoreColumn.Image = IconHelper.GetRestoreIcon()
            End If
        End If
    End Sub

    Private Sub LoadRestoreRecords()
        dgvCert.Rows.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Get total count
                Dim countSql As String = "SELECT COUNT(*) FROM tbl_certrestore"
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
                Dim sql As String = $"SELECT certificate, fullname, age, status, address, purpose, issuedon FROM tbl_certrestore ORDER BY issuedon DESC LIMIT {pageSize} OFFSET {offset}"
                
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim metadata As New CertificateRestoreMetadata()
                            metadata.Certificate = If(reader.IsDBNull(0), String.Empty, reader.GetString(0))
                            metadata.FullName = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
                            metadata.Age = If(reader.IsDBNull(2), 0, reader.GetInt32(2))
                            metadata.Status = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
                            metadata.Address = If(reader.IsDBNull(4), String.Empty, reader.GetString(4))
                            metadata.Purpose = If(reader.IsDBNull(5), String.Empty, reader.GetString(5))
                            metadata.IssuedOn = If(reader.IsDBNull(6), DateTime.MinValue, reader.GetDateTime(6))

                            Dim rowIndex As Integer = dgvCert.Rows.Add()
                            dgvCert.Rows(rowIndex).Cells("colSelect").Value = False
                            dgvCert.Rows(rowIndex).Cells("Column1").Value = metadata.Certificate
                            dgvCert.Rows(rowIndex).Cells("Column2").Value = metadata.IssuedOn.ToString("yyyy-MM-dd")
                            dgvCert.Rows(rowIndex).Cells("colFullName").Value = metadata.FullName
                            dgvCert.Rows(rowIndex).Tag = metadata
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

    Private Sub dgvCert_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCert.CellContentClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = dgvCert.Columns("colRestore").Index Then
            RestoreRecord(e.RowIndex)
        End If
    End Sub

    Private Sub RestoreRecord(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvCert.Rows.Count Then Return

        Dim row As DataGridViewRow = dgvCert.Rows(rowIndex)
        Dim fullName As String = Convert.ToString(row.Cells("colFullName").Value)
        Dim metadata As CertificateRestoreMetadata = TryCast(row.Tag, CertificateRestoreMetadata)
        If metadata Is Nothing Then Return

        Dim confirm = MessageBox.Show($"Restore {fullName} to certificate records?", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim insertSql As String = "INSERT INTO tbl_certificate (certificate, fullname, age, status, address, purpose, issuedon) VALUES (@certificate, @fullname, @age, @status, @address, @purpose, @issuedon)"

                        Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
                            insertCmd.Parameters.AddWithValue("@certificate", metadata.Certificate)
                            insertCmd.Parameters.AddWithValue("@fullname", metadata.FullName)
                            insertCmd.Parameters.AddWithValue("@age", metadata.Age)
                            insertCmd.Parameters.AddWithValue("@status", If(String.IsNullOrWhiteSpace(metadata.Status), DBNull.Value, metadata.Status))
                            insertCmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(metadata.Address), DBNull.Value, metadata.Address))
                            insertCmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrWhiteSpace(metadata.Purpose), DBNull.Value, metadata.Purpose))
                            insertCmd.Parameters.AddWithValue("@issuedon", metadata.IssuedOn)

                            Dim rowsInserted As Integer = insertCmd.ExecuteNonQuery()
                            If rowsInserted = 0 Then
                                Throw New Exception("Unable to restore record. It may have been removed already.")
                            End If
                        End Using

                        Dim deleteSql As String = "DELETE FROM tbl_certrestore WHERE certificate = @certificate AND fullname = @fullname AND issuedon = @issuedon LIMIT 1"

                        Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
                            deleteCmd.Parameters.AddWithValue("@certificate", metadata.Certificate)
                            deleteCmd.Parameters.AddWithValue("@fullname", metadata.FullName)
                            deleteCmd.Parameters.AddWithValue("@issuedon", metadata.IssuedOn)
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

    Private Class CertificateRestoreMetadata
        Public Property Certificate As String
        Public Property FullName As String
        Public Property Age As Integer
        Public Property Status As String
        Public Property Address As String
        Public Property Purpose As String
        Public Property IssuedOn As DateTime
    End Class
End Class