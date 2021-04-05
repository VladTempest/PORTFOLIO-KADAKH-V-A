Attribute VB_Name = "CopyAllValidSkillsModule"
Option Explicit



Function CopyAllValidSkills(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, PlaceToPaste As Range) As Integer
Dim RowOfLastCopiedSkill As Integer
RowOfLastCopiedSkill = PlaceToPaste.Row + 6


RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Intellect, 3)
RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Reaction, 3)
RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Dexterity, 3)
RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Body, 3)
RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Empathy, 3)
RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Craft, 2)
RowOfLastCopiedSkill = CopyFromToWithOffset(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill, Characteristics.Will, 2)
RowOfLastCopiedSkill = CopyProfessionFromTo(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPaste, RowOfLastCopiedSkill)




CopyAllValidSkills = RowOfLastCopiedSkill
End Function

Function ReturnRangeForBase(Characteristic As Characteristics) As Range
    Select Case (Characteristic)
        Case Intellect
           Set ReturnRangeForBase = Range("R36:R48")
        Case Reaction
           Set ReturnRangeForBase = Range("R26:R33")
        Case Dexterity
           Set ReturnRangeForBase = Range("L26:L30")
        Case Body
           Set ReturnRangeForBase = Range("L33:L34")
        Case Empathy
           Set ReturnRangeForBase = Range("L37:L46")
        Case Craft
           Set ReturnRangeForBase = Range("D26:D32")
        Case Will
           Set ReturnRangeForBase = Range("D35:D41")
    End Select
End Function

Function ReturnNumberForBase(Characteristic As Characteristics, PlaceToPaste As Range) As Integer
    Select Case (Characteristic)
        Case Intellect
           ReturnNumberForBase = PlaceToPaste.Offset(6, 0).Value
        Case Reaction
           ReturnNumberForBase = PlaceToPaste.Offset(7, 0).Value
        Case Dexterity
           ReturnNumberForBase = PlaceToPaste.Offset(8, 0).Value
        Case Body
           ReturnNumberForBase = PlaceToPaste.Offset(9, 0).Value
        Case Empathy
           ReturnNumberForBase = PlaceToPaste.Offset(11, 0).Value
        Case Craft
           ReturnNumberForBase = PlaceToPaste.Offset(12, 0).Value
        Case Will
           ReturnNumberForBase = PlaceToPaste.Offset(13, 0).Value
    End Select
End Function

Function CopyFromToWithOffset(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, PlaceToPaste As Range, RowOfLastCopiedSkill As Integer, Characteristic As Characteristics, OffsetValue As Integer) As Integer
Dim CurrentCell As Range
Dim CopiyngValue As Integer
Dim CopiyngSkillName As String
CurrentCharacterWorkbook.Activate

For Each CurrentCell In ReturnRangeForBase(Characteristic)
    If Not IsEmpty(CurrentCell) Then
        CurrentCharacterWorkbook.Activate
        CopiyngValue = CurrentCell.Value
        CopiyngSkillName = CurrentCell.Offset(0, -OffsetValue).Value
        GameMasterWorkbook.Activate
        WorksheetWithCharacters.Activate
        Cells(RowOfLastCopiedSkill, 9).Value = CopiyngValue
        Cells(RowOfLastCopiedSkill, 9).HorizontalAlignment = xlLeft
        Cells(RowOfLastCopiedSkill, 8).Value = CopiyngSkillName
        Cells(RowOfLastCopiedSkill, 8).HorizontalAlignment = xlRight
        Cells(RowOfLastCopiedSkill, 7).Value = ReturnNumberForBase(Characteristic, PlaceToPaste)
        Cells(RowOfLastCopiedSkill, 7).HorizontalAlignment = xlLeft
        Cells(RowOfLastCopiedSkill, 6).Value = ReturnShortVersionOfCharacteristic(Characteristic)
        Cells(RowOfLastCopiedSkill, 6).HorizontalAlignment = xlRight
        CurrentCharacterWorkbook.Activate
        RowOfLastCopiedSkill = RowOfLastCopiedSkill + 1
    End If
Next

CopyFromToWithOffset = RowOfLastCopiedSkill
End Function


Function CopyProfessionFromTo(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, PlaceToPaste As Range, RowOfLastCopiedSkill As Integer) As Integer
Dim CurrentCell As Range: Set CurrentCell = Range("U39")
Dim CopiyngValue As Integer
Dim CopiyngSkillName As String
    
    
        CurrentCharacterWorkbook.Activate
        CopiyngValue = CurrentCell.Offset(0, 2).Value
        CopiyngSkillName = CurrentCell.Value
        GameMasterWorkbook.Activate
        WorksheetWithCharacters.Activate
        Cells(RowOfLastCopiedSkill, 9).Value = CopiyngValue
        Cells(RowOfLastCopiedSkill, 9).HorizontalAlignment = xlLeft
        Cells(RowOfLastCopiedSkill, 8).Value = CopiyngSkillName
        Cells(RowOfLastCopiedSkill, 8).HorizontalAlignment = xlRight
        CurrentCharacterWorkbook.Activate
        RowOfLastCopiedSkill = RowOfLastCopiedSkill + 1
    
CopyProfessionFromTo = RowOfLastCopiedSkill
End Function
