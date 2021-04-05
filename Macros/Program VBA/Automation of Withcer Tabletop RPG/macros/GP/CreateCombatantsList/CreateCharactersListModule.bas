Attribute VB_Name = "CreateCharactersListModule"
Option Explicit
Sub CreateCharactersList()

Dim StartCell As Range: Set StartCell = Range("U5")
Dim NumberOfEmptyCells As Integer: NumberOfEmptyCells = 0
Dim CharacterName As String
Dim CurrentCellName As Range: Set CurrentCellName = Range("O6")

Do While NumberOfEmptyCells < 6
    If StartCell.Offset(0, -1) = "Живой игрок" Then
        CharacterName = StartCell.Offset(1, 0).Value
        CurrentCellName.Value = CharacterName
        Set CurrentCellName = CurrentCellName.Offset(1, 0)
    End If
    If IsEmpty(StartCell.Offset(-1, 0)) Then
      NumberOfEmptyCells = NumberOfEmptyCells + 1
    Else
      NumberOfEmptyCells = 0
    End If
    Set StartCell = StartCell.Offset(1, 0)
Loop

End Sub

