Attribute VB_Name = "DeleteEmptyInTRListModule"
Option Explicit

Sub DeleteEmptyInstanceInTransformerList()
Application.Range("C106").Activate

Do While Not ActiveCell.Value = "   Прочие"
    If IsEmpty(ActiveCell) Then
        ActiveCell.EntireRow.Delete
    Else: ActiveCell.Offset(1, 0).Activate
    End If
Loop

End Sub
