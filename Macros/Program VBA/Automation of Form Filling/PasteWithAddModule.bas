Attribute VB_Name = "PasteWithAddModule"
Sub PasteWithAdd()
Attribute PasteWithAdd.VB_ProcData.VB_Invoke_Func = "Ф\n14"
'
' pasts Макрос
'
Dim SelectedRange As Range
Dim SelectedCell As Range
'Application.Range ("K105")
Selection.PasteSpecial Paste:=xlPasteAll, Operation:=xlAdd, SkipBlanks:= _
        False, Transpose:=False
Selection.Font.Color = vbBlack
Set SelectedRange = Selection
    For Each SelectedCell In SelectedRange
        If SelectedCell.Value = 0 Then
            SelectedCell.Clear
        End If
    Next
    For Each SelectedCell In SelectedRange
        If Not IsEmpty(SelectedCell) Then
            SelectedCell.Copy
            SelectedCell.PasteSpecial Paste:=xlPasteValues
            SelectedCell.Interior.Color = xlNone
        End If
    Next
End Sub

