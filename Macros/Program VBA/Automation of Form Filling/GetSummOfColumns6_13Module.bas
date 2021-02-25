Attribute VB_Name = "GetSummOfColumns6_13Module"
Option Explicit

Sub GetSummOfColumns6_13()
ActiveWorkbook.ActiveSheet.Range("J105").Activate
Do While Not IsEmpty(ActiveCell.Offset(0, -2))
    ActiveCell.Formula = "=SUM(" + ActiveCell.Offset(0, 1).Address(0, 0) + ":" + ActiveCell.Offset(0, 8).Address(0, 0) + ")"
    ActiveCell.Offset(1, 0).Activate
Loop
End Sub

