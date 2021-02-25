Attribute VB_Name = "GetPercentValueModule"
Option Explicit

Sub GetPercentValue()

    ActiveWorkbook.ActiveSheet.Range("I106").Activate
    Do While Not IsEmpty(ActiveCell.Offset(0, -2))
        ActiveCell.Formula = "=" + ActiveCell.Offset(0, -2).Address(0, 0) + "/" + ActiveCell.Offset(0, -1).Address(0, 0) + "*100"
        ActiveCell.Offset(1, 0).Activate
    Loop
    
End Sub
