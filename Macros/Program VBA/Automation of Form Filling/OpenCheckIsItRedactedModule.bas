Attribute VB_Name = "OpenCheckIsItRedactedModule"
Option Explicit

Sub OpenCheckIsItRedacted()

Dim StartCell As Range: Set StartCell = Application.Range("A206")
Dim StartWorkbook As Workbook: Set StartWorkbook = ActiveWorkbook
StartCell.Activate


Do While Not IsEmpty(ActiveCell)

    Workbooks.Open Filename:=ActiveCell.Value
    Application.DisplayAlerts = False
    ActiveWorkbook.Save
    Application.DisplayAlerts = True
    ActiveWorkbook.Close
    StartWorkbook.Activate
    ActiveCell.Offset(1, 0).Activate
    ActiveCell.Offset(1, 0).Interior.Color = vbMagenta
    
    
Loop

End Sub

