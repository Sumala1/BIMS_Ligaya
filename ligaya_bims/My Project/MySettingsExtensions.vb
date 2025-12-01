Imports System.Configuration

Namespace My
    Partial Friend NotInheritable Class MySettings

        <UserScopedSetting()>
        <DefaultSettingValue("")>
        Public Property SavedUsername As String
            Get
                Return CType(Me("SavedUsername"), String)
            End Get
            Set(value As String)
                Me("SavedUsername") = value
            End Set
        End Property

        <UserScopedSetting()>
        <DefaultSettingValue("False")>
        Public Property RememberMe As Boolean
            Get
                Return CType(Me("RememberMe"), Boolean)
            End Get
            Set(value As Boolean)
                Me("RememberMe") = value
            End Set
        End Property

    End Class
End Namespace


