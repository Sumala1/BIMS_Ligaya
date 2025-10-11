Public Class certificateform
    Private Sub certificateform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the form
        cmbCertificateType.SelectedIndex = 0
        
        ' Test data synchronization (you can remove this after testing)
        ' Uncomment the line below to test if real-time sync is working
        ' SharedCertificateData.TestDataSync()
    End Sub

    Private Sub certificateform_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Clean up persistent forms when main form is closed
        CertificateFormManager.DisposeAllForms()
    End Sub

    ' Database methods
    Private Function ValidateFormData() As Boolean
        ' Check if all required fields are filled
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse txtName.Text = "Full Name" Then
            MessageBox.Show("Please enter the full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAge.Text) OrElse txtAge.Text = "Age" OrElse Not IsNumeric(txtAge.Text) Then
            MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAge.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAddress.Text) OrElse txtAddress.Text = "Address" Then
            MessageBox.Show("Please enter the address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPurpose.Text) OrElse txtPurpose.Text = "Purpose/Application" Then
            MessageBox.Show("Please enter the purpose.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurpose.Focus()
            Return False
        End If

        If cmbCertificateType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a certificate type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCertificateType.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function GetStatus() As String
        If rbSingle.Checked Then
            Return "Single"
        ElseIf rbMarried.Checked Then
            Return "Married"
        Else
            Return "Single" ' Default
        End If
    End Function

    Private Function SaveCertificateToDatabase() As Boolean
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                Dim sql As String = "INSERT INTO tbl_certificate (certificate, fullname, age, status, address, purpose, issuedon) VALUES (@certificate, @fullname, @age, @status, @address, @purpose, @issuedon)"

                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@certificate", cmbCertificateType.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@fullname", txtName.Text.Trim())
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text))
                    cmd.Parameters.AddWithValue("@status", GetStatus())
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@purpose", txtPurpose.Text.Trim())
                    cmd.Parameters.AddWithValue("@issuedon", dtpIssuedDate.Value)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving certificate to database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub ClearForm()
        ' Clear all form fields
        txtName.Text = "Full Name"
        txtName.ForeColor = Color.Silver

        txtAge.Text = "Age"
        txtAge.ForeColor = Color.Silver

        txtAddress.Text = "Address"
        txtAddress.ForeColor = Color.Silver

        txtPurpose.Text = "Purpose/Application"
        txtPurpose.ForeColor = Color.Silver

        cmbCertificateType.SelectedIndex = 0
        rbSingle.Checked = True
        dtpIssuedDate.Value = DateTime.Now

        ' Clear the picture panel
        pnlPic.Controls.Clear()
        
        ' Clear shared data
        SharedCertificateData.ClearData()
    End Sub

    Private Sub btnPageSetup_Click(sender As Object, e As EventArgs) Handles btnPageSetup.Click
        ' Show page setup dialog
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        ' Show print preview dialog
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Validate form data first
        If Not ValidateFormData() Then
            Return
        End If

        ' Save data to database
        If SaveCertificateToDatabase() Then
            MessageBox.Show("Certificate data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Show print dialog and print
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                PrintDocument1.Print()

                ' Ask if user wants to clear the form for next entry
                Dim result As DialogResult = MessageBox.Show("Certificate printed successfully! Would you like to clear the form for the next entry?",
                                                           "Print Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    ClearForm()
                End If
            End If
        Else
            MessageBox.Show("Failed to save certificate data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub PrintPreviewControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub panelRight_Paint(sender As Object, e As PaintEventArgs) Handles panelRight.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub pnlPic_Paint(sender As Object, e As PaintEventArgs) Handles pnlPic.Paint

    End Sub

    Private Sub cmbCertificateType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCertificateType.SelectedIndexChanged
        pnlPic.Controls.Clear()
        Dim selected As String = If(cmbCertificateType.SelectedItem, "").ToString()

        Dim sourceForm As Form = Nothing
        Try
            If selected = "Residency" Then
                sourceForm = CertificateFormManager.GetResidencyForm()
            ElseIf selected = "Indigency" Then
                sourceForm = CertificateFormManager.GetIndigencyForm()
            ElseIf selected = "Barangay Clearance" Then
                sourceForm = CertificateFormManager.GetBrgyClearanceForm()
            End If

            If sourceForm Is Nothing Then Return

            Dim sourcePanel As Panel = Nothing
            ' Prefer a Panel1 container when present
            For Each ctrl As Control In sourceForm.Controls
                If TypeOf ctrl Is Panel AndAlso String.Equals(ctrl.Name, "Panel1", StringComparison.OrdinalIgnoreCase) Then
                    sourcePanel = DirectCast(ctrl, Panel)
                    Exit For
                End If
            Next

            Dim container As Control = If(sourcePanel IsNot Nothing, DirectCast(sourcePanel, Control), DirectCast(sourceForm, Control))

            ' Copy all PictureBoxes from the container to pnlPic
            For Each ctrl As Control In container.Controls
                If TypeOf ctrl Is PictureBox Then
                    Dim src As PictureBox = DirectCast(ctrl, PictureBox)
                    Dim pb As New PictureBox()
                    pb.Image = src.Image
                    pb.SizeMode = src.SizeMode
                    pb.Location = src.Location
                    pb.Size = src.Size
                    pb.Anchor = src.Anchor
                    pb.Dock = DockStyle.None
                    pb.BackColor = src.BackColor
                    pb.Margin = src.Margin
                    pnlPic.Controls.Add(pb)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading certificate form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub panelRightHeader_Paint(sender As Object, e As PaintEventArgs) Handles panelRightHeader.Paint

    End Sub

    ' Text box event handlers for better user experience
    Private Sub txtName_Enter(sender As Object, e As EventArgs) Handles txtName.Enter
        If txtName.Text = "Full Name" Then
            txtName.Text = ""
            txtName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            txtName.Text = "Full Name"
            txtName.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        ' Update shared data in real-time
        If txtName.Text <> "Full Name" AndAlso Not String.IsNullOrWhiteSpace(txtName.Text) Then
            SharedCertificateData.FullName = txtName.Text
        End If
    End Sub

    Private Sub txtAge_Enter(sender As Object, e As EventArgs) Handles txtAge.Enter
        If txtAge.Text = "Age" Then
            txtAge.Text = ""
            txtAge.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtAge_Leave(sender As Object, e As EventArgs) Handles txtAge.Leave
        If String.IsNullOrWhiteSpace(txtAge.Text) Then
            txtAge.Text = "Age"
            txtAge.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtAddress_Enter(sender As Object, e As EventArgs) Handles txtAddress.Enter
        If txtAddress.Text = "Address" Then
            txtAddress.Text = ""
            txtAddress.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress.Leave
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            txtAddress.Text = "Address"
            txtAddress.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        ' Update shared data in real-time
        If txtAddress.Text <> "Address" AndAlso Not String.IsNullOrWhiteSpace(txtAddress.Text) Then
            SharedCertificateData.Address = txtAddress.Text
        End If
    End Sub

    Private Sub txtPurpose_Enter(sender As Object, e As EventArgs) Handles txtPurpose.Enter
        If txtPurpose.Text = "Purpose/Application" Then
            txtPurpose.Text = ""
            txtPurpose.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPurpose_Leave(sender As Object, e As EventArgs) Handles txtPurpose.Leave
        If String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            txtPurpose.Text = "Purpose/Application"
            txtPurpose.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtPurpose_TextChanged(sender As Object, e As EventArgs) Handles txtPurpose.TextChanged
        ' Update shared data in real-time
        If txtPurpose.Text <> "Purpose/Application" AndAlso Not String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            SharedCertificateData.Purpose = txtPurpose.Text
        End If
    End Sub

    Private Sub dtpIssuedDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpIssuedDate.ValueChanged
        ' Update shared data in real-time
        SharedCertificateData.IssuedDate = dtpIssuedDate.Value.ToString("MMM dd, yyyy")
    End Sub


End Class