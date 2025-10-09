﻿' Use fully qualified MySQL types to avoid collisions with local placeholder classes

Partial Class cedulatracker
	Private cedulaTable As DataTable

	Public Sub New()
		InitializeComponent()
		cmbFilter.SelectedIndex = 0
	End Sub

	Private Sub cedulatracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		LoadCedulaData()
	End Sub

	Private Sub LoadCedulaData()
		cedulaTable = New DataTable()
		Try
			Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
				conn.Open()
				Dim sql As String = "SELECT ctcnumber, CONCAT(lastname, ', ', firstname, IF(middlename IS NULL OR middlename = '', '', CONCAT(' ', middlename))) AS fullname, dateissued FROM tbl_cedulatracker ORDER BY dateissued DESC"
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

	End Sub
End Class