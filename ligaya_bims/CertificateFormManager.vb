Public Class CertificateFormManager
    Private Shared _certBrgyClearance As CertBrgyClearance
    Private Shared _certResidency As CertResidency
    Private Shared _certIndigency As CertifcateIndigency
    
    Public Shared Function GetBrgyClearanceForm() As CertBrgyClearance
        If _certBrgyClearance Is Nothing OrElse _certBrgyClearance.IsDisposed Then
            _certBrgyClearance = New CertBrgyClearance()
            _certBrgyClearance.TopLevel = False
            _certBrgyClearance.Visible = False
        End If
        Return _certBrgyClearance
    End Function
    
    Public Shared Function GetResidencyForm() As CertResidency
        If _certResidency Is Nothing OrElse _certResidency.IsDisposed Then
            _certResidency = New CertResidency()
            _certResidency.TopLevel = False
            _certResidency.Visible = False
        End If
        Return _certResidency
    End Function
    
    Public Shared Function GetIndigencyForm() As CertifcateIndigency
        If _certIndigency Is Nothing OrElse _certIndigency.IsDisposed Then
            _certIndigency = New CertifcateIndigency()
            _certIndigency.TopLevel = False
            _certIndigency.Visible = False
        End If
        Return _certIndigency
    End Function
    
    Public Shared Sub DisposeAllForms()
        If _certBrgyClearance IsNot Nothing AndAlso Not _certBrgyClearance.IsDisposed Then
            _certBrgyClearance.Dispose()
        End If
        If _certResidency IsNot Nothing AndAlso Not _certResidency.IsDisposed Then
            _certResidency.Dispose()
        End If
        If _certIndigency IsNot Nothing AndAlso Not _certIndigency.IsDisposed Then
            _certIndigency.Dispose()
        End If
    End Sub
End Class
