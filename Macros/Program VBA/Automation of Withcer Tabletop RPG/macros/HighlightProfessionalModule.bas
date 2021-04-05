Attribute VB_Name = "HighlightProfessionalModule"
Sub HighlightProfessionalSkills()

Dim ProfessionCell As Range: Set ProfessionCell = Application.Range("D8")
Dim Profession As String
Dim CurrentSkill As Range: Set CurrentSkill = ActiveCell
Dim FoundedProfessionRange As Range
Dim ActiveSkill As Range
Dim SkillCells As Range: Set SkillCells = Range("B25:S4")
Dim WorksheetProfession As Worksheet: Set WorksheetProfession = Worksheets("Проф. навыки&Снаряжение")
Dim WorksheetSkills As Worksheet: Set WorksheetSkills = Worksheets("ЛИСТ ПЕРСОНАЖА")

Dim AllSkillsSet As Range: Set AllSkillsSet = WorksheetProfession.Range("A7:I22")



Profession = WorksheetSkills.Cells(ProfessionCell.Row, ProfessionCell.Column).Value

Set FoundedProfessionRange = WorksheetProfession.Cells.Find(Profession)

For Each CurrentSkill In AllSkillsSet

    If (CurrentSkill.Column = FoundedProfessionRange.Column And CurrentSkill.Interior.Color = vbYellow) Then
                Debug.Print CurrentSkill.Value
                WorksheetSkills.Activate
                Range("B15:AB48").Find(CurrentSkill.Value, LookIn:=xlValues).Font.Bold = True
                
                
    End If


Next

'Debug.Print FoundedProfessionRange = Cells.Find(WorksheetSkills.Cells(ProfessionCell.Row, ProfessionCell.Column).Value, LookIn:=xlValues)

'WorksheetProfession.Cells.Find(CurrentSkill.Value, LookIn:=xlValues).Address




End Sub


