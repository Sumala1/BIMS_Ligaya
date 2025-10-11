Public Class CertBrgyClearance
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub CertBrgyClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Subscribe to shared data changes
        Try
            AddHandler SharedCertificateData.DataChanged, AddressOf OnSharedDataChanged
        Catch ex As Exception
            MessageBox.Show("Error subscribing to SharedCertificateData: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CertBrgyClearance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Unsubscribe from shared data changes
        RemoveHandler SharedCertificateData.DataChanged, AddressOf OnSharedDataChanged
    End Sub

    Private Sub OnSharedDataChanged(sender As Object, e As EventArgs)
        ' Update the textboxes with shared data
        UpdateTextboxes()
    End Sub

    Private Sub UpdateTextboxes()
        ' Update each textbox with the corresponding shared data
        Try
            Guna2TxtFullname.Text = SharedCertificateData.FullName
            Guna2TxtAddress.Text = SharedCertificateData.Address
            Guna2Txtpurpose.Text = SharedCertificateData.Purpose
            Guna2Txtissued.Text = SharedCertificateData.IssuedDate
        Catch ex As Exception
            MessageBox.Show("Error updating textboxes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2TxtFullname_TextChanged(sender As Object, e As EventArgs) Handles Guna2TxtFullname.TextChanged
        ' This textbox is read-only for display purposes
        ' Data comes from SharedCertificateData
    End Sub

    Private Sub Guna2TxtAddress_TextChanged(sender As Object, e As EventArgs) Handles Guna2TxtAddress.TextChanged
        ' This textbox is read-only for display purposes
        ' Data comes from SharedCertificateData
    End Sub

    Private Sub Guna2Txtissued_TextChanged(sender As Object, e As EventArgs) Handles Guna2Txtissued.TextChanged
        ' This textbox is read-only for display purposes
        ' Data comes from SharedCertificateData
    End Sub

    Private Sub Guna2Txtpurpose_TextChanged(sender As Object, e As EventArgs) Handles Guna2Txtpurpose.TextChanged
        ' This textbox is read-only for display purposes
        ' Data comes from SharedCertificateData
    End Sub
End Class