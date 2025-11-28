Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Global.ligaya_bims
Public Class RoundedButton
    Inherits Button

    Private _borderRadius As Integer = 15

    <Category("Appearance")>
    Public Property BorderRadius As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            If value >= 0 Then
                _borderRadius = value
                Invalidate()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        FlatStyle = FlatStyle.Flat
        FlatAppearance.BorderSize = 0
        DoubleBuffered = True
    End Sub

    Private Function IsInDesigner() As Boolean
        Try
            If DesignMode Then Return True
        Catch
        End Try
        Try
            If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return True
        Catch
        End Try
        Try
            Dim procName As String = Process.GetCurrentProcess().ProcessName
            If String.Equals(procName, "devenv", StringComparison.OrdinalIgnoreCase) Then Return True
        Catch
        End Try
        Return False
    End Function

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim w As Integer = Width
        Dim h As Integer = Height
        If w <= 0 OrElse h <= 0 Then
            MyBase.OnPaint(pevent)
            Return
        End If

        If IsInDesigner() OrElse _borderRadius = 0 Then
            MyBase.OnPaint(pevent)
            Return
        End If

        Using path As GraphicsPath = CreateRoundPath(New Rectangle(0, 0, w, h), _borderRadius)
            Try
                Region = New Region(path)
            Catch
            End Try
        End Using

        MyBase.OnPaint(pevent)
    End Sub

    Private Function CreateRoundPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height))

        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()

        Return path
    End Function

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub
End Class
End Namespace

