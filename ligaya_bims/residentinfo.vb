Public Class residentinfo
    Private residentForm As residentform
    Private residentsList As New List(Of ResidentData)
    Private currentResidentLastName As String = String.Empty
    Private currentResidentFirstName As String = String.Empty
    Private currentResidentMiddleName As String = String.Empty
    Private currentResidentBirthDate As DateTime = DateTime.MinValue
    Private currentPicturePath As String = String.Empty
    Private newPicturePath As String = String.Empty
    Private residentColumnRequirements As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)
    Private deleteIconImage As Image
    Private Shared ReadOnly deleteIconBase64 As String = "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"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub residentinfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Only run initialization at runtime, not in designer
        If Not DesignMode Then
            LoadResidentColumnRequirements()
            InitializeComboBoxes()
            EnableDetailEditing()
            LoadResidents()
            InitializeSelectAllCheckbox()
            PositionHeaderCheckBox()
            InitializeDeleteIcon()
        End If
    End Sub
    Private Sub LoadResidentColumnRequirements()
        residentColumnRequirements.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim schemaName As String = conn.Database
                Dim sql As String = "SELECT COLUMN_NAME, IS_NULLABLE FROM information_schema.columns WHERE table_schema = @schema AND table_name = 'tbl_residentinfo'"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@schema", schemaName)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim columnName As String = reader.GetString(0)
                            Dim isNullable As String = reader.GetString(1)
                            residentColumnRequirements(columnName) = String.Equals(isNullable, "NO", StringComparison.OrdinalIgnoreCase)
                        End While
                    End Using
                End Using
            End Using
        Catch
            ' If schema lookup fails, keep dictionary empty so default logic applies
        End Try
    End Sub

    Private Sub InitializeDeleteIcon()
        Try
            If deleteIconImage IsNot Nothing Then
                deleteIconImage.Dispose()
                deleteIconImage = Nothing
            End If

            deleteIconImage = CreateDeleteIconImage()
            Dim actionColumn = TryCast(dgvResidents.Columns("colAction"), DataGridViewImageColumn)
            If actionColumn IsNot Nothing Then
                actionColumn.Image = deleteIconImage
                actionColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            End If
        Catch
            ' Ignore icon creation failures silently
        End Try
    End Sub


    Private Sub EnableDetailEditing()
        Dim editableTextBoxes As TextBox() = {
            txtLastName,
            txtFirstName,
            txtMiddleName,
            txtAge,
            txtCitizenship,
            txtPhoneNumber,
            txtFathersName,
            txtMothersName,
            txtSpouse,
            txtReligion,
            txtHeight,
            txtWeight,
            txtAddress
        }

        For Each tb As TextBox In editableTextBoxes
            If tb IsNot Nothing Then
                tb.ReadOnly = False
            End If
        Next

        If cmbGender IsNot Nothing Then cmbGender.Enabled = True
        If cmbCivilStatus IsNot Nothing Then cmbCivilStatus.Enabled = True
        If cmbVotersStatus IsNot Nothing Then cmbVotersStatus.Enabled = True
        If dtpBirthdate IsNot Nothing Then dtpBirthdate.Enabled = True
    End Sub

    ' Method to handle when form is displayed as child form in dashboard
    Public Sub SetAsChildForm()
        ' Ensure the form is properly configured for child display
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub InitializeComboBoxes()
        ' Initialize Gender ComboBox
        cmbGender.Items.Clear()
        cmbGender.Items.Add("Male")
        cmbGender.Items.Add("Female")

        ' Initialize Civil Status ComboBox
        cmbCivilStatus.Items.Clear()
        cmbCivilStatus.Items.Add("Single")
        cmbCivilStatus.Items.Add("Married")
        cmbCivilStatus.Items.Add("Widowed")
        cmbCivilStatus.Items.Add("Divorced")
        cmbCivilStatus.Items.Add("Separated")

        ' Initialize Voters Status ComboBox
        cmbVotersStatus.Items.Clear()
        cmbVotersStatus.Items.Add("Registered")
        cmbVotersStatus.Items.Add("Not Registered")
        cmbVotersStatus.Items.Add("Active")
        cmbVotersStatus.Items.Add("Inactive")
    End Sub

    Private Sub LoadResidents()
        ' Load residents from database: id, lastname, firstname, middlename, phoneno, gender
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
        dgvResidents.Rows.Clear()

        For Each resident In residentsList
            Dim rowIndex = dgvResidents.Rows.Add()
            ' Ensure checkbox starts unchecked for accuracy (only if column exists)
            If dgvResidents.Columns.Contains("chkSelectAll") Then
                dgvResidents.Rows(rowIndex).Cells("chkSelectAll").Value = False
            End If
            dgvResidents.Rows(rowIndex).Cells("colID").Value = "" ' ID column removed - using composite key instead
            dgvResidents.Rows(rowIndex).Cells("colLastName").Value = resident.LastName
            dgvResidents.Rows(rowIndex).Cells("colFirstName").Value = resident.FirstName
            dgvResidents.Rows(rowIndex).Cells("colMiddleName").Value = resident.MiddleName
            dgvResidents.Rows(rowIndex).Cells("colMobileNo").Value = resident.MobileNo
            dgvResidents.Rows(rowIndex).Cells("colGender").Value = resident.Gender
        Next

        lblShowEntries.Text = $"Showing 1 to {residentsList.Count} of {residentsList.Count} entries"
    End Sub

    Private Sub btnNewResident_Click(sender As Object, e As EventArgs) Handles btnNewResidentApp.Click
        residentForm = New residentform()
        AddHandler residentForm.ResidentSaved, AddressOf OnResidentSaved
        residentForm.ShowDialog()
    End Sub

    Private Sub OnResidentSaved(resident As ResidentData)
        ' Reload residents from database to get the proper ID and ensure data consistency
        LoadResidents()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim searchText = txtSearch.Text.ToLower()

        If String.IsNullOrEmpty(searchText) Then
            RefreshDataGrid()
            Return
        End If

        dgvResidents.Rows.Clear()
        Dim filteredResidents = residentsList.Where(Function(r) _
            r.FirstName.ToLower().Contains(searchText) OrElse
            r.LastName.ToLower().Contains(searchText) OrElse
            r.MiddleName.ToLower().Contains(searchText)
        ).ToList()

        For Each resident In filteredResidents
            Dim rowIndex = dgvResidents.Rows.Add()
            ' Keep checkbox accurate: do not auto-check on filter (only if column exists)
            If dgvResidents.Columns.Contains("chkSelectAll") Then
                dgvResidents.Rows(rowIndex).Cells("chkSelectAll").Value = False
            End If
            dgvResidents.Rows(rowIndex).Cells("colID").Value = "" ' ID column removed - using composite key instead
            dgvResidents.Rows(rowIndex).Cells("colLastName").Value = resident.LastName
            dgvResidents.Rows(rowIndex).Cells("colFirstName").Value = resident.FirstName
            dgvResidents.Rows(rowIndex).Cells("colMiddleName").Value = resident.MiddleName
            dgvResidents.Rows(rowIndex).Cells("colMobileNo").Value = resident.MobileNo
            dgvResidents.Rows(rowIndex).Cells("colGender").Value = resident.Gender
        Next

        lblShowEntries.Text = $"Showing 1 to {filteredResidents.Count} of {filteredResidents.Count} entries"
    End Sub

    Private Sub btnExportResident_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Export functionality will be implemented here", "Export Residents", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnDeleteResident_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Delete functionality will be implemented here", "Delete Residents", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub dgvResidents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResidents.CellClick
        If e.RowIndex >= 0 Then
            ' Get resident data from the selected row using composite key
            Dim lastName As String = If(dgvResidents.Rows(e.RowIndex).Cells("colLastName").Value IsNot Nothing, dgvResidents.Rows(e.RowIndex).Cells("colLastName").Value.ToString(), "")
            Dim firstName As String = If(dgvResidents.Rows(e.RowIndex).Cells("colFirstName").Value IsNot Nothing, dgvResidents.Rows(e.RowIndex).Cells("colFirstName").Value.ToString(), "")

            ' Check if the Action (Delete) icon column was clicked
            If dgvResidents.Columns.Contains("colAction") AndAlso e.ColumnIndex = dgvResidents.Columns("colAction").Index Then
                DeleteResidentRow(e.RowIndex)
            Else
                ' Load and display resident details in the right panel
                LoadResidentDetails(lastName, firstName)
            End If
        End If
    End Sub

    Private Sub EditResident(lastName As String, firstName As String)
        Try
            ' Load resident data for editing using composite key
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT lastname, firstname, middlename, gender, birthdate, age, phoneno, civilstatus, citizenship, fathersname, mothersname, spouse, email, voterstatus, weight, height, address, religion, idpic FROM tbl_residentinfo WHERE lastname = @ln AND firstname = @fn"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ln", lastName)
                    cmd.Parameters.AddWithValue("@fn", firstName)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Open resident form in edit mode
                            Dim editForm As New residentform()
                            ' Set the editing resident using composite key (lastname, firstname, birthdate)
                            Dim birthDate As DateTime = If(Not reader.IsDBNull(4), reader.GetDateTime(4), DateTime.Now)
                            editForm.SetEditingResident(lastName, firstName, birthDate)
                            ' Load the existing data into the form
                            If Not reader.IsDBNull(0) Then editForm.txtLastName.Text = reader.GetString(0)
                            If Not reader.IsDBNull(1) Then editForm.txtFirstName.Text = reader.GetString(1)
                            If Not reader.IsDBNull(2) Then editForm.txtMiddleName.Text = reader.GetString(2)

                            ' Set Gender ComboBox
                            If Not reader.IsDBNull(3) Then
                                Dim genderValue As String = reader.GetString(3)
                                Dim genderIndex As Integer = editForm.cmbGender.FindStringExact(genderValue)
                                If genderIndex >= 0 Then
                                    editForm.cmbGender.SelectedIndex = genderIndex
                                Else
                                    editForm.cmbGender.Text = genderValue
                                End If
                            End If

                            If Not reader.IsDBNull(4) Then editForm.dtpBirthDate.Value = reader.GetDateTime(4)
                            If Not reader.IsDBNull(5) Then editForm.txtAge.Text = reader.GetInt32(5).ToString()
                            If Not reader.IsDBNull(6) Then editForm.txtPhoneNumber.Text = reader.GetString(6)

                            ' Set Civil Status ComboBox
                            If Not reader.IsDBNull(7) Then
                                Dim civilStatusValue As String = reader.GetString(7)
                                Dim civilStatusIndex As Integer = editForm.cmbCivilStatus.FindStringExact(civilStatusValue)
                                If civilStatusIndex >= 0 Then
                                    editForm.cmbCivilStatus.SelectedIndex = civilStatusIndex
                                Else
                                    editForm.cmbCivilStatus.Text = civilStatusValue
                                End If
                            End If

                            If Not reader.IsDBNull(8) Then editForm.txtCitizenship.Text = reader.GetString(8)
                            If Not reader.IsDBNull(9) Then editForm.txtFathersName.Text = reader.GetString(9)
                            If Not reader.IsDBNull(10) Then editForm.txtMothersName.Text = reader.GetString(10)
                            If Not reader.IsDBNull(11) Then editForm.txtSpouse.Text = reader.GetString(11)
                            If Not reader.IsDBNull(12) Then editForm.txtEmail.Text = reader.GetString(12)

                            ' Set Voters Status ComboBox
                            If Not reader.IsDBNull(13) Then
                                Dim votersStatusValue As String = reader.GetString(13)
                                Dim votersStatusIndex As Integer = editForm.cmbVotersStatus.FindStringExact(votersStatusValue)
                                If votersStatusIndex >= 0 Then
                                    editForm.cmbVotersStatus.SelectedIndex = votersStatusIndex
                                Else
                                    ' Try to match common variations
                                    Dim status As String = votersStatusValue.ToLower()
                                    If status.Contains("registered") OrElse status.Contains("active") Then
                                        Dim index As Integer = editForm.cmbVotersStatus.FindStringExact("Registered")
                                        If index >= 0 Then editForm.cmbVotersStatus.SelectedIndex = index
                                    ElseIf status.Contains("not") OrElse status.Contains("inactive") Then
                                        Dim index As Integer = editForm.cmbVotersStatus.FindStringExact("Not Registered")
                                        If index >= 0 Then editForm.cmbVotersStatus.SelectedIndex = index
                                    Else
                                        editForm.cmbVotersStatus.Text = votersStatusValue
                                    End If
                                End If
                            End If

                            If Not reader.IsDBNull(14) Then editForm.txtWeight.Text = reader.GetString(14)
                            If Not reader.IsDBNull(15) Then editForm.txtHeight.Text = reader.GetString(15)
                            If Not reader.IsDBNull(16) Then editForm.txtAddress.Text = reader.GetString(16)
                            If Not reader.IsDBNull(17) Then editForm.txtReligion.Text = reader.GetString(17)

                            ' Load existing picture if available (supports file path or BLOB)
                            If Not reader.IsDBNull(18) Then
                                Try
                                    Dim picValue As Object = reader.GetValue(18)
                                    If TypeOf picValue Is Byte() Then
                                        Dim bytes As Byte() = CType(picValue, Byte())
                                        Using ms As New System.IO.MemoryStream(bytes)
                                            Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                                            editForm.picIdPicture.Image = img
                                            editForm.picIdPicture.SizeMode = PictureBoxSizeMode.Zoom
                                        End Using
                                    ElseIf TypeOf picValue Is String AndAlso Not String.IsNullOrEmpty(CStr(picValue)) Then
                                        Dim picPath As String = CStr(picValue)
                                        editForm.SetOriginalPicturePath(picPath)
                                        If System.IO.File.Exists(picPath) Then
                                            Using fs As New System.IO.FileStream(picPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                                                editForm.picIdPicture.Image = System.Drawing.Image.FromStream(fs)
                                            End Using
                                            editForm.picIdPicture.SizeMode = PictureBoxSizeMode.Zoom
                                        End If
                                    End If
                                Catch ex As Exception
                                    ' If picture loading fails, continue without picture
                                End Try
                            End If

                            ' Handle the update after save
                            AddHandler editForm.ResidentSaved, Sub(resident As ResidentData)
                                                                   LoadResidents()
                                                                   MessageBox.Show("Resident information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                               End Sub

                            editForm.ShowDialog()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error editing resident: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadResidentDetails(lastName As String, firstName As String)
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT lastname, firstname, middlename, gender, birthdate, age, phoneno, civilstatus, citizenship, fathersname, mothersname, spouse, email, voterstatus, weight, height, address, religion, idpic FROM tbl_residentinfo WHERE lastname = @ln AND firstname = @fn"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ln", lastName)
                    cmd.Parameters.AddWithValue("@fn", firstName)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim resident As New ResidentData()
                            resident.LastName = If(Not reader.IsDBNull(0), reader.GetString(0), String.Empty)
                            resident.FirstName = If(Not reader.IsDBNull(1), reader.GetString(1), String.Empty)
                            resident.MiddleName = If(Not reader.IsDBNull(2), reader.GetString(2), String.Empty)
                            resident.Gender = If(Not reader.IsDBNull(3), reader.GetString(3), String.Empty)
                            resident.BirthDate = If(Not reader.IsDBNull(4), reader.GetDateTime(4), DateTime.MinValue)
                            resident.Age = If(Not reader.IsDBNull(5), reader.GetInt32(5), 0)
                            resident.PhoneNumber = If(Not reader.IsDBNull(6), reader.GetString(6), String.Empty)
                            resident.CivilStatus = If(Not reader.IsDBNull(7), reader.GetString(7), String.Empty)
                            resident.Citizenship = If(Not reader.IsDBNull(8), reader.GetString(8), String.Empty)
                            resident.FathersName = If(Not reader.IsDBNull(9), reader.GetString(9), String.Empty)
                            resident.MothersName = If(Not reader.IsDBNull(10), reader.GetString(10), String.Empty)
                            resident.Spouse = If(Not reader.IsDBNull(11), reader.GetString(11), String.Empty)
                            resident.Email = If(Not reader.IsDBNull(12), reader.GetString(12), String.Empty)
                            resident.VotersStatus = If(Not reader.IsDBNull(13), reader.GetString(13), String.Empty)
                            resident.Weight = If(Not reader.IsDBNull(14), reader.GetString(14), String.Empty)
                            resident.Height = If(Not reader.IsDBNull(15), reader.GetString(15), String.Empty)
                            resident.Address = If(Not reader.IsDBNull(16), reader.GetString(16), String.Empty)
                            resident.Religion = If(Not reader.IsDBNull(17), reader.GetString(17), String.Empty)
                            ' Handle idpic which can be either a byte array (BLOB) or string
                            If Not reader.IsDBNull(18) Then
                                If TypeOf reader.GetValue(18) Is Byte() Then
                                    ' It's a byte array - convert to string (file path or just leave empty)
                                    resident.IdPicture = String.Empty
                                Else
                                    ' It's a string
                                    resident.IdPicture = reader.GetString(18)
                                End If
                            Else
                                resident.IdPicture = String.Empty
                            End If
                            resident.MobileNo = resident.PhoneNumber
                            currentResidentLastName = resident.LastName
                            currentResidentFirstName = resident.FirstName
                            currentResidentMiddleName = resident.MiddleName
                            currentResidentBirthDate = resident.BirthDate
                            currentPicturePath = If(Not String.IsNullOrEmpty(resident.IdPicture), resident.IdPicture, String.Empty)
                            newPicturePath = String.Empty
                            ' Populate all controls with resident data
                            txtLastName.Text = resident.LastName
                            txtFirstName.Text = resident.FirstName
                            txtMiddleName.Text = resident.MiddleName

                            ' Set Gender ComboBox
                            If Not String.IsNullOrEmpty(resident.Gender) Then
                                Dim genderIndex As Integer = cmbGender.FindStringExact(resident.Gender)
                                If genderIndex >= 0 Then
                                    cmbGender.SelectedIndex = genderIndex
                                Else
                                    cmbGender.Text = resident.Gender
                                End If
                            End If

                            dtpBirthdate.Value = If(resident.BirthDate <> DateTime.MinValue, resident.BirthDate, DateTime.Now)
                            txtAge.Text = resident.Age.ToString()

                            ' Set Civil Status ComboBox
                            If Not String.IsNullOrEmpty(resident.CivilStatus) Then
                                Dim civilStatusIndex As Integer = cmbCivilStatus.FindStringExact(resident.CivilStatus)
                                If civilStatusIndex >= 0 Then
                                    cmbCivilStatus.SelectedIndex = civilStatusIndex
                                Else
                                    cmbCivilStatus.Text = resident.CivilStatus
                                End If
                            End If

                            txtCitizenship.Text = resident.Citizenship
                            txtPhoneNumber.Text = resident.PhoneNumber
                            txtFathersName.Text = resident.FathersName
                            txtMothersName.Text = resident.MothersName
                            txtSpouse.Text = resident.Spouse

                            ' Set Voters Status ComboBox
                            If Not String.IsNullOrEmpty(resident.VotersStatus) Then
                                Dim votersStatusIndex As Integer = cmbVotersStatus.FindStringExact(resident.VotersStatus)
                                If votersStatusIndex >= 0 Then
                                    cmbVotersStatus.SelectedIndex = votersStatusIndex
                                Else
                                    ' Try to match common variations
                                    Dim status As String = resident.VotersStatus.ToLower()
                                    If status.Contains("registered") OrElse status.Contains("active") Then
                                        cmbVotersStatus.SelectedIndex = cmbVotersStatus.FindStringExact("Registered")
                                    ElseIf status.Contains("not") OrElse status.Contains("inactive") Then
                                        cmbVotersStatus.SelectedIndex = cmbVotersStatus.FindStringExact("Not Registered")
                                    Else
                                        cmbVotersStatus.Text = resident.VotersStatus
                                    End If
                                End If
                            End If

                            txtReligion.Text = resident.Religion
                            txtHeight.Text = resident.Height
                            txtWeight.Text = resident.Weight
                            txtAddress.Text = resident.Address

                            ' Load profile picture if available (supports path or BLOB)
                            Try
                                If picProfile.Image IsNot Nothing Then
                                    picProfile.Image.Dispose()
                                    picProfile.Image = Nothing
                                End If

                                ' Attempt to read as BLOB (byte array) first
                                Dim picObj As Object = Nothing
                                Try
                                    picObj = reader.GetValue(18)
                                Catch
                                    picObj = Nothing
                                End Try

                                If picObj IsNot Nothing AndAlso TypeOf picObj Is Byte() Then
                                    Dim bytes As Byte() = CType(picObj, Byte())
                                    Dim loaded As Boolean = False
                                    ' Try: bytes are raw image
                                    Try
                                        Using ms As New System.IO.MemoryStream(bytes)
                                            picProfile.Image = System.Drawing.Image.FromStream(ms)
                                            loaded = True
                                        End Using
                                    Catch
                                        loaded = False
                                    End Try

                                    If Not loaded Then
                                        ' Fallback: bytes actually encode a UTF8 path or base64 string
                                        Try
                                            Dim asText As String = System.Text.Encoding.UTF8.GetString(bytes).Trim().Trim(""""c)
                                            If asText.Length > 0 Then
                                                If System.IO.File.Exists(asText) Then
                                                    Using fs As New System.IO.FileStream(asText, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                                                        picProfile.Image = System.Drawing.Image.FromStream(fs)
                                                    End Using
                                                    loaded = True
                                                Else
                                                    ' Maybe base64
                                                    Dim b As Byte() = Convert.FromBase64String(asText)
                                                    Using ms As New System.IO.MemoryStream(b)
                                                        picProfile.Image = System.Drawing.Image.FromStream(ms)
                                                    End Using
                                                    loaded = True
                                                End If
                                            End If
                                        Catch
                                            loaded = False
                                        End Try
                                    End If

                                    If loaded Then
                                        picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                        picProfile.Refresh()
                                    Else
                                        picProfile.Image = Nothing
                                        picProfile.Refresh()
                                    End If
                                ElseIf Not String.IsNullOrEmpty(resident.IdPicture) Then
                                    If System.IO.File.Exists(resident.IdPicture) Then
                                        Using fs As New System.IO.FileStream(resident.IdPicture, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                                            picProfile.Image = System.Drawing.Image.FromStream(fs)
                                        End Using
                                        picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                        picProfile.Refresh()
                                    Else
                                        ' Try to decode as Base64-encoded image string
                                        Try
                                            Dim base64 As String = resident.IdPicture.Trim()
                                            Dim bytes As Byte() = Convert.FromBase64String(base64)
                                            Using ms As New System.IO.MemoryStream(bytes)
                                                picProfile.Image = System.Drawing.Image.FromStream(ms)
                                            End Using
                                            picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                            picProfile.Refresh()
                                        Catch
                                            picProfile.Image = Nothing
                                            picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                            picProfile.Refresh()
                                        End Try
                                    End If
                                Else
                                    picProfile.Image = Nothing
                                    picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                    picProfile.Refresh()
                                End If
                            Catch ex As Exception
                                If picProfile.Image IsNot Nothing Then
                                    picProfile.Image.Dispose()
                                    picProfile.Image = Nothing
                                End If
                                picProfile.SizeMode = PictureBoxSizeMode.Zoom
                                picProfile.Refresh()
                            End Try
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading resident details:  " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===== Select-All Checkbox in DataGridView Header =====
    Private headerCheckBox As CheckBox

    Private Sub InitializeSelectAllCheckbox()
        If dgvResidents Is Nothing OrElse dgvResidents.Columns("chkSelectAll") Is Nothing Then Return
        headerCheckBox = New CheckBox()
        headerCheckBox.Size = New Size(15, 15)
        headerCheckBox.BackColor = Color.Transparent
        AddHandler headerCheckBox.CheckedChanged, AddressOf HeaderCheckBox_CheckedChanged
        dgvResidents.Controls.Add(headerCheckBox)
        PositionHeaderCheckBox()
    End Sub

    Private Sub PositionHeaderCheckBox()
        Try
            If dgvResidents Is Nothing OrElse headerCheckBox Is Nothing Then Return
            Dim col As DataGridViewColumn = Nothing
            Try
                col = dgvResidents.Columns("chkSelectAll")
            Catch
                col = Nothing
            End Try
            If col Is Nothing Then Return
            Dim rect = dgvResidents.GetCellDisplayRectangle(col.Index, -1, True)
            If rect.Width <= 0 OrElse rect.Height <= 0 Then Return
            headerCheckBox.Location = New Point(rect.X + (rect.Width - headerCheckBox.Width) \ 2, rect.Y + (rect.Height - headerCheckBox.Height) \ 2)
        Catch
        End Try
    End Sub

    Private Sub HeaderCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        If Not dgvResidents.Columns.Contains("chkSelectAll") Then Return
        For Each row As DataGridViewRow In dgvResidents.Rows
            row.Cells("chkSelectAll").Value = headerCheckBox.Checked
        Next
    End Sub

    Private Sub dgvResidents_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs)
        PositionHeaderCheckBox()
    End Sub

    Private Sub dgvResidents_Scroll(sender As Object, e As ScrollEventArgs)
        PositionHeaderCheckBox()
    End Sub

    Private Sub dgvResidents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvResidents_SelectionChanged(sender As Object, e As EventArgs) Handles dgvResidents.SelectionChanged
        ' Load resident details when a row is selected (supports keyboard navigation)
        If dgvResidents.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvResidents.SelectedRows(0)
            If selectedRow.Index >= 0 Then
                Dim lastName As String = If(selectedRow.Cells("colLastName").Value IsNot Nothing, selectedRow.Cells("colLastName").Value.ToString(), "")
                Dim firstName As String = If(selectedRow.Cells("colFirstName").Value IsNot Nothing, selectedRow.Cells("colFirstName").Value.ToString(), "")

                If Not String.IsNullOrEmpty(lastName) AndAlso Not String.IsNullOrEmpty(firstName) Then
                    ' Only load if not clicking the Action column (to avoid conflicts with CellClick)
                    If dgvResidents.CurrentCell Is Nothing OrElse dgvResidents.CurrentCell.ColumnIndex <> dgvResidents.Columns("colDelete").Index Then
                        LoadResidentDetails(lastName, firstName)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub lblShowEntries_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub dgvResidents_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResidents.CellContentClick

    End Sub

    Private Sub panelRight_Paint(sender As Object, e As PaintEventArgs) Handles panelRight.Paint

    End Sub


    Private Sub DeleteResidentRow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvResidents.Rows.Count Then Return

        Dim row As DataGridViewRow = dgvResidents.Rows(rowIndex)
        Dim lastNameValue As Object = row.Cells("colLastName").Value
        Dim firstNameValue As Object = row.Cells("colFirstName").Value
        Dim middleNameValue As Object = row.Cells("colMiddleName").Value

        Dim lastName As String = If(lastNameValue Is Nothing OrElse lastNameValue Is DBNull.Value, String.Empty, lastNameValue.ToString().Trim())
        Dim firstName As String = If(firstNameValue Is Nothing OrElse firstNameValue Is DBNull.Value, String.Empty, firstNameValue.ToString().Trim())
        Dim middleName As String = If(middleNameValue Is Nothing OrElse middleNameValue Is DBNull.Value, String.Empty, middleNameValue.ToString().Trim())

        If String.IsNullOrEmpty(lastName) OrElse String.IsNullOrEmpty(firstName) Then
            MessageBox.Show("Invalid resident data.", "Delete Resident", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim fullName As String = If(String.IsNullOrWhiteSpace(middleName), $"{firstName} {lastName}", $"{firstName} {middleName} {lastName}")
        Dim confirmation = MessageBox.Show($"Delete {fullName}? The record will move to the restore list.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmation <> DialogResult.Yes Then Return

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim selectSql As String = "SELECT lastname, firstname, middlename, gender, birthdate, age, phoneno, civilstatus, citizenship, fathersname, mothersname, spouse, email, religion, voterstatus, weight, height, idpic, address FROM tbl_residentinfo WHERE lastname = @ln AND firstname = @fn AND ((@mn IS NULL AND (middlename IS NULL OR TRIM(middlename) = '')) OR middlename = @mn) LIMIT 1"
                        Dim record As Dictionary(Of String, Object) = Nothing

                        Using selectCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(selectSql, conn, tran)
                            selectCmd.Parameters.AddWithValue("@ln", lastName)
                            selectCmd.Parameters.AddWithValue("@fn", firstName)
                            Dim middleParam As Object = If(String.IsNullOrWhiteSpace(middleName), CType(DBNull.Value, Object), middleName)
                            selectCmd.Parameters.AddWithValue("@mn", middleParam)

                            Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = selectCmd.ExecuteReader()
                                If reader.Read() Then
                                    record = New Dictionary(Of String, Object)()
                                    record("lastname") = reader.GetValue(0)
                                    record("firstname") = reader.GetValue(1)
                                    record("middlename") = reader.GetValue(2)
                                    record("gender") = reader.GetValue(3)
                                    record("birthdate") = reader.GetValue(4)
                                    record("age") = reader.GetValue(5)
                                    record("phoneno") = reader.GetValue(6)
                                    record("civilstatus") = reader.GetValue(7)
                                    record("citizenship") = reader.GetValue(8)
                                    record("fathersname") = reader.GetValue(9)
                                    record("mothersname") = reader.GetValue(10)
                                    record("spouse") = reader.GetValue(11)
                                    record("email") = reader.GetValue(12)
                                    record("religion") = reader.GetValue(13)
                                    record("voterstatus") = reader.GetValue(14)
                                    record("weight") = reader.GetValue(15)
                                    record("height") = reader.GetValue(16)
                                    record("idpic") = reader.GetValue(17)
                                    record("address") = reader.GetValue(18)
                                End If
                            End Using
                        End Using

                        If record Is Nothing Then
                            MessageBox.Show("Resident record not found in database.", "Delete Resident", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If

                        Dim insertSql As String = "INSERT INTO tbl_restore (lastname, firstname, middlename, gender, birthdate, age, phoneno, civilstatus, citizenship, fathersname, mothersname, spouse, email, religion, voterstatus, weight, height, idpic, address) VALUES (@ln, @fn, @mn, @gender, @birthdate, @age, @phoneno, @civilstatus, @citizenship, @fathersname, @mothersname, @spouse, @email, @religion, @voterstatus, @weight, @height, @idpic, @address)"
                        Using insertCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(insertSql, conn, tran)
                            insertCmd.Parameters.AddWithValue("@ln", record("lastname"))
                            insertCmd.Parameters.AddWithValue("@fn", record("firstname"))
                            insertCmd.Parameters.AddWithValue("@mn", record("middlename"))
                            insertCmd.Parameters.AddWithValue("@gender", record("gender"))
                            insertCmd.Parameters.AddWithValue("@birthdate", record("birthdate"))
                            insertCmd.Parameters.AddWithValue("@age", record("age"))
                            insertCmd.Parameters.AddWithValue("@phoneno", record("phoneno"))
                            insertCmd.Parameters.AddWithValue("@civilstatus", record("civilstatus"))
                            insertCmd.Parameters.AddWithValue("@citizenship", record("citizenship"))
                            insertCmd.Parameters.AddWithValue("@fathersname", record("fathersname"))
                            insertCmd.Parameters.AddWithValue("@mothersname", record("mothersname"))
                            insertCmd.Parameters.AddWithValue("@spouse", record("spouse"))
                            insertCmd.Parameters.AddWithValue("@email", record("email"))
                            insertCmd.Parameters.AddWithValue("@religion", record("religion"))
                            insertCmd.Parameters.AddWithValue("@voterstatus", record("voterstatus"))
                            insertCmd.Parameters.AddWithValue("@weight", record("weight"))
                            insertCmd.Parameters.AddWithValue("@height", record("height"))
                            insertCmd.Parameters.AddWithValue("@idpic", record("idpic"))
                            insertCmd.Parameters.AddWithValue("@address", record("address"))
                            insertCmd.ExecuteNonQuery()
                        End Using

                        Dim deleteSql As String = "DELETE FROM tbl_residentinfo WHERE lastname = @ln AND firstname = @fn AND ((@mn IS NULL AND (middlename IS NULL OR TRIM(middlename) = '')) OR middlename = @mn) AND ((@birthdate IS NULL AND birthdate IS NULL) OR birthdate = @birthdate) LIMIT 1"
                        Using deleteCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(deleteSql, conn, tran)
                            deleteCmd.Parameters.AddWithValue("@ln", record("lastname"))
                            deleteCmd.Parameters.AddWithValue("@fn", record("firstname"))
                            deleteCmd.Parameters.AddWithValue("@mn", record("middlename"))
                            deleteCmd.Parameters.AddWithValue("@birthdate", record("birthdate"))
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        tran.Commit()
                    Catch
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            LoadResidents()
            MessageBox.Show($"Moved {fullName} to restore list.", "Delete Resident", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Failed to delete resident: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(currentResidentLastName) OrElse String.IsNullOrWhiteSpace(currentResidentFirstName) Then
            MessageBox.Show("Select a resident from the list before updating.", "No Resident Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim computedAge As Integer = CalculateAge(dtpBirthdate.Value)
        txtAge.Text = computedAge.ToString()

        If Not ValidateResidentInputs() Then
            Return
        End If

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                Dim existsSql As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE lastname=@oldln AND firstname=@oldfn AND ((@oldmn IS NULL AND (middlename IS NULL OR TRIM(middlename) = '')) OR middlename=@oldmn) AND ((@oldbd IS NULL AND birthdate IS NULL) OR birthdate=@oldbd)"
                Using checkCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(existsSql, conn)
                    checkCmd.Parameters.AddWithValue("@oldln", currentResidentLastName)
                    checkCmd.Parameters.AddWithValue("@oldfn", currentResidentFirstName)
                    checkCmd.Parameters.AddWithValue("@oldmn", If(String.IsNullOrWhiteSpace(currentResidentMiddleName), CType(DBNull.Value, Object), currentResidentMiddleName))
                    checkCmd.Parameters.AddWithValue("@oldbd", If(currentResidentBirthDate = DateTime.MinValue, CType(DBNull.Value, Object), CType(currentResidentBirthDate, Object)))

                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count = 0 Then
                        MessageBox.Show("The selected resident no longer exists in the database. Please refresh the list.", "Record Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        LoadResidents()
                        Return
                    End If
                End Using

                Dim updatePicture As Boolean = Not String.IsNullOrWhiteSpace(newPicturePath)
                Dim updateSql As String = "UPDATE tbl_residentinfo SET lastname=@ln, firstname=@fn, middlename=@mn, gender=@gender, birthdate=@bd, age=@age, phoneno=@phone, civilstatus=@cstat, citizenship=@cit, fathersname=@father, mothersname=@mother, spouse=@spouse, voterstatus=@vstatus, weight=@weight, height=@height, address=@address, religion=@religion"
                If updatePicture Then
                    updateSql &= ", idpic=@idpic"
                End If
                updateSql &= " WHERE lastname=@oldln AND firstname=@oldfn AND ((@oldmn IS NULL AND (middlename IS NULL OR TRIM(middlename) = '')) OR middlename=@oldmn) AND ((@oldbd IS NULL AND birthdate IS NULL) OR birthdate=@oldbd)"

                Using updateCmd As New Global.MySql.Data.MySqlClient.MySqlCommand(updateSql, conn)
                    updateCmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                    updateCmd.Parameters.AddWithValue("@mn", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), CType(DBNull.Value, Object), txtMiddleName.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString())
                    updateCmd.Parameters.AddWithValue("@bd", dtpBirthdate.Value)
                    updateCmd.Parameters.AddWithValue("@age", computedAge)
                    updateCmd.Parameters.AddWithValue("@phone", If(String.IsNullOrWhiteSpace(txtPhoneNumber.Text), CType(DBNull.Value, Object), txtPhoneNumber.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@cstat", cmbCivilStatus.SelectedItem.ToString())
                    updateCmd.Parameters.AddWithValue("@cit", If(String.IsNullOrWhiteSpace(txtCitizenship.Text), CType(DBNull.Value, Object), txtCitizenship.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@father", If(String.IsNullOrWhiteSpace(txtFathersName.Text), CType(DBNull.Value, Object), txtFathersName.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@mother", If(String.IsNullOrWhiteSpace(txtMothersName.Text), CType(DBNull.Value, Object), txtMothersName.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@spouse", If(String.IsNullOrWhiteSpace(txtSpouse.Text), CType(DBNull.Value, Object), txtSpouse.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@vstatus", cmbVotersStatus.SelectedItem.ToString())
                    updateCmd.Parameters.AddWithValue("@weight", If(String.IsNullOrWhiteSpace(txtWeight.Text), CType(DBNull.Value, Object), txtWeight.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@height", If(String.IsNullOrWhiteSpace(txtHeight.Text), CType(DBNull.Value, Object), txtHeight.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@address", If(String.IsNullOrWhiteSpace(txtAddress.Text), CType(DBNull.Value, Object), txtAddress.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@religion", If(String.IsNullOrWhiteSpace(txtReligion.Text), CType(DBNull.Value, Object), txtReligion.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@oldln", currentResidentLastName)
                    updateCmd.Parameters.AddWithValue("@oldfn", currentResidentFirstName)
                    updateCmd.Parameters.AddWithValue("@oldmn", If(String.IsNullOrWhiteSpace(currentResidentMiddleName), CType(DBNull.Value, Object), currentResidentMiddleName))
                    updateCmd.Parameters.AddWithValue("@oldbd", If(currentResidentBirthDate = DateTime.MinValue, CType(DBNull.Value, Object), CType(currentResidentBirthDate, Object)))
                    If updatePicture Then
                        updateCmd.Parameters.AddWithValue("@idpic", newPicturePath)
                    End If

                    updateCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Resident information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                currentResidentLastName = txtLastName.Text.Trim()
                currentResidentFirstName = txtFirstName.Text.Trim()
                currentResidentMiddleName = txtMiddleName.Text.Trim()
                currentResidentBirthDate = dtpBirthdate.Value
                If Not String.IsNullOrWhiteSpace(newPicturePath) Then
                    currentPicturePath = newPicturePath
                    newPicturePath = String.Empty
                End If

                LoadResidents()
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to update resident: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub picProfile_Click(sender As Object, e As EventArgs) Handles picProfile.Click
        Dim openDialog As New OpenFileDialog With {
            .Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif|All Files (*.*)|*.*",
            .Title = "Select Resident Photo",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        }

        If openDialog.ShowDialog() = DialogResult.OK Then
            Try
                Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(openDialog.FileName)
                Dim clonedImage As Image
                Using ms As New System.IO.MemoryStream(fileBytes)
                    Using tempImage As Image = Image.FromStream(ms)
                        clonedImage = CType(tempImage.Clone(), Image)
                    End Using
                End Using

                If picProfile.Image IsNot Nothing Then
                    picProfile.Image.Dispose()
                End If

                picProfile.Image = clonedImage
                picProfile.SizeMode = PictureBoxSizeMode.Zoom
                picProfile.Refresh()

                newPicturePath = openDialog.FileName
            Catch ex As Exception
                MessageBox.Show("Unable to load the selected picture: " & ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function ValidateResidentInputs() As Boolean
        Dim missingFields As New List(Of String)()

        ValidateTextField("Last Name", txtLastName, "lastname", missingFields, defaultRequired:=True)
        ValidateTextField("First Name", txtFirstName, "firstname", missingFields, defaultRequired:=True)
        ValidateTextField("Middle Name", txtMiddleName, "middlename", missingFields)
        ValidateComboField("Gender", cmbGender, "gender", missingFields)
        ValidateDateField("Birthdate", dtpBirthdate, "birthdate", missingFields, defaultRequired:=True)
        ValidateTextField("Age", txtAge, "age", missingFields)
        ValidateComboField("Civil Status", cmbCivilStatus, "civilstatus", missingFields)
        ValidateTextField("Citizenship", txtCitizenship, "citizenship", missingFields)
        ValidateTextField("Phone Number", txtPhoneNumber, "phoneno", missingFields)
        ValidateTextField("Father's Name", txtFathersName, "fathersname", missingFields)
        ValidateTextField("Mother's Name", txtMothersName, "mothersname", missingFields)
        ValidateTextField("Spouse", txtSpouse, "spouse", missingFields)
        ValidateComboField("Voters Status", cmbVotersStatus, "voterstatus", missingFields)
        ValidateTextField("Religion", txtReligion, "religion", missingFields)
        ValidateTextField("Height", txtHeight, "height", missingFields)
        ValidateTextField("Weight", txtWeight, "weight", missingFields)
        ValidateTextField("Address", txtAddress, "address", missingFields)

        If missingFields.Count > 0 Then
            MessageBox.Show("Please fill out the following required fields:" & Environment.NewLine & String.Join(Environment.NewLine, missingFields), "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub ValidateTextField(fieldName As String, control As TextBox, columnKey As String, missingFields As List(Of String), Optional defaultRequired As Boolean = False)
        If Not FieldIsRequired(columnKey, defaultRequired) Then Return
        If control Is Nothing OrElse String.IsNullOrWhiteSpace(control.Text) Then
            missingFields.Add(fieldName)
        End If
    End Sub

    Private Sub ValidateComboField(fieldName As String, control As ComboBox, columnKey As String, missingFields As List(Of String), Optional defaultRequired As Boolean = False)
        If Not FieldIsRequired(columnKey, defaultRequired) Then Return
        If control Is Nothing OrElse control.SelectedIndex < 0 Then
            missingFields.Add(fieldName)
        End If
    End Sub

    Private Sub ValidateDateField(fieldName As String, control As DateTimePicker, columnKey As String, missingFields As List(Of String), Optional defaultRequired As Boolean = False)
        If Not FieldIsRequired(columnKey, defaultRequired) Then Return
        If control Is Nothing Then
            missingFields.Add(fieldName)
        End If
    End Sub

    Private Function FieldIsRequired(columnKey As String, defaultRequirement As Boolean) As Boolean
        If residentColumnRequirements IsNot Nothing AndAlso residentColumnRequirements.ContainsKey(columnKey) Then
            Return residentColumnRequirements(columnKey)
        End If
        Return defaultRequirement
    End Function

    Private Function CalculateAge(birthDate As DateTime) As Integer
        Dim today As DateTime = DateTime.Today
        Dim age As Integer = today.Year - birthDate.Year
        If birthDate.Date > today.AddYears(-age) Then
            age -= 1
        End If
        Return age
    End Function

    Private Function CreateDeleteIconImage() As Image
        Try
            Dim bytes As Byte() = Convert.FromBase64String(deleteIconBase64)
            Using ms As New System.IO.MemoryStream(bytes)
                Using loaded As Image = Image.FromStream(ms)
                    Return CType(loaded.Clone(), Image)
                End Using
            End Using
        Catch
            Return New Bitmap(48, 48)
        End Try
    End Function

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        If deleteIconImage IsNot Nothing Then
            deleteIconImage.Dispose()
            deleteIconImage = Nothing
        End If
        MyBase.OnFormClosed(e)
    End Sub
End Class