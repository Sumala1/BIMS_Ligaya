Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Diagnostics

Namespace Global.ligaya_bims
Public Class RoundedPanel
    Inherits Panel

    Private _borderRadius As Integer = 20
    Private _borderColor As Color = Color.Black
    Private _borderThickness As Integer = 2

    <Category("Appearance")>
    <Description("The radius of the rounded corners")>
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

    <Category("Appearance")>
    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property BorderThickness As Integer
        Get
            Return _borderThickness
        End Get
        Set(value As Integer)
            If value >= 0 Then
                _borderThickness = value
                Invalidate()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        DoubleBuffered = True
        BackColor = Color.White
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

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim rect As Rectangle = ClientRectangle
        If rect.Width <= 0 OrElse rect.Height <= 0 Then Return

        Using path As GraphicsPath = GetRoundedPath(rect, _borderRadius)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

            If Not IsInDesigner() Then
                Try
                    Region = New Region(path)
                Catch
                End Try
            End If

            Using brush As New SolidBrush(BackColor)
                e.Graphics.FillPath(brush, path)
            End Using

            If _borderThickness > 0 Then
                Using pen As New Pen(_borderColor, _borderThickness)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End If
        End Using
    End Sub

    Private Function GetRoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        If radius <= 0 Then
            path.AddRectangle(rect)
            Return path
        End If

        Dim diameter As Integer = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height))

        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)
        path.CloseFigure()

        Return path
    End Function

    Protected Overrides Sub OnResize(eventargs As EventArgs)
        MyBase.OnResize(eventargs)
        Invalidate()
    End Sub
End Class
End Namespace

