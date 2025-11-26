Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Public Class blotterrecords

    Public Sub New()
        InitializeComponent()
    End Sub

    Private editIcon As Image
    Private deleteIcon As Image
    Private printIcon As Image

    ' Method to handle when form is displayed as child form in dashboard
    Public Sub SetAsChildForm()
        ' Ensure the form is properly configured for child display
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
    End Sub

    Private Sub blotterform_Load(sender As Object, e As EventArgs)
        ' Set default search option
        If cmbSearchBy.Items.Count > 0 Then
            cmbSearchBy.SelectedIndex = 0
        End If

        ' Initialize DataGridViews
        InitializeDataGridViews()

        ' Load data
        LoadBlotterRecords()
        LoadScheduleRecords()
    End Sub

    Private Sub InitializeDataGridViews()
        LoadActionIcons()

        dgvBlotterRecords.Columns.Clear()
        dgvBlotterRecords.AutoGenerateColumns = False
        dgvBlotterRecords.RowTemplate.Height = 44

        dgvBlotterRecords.Columns.Add(CreateTextColumn("CaseNumber", "Brgy. Case #"))
        dgvBlotterRecords.Columns.Add(CreateTextColumn("Accusation", "Accusation"))
        dgvBlotterRecords.Columns.Add(CreateTextColumn("ComplainantName", "Complainant's Full Name"))
        dgvBlotterRecords.Columns.Add(CreateTextColumn("Purok", "Complainant's Purok"))
        dgvBlotterRecords.Columns.Add(CreateActionColumn("colEdit", editIcon, "Edit record"))
        dgvBlotterRecords.Columns.Add(CreateActionColumn("colDelete", deleteIcon, "Delete record"))
        dgvBlotterRecords.Columns.Add(CreateActionColumn("colPrint", printIcon, "Print record"))

        dgvSchedule.Columns.Clear()
        dgvSchedule.Columns.Add("SummonLevel", "Summon Level")
        dgvSchedule.Columns.Add("CaseDate", "Case Date")
        dgvSchedule.Columns.Add("StartTime", "Start Time")
        dgvSchedule.Columns.Add("EndTime", "End")
    End Sub

    Private Sub LoadBlotterRecords()
        Try
            dgvBlotterRecords.Rows.Clear()

            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT case_number, accusation, complainant_name, purok FROM tbl_blotter ORDER BY case_number DESC"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            dgvBlotterRecords.Rows.Add(
                                If(reader.IsDBNull(0), "", reader.GetString(0)),
                                If(reader.IsDBNull(1), "", reader.GetString(1)),
                                If(reader.IsDBNull(2), "", reader.GetString(2)),
                                If(reader.IsDBNull(3), "", reader.GetString(3))
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            ' Table might not exist yet, show empty grid
            MessageBox.Show("Blotter table not found. Please create the database table first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error loading blotter records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadScheduleRecords()
        Try
            dgvSchedule.Rows.Clear()

            Dim caseNumber As String = GetSelectedCaseNumber(False)
            If String.IsNullOrWhiteSpace(caseNumber) Then
                Return
            End If

            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT summon_level, case_date, start_time, end_time FROM tbl_blotter_schedule WHERE case_number = @caseNumber ORDER BY case_date DESC"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@caseNumber", caseNumber)
                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim record As New ScheduleRecord() With {
                                .CaseNumber = caseNumber,
                                .SummonLevel = If(reader.IsDBNull(0), String.Empty, reader.GetString(0)),
                                .CaseDate = If(reader.IsDBNull(1), Date.MinValue, reader.GetDateTime(1).Date),
                                .StartTime = If(reader.IsDBNull(2), TimeSpan.Zero, ReadTimeValue(reader, 2)),
                                .EndTime = If(reader.IsDBNull(3), TimeSpan.Zero, ReadTimeValue(reader, 3))
                            }

                            Dim rowIndex = dgvSchedule.Rows.Add(
                                record.SummonLevel,
                                If(record.CaseDate = Date.MinValue, String.Empty, record.CaseDate.ToString("MM/dd/yyyy")),
                                FormatTime(record.StartTime),
                                FormatTime(record.EndTime)
                            )

                            dgvSchedule.Rows(rowIndex).Tag = record
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            ' Table might not exist yet, show empty grid
        Catch ex As Exception
            ' Silently fail if no schedule data
        End Try
    End Sub

    ' Button Click Handlers for Blotter Records
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            Using incidentForm As New reportsform()
                AddHandler incidentForm.IncidentSubmitted, AddressOf HandleIncidentSubmitted
                incidentForm.StartPosition = FormStartPosition.CenterParent
                incidentForm.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Unable to open incident report form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HandleIncidentSubmitted()
        LoadBlotterRecords()
        LoadScheduleRecords()
    End Sub


    ' Button Click Handlers for Schedule
    Private Sub btnAddSchedule_Click(sender As Object, e As EventArgs) Handles btnAddSchedule.Click
        Dim caseNumber As String = GetSelectedCaseNumber()
        If String.IsNullOrWhiteSpace(caseNumber) Then
            Return
        End If

        Dim scheduleDetails As ScheduleRecord = PromptScheduleRecord()
        If scheduleDetails Is Nothing Then
            Return
        End If

        scheduleDetails.CaseNumber = caseNumber

        Try
            InsertSchedule(scheduleDetails)
            LoadScheduleRecords()
            MessageBox.Show("Schedule added successfully.", "Add Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            ShowScheduleDatabaseError("add the schedule", ex)
        Catch ex As Exception
            MessageBox.Show($"Unable to add schedule: {ex.Message}", "Add Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditSchedule_Click(sender As Object, e As EventArgs) Handles btnEditSchedule.Click
        Dim selectedRecord As ScheduleRecord = GetSelectedScheduleRecord()
        If selectedRecord Is Nothing Then
            MessageBox.Show("Please select a schedule to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim updatedRecord As ScheduleRecord = PromptScheduleRecord(selectedRecord)
        If updatedRecord Is Nothing Then
            Return
        End If

        updatedRecord.CaseNumber = selectedRecord.CaseNumber

        Try
            UpdateSchedule(selectedRecord, updatedRecord)
            LoadScheduleRecords()
            MessageBox.Show("Schedule updated successfully.", "Edit Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            ShowScheduleDatabaseError("update the schedule", ex)
        Catch ex As Exception
            MessageBox.Show($"Unable to update schedule: {ex.Message}", "Edit Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteSchedule_Click(sender As Object, e As EventArgs) Handles btnDeleteSchedule.Click
        Dim selectedRecord As ScheduleRecord = GetSelectedScheduleRecord()
        If selectedRecord Is Nothing Then
            MessageBox.Show("Please select a schedule to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this schedule?", "Delete Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result <> DialogResult.Yes Then
            Return
        End If

        Try
            DeleteSchedule(selectedRecord)
            LoadScheduleRecords()
            MessageBox.Show("Schedule deleted successfully.", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            ShowScheduleDatabaseError("delete the schedule", ex)
        Catch ex As Exception
            MessageBox.Show($"Unable to delete schedule: {ex.Message}", "Delete Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateSettlementStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateSettlementStatus.Click
        Dim caseNumber As String = GetSelectedCaseNumber()
        If String.IsNullOrWhiteSpace(caseNumber) Then
            Return
        End If

        Dim currentStatus As String = GetCurrentSettlementStatus(caseNumber)

        Using dialog As New SettlementStatusDialog(currentStatus)
            If dialog.ShowDialog(Me) <> DialogResult.OK Then
                Return
            End If

            Try
                UpdateSettlementStatus(caseNumber, dialog.SelectedStatus)
                LoadBlotterRecords()
                MessageBox.Show("Settlement status updated.", "Update Settlement", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Global.MySql.Data.MySqlClient.MySqlException
                MessageBox.Show($"Unable to update settlement status. Please ensure the 'settlement_status' column exists in tbl_blotter." & Environment.NewLine & $"Details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show($"Unable to update settlement status: {ex.Message}", "Update Settlement", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' Search functionality
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' TODO: Implement search filtering
        ' For now, just reload all records
        LoadBlotterRecords()
    End Sub

    Private Sub cmbSearchBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBy.SelectedIndexChanged
        ' Reset search when filter changes
        txtSearch.Clear()
    End Sub

    ' DataGridView event handlers
    Private Sub dgvBlotterRecords_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBlotterRecords.SelectionChanged
        ' Load schedule when a blotter record is selected
        If dgvBlotterRecords.SelectedRows.Count > 0 Then
            LoadScheduleRecords()
        End If
    End Sub

    Private Sub dgvBlotterRecords_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBlotterRecords.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim columnName As String = dgvBlotterRecords.Columns(e.ColumnIndex).Name
        Dim row As DataGridViewRow = dgvBlotterRecords.Rows(e.RowIndex)

        Select Case columnName
            Case "colEdit"
                EditBlotterRecord(row)
            Case "colDelete"
                DeleteBlotterRecord(row)
            Case "colPrint"
                PrintBlotterRecord(row)
        End Select
    End Sub

    Private Sub dgvSchedule_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSchedule.CellContentClick

    End Sub

    Private Sub EditBlotterRecord(row As DataGridViewRow)
        Dim caseNumber As String = Convert.ToString(row.Cells("CaseNumber").Value)
        MessageBox.Show($"Edit functionality for Case #{caseNumber} will be implemented here.", "Edit Blotter", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub DeleteBlotterRecord(row As DataGridViewRow)
        Dim caseNumber As String = Convert.ToString(row.Cells("CaseNumber").Value)
        Dim confirm = MessageBox.Show($"Delete blotter record for Case #{caseNumber}?", "Delete Blotter", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            MessageBox.Show("Delete functionality will be implemented here.", "Delete Blotter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PrintBlotterRecord(row As DataGridViewRow)
        Dim caseNumber As String = Convert.ToString(row.Cells("CaseNumber").Value)
        MessageBox.Show($"Print functionality for Case #{caseNumber} will be implemented here.", "Print Blotter", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function GetSelectedCaseNumber(Optional showWarning As Boolean = True) As String
        If dgvBlotterRecords.SelectedRows.Count = 0 Then
            If showWarning Then
                MessageBox.Show("Please select a blotter record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Return Nothing
        End If

        Dim value = dgvBlotterRecords.SelectedRows(0).Cells("CaseNumber").Value
        Dim caseNumber As String = If(value Is Nothing, String.Empty, value.ToString())

        If String.IsNullOrWhiteSpace(caseNumber) AndAlso showWarning Then
            MessageBox.Show("The selected blotter record does not contain a case number.", "Invalid Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Return caseNumber
    End Function

    Private Function GetSelectedScheduleRecord() As ScheduleRecord
        If dgvSchedule.SelectedRows.Count = 0 Then
            Return Nothing
        End If

        Dim record As ScheduleRecord = TryCast(dgvSchedule.SelectedRows(0).Tag, ScheduleRecord)
        Return If(record Is Nothing, Nothing, record.Clone())
    End Function

    Private Function PromptScheduleRecord(Optional existing As ScheduleRecord = Nothing) As ScheduleRecord
        Using dialog As New ScheduleEditorDialog(existing)
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                Return dialog.ScheduleData
            End If
        End Using

        Return Nothing
    End Function

    Private Sub InsertSchedule(schedule As ScheduleRecord)
        Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
            conn.Open()
            Dim sql As String = "INSERT INTO tbl_blotter_schedule (case_number, summon_level, case_date, start_time, end_time) VALUES (@caseNumber, @summonLevel, @caseDate, @startTime, @endTime)"
            Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@caseNumber", schedule.CaseNumber)
                cmd.Parameters.AddWithValue("@summonLevel", schedule.SummonLevel)
                cmd.Parameters.AddWithValue("@caseDate", schedule.CaseDate)
                cmd.Parameters.AddWithValue("@startTime", schedule.StartTime)
                cmd.Parameters.AddWithValue("@endTime", schedule.EndTime)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateSchedule(originalRecord As ScheduleRecord, updatedRecord As ScheduleRecord)
        Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
            conn.Open()
            Dim sql As String =
                "UPDATE tbl_blotter_schedule " &
                "SET summon_level = @newSummonLevel, case_date = @newCaseDate, start_time = @newStartTime, end_time = @newEndTime " &
                "WHERE case_number = @caseNumber AND summon_level = @oldSummonLevel AND case_date = @oldCaseDate AND start_time = @oldStartTime AND end_time = @oldEndTime LIMIT 1"

            Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@newSummonLevel", updatedRecord.SummonLevel)
                cmd.Parameters.AddWithValue("@newCaseDate", updatedRecord.CaseDate)
                cmd.Parameters.AddWithValue("@newStartTime", updatedRecord.StartTime)
                cmd.Parameters.AddWithValue("@newEndTime", updatedRecord.EndTime)
                cmd.Parameters.AddWithValue("@caseNumber", originalRecord.CaseNumber)
                cmd.Parameters.AddWithValue("@oldSummonLevel", originalRecord.SummonLevel)
                cmd.Parameters.AddWithValue("@oldCaseDate", originalRecord.CaseDate)
                cmd.Parameters.AddWithValue("@oldStartTime", originalRecord.StartTime)
                cmd.Parameters.AddWithValue("@oldEndTime", originalRecord.EndTime)

                Dim affected = cmd.ExecuteNonQuery()
                If affected = 0 Then
                    Throw New InvalidOperationException("The selected schedule could not be updated. It may have been removed by another user.")
                End If
            End Using
        End Using
    End Sub

    Private Sub DeleteSchedule(record As ScheduleRecord)
        Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
            conn.Open()
            Dim sql As String =
                "DELETE FROM tbl_blotter_schedule WHERE case_number = @caseNumber AND summon_level = @summonLevel AND case_date = @caseDate AND start_time = @startTime AND end_time = @endTime LIMIT 1"

            Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@caseNumber", record.CaseNumber)
                cmd.Parameters.AddWithValue("@summonLevel", record.SummonLevel)
                cmd.Parameters.AddWithValue("@caseDate", record.CaseDate)
                cmd.Parameters.AddWithValue("@startTime", record.StartTime)
                cmd.Parameters.AddWithValue("@endTime", record.EndTime)

                Dim affected = cmd.ExecuteNonQuery()
                If affected = 0 Then
                    Throw New InvalidOperationException("The selected schedule could not be deleted. It may have been removed already.")
                End If
            End Using
        End Using
    End Sub

    Private Function ReadTimeValue(reader As Global.MySql.Data.MySqlClient.MySqlDataReader, ordinal As Integer) As TimeSpan
        Dim fieldType = reader.GetFieldType(ordinal)
        If fieldType Is GetType(TimeSpan) Then
            Return reader.GetTimeSpan(ordinal)
        End If

        Return reader.GetDateTime(ordinal).TimeOfDay
    End Function

    Private Function FormatTime(value As TimeSpan) As String
        If value = TimeSpan.Zero Then
            Return String.Empty
        End If

        Return value.ToString("hh\:mm")
    End Function

    Private Function GetCurrentSettlementStatus(caseNumber As String) As String
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT settlement_status FROM tbl_blotter WHERE case_number = @caseNumber LIMIT 1"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@caseNumber", caseNumber)
                    Dim result = cmd.ExecuteScalar()
                    Return If(result Is Nothing OrElse result Is DBNull.Value, String.Empty, result.ToString())
                End Using
            End Using
        Catch ex As Global.MySql.Data.MySqlClient.MySqlException
            ' Column might not exist yet, fall back to empty
            Return String.Empty
        End Try
    End Function

    Private Sub UpdateSettlementStatus(caseNumber As String, newStatus As String)
        Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
            conn.Open()
            Dim sql As String = "UPDATE tbl_blotter SET settlement_status = @status WHERE case_number = @caseNumber LIMIT 1"
            Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@caseNumber", caseNumber)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ShowScheduleDatabaseError(action As String, ex As Global.MySql.Data.MySqlClient.MySqlException)
        MessageBox.Show($"Unable to {action}. Details: {ex.Message}", "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub LoadActionIcons()
        If editIcon IsNot Nothing Then Return

        editIcon = CreatePencilIcon()
        deleteIcon = CreateDeleteIcon()
        printIcon = CreatePrintIcon()
    End Sub

    Private Function CreateTextColumn(name As String, header As String) As DataGridViewTextBoxColumn
        Dim column As New DataGridViewTextBoxColumn()
        column.Name = name
        column.HeaderText = header
        column.SortMode = DataGridViewColumnSortMode.Programmatic
        Return column
    End Function

    Private Function CreateActionColumn(name As String, icon As Image, tooltip As String) As DataGridViewImageColumn
        Dim column As New DataGridViewImageColumn()
        column.Name = name
        column.HeaderText = ""
        column.Image = icon
        column.ImageLayout = DataGridViewImageCellLayout.Zoom
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        column.ToolTipText = tooltip
        column.SortMode = DataGridViewColumnSortMode.NotSortable
        column.ReadOnly = True
        Return column
    End Function

    Private Function CreatePencilIcon() As Image
        Dim size As Integer = 28
        Dim bmp As New Bitmap(size, size)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            Using bodyBrush As New SolidBrush(Color.FromArgb(30, 136, 229))
                Using pen As New Pen(bodyBrush, 6)
                    g.DrawLine(pen, 6, size - 8, size - 4, 6)
                End Using
                Using tipBrush As New SolidBrush(Color.FromArgb(255, 213, 79))
                    Dim tipPoints As Point() = {
                        New Point(size - 5, 5),
                        New Point(size - 1, 1),
                        New Point(size - 1, 9)
                    }
                    g.FillPolygon(tipBrush, tipPoints)
                End Using
            End Using
        End Using
        Return bmp
    End Function

    Private Function CreateDeleteIcon() As Image
        Dim size As Integer = 28
        Dim bmp As New Bitmap(size, size)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            Using brush As New SolidBrush(Color.FromArgb(227, 53, 55))
                g.FillEllipse(brush, 2, 2, size - 4, size - 4)
            End Using

            Using pen As New Pen(Color.White, 3)
                g.DrawLine(pen, 8, 8, size - 8, size - 8)
                g.DrawLine(pen, size - 8, 8, 8, size - 8)
            End Using
        End Using
        Return bmp
    End Function

    Private Function CreatePrintIcon() As Image
        Dim size As Integer = 28
        Dim bmp As New Bitmap(size, size)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)

            Using bodyBrush As New SolidBrush(Color.FromArgb(67, 195, 95))
                g.FillRectangle(bodyBrush, 4, 6, size - 8, size - 10)
                g.FillRectangle(bodyBrush, 7, size - 12, size - 14, 8)
            End Using

            Using paperBrush As New SolidBrush(Color.White)
                g.FillRectangle(paperBrush, 8, 10, size - 16, size - 18)
            End Using
        End Using
        Return bmp
    End Function

    Private Sub pnlBlotterButtons_Paint(sender As Object, e As PaintEventArgs) Handles pnlBlotterButtons.Paint

    End Sub

    Private Sub dgvBlotterRecords_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBlotterRecords.CellContentClick

    End Sub

    Private Sub pnlLeftTable_Paint(sender As Object, e As PaintEventArgs) Handles pnlLeftTable.Paint

    End Sub
End Class

Friend Class ScheduleRecord
    Public Property CaseNumber As String
    Public Property SummonLevel As String
    Public Property CaseDate As Date
    Public Property StartTime As TimeSpan
    Public Property EndTime As TimeSpan

    Public Function Clone() As ScheduleRecord
        Return CType(Me.MemberwiseClone(), ScheduleRecord)
    End Function
End Class

Friend Class ScheduleEditorDialog
    Inherits Form

    Private ReadOnly txtSummonLevel As TextBox
    Private ReadOnly dtpCaseDate As DateTimePicker
    Private ReadOnly dtpStartTime As DateTimePicker
    Private ReadOnly dtpEndTime As DateTimePicker
    Private ReadOnly btnSave As Button
    Private ReadOnly btnCancel As Button

    Private _scheduleData As ScheduleRecord

    Public ReadOnly Property ScheduleData As ScheduleRecord
        Get
            Return _scheduleData
        End Get
    End Property

    Public Sub New(Optional existing As ScheduleRecord = Nothing)
        Text = If(existing Is Nothing, "Add Schedule", "Edit Schedule")
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        StartPosition = FormStartPosition.CenterParent
        ClientSize = New Size(430, 300)
        BackColor = Color.White

        Dim layout As New TableLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 5,
            .Padding = New Padding(20),
            .AutoSize = False
        }

        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
        For i As Integer = 0 To 3
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 45.0F))
        Next
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 60.0F))

        txtSummonLevel = New TextBox() With {
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        }

        dtpCaseDate = New DateTimePicker() With {
            .Dock = DockStyle.Fill,
            .Format = DateTimePickerFormat.[Short],
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        }

        dtpStartTime = New DateTimePicker() With {
            .Dock = DockStyle.Fill,
            .Format = DateTimePickerFormat.Time,
            .ShowUpDown = True,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        }

        dtpEndTime = New DateTimePicker() With {
            .Dock = DockStyle.Fill,
            .Format = DateTimePickerFormat.Time,
            .ShowUpDown = True,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular)
        }

        btnSave = New Button() With {
            .Text = "Save",
            .Width = 90,
            .Height = 32,
            .BackColor = Color.FromArgb(0, 120, 215),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        btnSave.FlatAppearance.BorderSize = 0

        btnCancel = New Button() With {
            .Text = "Cancel",
            .Width = 90,
            .Height = 32,
            .BackColor = Color.Gainsboro,
            .ForeColor = Color.Black,
            .FlatStyle = FlatStyle.Flat,
            .DialogResult = DialogResult.Cancel
        }
        btnCancel.FlatAppearance.BorderSize = 0

        Dim buttonsPanel As New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.RightToLeft,
            .Padding = New Padding(0, 10, 0, 0)
        }
        buttonsPanel.Controls.Add(btnSave)
        buttonsPanel.Controls.Add(btnCancel)

        layout.Controls.Add(CreateFieldLabel("Summon Level"), 0, 0)
        layout.Controls.Add(txtSummonLevel, 1, 0)
        layout.Controls.Add(CreateFieldLabel("Case Date"), 0, 1)
        layout.Controls.Add(dtpCaseDate, 1, 1)
        layout.Controls.Add(CreateFieldLabel("Start Time"), 0, 2)
        layout.Controls.Add(dtpStartTime, 1, 2)
        layout.Controls.Add(CreateFieldLabel("End Time"), 0, 3)
        layout.Controls.Add(dtpEndTime, 1, 3)
        layout.Controls.Add(buttonsPanel, 0, 4)
        layout.SetColumnSpan(buttonsPanel, 2)

        Controls.Add(layout)

        Dim today As Date = Date.Today
        txtSummonLevel.Text = If(existing Is Nothing, String.Empty, existing.SummonLevel)
        dtpCaseDate.Value = If(existing IsNot Nothing AndAlso existing.CaseDate > Date.MinValue, existing.CaseDate, today)
        dtpStartTime.Value = today.Add(If(existing IsNot Nothing AndAlso existing.StartTime > TimeSpan.Zero, existing.StartTime, TimeSpan.FromHours(8)))
        dtpEndTime.Value = today.Add(If(existing IsNot Nothing AndAlso existing.EndTime > TimeSpan.Zero, existing.EndTime, TimeSpan.FromHours(9)))

        AddHandler btnSave.Click, AddressOf HandleSaveClick

        AcceptButton = btnSave
        CancelButton = btnCancel
    End Sub

    Private Function CreateFieldLabel(text As String) As Label
        Return New Label() With {
            .Text = text,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Regular)
        }
    End Function

    Private Sub HandleSaveClick(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtSummonLevel.Text) Then
            MessageBox.Show("Summon level is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSummonLevel.Focus()
            Return
        End If

        If dtpEndTime.Value.TimeOfDay <= dtpStartTime.Value.TimeOfDay Then
            MessageBox.Show("End time must be later than start time.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpEndTime.Focus()
            Return
        End If

        _scheduleData = New ScheduleRecord() With {
            .SummonLevel = txtSummonLevel.Text.Trim(),
            .CaseDate = dtpCaseDate.Value.Date,
            .StartTime = dtpStartTime.Value.TimeOfDay,
            .EndTime = dtpEndTime.Value.TimeOfDay
        }

        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class

Friend Class SettlementStatusDialog
    Inherits Form

    Private ReadOnly cmbStatus As ComboBox
    Private ReadOnly btnSave As Button
    Private ReadOnly btnCancel As Button

    Public ReadOnly Property SelectedStatus As String
        Get
            Return cmbStatus.Text.Trim()
        End Get
    End Property

    Public Sub New(currentStatus As String)
        Text = "Update Settlement Status"
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        StartPosition = FormStartPosition.CenterParent
        ClientSize = New Size(360, 180)
        BackColor = Color.White

        Dim lblPrompt As New Label() With {
            .Text = "Select the new settlement status:",
            .Dock = DockStyle.Top,
            .Height = 40,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("Segoe UI Semibold", 10.0F, FontStyle.Regular),
            .Padding = New Padding(20, 10, 20, 5)
        }

        cmbStatus = New ComboBox() With {
            .Dock = DockStyle.Top,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Regular),
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Margin = New Padding(20, 0, 20, 0)
        }
        cmbStatus.Items.AddRange(New Object() {"Pending", "For Mediation", "Under Hearing", "Settled", "Dismissed", "For Follow-up"})
        Dim selectedIndex As Integer = -1
        If Not String.IsNullOrWhiteSpace(currentStatus) Then
            For i As Integer = 0 To cmbStatus.Items.Count - 1
                If String.Equals(cmbStatus.Items(i).ToString(), currentStatus, StringComparison.OrdinalIgnoreCase) Then
                    selectedIndex = i
                    Exit For
                End If
            Next
        End If
        cmbStatus.SelectedIndex = If(selectedIndex >= 0, selectedIndex, 0)

        btnSave = New Button() With {
            .Text = "Save",
            .Width = 90,
            .Height = 32,
            .BackColor = Color.FromArgb(0, 120, 215),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        btnSave.FlatAppearance.BorderSize = 0

        btnCancel = New Button() With {
            .Text = "Cancel",
            .Width = 90,
            .Height = 32,
            .BackColor = Color.Gainsboro,
            .ForeColor = Color.Black,
            .FlatStyle = FlatStyle.Flat,
            .DialogResult = DialogResult.Cancel
        }
        btnCancel.FlatAppearance.BorderSize = 0

        Dim buttonsPanel As New FlowLayoutPanel() With {
            .Dock = DockStyle.Bottom,
            .Height = 60,
            .FlowDirection = FlowDirection.RightToLeft,
            .Padding = New Padding(0, 10, 20, 10)
        }
        buttonsPanel.Controls.Add(btnSave)
        buttonsPanel.Controls.Add(btnCancel)

        Controls.Add(buttonsPanel)
        Controls.Add(cmbStatus)
        Controls.Add(lblPrompt)

        AddHandler btnSave.Click, AddressOf HandleSave

        AcceptButton = btnSave
        CancelButton = btnCancel
    End Sub

    Private Sub HandleSave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(cmbStatus.Text) Then
            MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return
        End If

        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class