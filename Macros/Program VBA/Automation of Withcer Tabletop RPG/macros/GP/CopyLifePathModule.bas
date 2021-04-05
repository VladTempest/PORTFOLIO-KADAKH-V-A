Attribute VB_Name = "CopyLifePathModule"
Option Explicit

Function CopyLifePath(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, PlaceToPaste As Range)

Dim CurrentCell As Range
Dim LifePathRange As Range
Dim CopiyngValue As String
Dim CopiyngDate As String
Dim RowOfLastCopiedPath As Integer

RowOfLastCopiedPath = PlaceToPaste.Offset(2, 9).Row

If Range("D8").Value = "Ведьмак" Then
    Set LifePathRange = Range("BW16:BW46")
Else
    Set LifePathRange = Range("BP16:BP46")
End If

For Each CurrentCell In LifePathRange
    If Not IsEmpty(CurrentCell) Then
        CurrentCharacterWorkbook.Activate
        CopiyngValue = CurrentCell.Value
        CopiyngDate = CurrentCell.Offset(0, -1).Value
        GameMasterWorkbook.Activate
        WorksheetWithCharacters.Activate
        Cells(RowOfLastCopiedPath, 13).Value = CopiyngValue
        Cells(RowOfLastCopiedPath, 13).HorizontalAlignment = xlLeft
        Cells(RowOfLastCopiedPath, 12).Value = CopiyngDate
        Cells(RowOfLastCopiedPath, 12).HorizontalAlignment = xlRight
        CurrentCharacterWorkbook.Activate
        RowOfLastCopiedPath = RowOfLastCopiedPath + 1
    End If
Next
CopyLifePath = RowOfLastCopiedPath
End Function

