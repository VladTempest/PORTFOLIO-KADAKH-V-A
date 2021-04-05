Attribute VB_Name = "CopyFriendEnemiesFamilyModule"
Option Explicit

Function CopyFriendEnemiesFamily(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, PlaceToPaste As Range)

Dim CurrentCell As Range
Dim FriendEnemiesFamilyRange As Range
Dim CopiyngValue As String
Dim RowOfLastCopiedCharacter As Integer

RowOfLastCopiedCharacter = PlaceToPaste.Offset(6, 0).Row

If Range("D8").Value = "Ведьмак" Then
    Set FriendEnemiesFamilyRange = Range("BS18:BS46")
Else
    Set FriendEnemiesFamilyRange = Range("BL18:BL46")
End If

For Each CurrentCell In FriendEnemiesFamilyRange
    If Not IsEmpty(CurrentCell) Then
        CurrentCharacterWorkbook.Activate
        CopiyngValue = CurrentCell.Value
        GameMasterWorkbook.Activate
        WorksheetWithCharacters.Activate
        Cells(RowOfLastCopiedCharacter, 10).Value = CopiyngValue
        Cells(RowOfLastCopiedCharacter, 10).HorizontalAlignment = xlLeft
        CurrentCharacterWorkbook.Activate
        RowOfLastCopiedCharacter = RowOfLastCopiedCharacter + 1
    End If
Next

End Function
