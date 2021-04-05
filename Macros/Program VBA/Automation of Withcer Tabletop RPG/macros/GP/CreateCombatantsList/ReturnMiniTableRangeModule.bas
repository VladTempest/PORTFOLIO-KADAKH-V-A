Attribute VB_Name = "ReturnMiniTableRangeModule"
Option Explicit

Function ReturnMiniTableRange(CharacterName As String) As Range

Dim CharacterName As String: CharacterName = ActiveCell.Value
Dim FinalRange As Range
Dim UpperLeftCell As Range
Dim DownRightCell As Range
Dim CurrentSkillCell As Range

Dim LastRowSkill As Integer: LastRowSkill = 5
Dim LastRowTable As Integer: LastRowTable = 12

Range("U:U").Select
Set UpperLeftCell = Selection.Find(What:=CharacterName, After:=ActiveCell, LookIn:=xlFormulas, _
        LookAt:=xlWhole, SearchOrder:=xlByRows, SearchDirection:=xlNext, _
        MatchCase:=False, SearchFormat:=False)
Set UpperLeftCell = UpperLeftCell.Offset(-1, -1)


Set CurrentSkillCell = UpperLeftCell.Offset(5, 6)
Do While Not IsEmpty(CurrentSkillCell)
    LastRowSkill = LastRowSkill + 1
    Set CurrentSkillCell = CurrentSkillCell.Offset(1, 0)
Loop

Set DownRightCell = UpperLeftCell.Offset(WorksheetFunction.Max(LastRowSkill, LastRowTable), 9)
 
Set FinalRange = Range(UpperLeftCell.Address(RowAbsolute:=False, ColumnAbsolute:=False) & ":" & DownRightCell.Address(RowAbsolute:=False, ColumnAbsolute:=False))

ReturnMiniTableRange = FinalRange
End Function


