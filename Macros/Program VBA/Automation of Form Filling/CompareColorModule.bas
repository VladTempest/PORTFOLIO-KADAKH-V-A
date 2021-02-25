Attribute VB_Name = "CompareColorModule"
Option Explicit

Sub CompareColor()

Dim CalculatedRange As Range: Set CalculatedRange = Selection
Dim CalculatedCell As Range

For Each CalculatedCell In CalculatedRange.Cells

    If CalculatedCell.Offset(0, -1).Interior.Color = CalculatedCell.Offset(0, -2).Interior.Color Then
        CalculatedCell.Value = 1
        Debug.Print CalculatedCell.Offset(0, -1).Interior.Color
        Debug.Print CalculatedCell.Offset(0, -2).Interior.Color
    End If
Next

End Sub
