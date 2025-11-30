Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Utility class for password hashing and verification
''' Uses SHA256 for password hashing
''' </summary>
Public Module PasswordHelper
    ''' <summary>
    ''' Hashes a password using SHA256 algorithm
    ''' </summary>
    ''' <param name="password">Plain text password to hash</param>
    ''' <returns>Hashed password as hexadecimal string</returns>
    Public Function HashPassword(password As String) As String
        If String.IsNullOrEmpty(password) Then
            Throw New ArgumentException("Password cannot be null or empty", NameOf(password))
        End If

        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    ''' <summary>
    ''' Verifies a password against a hash
    ''' </summary>
    ''' <param name="password">Plain text password to verify</param>
    ''' <param name="hash">Hashed password to compare against</param>
    ''' <returns>True if password matches hash, False otherwise</returns>
    Public Function VerifyPassword(password As String, hash As String) As Boolean
        If String.IsNullOrEmpty(password) OrElse String.IsNullOrEmpty(hash) Then
            Return False
        End If

        Dim passwordHash As String = HashPassword(password)
        Return String.Equals(passwordHash, hash, StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Alternative method: Uses MySQL SHA2 function for consistency with database
    ''' This method hashes the password using SHA256 and returns it in the same format as MySQL SHA2
    ''' </summary>
    ''' <param name="password">Plain text password to hash</param>
    ''' <returns>Hashed password as hexadecimal string (compatible with MySQL SHA2)</returns>
    Public Function HashPasswordMySQL(password As String) As String
        If String.IsNullOrEmpty(password) Then
            Throw New ArgumentException("Password cannot be null or empty", NameOf(password))
        End If

        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            ' Convert to lowercase hex string (MySQL SHA2 format)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function
End Module

