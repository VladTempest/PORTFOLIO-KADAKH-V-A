Attribute VB_Name = "MainCopyCharacterInfoModule"
Option Explicit


Enum Characteristics
Intellect = 1
Reaction = 2
Dexterity = 3
Body = 4
Speed = 5
Empathy = 6
Craft = 7
Will = 8
Luck = 9
End Enum

Enum ParameterBlocks
MainInfoBlock = 1
HealthBlock = 2
MainCharacteristicsBlock = 3
DerivedCharacteristicsBlock = 4
BaseSkillsBlock = 5
SkillsBlock = 6
MainWeaponsBlock = 7
MagicBlock = 8
FamilyInfoBlock = 9
FriendsEnemiesBlock = 10
LifePathInfoBlock = 11
End Enum


Sub MainCopyCharacterInfo()
Dim CharacterAddressesWorksheet As Worksheet: Set CharacterAddressesWorksheet = Worksheets("Адреса")
Dim StartRow As Integer, CurrentRow As Integer
Dim GameMasterWorkbook As Workbook: Set GameMasterWorkbook = ActiveWorkbook
Dim WorksheetWithCharacters As Worksheet
Dim WorksheetWithTemplate As Worksheet: Set WorksheetWithTemplate = Worksheets("шаблон")
Dim PlaceToPasteForPlayers As Range: Set PlaceToPasteForPlayers = Worksheets("Список персонажей").Range("C2")
Dim PlaceToPasteForNPC As Range: Set PlaceToPasteForNPC = Worksheets("Список НПЦ").Range("C2")
Dim SkillsTableLastRow As Integer: SkillsTableLastRow = 0
Dim SpellsTableLastRow As Integer: SpellsTableLastRow = 0
Dim CurrentCharacterWorkbook As Workbook

StartRow = ActiveCell.Row
CurrentRow = StartRow


Do Until EndOrStopColor(CurrentRow)
If Cells(CurrentRow, 1).Value = "Живой игрок" Then
    Set WorksheetWithCharacters = Worksheets("Список персонажей")
    Workbooks.Open Filename:=Cells(CurrentRow, 4).Value
    Set CurrentCharacterWorkbook = ActiveWorkbook
    Call FirstBlocksCopyFromTo(GameMasterWorkbook, WorksheetWithCharacters, WorksheetWithTemplate, PlaceToPasteForPlayers, "Живой игрок")
    SkillsTableLastRow = CopyAllValidSkills(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    Call CopyLifePath(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    Call CopyFriendEnemiesFamily(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    SpellsTableLastRow = CopySpells(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    'CurrentCharacterWorkbook.Close
    GameMasterWorkbook.Activate
    WorksheetWithCharacters.Activate
    Set PlaceToPasteForPlayers = Cells(Application.WorksheetFunction.Max(SpellsTableLastRow, SkillsTableLastRow) + 1, PlaceToPasteForPlayers.Column)
    
    
    
    
    
    
    
    
    
Else
    Set WorksheetWithCharacters = Worksheets("Список НПЦ")
    Workbooks.Open Filename:=Cells(CurrentRow, 4).Value
    Set CurrentCharacterWorkbook = ActiveWorkbook
    Call FirstBlocksCopyFromTo(GameMasterWorkbook, WorksheetWithCharacters, WorksheetWithTemplate, PlaceToPasteForNPC, "НПЦ")
    SkillsTableLastRow = CopyAllValidSkills(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForNPC)
    SpellsTableLastRow = CopySpells(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForNPC)
    GameMasterWorkbook.Activate
    WorksheetWithCharacters.Activate
    Set PlaceToPasteForNPC = Cells(Application.WorksheetFunction.Max(SpellsTableLastRow, SkillsTableLastRow) + 1, PlaceToPasteForPlayers.Column)
End If

    CharacterAddressesWorksheet.Activate
    CurrentRow = CurrentRow + 1
Loop
End Sub








Function EndOrStopColor(CurrentRow As Integer) As Boolean

EndOrStopColor = IsEmpty(Cells(CurrentRow, 3)) Or Cells(CurrentRow, 3).Interior.Color = vbYellow

End Function

Function ReturnShortVersionOfCharacteristic(Characteristic As Characteristics) As String
    Select Case (Characteristic)
        Case Intellect
           ReturnShortVersionOfCharacteristic = "ИНТ"
        Case Reaction
           ReturnShortVersionOfCharacteristic = "РЕА"
        Case Dexterity
           ReturnShortVersionOfCharacteristic = "ЛВК"
        Case Body
           ReturnShortVersionOfCharacteristic = "ТЕЛ"
        Case Speed
           ReturnShortVersionOfCharacteristic = "СКОР"
        Case Empathy
           ReturnShortVersionOfCharacteristic = "ЭМП"
        Case Craft
           ReturnShortVersionOfCharacteristic = "РЕМ"
        Case Will
           ReturnShortVersionOfCharacteristic = "ВОЛЯ"
        Case Luck
           ReturnShortVersionOfCharacteristic = "УДАЧА"
    End Select
End Function

