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
Dim CharacterAddressesWorksheet As Worksheet: Set CharacterAddressesWorksheet = Worksheets("������")
Dim StartRow As Integer, CurrentRow As Integer
Dim GameMasterWorkbook As Workbook: Set GameMasterWorkbook = ActiveWorkbook
Dim WorksheetWithCharacters As Worksheet
Dim WorksheetWithTemplate As Worksheet: Set WorksheetWithTemplate = Worksheets("������")
Dim PlaceToPasteForPlayers As Range: Set PlaceToPasteForPlayers = Worksheets("������ ����������").Range("C2")
Dim PlaceToPasteForNPC As Range: Set PlaceToPasteForNPC = Worksheets("������ ���").Range("C2")
Dim SkillsTableLastRow As Integer: SkillsTableLastRow = 0
Dim SpellsTableLastRow As Integer: SpellsTableLastRow = 0
Dim CurrentCharacterWorkbook As Workbook

StartRow = ActiveCell.Row
CurrentRow = StartRow


Do Until EndOrStopColor(CurrentRow)
If Cells(CurrentRow, 1).Value = "����� �����" Then
    Set WorksheetWithCharacters = Worksheets("������ ����������")
    Workbooks.Open Filename:=Cells(CurrentRow, 4).Value
    Set CurrentCharacterWorkbook = ActiveWorkbook
    Call FirstBlocksCopyFromTo(GameMasterWorkbook, WorksheetWithCharacters, WorksheetWithTemplate, PlaceToPasteForPlayers, "����� �����")
    SkillsTableLastRow = CopyAllValidSkills(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    Call CopyLifePath(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    Call CopyFriendEnemiesFamily(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    SpellsTableLastRow = CopySpells(CurrentCharacterWorkbook, GameMasterWorkbook, WorksheetWithCharacters, PlaceToPasteForPlayers)
    'CurrentCharacterWorkbook.Close
    GameMasterWorkbook.Activate
    WorksheetWithCharacters.Activate
    Set PlaceToPasteForPlayers = Cells(Application.WorksheetFunction.Max(SpellsTableLastRow, SkillsTableLastRow) + 1, PlaceToPasteForPlayers.Column)
    
    
    
    
    
    
    
    
    
Else
    Set WorksheetWithCharacters = Worksheets("������ ���")
    Workbooks.Open Filename:=Cells(CurrentRow, 4).Value
    Set CurrentCharacterWorkbook = ActiveWorkbook
    Call FirstBlocksCopyFromTo(GameMasterWorkbook, WorksheetWithCharacters, WorksheetWithTemplate, PlaceToPasteForNPC, "���")
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
           ReturnShortVersionOfCharacteristic = "���"
        Case Reaction
           ReturnShortVersionOfCharacteristic = "���"
        Case Dexterity
           ReturnShortVersionOfCharacteristic = "���"
        Case Body
           ReturnShortVersionOfCharacteristic = "���"
        Case Speed
           ReturnShortVersionOfCharacteristic = "����"
        Case Empathy
           ReturnShortVersionOfCharacteristic = "���"
        Case Craft
           ReturnShortVersionOfCharacteristic = "���"
        Case Will
           ReturnShortVersionOfCharacteristic = "����"
        Case Luck
           ReturnShortVersionOfCharacteristic = "�����"
    End Select
End Function

