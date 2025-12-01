Public Class certissuance
    Private residentsList As New List(Of ResidentData)

    ' Method to handle when form is displayed as child form in dashboard
    Public Sub SetAsChildForm()
        ' Ensure the form is properly configured for child display
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub btnCreateCertificate_Click(sender As Object, e As EventArgs) Handles btnCreateCertificate.Click
        Dim f As New certificateform()
        AddHandler f.CertificateSaved, Sub()
                                           ' Hook for refreshing lists after save if needed
                                           ' Currently left empty as grid shows residents
                                       End Sub
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)

    End Sub

    Private Sub certissuance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadResidents()
    End Sub

    Private Sub LoadResidents()
        ' Load residents from database: lastname, firstname, middlename, phoneno, gender
        residentsList.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT lastname, firstname, middlename, phoneno, gender FROM tbl_residentinfo"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim data As New ResidentData()
                            data.LastName = If(Not reader.IsDBNull(0), reader.GetString(0), String.Empty)
                            data.FirstName = If(Not reader.IsDBNull(1), reader.GetString(1), String.Empty)
                            data.MiddleName = If(Not reader.IsDBNull(2), reader.GetString(2), String.Empty)
                            data.MobileNo = If(Not reader.IsDBNull(3), reader.GetString(3), String.Empty)
                            data.Gender = If(Not reader.IsDBNull(4), reader.GetString(4), String.Empty)
                            residentsList.Add(data)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Failed to load residents: " & ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try

        RefreshDataGrid()
    End Sub

    Private Sub RefreshDataGrid()
        DataGridView1.Rows.Clear()

        For Each resident In residentsList
            Dim rowIndex = DataGridView1.Rows.Add()
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn1").Value = "Select"
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn2").Value = resident.LastName
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn3").Value = resident.FirstName
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn4").Value = resident.MiddleName
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn5").Value = resident.MobileNo
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn6").Value = resident.Gender
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PerformSearch()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Auto-refresh when search text is cleared
        PerformSearch()
    End Sub

    Private Sub PerformSearch()
        Dim searchText = TextBox1.Text.ToLower()

        If String.IsNullOrEmpty(searchText) Then
            RefreshDataGrid()
            Return
        End If

        DataGridView1.Rows.Clear()
        Dim filteredResidents = residentsList.Where(Function(r) _
            r.FirstName.ToLower().Contains(searchText) OrElse
            r.LastName.ToLower().Contains(searchText) OrElse
            r.MiddleName.ToLower().Contains(searchText)
        ).ToList()

        For Each resident In filteredResidents
            Dim rowIndex = DataGridView1.Rows.Add()
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn1").Value = "Select"
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn2").Value = resident.LastName
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn3").Value = resident.FirstName
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn4").Value = resident.MiddleName
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn5").Value = resident.MobileNo
            DataGridView1.Rows(rowIndex).Cells("DataGridViewTextBoxColumn6").Value = resident.Gender
        Next
    End Sub

    Private Sub dgvResidents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        ' Delete button - delete selected certificate
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a certificate to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow = DataGridView1.SelectedRows(0)
        Dim lastName As String = If(selectedRow.Cells("DataGridViewTextBoxColumn2").Value IsNot Nothing, selectedRow.Cells("DataGridViewTextBoxColumn2").Value.ToString(), "")
        Dim firstName As String = If(selectedRow.Cells("DataGridViewTextBoxColumn3").Value IsNot Nothing, selectedRow.Cells("DataGridViewTextBoxColumn3").Value.ToString(), "")
        Dim middleName As String = If(selectedRow.Cells("DataGridViewTextBoxColumn4").Value IsNot Nothing, selectedRow.Cells("DataGridViewTextBoxColumn4").Value.ToString(), "")

        If String.IsNullOrEmpty(lastName) OrElse String.IsNullOrEmpty(firstName) Then
            MessageBox.Show("Invalid certificate data.", "Delete Certificate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fullName As String = If(String.IsNullOrWhiteSpace(middleName), $"{firstName} {lastName}", $"{firstName} {middleName} {lastName}")
        Dim confirmation = MessageBox.Show($"Delete certificate for {fullName}? The record will be moved to the restore list.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmation <> DialogResult.Yes Then Return

        ' Load certificates for this resident and delete them
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                ' First, get all certificates for this resident
                Dim selectSql As String = "SELECT certificate, fullname, age, status, address, purpose, issuedon FROM tbl_certificate WHERE fullname LIKE @fullnamePattern"
                Dim certificatesToDelete As New List(Of Dictionary(Of String, Object))()

                Using selectCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(selectSql, conn)
                    Dim namePattern As String = $"%{firstName}%{lastName}%"
                    selectCmd.Parameters.AddWithValue("@fullnamePattern", namePattern)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = selectCmd.ExecuteReader()
                        While reader.Read()
                            Dim cert As New Dictionary(Of String, Object)()
                            cert("certificate") = If(reader.IsDBNull(0), String.Empty, reader.GetString(0))
                            cert("fullname") = If(reader.IsDBNull(1), String.Empty, reader.GetString(1))
                            cert("age") = If(reader.IsDBNull(2), 0, reader.GetInt32(2))
                            cert("status") = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
                            cert("address") = If(reader.IsDBNull(4), String.Empty, reader.GetString(4))
                            cert("purpose") = If(reader.IsDBNull(5), String.Empty, reader.GetString(5))
                            cert("issuedon") = If(reader.IsDBNull(6), DateTime.MinValue, reader.GetDateTime(6))
                            certificatesToDelete.Add(cert)
                        End While
                    End Using
                End Using

                If certificatesToDelete.Count = 0 Then
                    MessageBox.Show("No certificates found for this resident.", "Delete Certificate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' Move to restore table and delete from main table
                Using tran = conn.BeginTransaction()
                    Try
                        For Each cert In certificatesToDelete
                            ' Insert into restore table
                            Dim insertSql As String = "INSERT INTO tbl_certrestore (certificate, fullname, age, status, address, purpose, issuedon) VALUES (@certificate, @fullname, @age, @status, @address, @purpose, @issuedon)"
                            Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
                                insertCmd.Parameters.AddWithValue("@certificate", cert("certificate"))
                                insertCmd.Parameters.AddWithValue("@fullname", cert("fullname"))
                                insertCmd.Parameters.AddWithValue("@age", cert("age"))
                                insertCmd.Parameters.AddWithValue("@status", If(String.IsNullOrWhiteSpace(cert("status").ToString()), DBNull.Value, cert("status")))
                                insertCmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(cert("address").ToString()), DBNull.Value, cert("address")))
                                insertCmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrWhiteSpace(cert("purpose").ToString()), DBNull.Value, cert("purpose")))
                                insertCmd.Parameters.AddWithValue("@issuedon", cert("issuedon"))
                                insertCmd.ExecuteNonQuery()
                            End Using

                            ' Delete from main table
                            Dim deleteSql As String = "DELETE FROM tbl_certificate WHERE certificate = @certificate AND fullname = @fullname AND issuedon = @issuedon LIMIT 1"
                            Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
                                deleteCmd.Parameters.AddWithValue("@certificate", cert("certificate"))
                                deleteCmd.Parameters.AddWithValue("@fullname", cert("fullname"))
                                deleteCmd.Parameters.AddWithValue("@issuedon", cert("issuedon"))
                                deleteCmd.ExecuteNonQuery()
                            End Using
                        Next

                        tran.Commit()
                        MessageBox.Show($"Moved {certificatesToDelete.Count} certificate(s) for {fullName} to restore list.", "Delete Certificate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to delete certificate: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class