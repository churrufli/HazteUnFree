Public Class CustomProgressBar
    Inherits ProgressBar

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim progressBarRectangle As New Rectangle(0, 0, Width, Height)
        Dim progressBarFillWidth As Integer = CInt((Value / Maximum) * Width)

        ' Dibujar el fondo de la ProgressBar
        Using bgBrush As New SolidBrush(BackColor)
            g.FillRectangle(bgBrush, progressBarRectangle)
        End Using

        ' Cambiar el color de la barra de progreso a azul
        Using barBrush As New SolidBrush(Color.Blue)
            Dim barFillRectangle As New Rectangle(0, 0, progressBarFillWidth, Height)
            g.FillRectangle(barBrush, barFillRectangle)
        End Using
    End Sub

End Class