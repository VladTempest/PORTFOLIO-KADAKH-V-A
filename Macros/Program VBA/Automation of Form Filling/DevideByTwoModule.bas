Attribute VB_Name = "DevideByTwoModule"
Option Explicit

Sub DevideByTwo()
Attribute DevideByTwo.VB_ProcData.VB_Invoke_Func = "И\n14"
Dim CalculatedRange As Range: Set CalculatedRange = Selection
Dim CalculatedCell As Range

For Each CalculatedCell In CalculatedRange.Cells

    If Not (IsEmpty(CalculatedCell) Or CalculatedCell.Rows.Hidden) Then
        If IsNumeric(CalculatedCell.Formula) Then
            CalculatedCell.Formula = "=" + ReturnStringValueWithDot(CalculatedCell.Formula) + "/2"
            CalculatedCell.Interior.Color = vbRed
        ElseIf IsThereResultOfSearch(CalculatedCell.Find("=", LookIn:=xlFormulas)) Then
            CalculatedCell.Formula = CStr(CalculatedCell.Formula) + "/2"
            CalculatedCell.Interior.Color = vbMagenta
        Else
            CalculatedCell.Formula = "=" + ReturnStringValueWithDot(CDbl(CalculatedCell.Value)) + "/2"
            CalculatedCell.Interior.Color = vbRed
            'MsgBox "В " & CalculatedCell.Address(0, 0) & " текст"
        End If
    End If
Next

End Sub
