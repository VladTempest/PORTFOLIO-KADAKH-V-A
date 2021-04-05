Attribute VB_Name = "CopySkillsToTemplateModule"
Option Explicit

Function CopySkillsToTemplate(WorksheetCopyFrom As Worksheet, WorksheetCopyTo As Worksheet, FinalRow As Integer, StartCell As Range) As Integer
Dim CurrentCell As Range

Dim StartSkillCell As Range: Set StartSkillCell = StartCell

Dim SkillBaseName As String
Dim SkillBaseNumber As String
Dim SkillName As String
Dim SkillNumber As String

Dim NumberOfCopiedSkills As Integer: NumberOfCopiedSkills = 0

Set CurrentCell = Range("T" & (FinalRow + NumberOfCopiedSkills))

Do While Not IsEmpty(StartSkillCell.Offset(6, 5))
Debug.Print StartCell.Offset(6, 5).Address
    WorksheetCopyFrom.Activate
    If CheckIfSkillValid(StartSkillCell.Offset(6, 5).Value) Then
        SkillBaseName = StartSkillCell.Offset(6, 3).Value
        SkillBaseNumber = StartSkillCell.Offset(6, 4).Value
        SkillName = StartSkillCell.Offset(6, 5).Value
        SkillNumber = StartSkillCell.Offset(6, 6).Value
        
        WorksheetCopyTo.Activate
        Set CurrentCell = Range("T" & (FinalRow + NumberOfCopiedSkills))
        CurrentCell.Offset(6, 4) = SkillBaseName
        CurrentCell.Offset(6, 5) = SkillBaseNumber
        CurrentCell.Offset(6, 6) = SkillName
        CurrentCell.Offset(6, 7) = SkillNumber
        NumberOfCopiedSkills = NumberOfCopiedSkills + 1
    End If


    Set StartSkillCell = StartSkillCell.Offset(1, 0)
Loop


WorksheetCopyTo.Activate
CopySkillsToTemplate = FinalRow + NumberOfCopiedSkills + 5
End Function

Function CheckIfSkillValid(CurrentSkill) As Boolean

Dim ValidSkills As Variant
Dim InArray As Boolean: InArray = False
Dim i As Integer

ValidSkills = Array("Наведение" & Chr(10) & "порчи*", "Использование" & Chr(10) & "заклинаний*", _
"Сопротивление" & Chr(10) & "магии*", "Проведение" & Chr(10) & "ритуалов*", "Стрельба из лука", _
"Атлетика", "Стрельба" & Chr(10) & "из арбалета", "Сила", "Стойкость", "Борьба", "Уклонение/" & Chr(10) & "изворотливость", "Ближний бой" _
, "Владение" & Chr(10) & "легкими клинками", "Владение" & Chr(10) & "древковым оружием", "Владение мечом")

For i = LBound(ValidSkills) To UBound(ValidSkills)
    If ValidSkills(i) = CurrentSkill Then
                InArray = True
                Exit For
    End If
Next

CheckIfSkillValid = InArray
End Function
