Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms

''' <summary>
''' Shared utility class for creating consistent icons across all DataGridViews
''' </summary>
Public Class IconHelper
    Private Shared _deleteIcon As Image = Nothing
    Private Shared _restoreIcon As Image = Nothing
    Private Shared _editIcon As Image = Nothing
    Private Shared _printIcon As Image = Nothing

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
    ''' Gets or creates the standard restore icon by loading from Resources folder
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
    ''' Gets or creates the standard print icon by loading from Resources folder
    ''' Returns a cloned copy to prevent sharing issues
    ''' </summary>
    Public Shared Function GetPrintIcon() As Image
        If _printIcon Is Nothing Then
            _printIcon = CreatePrintIcon()
        End If
        ' Return a clone to prevent issues when multiple DataGridViews use the same image
        Return CType(_printIcon.Clone(), Image)
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
    ''' Creates a restore icon by loading the image from Resources folder
    ''' The image is resized to fit perfectly in the DataGridView cell (24x24 pixels)
    ''' </summary>
    Private Shared Function CreateRestoreIcon() As Image
        Try
            ' Try multiple possible locations and filenames for the restore icon image
            Dim possiblePaths As New List(Of String)()
            Dim imageNames As String() = {"restore_icon.png.png", "restore_icon.png"}
            
            ' Get the assembly location (where the executable is running from)
            Dim assemblyPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            
            ' Try each location with each possible filename
            Dim basePaths As New List(Of String)()
            
            ' 1. Resources folder next to the executable (bin\Debug\Resources or bin\Release\Resources)
            If Not String.IsNullOrEmpty(assemblyPath) Then
                basePaths.Add(assemblyPath)
            End If
            
            ' 2. Application startup path
            basePaths.Add(Application.StartupPath)
            
            ' 3. Project root Resources folder (for development/debugging)
            If Not String.IsNullOrEmpty(assemblyPath) Then
                ' Go up from bin\Debug to project root
                Dim projectRoot As String = Path.GetFullPath(Path.Combine(assemblyPath, "..", ".."))
                basePaths.Add(projectRoot)
            End If
            
            ' 4. Current directory
            basePaths.Add(Directory.GetCurrentDirectory())
            
            ' Build all possible paths
            For Each basePath In basePaths
                For Each imageName In imageNames
                    Dim fullPath As String = Path.Combine(basePath, "Resources", imageName)
                    If File.Exists(fullPath) Then
                        possiblePaths.Add(fullPath)
                    End If
                Next
            Next
            
            ' Find the first existing path
            Dim imagePath As String = Nothing
            For Each path In possiblePaths
                If File.Exists(path) Then
                    imagePath = path
                    Exit For
                End If
            Next
            
            ' If image file exists, load and resize it
            If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                Using originalImage As Image = Image.FromFile(imagePath)
                    ' Resize to 24x24 pixels for optimal display in DataGridView
                    Dim targetSize As Integer = 24
                    ' Create bitmap with transparency support
                    Dim resizedImage As New Bitmap(targetSize, targetSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    Using g As Graphics = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.SmoothingMode = SmoothingMode.HighQuality
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality
                        g.CompositingQuality = CompositingQuality.HighQuality
                        ' Clear with transparent background
                        g.Clear(Color.Transparent)
                        ' Draw the image
                        g.DrawImage(originalImage, 0, 0, targetSize, targetSize)
                    End Using
                    Return resizedImage
                End Using
            Else
                ' Fallback: Create a simple circular arrow icon programmatically if file not found
                Dim size As Integer = 24
                Dim bmp As New Bitmap(size, size)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.SmoothingMode = SmoothingMode.AntiAlias
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality
                    g.Clear(Color.Transparent)

                    Dim centerX As Single = size / 2
                    Dim centerY As Single = size / 2
                    Dim radius As Single = (size - 4) / 2

                    ' Bold black circular arrow (clockwise, starting from 7 o'clock = 210 degrees)
                    Using pen As New Pen(Color.Black, 2.8F)
                        pen.EndCap = LineCap.Round
                        pen.StartCap = LineCap.Round
                        
                        Dim rect As New RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2)
                        g.DrawArc(pen, rect, 210, 175)

                        Dim arrowAngleDegrees As Single = 30.0F
                        Dim arrowAngleRad As Single = arrowAngleDegrees * Math.PI / 180.0F
                        
                        Dim arrowTipX As Single = centerX + radius * CSng(Math.Cos(arrowAngleRad))
                        Dim arrowTipY As Single = centerY - radius * CSng(Math.Sin(arrowAngleRad))

                        Dim arrowSize As Single = 3.5F
                        Dim tangentAngle As Single = arrowAngleRad + Math.PI / 2.0F
                        
                        Dim arrowBase1X As Single = arrowTipX - arrowSize * CSng(Math.Cos(tangentAngle - Math.PI / 3))
                        Dim arrowBase1Y As Single = arrowTipY + arrowSize * CSng(Math.Sin(tangentAngle - Math.PI / 3))
                        Dim arrowBase2X As Single = arrowTipX - arrowSize * CSng(Math.Cos(tangentAngle + Math.PI / 3))
                        Dim arrowBase2Y As Single = arrowTipY + arrowSize * CSng(Math.Sin(tangentAngle + Math.PI / 3))

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
                Return bmp
            End If
        Catch ex As Exception
            ' Return a simple fallback bitmap if loading fails
            Return New Bitmap(24, 24)
        End Try
    End Function

    ''' <summary>
    ''' Creates a print icon by loading the image from Resources folder
    ''' The image is resized to fit perfectly in the DataGridView cell (24x24 pixels)
    ''' </summary>
    Private Shared Function CreatePrintIcon() As Image
        Try
            ' Try multiple possible locations and filenames for the print icon image
            Dim possiblePaths As New List(Of String)()
            Dim imageNames As String() = {"print_icon.png.png", "print_icon.png"}
            
            ' Get the assembly location (where the executable is running from)
            Dim assemblyPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            
            ' Try each location with each possible filename
            Dim basePaths As New List(Of String)()
            
            ' 1. Resources folder next to the executable (bin\Debug\Resources or bin\Release\Resources)
            If Not String.IsNullOrEmpty(assemblyPath) Then
                basePaths.Add(assemblyPath)
            End If
            
            ' 2. Application startup path
            basePaths.Add(Application.StartupPath)
            
            ' 3. Project root Resources folder (for development/debugging)
            If Not String.IsNullOrEmpty(assemblyPath) Then
                ' Go up from bin\Debug to project root
                Dim projectRoot As String = Path.GetFullPath(Path.Combine(assemblyPath, "..", ".."))
                basePaths.Add(projectRoot)
            End If
            
            ' 4. Current directory
            basePaths.Add(Directory.GetCurrentDirectory())
            
            ' Build all possible paths
            For Each basePath In basePaths
                For Each imageName In imageNames
                    Dim fullPath As String = Path.Combine(basePath, "Resources", imageName)
                    If File.Exists(fullPath) Then
                        possiblePaths.Add(fullPath)
                    End If
                Next
            Next
            
            ' Find the first existing path
            Dim imagePath As String = Nothing
            For Each path In possiblePaths
                If File.Exists(path) Then
                    imagePath = path
                    Exit For
                End If
            Next
            
            ' If image file exists, load and resize it
            If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                Using originalImage As Image = Image.FromFile(imagePath)
                    ' Resize to 24x24 pixels for optimal display in DataGridView
                    Dim targetSize As Integer = 24
                    ' Create bitmap with transparency support
                    Dim resizedImage As New Bitmap(targetSize, targetSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    Using g As Graphics = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.SmoothingMode = SmoothingMode.HighQuality
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality
                        g.CompositingQuality = CompositingQuality.HighQuality
                        ' Clear with transparent background
                        g.Clear(Color.Transparent)
                        ' Draw the image
                        g.DrawImage(originalImage, 0, 0, targetSize, targetSize)
                    End Using
                    Return resizedImage
                End Using
            Else
                ' Fallback: Create a simple print icon programmatically if file not found
                Dim size As Integer = 24
                Dim bmp As New Bitmap(size, size)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.SmoothingMode = SmoothingMode.AntiAlias
                    g.Clear(Color.Transparent)

                    Using bodyBrush As New SolidBrush(Color.FromArgb(67, 195, 95))
                        g.FillRectangle(bodyBrush, 4, 6, size - 8, size - 10)
                        g.FillRectangle(bodyBrush, 7, size - 12, size - 14, 8)
                    End Using

                    Using paperBrush As New SolidBrush(Color.White)
                        g.FillRectangle(paperBrush, 8, 10, size - 16, size - 18)
                    End Using
                End Using
                Return bmp
            End If
        Catch ex As Exception
            ' Return a simple fallback bitmap if loading fails
            Return New Bitmap(24, 24)
        End Try
    End Function

    ''' <summary>
    ''' Creates an edit icon by loading the image from Resources folder
    ''' The image is resized to fit perfectly in the DataGridView cell (24x24 pixels)
    ''' Place your edit icon image (26x26 pixels) as "edit_icon.png" in the Resources folder
    ''' </summary>
    Private Shared Function CreateEditIcon() As Image
        Try
            ' Try multiple possible locations and filenames for the edit icon image
            Dim possiblePaths As New List(Of String)()
            Dim imageNames As String() = {"edit_icon.png", "edit_icon.png.png", "icons8-edit-property-26.png"}
            
            ' Get the assembly location (where the executable is running from)
            Dim assemblyPath As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            
            ' Try each location with each possible filename
            Dim basePaths As New List(Of String)()
            
            ' 1. Resources folder next to the executable (bin\Debug\Resources or bin\Release\Resources)
            If Not String.IsNullOrEmpty(assemblyPath) Then
                basePaths.Add(assemblyPath)
            End If
            
            ' 2. Application startup path
            basePaths.Add(Application.StartupPath)
            
            ' 3. Project root Resources folder (for development/debugging)
            If Not String.IsNullOrEmpty(assemblyPath) Then
                ' Go up from bin\Debug to project root
                Dim projectRoot As String = Path.GetFullPath(Path.Combine(assemblyPath, "..", ".."))
                basePaths.Add(projectRoot)
            End If
            
            ' 4. Current directory
            basePaths.Add(Directory.GetCurrentDirectory())
            
            ' Build all possible paths
            For Each basePath In basePaths
                For Each imageName In imageNames
                    Dim fullPath As String = Path.Combine(basePath, "Resources", imageName)
                    If File.Exists(fullPath) Then
                        possiblePaths.Add(fullPath)
                    End If
                Next
            Next
            
            ' Find the first existing path
            Dim imagePath As String = Nothing
            For Each path In possiblePaths
                If File.Exists(path) Then
                    imagePath = path
                    Exit For
                End If
            Next
            
            ' If image file exists, load and resize it
            If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                Using originalImage As Image = Image.FromFile(imagePath)
                    ' Resize to 24x24 pixels for optimal display in DataGridView (slightly smaller than 26x26 for better fit)
                    Dim targetSize As Integer = 24
                    ' Create bitmap with transparency support
                    Dim resizedImage As New Bitmap(targetSize, targetSize, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                    Using g As Graphics = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic
                        g.SmoothingMode = SmoothingMode.HighQuality
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality
                        g.CompositingQuality = CompositingQuality.HighQuality
                        ' Clear with transparent background
                        g.Clear(Color.Transparent)
                        ' Draw the image
                        g.DrawImage(originalImage, 0, 0, targetSize, targetSize)
                    End Using
                    Return resizedImage
                End Using
            Else
                ' Fallback: Create a simple document with pen icon programmatically if file not found
                ' This matches the description: document with three lines and a pen
                Dim size As Integer = 24
                Dim bmp As New Bitmap(size, size)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.SmoothingMode = SmoothingMode.AntiAlias
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality
                    g.Clear(Color.Transparent)

                    Using brush As New SolidBrush(Color.Black)
                        ' Draw document (rectangle with rounded corners)
                        Dim docRect As New RectangleF(4, 4, size - 8, size - 8)
                        Using docPath As New GraphicsPath()
                            Dim radius As Single = 2.0F
                            docPath.AddArc(docRect.Left, docRect.Top, radius * 2, radius * 2, 180, 90)
                            docPath.AddArc(docRect.Right - radius * 2, docRect.Top, radius * 2, radius * 2, 270, 90)
                            docPath.AddArc(docRect.Right - radius * 2, docRect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
                            docPath.AddArc(docRect.Left, docRect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
                            docPath.CloseFigure()
                            g.FillPath(brush, docPath)
                        End Using

                        ' Draw three horizontal lines (list items) inside document
                        Using linePen As New Pen(Color.Black, 1.5F)
                            g.DrawLine(linePen, 7, 9, size - 7, 9)
                            g.DrawLine(linePen, 7, 12, size - 7, 12)
                            g.DrawLine(linePen, 7, 15, size - 7, 15)
                        End Using

                        ' Draw pen/pencil diagonally across bottom right
                        Using penBrush As New SolidBrush(Color.Black)
                            ' Pen body (diagonal rectangle)
                            Dim penPoints() As PointF = {
                                New PointF(size - 8, size - 6),
                                New PointF(size - 4, size - 10),
                                New PointF(size - 3, size - 9),
                                New PointF(size - 7, size - 5)
                            }
                            g.FillPolygon(penBrush, penPoints)
                        End Using
                    End Using
                End Using
                Return bmp
            End If
        Catch ex As Exception
            ' Return a simple fallback bitmap if loading fails
            Return New Bitmap(24, 24)
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
        If _printIcon IsNot Nothing Then
            _printIcon.Dispose()
            _printIcon = Nothing
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

