Partial Class cedulaform
    Inherits System.Windows.Forms.Form

	Public Sub New()
		InitializeComponent()
		' Half-size window relative to typical 1200x700 main: set to 600x440 in designer
	End Sub

	Private Function ValidateInputs() As Boolean
		' Validate required fields
		If String.IsNullOrWhiteSpace(txtCTC.Text) Then
			MessageBox.Show("Please enter CTC Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return False
		End If
		If String.IsNullOrWhiteSpace(txtFullname.Text) Then
			MessageBox.Show("Please enter Fullname.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return False
		End If
		If String.IsNullOrWhiteSpace(txtAddress.Text) Then
			MessageBox.Show("Please enter Address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return False
		End If
		If String.IsNullOrWhiteSpace(txtPlace.Text) Then
			MessageBox.Show("Please enter Place of Issue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return False
		End If

		Return True
	End Function

	Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
		If Not ValidateInputs() Then Return

		Dim ctcNumberInt As Integer
		If Not Integer.TryParse(txtCTC.Text.Trim(), ctcNumberInt) Then
			MessageBox.Show("CTC Number must be a valid integer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			Return
		End If

		Try
			Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
				conn.Open()
				Dim sql As String = "INSERT INTO tbl_cedulatracker (ctcnumber, year, placeissued, fullname, address, gender, dateissued, citizenship, placeofbirth, civilstatus, dateofbirth, profession) VALUES (@ctc, @year, @place, @fullname, @addr, @gender, @date, @citizenship, @placeofbirth, @civilstatus, @dateofbirth, @profession)"
				Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
					cmd.Parameters.AddWithValue("@ctc", ctcNumberInt)
					cmd.Parameters.AddWithValue("@year", If(cmbYear.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(cmbYear.SelectedItem.ToString()), DBNull.Value, CType(cmbYear.SelectedItem.ToString(), Object)))
					cmd.Parameters.AddWithValue("@place", txtPlace.Text.Trim())
					cmd.Parameters.AddWithValue("@fullname", txtFullname.Text.Trim())
					cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim())
					cmd.Parameters.AddWithValue("@gender", If(cmbGender.SelectedItem IsNot Nothing, cmbGender.SelectedItem.ToString(), DBNull.Value))
					cmd.Parameters.AddWithValue("@date", dtpIssued.Value)
					cmd.Parameters.AddWithValue("@citizenship", If(String.IsNullOrWhiteSpace(txtCitizenship.Text), DBNull.Value, CType(txtCitizenship.Text.Trim(), Object)))
					cmd.Parameters.AddWithValue("@placeofbirth", If(String.IsNullOrWhiteSpace(txtPlaceOfBirth.Text), DBNull.Value, CType(txtPlaceOfBirth.Text.Trim(), Object)))
					cmd.Parameters.AddWithValue("@civilstatus", If(cmbCivilStatus.SelectedItem IsNot Nothing, cmbCivilStatus.SelectedItem.ToString(), DBNull.Value))
					cmd.Parameters.AddWithValue("@dateofbirth", If(dtpDateOfBirth.Checked, CType(dtpDateOfBirth.Value, Object), DBNull.Value))
					cmd.Parameters.AddWithValue("@profession", If(String.IsNullOrWhiteSpace(txtProfession.Text), DBNull.Value, CType(txtProfession.Text.Trim(), Object)))

					cmd.ExecuteNonQuery()
				End Using
			End Using

			MessageBox.Show("Cedula record saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Me.DialogResult = DialogResult.OK
			Me.Close()
		Catch ex As Global.MySql.Data.MySqlClient.MySqlException
			MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Catch ex As Exception
			MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub
End Class