' Shared data class for certificate information
Public Class SharedCertificateData
    Public Shared Event DataChanged As EventHandler
    
    Private Shared _fullName As String = ""
    Private Shared _address As String = ""
    Private Shared _purpose As String = ""
    Private Shared _issuedDate As String = ""
    
    Public Shared Property FullName As String
        Get
            Return _fullName
        End Get
        Set(value As String)
            If _fullName <> value Then
                _fullName = value
                RaiseEvent DataChanged(Nothing, EventArgs.Empty)
            End If
        End Set
    End Property
    
    Public Shared Property Address As String
        Get
            Return _address
        End Get
        Set(value As String)
            If _address <> value Then
                _address = value
                RaiseEvent DataChanged(Nothing, EventArgs.Empty)
            End If
        End Set
    End Property
    
    Public Shared Property Purpose As String
        Get
            Return _purpose
        End Get
        Set(value As String)
            If _purpose <> value Then
                _purpose = value
                RaiseEvent DataChanged(Nothing, EventArgs.Empty)
            End If
        End Set
    End Property
    
    Public Shared Property IssuedDate As String
        Get
            Return _issuedDate
        End Get
        Set(value As String)
            If _issuedDate <> value Then
                _issuedDate = value
                RaiseEvent DataChanged(Nothing, EventArgs.Empty)
            End If
        End Set
    End Property
    
    Public Shared Sub ClearData()
        _fullName = ""
        _address = ""
        _purpose = ""
        _issuedDate = ""
        RaiseEvent DataChanged(Nothing, EventArgs.Empty)
    End Sub
    
    Public Shared Sub TestDataSync()
        ' Test method to verify data synchronization is working
        FullName = "Test Name"
        Address = "Test Address"
        Purpose = "Test Purpose"
        IssuedDate = DateTime.Now.ToString("MMM dd, yyyy")
    End Sub
End Class
