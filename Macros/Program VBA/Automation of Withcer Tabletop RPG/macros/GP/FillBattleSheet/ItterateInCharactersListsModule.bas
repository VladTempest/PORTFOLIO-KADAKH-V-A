Attribute VB_Name = "ItterateInCharactersListsModule"
Option Explicit

Sub ItterateInCharactersLists()

Dim NPCWorksheet As Worksheet: Set NPCWorksheet = Worksheets("Список НПЦ")
Dim PlayersWorksheet As Worksheet: Set PlayersWorksheet = Worksheets("Список персонажей")
Dim BattleWorksheet As Worksheet: Set BattleWorksheet = Worksheets("Бой")
Dim FinalRow As Integer: FinalRow = 5

FinalRow = ItterateInWorksheets(PlayersWorksheet, BattleWorksheet, FinalRow)
FinalRow = ItterateInWorksheets(NPCWorksheet, BattleWorksheet, FinalRow)

End Sub

Function ItterateInWorksheets(WorksheetCopyFrom As Worksheet, WorksheetCopyTo As Worksheet, FinalRow As Integer) As Integer

WorksheetCopyFrom.Activate

Dim StartCell As Range: Set StartCell = WorksheetCopyFrom.Range("C2")
Dim NumberOfEmptyCells As Integer: NumberOfEmptyCells = 0
Dim FinalRowSkill As Integer: FinalRowSkill = FinalRow
Dim FinalRowTemplate As Integer


Do While NumberOfEmptyCells < 6

If StartCell.Offset(0, -1) = "Живой игрок" Then
    CopyTemplate (FinalRow)
    FinalRowTemplate = FinalRow + 10
    Call CopyMainDataToTemplate(WorksheetCopyFrom, WorksheetCopyTo, FinalRow, StartCell)
    FinalRowSkill = CopySkillsToTemplate(WorksheetCopyFrom, WorksheetCopyTo, FinalRow, StartCell)
    
    
    
    FinalRow = WorksheetFunction.Max(FinalRowTemplate, FinalRowSkill) + 3
End If
If IsEmpty(StartCell.Offset(-1, 0)) Then
  NumberOfEmptyCells = NumberOfEmptyCells + 1
Else
  NumberOfEmptyCells = 0
End If

Set StartCell = StartCell.Offset(1, 0)

Loop

ItterateInWorksheets = FinalRow
End Function


Function CopyTemplate(FinalRow)
Dim BattleWorksheet As Worksheet: Set BattleWorksheet = Worksheets("Бой")
Dim TemplateWorksheet As Worksheet: Set TemplateWorksheet = Worksheets("шаблон")
Dim TemplateRange As Range: Set TemplateRange = TemplateWorksheet.Range("B31:K42")

TemplateWorksheet.Activate
TemplateRange.Copy
BattleWorksheet.Activate
Range("T" & FinalRow).PasteSpecial (xlPasteAll)

End Function



Function CopySkillsAndBaseDataToTemplate(WorksheetCopyFrom As Worksheet, WorksheetCopyTo As Worksheet, FinalRow As Integer, StartCell As Range) As Integer



End Function
