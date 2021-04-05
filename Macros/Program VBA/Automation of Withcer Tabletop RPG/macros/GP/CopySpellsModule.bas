Attribute VB_Name = "CopySpellsModule"
Option Explicit

Enum Spells
MagicSpell = 1
JinxSpell = 2
RitualSpell = 3

End Enum

Function ReturnRange(TypeOfSpell As Spells) As Range
    Select Case (TypeOfSpell)
        Case MagicSpell
           Set ReturnRange = Range("AX4:AX34")
        Case JinxSpell
           Set ReturnRange = Range("BG16:BG32")
        Case RitualSpell
           Set ReturnRange = Range("AX39:AX47")
    End Select
End Function






Function CopySpells(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, PlaceToPaste As Range) As Integer




Dim RowOfLastCopiedSpell As Integer

RowOfLastCopiedSpell = PlaceToPaste.Offset(22, -1).Row

RowOfLastCopiedSpell = CopySpellsFromRange(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, RowOfLastCopiedSpell, Spells.MagicSpell)
RowOfLastCopiedSpell = CopySpellsFromRange(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, RowOfLastCopiedSpell, Spells.JinxSpell)
RowOfLastCopiedSpell = CopySpellsFromRange(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, RowOfLastCopiedSpell, Spells.RitualSpell)

CopySpells = RowOfLastCopiedSpell
End Function

Function CopySpellsFromRange(CurrentCharacterWorkbook As Workbook, GameMasterWorkbook As Workbook, WorksheetWithCharacters As Worksheet, RowOfLastCopiedSpell As Integer, Spell As Spells) As Integer

Dim CurrentCell As Range

Dim CopiyngName As String: CopiyngName = "-"
Dim CopiyngPrice As String: CopiyngPrice = "-"
Dim CopiyngEffect As String: CopiyngEffect = "-"
Dim CopiyngSpellDistance As String: CopiyngSpellDistance = "-"
Dim CopiyngTime As String: CopiyngTime = "-"
Dim CopiyngDC As String: CopiyngDC = "-"
Dim CopiyngDuration As String: CopiyngDuration = "-"

CurrentCharacterWorkbook.Activate

For Each CurrentCell In ReturnRange(Spell)
    If Not IsEmpty(CurrentCell) Then
        CurrentCharacterWorkbook.Activate
        
        
        Select Case (Spell)
            Case MagicSpell
                CopiyngName = CurrentCell.Value
                CopiyngPrice = CurrentCell.Offset(0, 1).Value
                CopiyngEffect = CurrentCell.Offset(0, 2).Value
                CopiyngSpellDistance = CurrentCell.Offset(0, 3).Value
                CopiyngDuration = CurrentCell.Offset(0, 4).Value
            Case JinxSpell
                CopiyngName = CurrentCell.Value
                CopiyngPrice = CurrentCell.Offset(0, 1).Value
                CopiyngEffect = CurrentCell.Offset(0, 2).Value
            Case RitualSpell
                CopiyngName = CurrentCell.Value
                CopiyngPrice = CurrentCell.Offset(0, 1).Value
                CopiyngEffect = CurrentCell.Offset(0, 2).Value
                CopiyngTime = CurrentCell.Offset(0, 6).Value
                CopiyngDC = CurrentCell.Offset(0, 7).Value
                CopiyngDuration = CurrentCell.Offset(0, 9).Value
        End Select
        
        
        
        
        GameMasterWorkbook.Activate
        WorksheetWithCharacters.Activate
        Cells(RowOfLastCopiedSpell, 2).Value = CopiyngName
        Cells(RowOfLastCopiedSpell, 3).Value = CopiyngPrice + "/" + CopiyngTime
        Cells(RowOfLastCopiedSpell, 4).Value = CopiyngEffect
        Cells(RowOfLastCopiedSpell, 5).Value = CopiyngSpellDistance + "/" + CopiyngDuration + "/" + CopiyngDC
        CurrentCharacterWorkbook.Activate
        RowOfLastCopiedSpell = RowOfLastCopiedSpell + 1
    End If
Next
CopySpellsFromRange = RowOfLastCopiedSpell
End Function



