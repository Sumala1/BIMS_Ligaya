Imports System.Drawing
Imports System.Drawing.Drawing2D

''' <summary>
''' Shared utility class for creating consistent icons across all DataGridViews
''' </summary>
Public Class IconHelper
    Private Shared _deleteIcon As Image = Nothing
    Private Shared _restoreIcon As Image = Nothing
    Private Shared _editIcon As Image = Nothing

    ''' <summary>
    ''' Gets or creates the standard delete icon (trash can)
    ''' Returns a cloned copy to prevent sharing issues
    ''' </summary>
    Public Shared Function GetDeleteIcon() As Image
        If _deleteIcon Is Nothing Then
            _deleteIcon = CreateDeleteIcon()
        End If
        ' Return a clone to prevent issues when multiple DataGridViews use the same image
        Return CType(_deleteIcon.Clone(), Image)
    End Function

    ''' <summary>
    ''' Gets or creates the standard restore icon (circular arrow)
    ''' Returns a cloned copy to prevent sharing issues
    ''' </summary>
    Public Shared Function GetRestoreIcon() As Image
        If _restoreIcon Is Nothing Then
            _restoreIcon = CreateRestoreIcon()
        End If
        ' Return a clone to prevent issues when multiple DataGridViews use the same image
        Return CType(_restoreIcon.Clone(), Image)
    End Function

    ''' <summary>
    ''' Gets or creates the standard edit icon (user/profile icon)
    ''' Returns a cloned copy to prevent sharing issues
    ''' </summary>
    Public Shared Function GetEditIcon() As Image
        If _editIcon Is Nothing Then
            _editIcon = CreateEditIcon()
        End If
        ' Return a clone to prevent issues when multiple DataGridViews use the same image
        Return CType(_editIcon.Clone(), Image)
    End Function

    ''' <summary>
    ''' Creates a simple black trash can icon (delete icon)
    ''' </summary>
    Private Shared Function CreateDeleteIcon() As Image
        Try
            Dim size As Integer = 20
            Dim bmp As New Bitmap(size, size)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.Clear(Color.Transparent)

                ' Trash can body (solid black rectangle with slightly rounded bottom corners)
                Using bodyBrush As New SolidBrush(Color.Black)
                    ' Main body rectangle - positioned to center nicely (scaled for 20x20)
                    Dim bodyRect As New RectangleF(6, 7.5F, 8, 10)
                    g.FillRoundedRectangle(bodyBrush, bodyRect, 1.5F)
                End Using

                ' Lid (thin rectangle, slightly wider than body)
                Using lidBrush As New SolidBrush(Color.Black)
                    Dim lidRect As New RectangleF(5.5F, 6, 9, 2)
                    g.FillRectangle(lidBrush, lidRect)
                End Using

                ' Horizontal white line (rim/handle) across upper portion of body
                Using linePen As New Pen(Color.White, 1.0F)
                    g.DrawLine(linePen, 7, 8.5F, 13, 8.5F)
                End Using
            End Using
            ' Graphics is disposed, bitmap is ready to use
            Return bmp
        Catch ex As Exception
            ' Return a simple fallback bitmap if creation fails
            Return New Bitmap(20, 20)
        End Try
    End Function

    ''' <summary>
    ''' Creates a bold black circular arrow icon (restore icon) - clockwise starting from 7 o'clock with arrowhead at 1 o'clock
    ''' </summary>
    Private Shared Function CreateRestoreIcon() As Image
        Try
            Dim size As Integer = 20
            Dim bmp As New Bitmap(size, size)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.Clear(Color.Transparent)

                Dim centerX As Single = size / 2
                Dim centerY As Single = size / 2
                Dim radius As Single = (size - 4) / 2

                ' Bold black circular arrow (clockwise, starting from 7 o'clock = 210 degrees)
                ' Sweeps clockwise to 1 o'clock = 30 degrees (about 180 degrees sweep)
                Using pen As New Pen(Color.Black, 2.8F)
                    pen.EndCap = LineCap.Round
                    pen.StartCap = LineCap.Round
                    
                    ' Draw circular arc starting from 7 o'clock (210 degrees) sweeping clockwise
                    ' Sweep about 175 degrees clockwise, ending just before 1 o'clock, leaving small gap
                    Dim rect As New RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2)
                    g.DrawArc(pen, rect, 210, 175)

                    ' Draw arrowhead at 1 o'clock (30 degrees) pointing clockwise
                    ' Positioned slightly after the arc end to create visible gap
                    Dim arrowAngleDegrees As Single = 30.0F
                    Dim arrowAngleRad As Single = arrowAngleDegrees * Math.PI / 180.0F
                    
                    ' Calculate arrow tip position on the circle
                    Dim arrowTipX As Single = centerX + radius * CSng(Math.Cos(arrowAngleRad))
                    Dim arrowTipY As Single = centerY - radius * CSng(Math.Sin(arrowAngleRad))

                    ' Arrowhead size (proportional to icon size)
                    Dim arrowSize As Single = 3.5F
                    
                    ' Calculate arrowhead direction - tangent to the circle at this point (clockwise)
                    ' For clockwise, tangent angle is arrowAngleRad + Math.PI / 2.0F
                    Dim tangentAngle As Single = arrowAngleRad + Math.PI / 2.0F
                    
                    ' Calculate arrowhead base points (forming a triangle pointing along the tangent)
                    Dim arrowBase1X As Single = arrowTipX - arrowSize * CSng(Math.Cos(tangentAngle - Math.PI / 3))
                    Dim arrowBase1Y As Single = arrowTipY + arrowSize * CSng(Math.Sin(tangentAngle - Math.PI / 3))
                    Dim arrowBase2X As Single = arrowTipX - arrowSize * CSng(Math.Cos(tangentAngle + Math.PI / 3))
                    Dim arrowBase2Y As Single = arrowTipY + arrowSize * CSng(Math.Sin(tangentAngle + Math.PI / 3))

                    ' Fill arrowhead triangle
                    Using arrowBrush As New SolidBrush(Color.Black)
                        Dim arrowPoints() As PointF = {
                            New PointF(arrowTipX, arrowTipY),
                            New PointF(arrowBase1X, arrowBase1Y),
                            New PointF(arrowBase2X, arrowBase2Y)
                        }
                        g.FillPolygon(arrowBrush, arrowPoints)
                    End Using
                End Using
            End Using
            ' Graphics is disposed, bitmap is ready to use
            Return bmp
        Catch ex As Exception
            ' Return a simple fallback bitmap if creation fails
            Return New Bitmap(20, 20)
        End Try
    End Function

    ''' <summary>
    ''' Creates a user/profile icon (edit icon) - circular head with two body segments separated by diagonal gap
    ''' </summary>
    Private Shared Function CreateEditIcon() As Image
        Try
            Dim size As Integer = 20
            Dim bmp As New Bitmap(size, size)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.PixelOffsetMode = PixelOffsetMode.HighQuality
                g.Clear(Color.Transparent)

                Using brush As New SolidBrush(Color.Black)
                    ' Draw circular head at top center
                    Dim headRadius As Single = 4.0F
                    Dim headCenterX As Single = size / 2
                    Dim headCenterY As Single = 5.5F
                    g.FillEllipse(brush, headCenterX - headRadius, headCenterY - headRadius, headRadius * 2, headRadius * 2)

                    ' Draw left body segment (larger, more rounded, smooth curved mass extending down and slightly left)
                    ' The gap runs from bottom-right edge of head circle downwards and to the right
                    Dim leftBodyRect As New RectangleF(2.5F, 10.5F, 7.0F, 7.0F)
                    Using leftPath As New GraphicsPath()
                        ' Create more rounded, organic shape for left segment
                        Dim leftRadius As Single = 2.2F
                        leftPath.AddArc(leftBodyRect.Left, leftBodyRect.Top, leftRadius * 2, leftRadius * 2, 180, 90)
                        leftPath.AddArc(leftBodyRect.Right - leftRadius * 2, leftBodyRect.Top, leftRadius * 2, leftRadius * 2, 270, 90)
                        leftPath.AddArc(leftBodyRect.Right - leftRadius * 2, leftBodyRect.Bottom - leftRadius * 2, leftRadius * 2, leftRadius * 2, 0, 90)
                        leftPath.AddArc(leftBodyRect.Left, leftBodyRect.Bottom - leftRadius * 2, leftRadius * 2, leftRadius * 2, 90, 90)
                        leftPath.CloseFigure()
                        g.FillPath(brush, leftPath)
                    End Using

                    ' Draw right body segment (smaller, elongated capsule with rounded ends, extends down and to the right)
                    ' Positioned to create prominent diagonal gap starting from bottom-right of head
                    Dim rightBodyRect As New RectangleF(11.5F, 11.0F, 4.0F, 6.5F)
                    Using rightPath As New GraphicsPath()
                        ' Create elongated capsule shape for right segment
                        Dim rightRadius As Single = 1.8F
                        rightPath.AddArc(rightBodyRect.Left, rightBodyRect.Top, rightRadius * 2, rightRadius * 2, 180, 90)
                        rightPath.AddArc(rightBodyRect.Right - rightRadius * 2, rightBodyRect.Top, rightRadius * 2, rightRadius * 2, 270, 90)
                        rightPath.AddArc(rightBodyRect.Right - rightRadius * 2, rightBodyRect.Bottom - rightRadius * 2, rightRadius * 2, rightRadius * 2, 0, 90)
                        rightPath.AddArc(rightBodyRect.Left, rightBodyRect.Bottom - rightRadius * 2, rightRadius * 2, rightRadius * 2, 90, 90)
                        rightPath.CloseFigure()
                        g.FillPath(brush, rightPath)
                    End Using
                End Using
            End Using
            ' Graphics is disposed, bitmap is ready to use
            Return bmp
        Catch ex As Exception
            ' Return a simple fallback bitmap if creation fails
            Return New Bitmap(20, 20)
        End Try
    End Function

    ''' <summary>
    ''' Disposes all cached icons (call on application exit)
    ''' </summary>
    Public Shared Sub DisposeIcons()
        If _deleteIcon IsNot Nothing Then
            _deleteIcon.Dispose()
            _deleteIcon = Nothing
        End If
        If _restoreIcon IsNot Nothing Then
            _restoreIcon.Dispose()
            _restoreIcon = Nothing
        End If
        If _editIcon IsNot Nothing Then
            _editIcon.Dispose()
            _editIcon = Nothing
        End If
    End Sub
End Class

''' <summary>
''' Extension method for drawing rounded rectangles
''' </summary>
Public Module GraphicsExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub FillRoundedRectangle(g As Graphics, brush As Brush, rect As RectangleF, radius As Single)
        Using path As GraphicsPath = CreateRoundedRectanglePath(rect, radius)
            g.FillPath(brush, path)
        End Using
    End Sub

    Private Function CreateRoundedRectanglePath(rect As RectangleF, radius As Single) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Single = radius * 2
        Dim size As New SizeF(diameter, diameter)

        path.AddArc(New RectangleF(rect.Location, size), 180, 90)
        path.AddArc(New RectangleF(New PointF(rect.Right - diameter, rect.Y), size), 270, 90)
        path.AddArc(New RectangleF(New PointF(rect.Right - diameter, rect.Bottom - diameter), size), 0, 90)
        path.AddArc(New RectangleF(New PointF(rect.X, rect.Bottom - diameter), size), 90, 90)
        path.CloseFigure()

        Return path
    End Function
End Module

