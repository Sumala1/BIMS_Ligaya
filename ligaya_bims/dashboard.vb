' Removed Imports MySql.Data.MySqlClient - using fully qualified names to avoid conflicts

Public Class dashboard
    Private currentChildForm As Form
    Private residentsList As New List(Of ResidentData)

    Private Sub OpenChildForm(child As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
            currentChildForm.Dispose()
            currentChildForm = Nothing
        End If

        currentChildForm = child
        child.TopLevel = False
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill
        contentHost.Controls.Clear()
        contentHost.Controls.Add(child)
        child.Show()
        child.BringToFront()
    End Sub
    Private Sub topBar_Paint(sender As Object, e As PaintEventArgs) Handles topBar.Paint

    End Sub

    Private Sub navResidents_Click(sender As Object, e As EventArgs) Handles navResidents.Click
        Dim residentForm As New residentinfo()
        residentForm.SetAsChildForm()
        OpenChildForm(residentForm)
    End Sub

    Private Sub navReports_Click(sender As Object, e As EventArgs) Handles navReports.Click
        Dim blotterform As New blotterrecords()
        blotterform.SetAsChildForm()
        OpenChildForm(blotterform)
    End Sub

    Private Sub navDashboard_Click(sender As Object, e As EventArgs) Handles navDashboard.Click
        ' Close any child and bring back the dashboard layout
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
            currentChildForm.Dispose()
            currentChildForm = Nothing
        End If

        ' Restore dashboard layout
        RestoreDashboardControls()

        ' Bring all dashboard panels to front
        panelResidents.BringToFront()
        panelBlotter.BringToFront()
        panelCertificates.BringToFront()
        panelOfficials.BringToFront()
        Panel1.BringToFront()
        Panel2.BringToFront()
        Panel3.BringToFront()
        Panel4.BringToFront()
        panelLeft.BringToFront()
        panelRight.BringToFront()
    End Sub

    Private Sub navDocs_Click(sender As Object, e As EventArgs) Handles navDocs.Click
        Dim docsForm As New certissuance()
        docsForm.SetAsChildForm()
        OpenChildForm(docsForm)
    End Sub

    Private Sub RestoreDashboardControls()
        ' Clear any child forms
        contentHost.Controls.Clear()

        ' Add the TableLayoutPanel back which contains all dashboard panels
        contentHost.Controls.Add(TableLayoutPanel1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.BringToFront()

        ' Reload dashboard data
        LoadDashboardData()
    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboardData()
        ' Remove or hide selection checkbox column from dashboard grid
        Try
            If dgvDashboardResidents IsNot Nothing AndAlso dgvDashboardResidents.Columns.Contains("chkSelectAllDashboard") Then
                dgvDashboardResidents.Columns("chkSelectAllDashboard").Visible = False
            End If
        Catch ex As Exception
            ' Ignore if grid not yet initialized
        End Try
    End Sub

    Private Sub LoadDashboardData()
        LoadResidentsData()
        LoadStatistics()
        LoadPurokPopulationChart()
        LoadDemographicsChart()
    End Sub

    Private Sub LoadStatistics()
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Get Total Residents count
                Dim sqlTotalResidents As String = "SELECT COUNT(*) FROM tbl_residentinfo"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sqlTotalResidents, conn)
                    Dim totalResidents = CInt(cmd.ExecuteScalar())
                    lblResidentsCount.Text = totalResidents.ToString()
                End Using

                ' Get Active Voters count (voterstatus = 'Active')
                Dim sqlActiveVoters As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE voterstatus = 'Active'"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sqlActiveVoters, conn)
                    Dim activeVoters = Convert.ToInt32(cmd.ExecuteScalar())
                    Label6.Text = activeVoters.ToString()
                End Using

                ' Get Senior Citizens count (age >= 60)
                Dim sqlSeniorCitizens As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE age >= 60"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sqlSeniorCitizens, conn)
                    Dim seniorCitizens = CInt(cmd.ExecuteScalar())
                    Label12.Text = seniorCitizens.ToString()
                End Using

                ' Get PWDs count - try to find them in the database
                Dim sqlPWDs As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE pwdstatus = 'Yes' OR pwd = 'Yes' OR disability = 'Yes'"
                Dim pwdCount As Integer = 0
                Try
                    Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sqlPWDs, conn)
                        Dim pwdResult = cmd.ExecuteScalar()
                        If pwdResult IsNot Nothing AndAlso Not IsDBNull(pwdResult) Then
                            pwdCount = Convert.ToInt32(pwdResult)
                        End If
                    End Using
                Catch
                    ' If PWD query fails, set to 0
                    pwdCount = 0
                End Try

                ' Update PWDs panel label (Label9)
                If Label9 IsNot Nothing Then
                    Label9.Text = pwdCount.ToString()
                End If

            End Using
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Failed to load statistics: " & ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadResidentsData()
        residentsList.Clear()
        dgvDashboardResidents.Rows.Clear()

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim sql As String = "SELECT lastname, firstname, middlename, phoneno, gender FROM tbl_residentinfo ORDER BY lastname, firstname DESC LIMIT 10"
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

                            Dim rowIndex = dgvDashboardResidents.Rows.Add()
                            dgvDashboardResidents.Rows(rowIndex).Cells("chkSelectAllDashboard").Value = False
                            dgvDashboardResidents.Rows(rowIndex).Cells("colLastNameDashboard").Value = data.LastName
                            dgvDashboardResidents.Rows(rowIndex).Cells("colFirstNameDashboard").Value = data.FirstName
                            dgvDashboardResidents.Rows(rowIndex).Cells("colMiddleNameDashboard").Value = data.MiddleName
                            dgvDashboardResidents.Rows(rowIndex).Cells("colMobileNoDashboard").Value = data.MobileNo
                            dgvDashboardResidents.Rows(rowIndex).Cells("colGenderDashboard").Value = data.Gender
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Failed to load residents: " & ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPurokPopulationChart()
        Try
            chartPurokPopulation.Series.Clear()
            chartPurokPopulation.ChartAreas.Clear()

            ' Add chart area
            Dim chartArea As New DataVisualization.Charting.ChartArea()
            chartArea.Name = "PurokPopulationArea"
            chartArea.AxisX.Title = "Purok"
            chartArea.AxisY.Title = "Population"
            chartArea.AxisX.MajorGrid.Enabled = False
            chartArea.AxisY.MajorGrid.Enabled = True
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray
            chartPurokPopulation.ChartAreas.Add(chartArea)

            ' Add series
            Dim series As New DataVisualization.Charting.Series()
            series.Name = "PurokPopulation"
            series.ChartType = DataVisualization.Charting.SeriesChartType.Column
            series.Color = Color.FromArgb(27, 94, 32)
            chartPurokPopulation.Series.Add(series)

            ' Query database for purok population
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Build category list: Purok 1-7 + Agan Ligaya
                Dim categories As New List(Of String)()
                For i As Integer = 1 To 7
                    categories.Add("Purok " & i.ToString())
                Next
                categories.Add("Agan Ligaya")


                ' Count residents per category by matching the address field
                For Each category As String In categories
                    Dim sql As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE address LIKE @category"
                    Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@category", "%" & category & "%")
                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        series.Points.AddXY(category, count)
                    End Using
                Next
            End Using

            ' Update chart labels
            chartPurokPopulation.ChartAreas(0).AxisX.Title = "Purok / Areas"
            chartPurokPopulation.Series(0).Name = "PopulationByArea"

            ' Configure chart appearance
            chartPurokPopulation.BackColor = Color.White
            chartPurokPopulation.ChartAreas(0).BackColor = Color.Transparent
            chartPurokPopulation.Legends.Clear()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Failed to load purok population chart: " & ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDemographicsChart()
        Try
            chartDemographics.Series.Clear()
            chartDemographics.ChartAreas.Clear()
            chartDemographics.Legends.Clear()

            ' Add chart area
            Dim chartArea As New DataVisualization.Charting.ChartArea()
            chartArea.Name = "DemographicsArea"
            chartDemographics.ChartAreas.Add(chartArea)

            ' Add legend
            Dim legend As New DataVisualization.Charting.Legend()
            legend.Name = "DemographicsLegend"
            legend.Alignment = System.Drawing.StringAlignment.Near
            legend.Docking = DataVisualization.Charting.Docking.Bottom
            legend.IsDockedInsideChartArea = False
            legend.BackColor = Color.Transparent
            chartDemographics.Legends.Add(legend)

            ' Add series for Pie Chart
            Dim seniorsSeries As New DataVisualization.Charting.Series()
            seniorsSeries.Name = "Demographics"
            seniorsSeries.ChartType = DataVisualization.Charting.SeriesChartType.Pie
            seniorsSeries("PieLabelStyle") = "Disabled"
            chartDemographics.Series.Add(seniorsSeries)

            ' Query database for statistics
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Get senior citizens (age >= 60)
                Dim sqlSeniors As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE age >= 60"
                Dim seniorCount As Integer = 0
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sqlSeniors, conn)
                    Dim seniorResult = cmd.ExecuteScalar()
                    If seniorResult IsNot Nothing AndAlso Not IsDBNull(seniorResult) Then
                        seniorCount = Convert.ToInt32(seniorResult)
                    End If
                End Using

                ' Get PWDs - try to find them in the database
                ' Note: This is a placeholder. You may need to adjust the query based on your actual database structure
                Dim sqlPWDs As String = "SELECT COUNT(*) FROM tbl_residentinfo WHERE pwdstatus = 'Yes' OR pwd = 'Yes' OR disability = 'Yes'"
                Dim pwdCount As Integer = 0
                Try
                    Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sqlPWDs, conn)
                        Dim pwdResult = cmd.ExecuteScalar()
                        If pwdResult IsNot Nothing AndAlso Not IsDBNull(pwdResult) Then
                            pwdCount = Convert.ToInt32(pwdResult)
                        End If
                    End Using
                Catch
                    ' If PWD query fails, set to 0
                    pwdCount = 0
                End Try

                ' Add data points for pie chart
                If seniorCount > 0 Then
                    Dim seniorPoint As New DataVisualization.Charting.DataPoint()
                    seniorPoint.SetValueXY("Senior Citizens", seniorCount)
                    seniorPoint.Color = Color.FromArgb(76, 175, 80) ' Green color
                    seniorsSeries.Points.Add(seniorPoint)
                End If

                If pwdCount > 0 Then
                    Dim pwdPoint As New DataVisualization.Charting.DataPoint()
                    pwdPoint.SetValueXY("PWDs", pwdCount)
                    pwdPoint.Color = Color.FromArgb(100, 102, 204) ' Purple color
                    seniorsSeries.Points.Add(pwdPoint)
                End If

                ' If no data, show placeholder
                If seniorCount = 0 AndAlso pwdCount = 0 Then
                    Dim placeholderPoint As New DataVisualization.Charting.DataPoint()
                    placeholderPoint.SetValueXY("No Data", 1)
                    placeholderPoint.Color = Color.LightGray
                    seniorsSeries.Points.Add(placeholderPoint)
                End If
            End Using

            ' Configure chart appearance
            chartDemographics.BackColor = Color.White
            chartDemographics.ChartAreas(0).BackColor = Color.Transparent
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Failed to load demographics chart: " & ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub navCedula_Click(sender As Object, e As EventArgs) Handles navCedula.Click
        OpenChildForm(New cedulatracker())
    End Sub

    Private Sub leftNav_Paint(sender As Object, e As PaintEventArgs) Handles leftNav.Paint

    End Sub

    ' Panel click event handlers for navigation





    ' New panel click event handlers
    Private Sub panelResidents_Click(sender As Object, e As EventArgs)
        OpenChildForm(New residentinfo())
    End Sub

    Private Sub panelBlotter_Click(sender As Object, e As EventArgs)
        OpenChildForm(New reportsform())
    End Sub

    Private Sub panelCertificates_Click(sender As Object, e As EventArgs)
        OpenChildForm(New certissuance())
    End Sub

    Private Sub panelOfficials_Click(sender As Object, e As EventArgs)
        OpenChildForm(New reportsform())
    End Sub

    ' Mouse hover effects for better UX
    Private Sub panelResidents_MouseEnter(sender As Object, e As EventArgs)
        panelResidents.BackColor = Color.FromArgb(0, 150, 170) ' Darker teal
    End Sub

    Private Sub panelResidents_MouseLeave(sender As Object, e As EventArgs)
        panelResidents.BackColor = Color.FromArgb(0, 188, 212) ' Original teal
    End Sub

    Private Sub panelBlotter_MouseEnter(sender As Object, e As EventArgs)
        panelBlotter.BackColor = Color.FromArgb(56, 142, 60) ' Darker green
    End Sub

    Private Sub panelBlotter_MouseLeave(sender As Object, e As EventArgs)
        panelBlotter.BackColor = Color.FromArgb(76, 175, 80) ' Original green
    End Sub

    Private Sub panelCertificates_MouseEnter(sender As Object, e As EventArgs)
        panelCertificates.BackColor = Color.FromArgb(245, 127, 23) ' Darker yellow
    End Sub

    Private Sub panelCertificates_MouseLeave(sender As Object, e As EventArgs)
        panelCertificates.BackColor = Color.FromArgb(255, 193, 7) ' Original yellow
    End Sub

    Private Sub panelOfficials_MouseEnter(sender As Object, e As EventArgs)
        panelOfficials.BackColor = Color.FromArgb(198, 40, 40) ' Darker red
    End Sub

    Private Sub panelOfficials_MouseLeave(sender As Object, e As EventArgs)
        panelOfficials.BackColor = Color.FromArgb(244, 67, 54) ' Original red
    End Sub

    Private Sub navBackup_Click(sender As Object, e As EventArgs) Handles navBackup.Click
        Dim backupForm As New BackupRestore()
        backupForm.SetAsChildForm()
        OpenChildForm(backupForm)
    End Sub

    ' Clean up resources when form closes
    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        Try
            ' Ensure all resources are properly disposed
            If dgvDashboardResidents IsNot Nothing Then
                dgvDashboardResidents.Dispose()
            End If
            If chartPurokPopulation IsNot Nothing Then
                chartPurokPopulation.Dispose()
            End If
            If chartDemographics IsNot Nothing Then
                chartDemographics.Dispose()
            End If
        Catch ex As Exception
            ' Log error if needed
        End Try
        MyBase.OnFormClosed(e)
    End Sub

    Private Sub panelLegend1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub chartPurokPopulation_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub navLogout_Click(sender As Object, e As EventArgs) Handles navLogout.Click
        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            ' Close any child forms
            If currentChildForm IsNot Nothing Then
                currentChildForm.Close()
                currentChildForm.Dispose()
                currentChildForm = Nothing
            End If

            ' Show login form (Form1)
            Dim loginForm As New Form1()
            loginForm.Show()

            ' Close and dispose the dashboard
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub chartPurokPopulation_Click_1(sender As Object, e As EventArgs) Handles chartPurokPopulation.Click

    End Sub
End Class