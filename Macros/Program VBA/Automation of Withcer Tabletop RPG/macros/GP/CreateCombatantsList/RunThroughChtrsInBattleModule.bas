Attribute VB_Name = "RunThroughChtrsInBattleModule"
Option Explicit

Sub RunThroughCharactersInBattle()
Dim CurrentNameCell As Range
Dim AllFightingCharacters As Range: Set AllFightingCharacters = Range("M5:M25")
Dim Modificator As String
Dim CharacterName As String
Dim CurrentCellToCopyTo As Range: Set CurrentCellToCopyTo = Range("A6")
For Each CurrentNameCell In AllFightingCharacters
    If Not (ReturnMiniTableRange(CurrentNameCell.Value) Is Nothing) Then
        Modificator = CurrentNameCell.Offset(0, 1).Value
        CharacterName = CurrentNameCell.Value
        ReturnMiniTableRange(CurrentNameCell.Value).Copy
        CurrentCellToCopyTo.PasteSpecial
        
        CurrentCellToCopyTo.Offset(1, 1).Value = CharacterName + " " + Modificator
        
        Set CurrentCellToCopyTo = CurrentCellToCopyTo.Offset(ReturnMiniTableRange(CurrentNameCell.Value).Rows.Count, 0)
        
    End If
Next


End Sub
