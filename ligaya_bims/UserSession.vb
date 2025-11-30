Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Global session management class for storing current user information
''' This class maintains the logged-in user's role and information throughout the application
''' </summary>
Public Module UserSession
    ' Current user information
    Private _currentUserID As Integer = 0
    Private _currentUsername As String = String.Empty
    Private _currentRoleName As String = String.Empty
    Private _currentRoleID As Integer = 0
    Private _currentFullName As String = String.Empty
    Private _isLoggedIn As Boolean = False

    ''' <summary>
    ''' Gets or sets the current user's ID
    ''' </summary>
    Public Property CurrentUserID As Integer
        Get
            Return _currentUserID
        End Get
        Set(value As Integer)
            _currentUserID = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current user's username
    ''' </summary>
    Public Property CurrentUsername As String
        Get
            Return _currentUsername
        End Get
        Set(value As String)
            _currentUsername = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current user's role name (Admin or User)
    ''' </summary>
    Public Property CurrentRoleName As String
        Get
            Return _currentRoleName
        End Get
        Set(value As String)
            _currentRoleName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current user's role ID
    ''' </summary>
    Public Property CurrentRoleID As Integer
        Get
            Return _currentRoleID
        End Get
        Set(value As Integer)
            _currentRoleID = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the current user's full name
    ''' </summary>
    Public Property CurrentFullName As String
        Get
            Return _currentFullName
        End Get
        Set(value As String)
            _currentFullName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets whether a user is currently logged in
    ''' </summary>
    Public Property IsLoggedIn As Boolean
        Get
            Return _isLoggedIn
        End Get
        Set(value As Boolean)
            _isLoggedIn = value
        End Set
    End Property

    ''' <summary>
    ''' Checks if the current user has Admin role
    ''' </summary>
    ''' <returns>True if user is Admin, False otherwise</returns>
    Public Function IsAdmin() As Boolean
        Return _isLoggedIn AndAlso String.Equals(_currentRoleName, "Admin", StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Checks if the current user has User role
    ''' </summary>
    ''' <returns>True if user is User role, False otherwise</returns>
    Public Function IsUser() As Boolean
        Return _isLoggedIn AndAlso String.Equals(_currentRoleName, "User", StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Initializes the session with user information after successful login
    ''' </summary>
    ''' <param name="userID">User ID from database</param>
    ''' <param name="username">Username</param>
    ''' <param name="roleName">Role name (Admin or User)</param>
    ''' <param name="roleID">Role ID from database</param>
    ''' <param name="fullName">User's full name</param>
    Public Sub InitializeSession(userID As Integer, username As String, roleName As String, roleID As Integer, fullName As String)
        _currentUserID = userID
        _currentUsername = username
        _currentRoleName = roleName
        _currentRoleID = roleID
        _currentFullName = fullName
        _isLoggedIn = True

        ' Update last login date in database
        Try
            Using conn As Global.MySql.Data.MySqlClient.MySqlConnection = Database.CreateConnection()
                conn.Open()
                Dim updateSql As String = "UPDATE tbl_login SET LastLoginDate = NOW() WHERE id = @userID"
                Using cmd As New Global.MySql.Data.MySqlClient.MySqlCommand(updateSql, conn)
                    cmd.Parameters.AddWithValue("@userID", userID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log error but don't prevent login
            System.Diagnostics.Debug.WriteLine("Failed to update last login date: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Clears the session (called on logout)
    ''' </summary>
    Public Sub ClearSession()
        _currentUserID = 0
        _currentUsername = String.Empty
        _currentRoleName = String.Empty
        _currentRoleID = 0
        _currentFullName = String.Empty
        _isLoggedIn = False
    End Sub

    ''' <summary>
    ''' Checks if the current user can access a specific form
    ''' User role CAN access all forms (but can only edit in BlotterRecords and ResidentInfo)
    ''' Admin has access to everything
    ''' </summary>
    ''' <param name="formName">Name of the form to check</param>
    ''' <returns>True if user can access, False otherwise</returns>
    Public Function CanAccessForm(formName As String) As Boolean
        If Not _isLoggedIn Then Return False
        ' Both Admin and User roles can access all forms
        ' User role can only EDIT/UPDATE in BlotterRecords and ResidentInfo (checked via CanEditInForm)
        Return True
    End Function

    ''' <summary>
    ''' Checks if the current user can perform edit/update operations
    ''' </summary>
    ''' <returns>True if user can edit, False otherwise</returns>
    Public Function CanEdit() As Boolean
        If Not _isLoggedIn Then Return False
        Return IsAdmin() ' Admin can edit everything
    End Function

    ''' <summary>
    ''' Checks if the current user can edit/update records in a specific form
    ''' User role can only edit in BlotterRecords and ResidentInfo
    ''' Admin can edit in all forms
    ''' </summary>
    ''' <param name="formName">Name of the form to check (e.g., "blotterrecords", "residentinfo")</param>
    ''' <returns>True if user can edit in this form, False otherwise</returns>
    Public Function CanEditInForm(formName As String) As Boolean
        If Not _isLoggedIn Then Return False
        If IsAdmin() Then Return True ' Admin can edit in all forms

        ' User role can only edit in BlotterRecords and ResidentInfo
        If IsUser() Then
            Dim allowedForms As String() = {"blotterrecords", "residentinfo"}
            Return allowedForms.Contains(formName.ToLower())
        End If

        Return False
    End Function

    ''' <summary>
    ''' Checks if the current user can access backup/restore functionality
    ''' </summary>
    ''' <returns>True if user can access backup/restore, False otherwise</returns>
    Public Function CanAccessBackupRestore() As Boolean
        If Not _isLoggedIn Then Return False
        Return IsAdmin() ' Only Admin can access backup/restore
    End Function
End Module

