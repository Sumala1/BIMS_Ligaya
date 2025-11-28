' Use fully qualified MySQL types to avoid collisions with local placeholder classes

Partial Class cedulatracker
	Private cedulaTable As DataTable

	Public Sub New()
		InitializeComponent()
        If IsInDesigner Then
            Return
        End If

		cmbFilter.SelectedIndex = 0
	End Sub

	Private Sub cedulatracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsInDesigner Then
            Return
        End If

		LoadCedulaData()
	End Sub

    Private Function IsInDesigner() As Boolean
        Try
            If Me IsNot Nothing AndAlso Me.DesignMode Then Return True
        Catch
        End Try
        Try
            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then Return True
        Catch
        End Try
        Try
            Dim procName As String = System.Diagnostics.Process.GetCurrentProcess().ProcessName
            If String.Equals(procName, "devenv", StringComparison.OrdinalIgnoreCase) Then Return True
        Catch
        End Try
        Return False
    End Function

	Private Sub LoadCedulaData()
        If IsInDesigner Then
            dgvCedula.Rows.Clear()
            Return
        End If

		cedulaTable = New DataTable()
		Try
			Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
				conn.Open()
				Dim sql As String = "SELECT ctcnumber, fullname, dateissued FROM tbl_cedulatracker ORDER BY dateissued DESC"
				Using da As New Global.MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
					da.Fill(cedulaTable)
				End Using
			End Using

			BindGrid(cedulaTable)
		Catch ex As Exception
			MessageBox.Show($"Failed to load data: {ex.Message}")
		End Try
	End Sub

	Private Sub BindGrid(source As DataTable)
		dgvCedula.Rows.Clear()
		For Each row As DataRow In source.Rows
			Dim idx As Integer = dgvCedula.Rows.Add()
			dgvCedula.Rows(idx).Cells("colAction").Value = "View"
			dgvCedula.Rows(idx).Cells("colCTCNumber").Value = row("ctcnumber").ToString()
			dgvCedula.Rows(idx).Cells("colFullName").Value = row("fullname").ToString()
			dgvCedula.Rows(idx).Cells("colDateIssued").Value = Convert.ToDateTime(row("dateissued")).ToString("yyyy-MM-dd HH:mm")
			' Store the ctcnumber in the row tag for delete operation
			dgvCedula.Rows(idx).Tag = row("ctcnumber")
		Next
		lblShowingEntries.Text = $"Showing 1 to {source.Rows.Count} of {source.Rows.Count} entries"
	End Sub

	Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
		ApplyFilter()
	End Sub

	Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
		ApplyFilter()
	End Sub

	Private Sub ApplyFilter()
		If cedulaTable Is Nothing Then Return
		Dim term As String = txtSearch.Text.Trim().ToLowerInvariant()
		Dim view As DataView = cedulaTable.DefaultView
		Select Case cmbFilter.SelectedIndex
			Case 0 ' CTC Number
				view.RowFilter = If(term = "", "", $"CONVERT(ctcnumber, 'System.String') LIKE '%{term.Replace("'", "''")}%' ")
			Case 1 ' Full Name
				view.RowFilter = If(term = "", "", $"fullname LIKE '%{term.Replace("'", "''")}%' ")
			Case 2 ' Date Issued
				view.RowFilter = If(term = "", "", $"CONVERT(dateissued, 'System.String') LIKE '%{term.Replace("'", "''")}%' ")
		End Select
		BindGrid(view.ToTable())
	End Sub

	Private Sub btnTransaction_Click(sender As Object, e As EventArgs) Handles btnTransaction.Click
		Dim f As New cedulaform()
		f.StartPosition = FormStartPosition.CenterScreen
		If f.ShowDialog(Me) = DialogResult.OK Then
			LoadCedulaData()
		 End If
	End Sub

	Private Sub dgvCedula_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCedula.CellContentClick
		If e.RowIndex < 0 Then Return
		
		' Check if Delete column was clicked
		If e.ColumnIndex = dgvCedula.Columns("colDelete").Index Then
			DeleteCedulaRecord(e.RowIndex)
		End If
	End Sub

	Private Sub DeleteCedulaRecord(rowIndex As Integer)
		If rowIndex < 0 OrElse rowIndex >= dgvCedula.Rows.Count Then Return

		Dim row As DataGridViewRow = dgvCedula.Rows(rowIndex)
		Dim ctcNumberObj As Object = row.Tag
		Dim ctcNumber As Integer = 0
		
		If ctcNumberObj IsNot Nothing AndAlso Integer.TryParse(ctcNumberObj.ToString(), ctcNumber) Then
			' Get full name for confirmation
			Dim fullName As String = If(row.Cells("colFullName").Value IsNot Nothing, row.Cells("colFullName").Value.ToString(), "")
			Dim confirmation = MessageBox.Show($"Delete cedula record for {fullName} (CTC: {ctcNumber})? The record will be moved to the restore list.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
			If confirmation <> DialogResult.Yes Then Return

			Try
				Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
					conn.Open()
					Using tran = conn.BeginTransaction()
						Try
							' First, get the full record from tbl_cedulatracker
							Dim selectSql As String = "SELECT ctcnumber, year, placeissued, fullname, address, gender, dateissued, citizenship, placeofbirth, civilstatus, dateofbirth, profession FROM tbl_cedulatracker WHERE ctcnumber = @ctcnumber LIMIT 1"
							Dim record As Dictionary(Of String, Object) = Nothing

							Using selectCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(selectSql, conn, tran)
								selectCmd.Parameters.AddWithValue("@ctcnumber", ctcNumber)
								Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = selectCmd.ExecuteReader()
									If reader.Read() Then
										record = New Dictionary(Of String, Object)()
										record("ctcnumber") = reader.GetInt32(0)
										record("year") = If(reader.IsDBNull(1), DBNull.Value, CType(reader.GetInt32(1), Object))
										record("placeissued") = If(reader.IsDBNull(2), String.Empty, reader.GetString(2))
										record("fullname") = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
										record("address") = If(reader.IsDBNull(4), String.Empty, reader.GetString(4))
										record("gender") = If(reader.IsDBNull(5), DBNull.Value, reader.GetString(5))
										record("dateissued") = If(reader.IsDBNull(6), DateTime.MinValue, reader.GetDateTime(6))
										record("citizenship") = If(reader.IsDBNull(7), DBNull.Value, reader.GetString(7))
										record("placeofbirth") = If(reader.IsDBNull(8), DBNull.Value, reader.GetString(8))
										record("civilstatus") = If(reader.IsDBNull(9), DBNull.Value, reader.GetString(9))
										record("dateofbirth") = If(reader.IsDBNull(10), DBNull.Value, reader.GetDateTime(10))
										record("profession") = If(reader.IsDBNull(11), DBNull.Value, reader.GetString(11))
									End If
								End Using
							End Using

							If record Is Nothing Then
								MessageBox.Show("Cedula record not found in database.", "Delete Cedula", MessageBoxButtons.OK, MessageBoxIcon.Warning)
								Return
							End If

							' Insert into restore table
							Dim insertSql As String = "INSERT INTO tbl_cedularestore (ctcnumber, year, placeissued, fullname, address, gender, dateissued, citizenship, placeofbirth, civilstatus, dateofbirth, profession) VALUES (@ctcnumber, @year, @placeissued, @fullname, @address, @gender, @dateissued, @citizenship, @placeofbirth, @civilstatus, @dateofbirth, @profession)"
							Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
								insertCmd.Parameters.AddWithValue("@ctcnumber", record("ctcnumber"))
								insertCmd.Parameters.AddWithValue("@year", record("year"))
								insertCmd.Parameters.AddWithValue("@placeissued", If(String.IsNullOrWhiteSpace(record("placeissued").ToString()), DBNull.Value, record("placeissued")))
								insertCmd.Parameters.AddWithValue("@fullname", If(String.IsNullOrWhiteSpace(record("fullname").ToString()), DBNull.Value, record("fullname")))
								insertCmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(record("address").ToString()), DBNull.Value, record("address")))
								insertCmd.Parameters.AddWithValue("@gender", record("gender"))
								insertCmd.Parameters.AddWithValue("@dateissued", record("dateissued"))
								insertCmd.Parameters.AddWithValue("@citizenship", record("citizenship"))
								insertCmd.Parameters.AddWithValue("@placeofbirth", record("placeofbirth"))
								insertCmd.Parameters.AddWithValue("@civilstatus", record("civilstatus"))
								insertCmd.Parameters.AddWithValue("@dateofbirth", record("dateofbirth"))
								insertCmd.Parameters.AddWithValue("@profession", record("profession"))
								insertCmd.ExecuteNonQuery()
							End Using

							' Delete from main table
							Dim deleteSql As String = "DELETE FROM tbl_cedulatracker WHERE ctcnumber = @ctcnumber LIMIT 1"
							Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
								deleteCmd.Parameters.AddWithValue("@ctcnumber", ctcNumber)
								deleteCmd.ExecuteNonQuery()
							End Using

							tran.Commit()
							MessageBox.Show($"Moved cedula record for {fullName} to restore list.", "Delete Cedula", MessageBoxButtons.OK, MessageBoxIcon.Information)
							LoadCedulaData()
						Catch
							tran.Rollback()
							Throw
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Failed to delete cedula: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		Else
			MessageBox.Show("Invalid CTC number.", "Delete Cedula", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		End If
    End Sub
End Class
