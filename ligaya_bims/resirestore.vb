Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class resirestore
    Private currentPage As Integer = 1
    Private pageSize As Integer = 10
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0

    Friend Sub SetAsChildForm()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub resirestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRestoreIcon()
        LoadRestoreRecords()
    End Sub

    Private Sub SetRestoreIcon()
        If dgvProfiles IsNot Nothing AndAlso dgvProfiles.Columns.Contains("colRestore") Then
            Dim restoreColumn As DataGridViewImageColumn = TryCast(dgvProfiles.Columns("colRestore"), DataGridViewImageColumn)
            If restoreColumn IsNot Nothing Then
                restoreColumn.Image = IconHelper.GetRestoreIcon()
            End If
        End If
    End Sub

    Private Sub LoadRestoreRecords()
        dgvProfiles.Rows.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Get total count
                Dim countSql As String = "SELECT COUNT(*) FROM tbl_residentrestore"
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
                Dim sql As String = $"SELECT lastname, firstname, middlename, gender, birthdate, age, phoneno, civilstatus, citizenship, fathersname, mothersname, spouse, email, religion, voterstatus, weight, height, idpic, address FROM tbl_residentrestore ORDER BY lastname, firstname LIMIT {pageSize} OFFSET {offset}"
                
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim metadata As New RestoreMetadata()
                            metadata.LastName = If(reader.IsDBNull(0), String.Empty, reader.GetString(0))
                            metadata.FirstName = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
                            metadata.MiddleName = If(reader.IsDBNull(2), String.Empty, reader.GetString(2))
                            metadata.Gender = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
                            metadata.BirthDate = If(reader.IsDBNull(4), CType(Nothing, DateTime?), reader.GetDateTime(4))
                            metadata.Age = If(reader.IsDBNull(5), String.Empty, reader.GetString(5))
                            metadata.Phoneno = If(reader.IsDBNull(6), String.Empty, reader.GetString(6))
                            metadata.Civilstatus = If(reader.IsDBNull(7), String.Empty, reader.GetString(7))
                            metadata.Citizenship = If(reader.IsDBNull(8), String.Empty, reader.GetString(8))
                            metadata.Fathersname = If(reader.IsDBNull(9), String.Empty, reader.GetString(9))
                            metadata.Mothersname = If(reader.IsDBNull(10), String.Empty, reader.GetString(10))
                            metadata.Spouse = If(reader.IsDBNull(11), String.Empty, reader.GetString(11))
                            metadata.Email = If(reader.IsDBNull(12), String.Empty, reader.GetString(12))
                            metadata.Religion = If(reader.IsDBNull(13), String.Empty, reader.GetString(13))
                            metadata.Voterstatus = If(reader.IsDBNull(14), String.Empty, reader.GetString(14))
                            metadata.Weight = If(reader.IsDBNull(15), String.Empty, reader.GetString(15))
                            metadata.Height = If(reader.IsDBNull(16), String.Empty, reader.GetString(16))
                            metadata.Address = If(reader.IsDBNull(18), String.Empty, reader.GetString(18))

                            ' Handle idpic (can be byte array or null)
                            If Not reader.IsDBNull(17) Then
                                metadata.Idpic = reader.GetValue(17)
                            Else
                                metadata.Idpic = DBNull.Value
                            End If

                            Dim rowIndex As Integer = dgvProfiles.Rows.Add()
                            dgvProfiles.Rows(rowIndex).Cells("colSelect").Value = False
                            dgvProfiles.Rows(rowIndex).Cells("colFullName").Value = BuildFullName(metadata.FirstName, metadata.MiddleName, metadata.LastName)
                            dgvProfiles.Rows(rowIndex).Tag = metadata
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

    Private Function BuildFullName(firstName As String, middleName As String, lastName As String) As String
        Dim parts As New List(Of String)()
        If Not String.IsNullOrWhiteSpace(firstName) Then parts.Add(firstName.Trim())
        If Not String.IsNullOrWhiteSpace(middleName) Then parts.Add(middleName.Trim())
        If Not String.IsNullOrWhiteSpace(lastName) Then parts.Add(lastName.Trim())

        Return String.Join(" ", parts)
    End Function

    Private Sub dgvProfiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProfiles.CellClick
        If e.RowIndex < 0 Then Return
        If e.ColumnIndex = dgvProfiles.Columns("colRestore").Index Then
            RestoreRecord(e.RowIndex)
        End If
    End Sub

    Private Sub RestoreRecord(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvProfiles.Rows.Count Then Return

        Dim row As DataGridViewRow = dgvProfiles.Rows(rowIndex)
        Dim fullName As String = Convert.ToString(row.Cells("colFullName").Value)
        Dim metadata As RestoreMetadata = TryCast(row.Tag, RestoreMetadata)
        If metadata Is Nothing Then Return

        Dim confirm = MessageBox.Show($"Restore {fullName} to resident records?", "Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim insertSql As String = "INSERT INTO tbl_residentinfo (lastname, firstname, middlename, gender, birthdate, age, phoneno, civilstatus, citizenship, fathersname, mothersname, spouse, email, religion, voterstatus, weight, height, idpic, address) VALUES (@ln, @fn, @mn, @gender, @birthdate, @age, @phoneno, @civilstatus, @citizenship, @fathersname, @mothersname, @spouse, @email, @religion, @voterstatus, @weight, @height, @idpic, @address)"

                        Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
                            insertCmd.Parameters.AddWithValue("@ln", metadata.LastName)
                            insertCmd.Parameters.AddWithValue("@fn", metadata.FirstName)
                            Dim middleParam As Object = If(String.IsNullOrWhiteSpace(metadata.MiddleName), CType(DBNull.Value, Object), metadata.MiddleName)
                            insertCmd.Parameters.AddWithValue("@mn", middleParam)
                            insertCmd.Parameters.AddWithValue("@gender", If(String.IsNullOrWhiteSpace(metadata.Gender), DBNull.Value, metadata.Gender))
                            Dim birthParam As Object = If(metadata.BirthDate.HasValue, CType(metadata.BirthDate.Value, Object), DBNull.Value)
                            insertCmd.Parameters.AddWithValue("@birthdate", birthParam)
                            insertCmd.Parameters.AddWithValue("@age", If(String.IsNullOrWhiteSpace(metadata.Age), DBNull.Value, metadata.Age))
                            insertCmd.Parameters.AddWithValue("@phoneno", If(String.IsNullOrWhiteSpace(metadata.Phoneno), DBNull.Value, metadata.Phoneno))
                            insertCmd.Parameters.AddWithValue("@civilstatus", If(String.IsNullOrWhiteSpace(metadata.Civilstatus), DBNull.Value, metadata.Civilstatus))
                            insertCmd.Parameters.AddWithValue("@citizenship", If(String.IsNullOrWhiteSpace(metadata.Citizenship), DBNull.Value, metadata.Citizenship))
                            insertCmd.Parameters.AddWithValue("@fathersname", If(String.IsNullOrWhiteSpace(metadata.Fathersname), DBNull.Value, metadata.Fathersname))
                            insertCmd.Parameters.AddWithValue("@mothersname", If(String.IsNullOrWhiteSpace(metadata.Mothersname), DBNull.Value, metadata.Mothersname))
                            insertCmd.Parameters.AddWithValue("@spouse", If(String.IsNullOrWhiteSpace(metadata.Spouse), DBNull.Value, metadata.Spouse))
                            insertCmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(metadata.Email), DBNull.Value, metadata.Email))
                            insertCmd.Parameters.AddWithValue("@religion", If(String.IsNullOrWhiteSpace(metadata.Religion), DBNull.Value, metadata.Religion))
                            insertCmd.Parameters.AddWithValue("@voterstatus", If(String.IsNullOrWhiteSpace(metadata.Voterstatus), DBNull.Value, metadata.Voterstatus))
                            insertCmd.Parameters.AddWithValue("@weight", If(String.IsNullOrWhiteSpace(metadata.Weight), DBNull.Value, metadata.Weight))
                            insertCmd.Parameters.AddWithValue("@height", If(String.IsNullOrWhiteSpace(metadata.Height), DBNull.Value, metadata.Height))
                            insertCmd.Parameters.AddWithValue("@idpic", metadata.Idpic)
                            insertCmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(metadata.Address), DBNull.Value, metadata.Address))

                            Dim rowsInserted As Integer = insertCmd.ExecuteNonQuery()
                            If rowsInserted = 0 Then
                                Throw New Exception("Unable to restore record. It may have been removed already.")
                            End If
                        End Using

                        Dim deleteSql As String = "DELETE FROM tbl_residentrestore WHERE lastname = @ln AND firstname = @fn AND ((@mn IS NULL AND (middlename IS NULL OR TRIM(middlename) = '')) OR middlename = @mn) " &
                                                 "AND ((@birthdate IS NULL AND birthdate IS NULL) OR birthdate = @birthdate) LIMIT 1"

                        Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
                            deleteCmd.Parameters.AddWithValue("@ln", metadata.LastName)
                            deleteCmd.Parameters.AddWithValue("@fn", metadata.FirstName)
                            Dim middleParam As Object = If(String.IsNullOrWhiteSpace(metadata.MiddleName), CType(DBNull.Value, Object), metadata.MiddleName)
                            deleteCmd.Parameters.AddWithValue("@mn", middleParam)
                            Dim birthParam As Object = If(metadata.BirthDate.HasValue, CType(metadata.BirthDate.Value, Object), DBNull.Value)
                            deleteCmd.Parameters.AddWithValue("@birthdate", birthParam)
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

    Private Class RestoreMetadata
        Public Property LastName As String
        Public Property FirstName As String
        Public Property MiddleName As String
        Public Property BirthDate As Nullable(Of DateTime)
        Public Property Gender As String
        Public Property Age As String
        Public Property Phoneno As String
        Public Property Civilstatus As String
        Public Property Citizenship As String
        Public Property Fathersname As String
        Public Property Mothersname As String
        Public Property Spouse As String
        Public Property Email As String
        Public Property Religion As String
        Public Property Voterstatus As String
        Public Property Weight As String
        Public Property Height As String
        Public Property Idpic As Object
        Public Property Address As String
    End Class

    Private Sub dgvProfiles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProfiles.CellContentClick

    End Sub
End Class
