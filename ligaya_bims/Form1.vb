'Imports MySql.Data.MySqlClient

Public Class Form1
    ' Cache for processed logo image (with white background removed)
    Private processedLogoImage As Image = Nothing
    ' Store original image separately to prevent default rendering
    Private originalLogoImage As Image = Nothing

    Private Sub txtUsername_Enter(sender As Object, e As EventArgs) Handles txtUsername.Enter
        If txtUsername.Text = "Enter your username" And txtUsername.ForeColor = Color.Gray Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            SetPlaceholder(txtUsername, "Enter your username")
        End If
    End Sub

    Private Sub leftPanel_Paint(sender As Object, e As PaintEventArgs) Handles leftPanel.Paint

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Basic input validation
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()

                ' Query to get user information with role
                ' Uses tbl_login (existing table) and tbl_roles tables with password hashing
                Dim query As String = "SELECT l.id AS UserID, l.username AS Username, l.password AS PasswordHash, l.FullName, r.RoleID, r.RoleName, l.IsActive " &
                                      "FROM tbl_login l " &
                                      "INNER JOIN tbl_roles r ON l.RoleID = r.RoleID " &
                                      "WHERE l.username = @username AND l.IsActive = 1"

                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As Global.MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Get user information
                            Dim userID As Integer = reader.GetInt32("UserID")
                            Dim storedHash As String = reader.GetString("PasswordHash")
                            Dim fullName As String = If(Not reader.IsDBNull(reader.GetOrdinal("FullName")), reader.GetString("FullName"), username)
                            Dim roleID As Integer = reader.GetInt32("RoleID")
                            Dim roleName As String = reader.GetString("RoleName")

                            ' Verify password
                            If PasswordHelper.VerifyPassword(password, storedHash) Then
                                ' Password matches - initialize session
                                UserSession.InitializeSession(userID, username, roleName, roleID, fullName)

                                ' Handle Remember Me preference
                                If chkRemember.Checked Then
                                    My.Settings.RememberMe = True
                                    My.Settings.SavedUsername = username
                                Else
                                    My.Settings.RememberMe = False
                                    My.Settings.SavedUsername = String.Empty
                                End If
                                My.Settings.Save()

                                ' Show welcome message with role
                                Dim welcomeMsg As String = $"Login successful! Welcome {fullName} ({roleName})!"
                                MessageBox.Show(welcomeMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                ' Open dashboard
                                Dim dashboardForm As New dashboard()
                                dashboardForm.Show()
                                Me.Hide()
                            Else
                                ' Password doesn't match
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            ' User not found or inactive
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
    '    Dim username As String = txtUsername.Text.Trim()
    '    Dim password As String = txtPassword.Text.Trim()

    '    If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
    '        MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    Try
    '        Using conn As MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
    '            conn.Open()
    '            Dim query As String = "SELECT COUNT(*) FROM tbl_login WHERE username=@u AND password=@p"
    '            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
    '                cmd.Parameters.AddWithValue("@u", username)
    '                cmd.Parameters.AddWithValue("@p", password)
    '                Dim result As Object = cmd.ExecuteScalar()
    '                Dim count As Integer = If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)

    '                ' Debug information
    '                Dim debugMsg As String = $"Debug Info:" & vbCrLf &
    '                                       $"Username: '{username}'" & vbCrLf &
    '                                       $"Password: '{password}'" & vbCrLf &
    '                                       $"Query Result: {count}" & vbCrLf &
    '                                       $"Database Connected: {conn.State.ToString()}"

    '                If count > 0 Then
    '                    MessageBox.Show("Login successful! Welcome " & username & "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Dim dashboardForm As New dashboard()
    '                    dashboardForm.Show()
    '                    Me.Hide()
    '                Else
    '                    MessageBox.Show("Invalid username or password." & vbCrLf & vbCrLf & debugMsg, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End If
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load remembered username if enabled
        If My.Settings.RememberMe AndAlso Not String.IsNullOrWhiteSpace(My.Settings.SavedUsername) Then
            txtUsername.Text = My.Settings.SavedUsername
            txtUsername.ForeColor = Color.Black
            chkRemember.Checked = True
        Else
            ' Username placeholder
            txtUsername.Text = "Enter your username"
            txtUsername.ForeColor = Color.Gray
            chkRemember.Checked = False
        End If

        ' Password placeholder - NO PasswordChar initially
        txtPassword.Text = "Enter your password"
        txtPassword.ForeColor = Color.Gray
        txtPassword.PasswordChar = "" ' Keep empty initially!

        ' Make logo circular - don't remove white background (white ring with text is part of design)
        If picLogo.Image IsNot Nothing Then
            ' Store original image and clear PictureBox image to prevent default rendering
            originalLogoImage = picLogo.Image
            ' Use original image directly - don't remove white background
            processedLogoImage = originalLogoImage
            ' Clear the Image property so only our custom paint draws it
            picLogo.Image = Nothing
        End If
        MakePictureBoxCircular(picLogo)
    End Sub

    ''' <summary>
    ''' Makes a PictureBox display as a circle and removes white background
    ''' </summary>
    Private Sub MakePictureBoxCircular(pb As PictureBox)
        If pb Is Nothing Then Return

        ' Set the region to a circle
        Dim diameter As Integer = Math.Min(pb.Width, pb.Height)
        Dim radius As Integer = diameter \ 2
        Dim centerX As Integer = pb.Width \ 2
        Dim centerY As Integer = pb.Height \ 2

        Using path As New System.Drawing.Drawing2D.GraphicsPath()
            path.AddEllipse(centerX - radius, centerY - radius, diameter, diameter)
            pb.Region = New Region(path)
        End Using

        ' Set background to transparent
        pb.BackColor = Color.Transparent

        ' Add Paint event to handle custom drawing
        AddHandler pb.Paint, AddressOf PictureBox_Paint
    End Sub

    ''' <summary>
    ''' Paint event handler to draw image with enhanced quality rendering
    ''' </summary>
    Private Sub PictureBox_Paint(sender As Object, e As PaintEventArgs)
        Dim pb As PictureBox = TryCast(sender, PictureBox)
        If pb Is Nothing Then Return

        ' Only draw if we have a processed image
        Dim processedImage As Image = Nothing
        If pb Is picLogo AndAlso processedLogoImage IsNot Nothing Then
            processedImage = processedLogoImage
        Else
            Return ' No image to draw
        End If

        If processedImage Is Nothing Then Return

        ' Enable highest quality rendering to reduce pixelation
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
        e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver

        ' Create a circular clipping region
        Dim diameter As Integer = Math.Min(pb.Width, pb.Height)
        Dim radius As Integer = diameter \ 2
        Dim centerX As Integer = pb.Width \ 2
        Dim centerY As Integer = pb.Height \ 2

        Using path As New System.Drawing.Drawing2D.GraphicsPath()
            path.AddEllipse(centerX - radius, centerY - radius, diameter, diameter)
            e.Graphics.SetClip(path)

            ' Calculate image rectangle to maintain aspect ratio and fill the circle
            Dim imgWidth As Integer = processedImage.Width
            Dim imgHeight As Integer = processedImage.Height
            Dim imgAspect As Double = imgWidth / imgHeight
            Dim pbAspect As Double = pb.Width / pb.Height

            Dim drawWidth, drawHeight, drawX, drawY As Integer

            ' Use the diameter to ensure the image fills the circle properly
            If imgAspect > pbAspect Then
                ' Image is wider - fit to height (diameter)
                drawHeight = diameter
                drawWidth = CInt(drawHeight * imgAspect)
                drawX = (pb.Width - drawWidth) \ 2
                drawY = (pb.Height - drawHeight) \ 2
            Else
                ' Image is taller - fit to width (diameter)
                drawWidth = diameter
                drawHeight = CInt(drawWidth / imgAspect)
                drawX = (pb.Width - drawWidth) \ 2
                drawY = (pb.Height - drawHeight) \ 2
            End If

            ' Create a high-quality image attribute for better rendering
            Using imgAttributes As New System.Drawing.Imaging.ImageAttributes()
                ' Use high-quality resampling
                imgAttributes.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY)
                
                ' Draw the image with enhanced quality
                e.Graphics.DrawImage(
                    processedImage,
                    New Rectangle(drawX, drawY, drawWidth, drawHeight),
                    0, 0, processedImage.Width, processedImage.Height,
                    GraphicsUnit.Pixel,
                    imgAttributes
                )
            End Using

            ' Reset clip
            e.Graphics.ResetClip()
        End Using
    End Sub

    ''' <summary>
    ''' Removes white background from an image by making white pixels transparent
    ''' </summary>
    Private Function RemoveWhiteBackground(originalImage As Image) As Image
        If originalImage Is Nothing Then Return Nothing

        Dim bitmap As New Bitmap(originalImage.Width, originalImage.Height)
        Using g As Graphics = Graphics.FromImage(bitmap)
            g.DrawImage(originalImage, 0, 0)
        End Using

        ' Make white pixels transparent
        bitmap.MakeTransparent(Color.White)

        ' Also handle near-white pixels (with tolerance)
        For x As Integer = 0 To bitmap.Width - 1
            For y As Integer = 0 To bitmap.Height - 1
                Dim pixel As Color = bitmap.GetPixel(x, y)
                ' Check if pixel is white or near-white (tolerance of 30)
                If pixel.R > 225 AndAlso pixel.G > 225 AndAlso pixel.B > 225 Then
                    bitmap.SetPixel(x, y, Color.Transparent)
                End If
            Next
        Next

        Return bitmap
    End Function
    Private Sub SetPlaceholder(txt As TextBox, placeholder As String)
        txt.Text = placeholder
        txt.ForeColor = Color.Gray
    End Sub


    Private Sub rightPanel_Paint(sender As Object, e As PaintEventArgs) Handles rightPanel.Paint

    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        If txtPassword.Text = "Enter your password" And txtPassword.ForeColor = Color.Gray Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "•"
        End If
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            txtPassword.PasswordChar = ""
            SetPlaceholder(txtPassword, "Enter your password")
        End If
    End Sub
End Class
