Attribute VB_Name = "DivideNRoundModule"
Option Explicit

Function DevideNRound(TypeOfPS As Integer)
Dim LoadCell As Range
Dim LoadRange As Range: Set LoadRange = Application.Range("K105:R105")


        For Each LoadCell In LoadRange.Cells
            
            If Not IsEmpty(LoadCell) Then
                
                Call DevideRoundReplace(LoadCell, TypeOfPS)
            End If
            If LoadCell.Value = 0 Then
                LoadCell.Clear
            End If
        Next
    
ActiveWorkbook.ActiveSheet.Cells(105, 10).Activate
Call GetSummOfColumns6_13

End Function


Function DevideRoundReplace(StartCell As Range, TypeOfPS As Integer)
Dim StartCellValue As Double
Dim DevidedValue As Double

Dim ValueForFirstCouple As Double
Dim ValueForSecondCouple As Double

StartCell.Activate
StartCellValue = StartCell.Value


Select Case TypeOfPS
Case 1, 4
    StartCell.Offset(1, 0).Value = Format(StartCell / 2, "0.00")
    StartCell.Offset(1, 0).Value = CDbl(StartCell.Offset(1, 0).Value)
    
    StartCell.Offset(2, 0).Value = Format(StartCell / 2, "0.00")
    StartCell.Offset(2, 0).Value = CDbl(StartCell.Offset(2, 0).Value)
    
    StartCell.Value = Format(CDbl(StartCell.Offset(1, 0).Value) + CDbl(StartCell.Offset(2, 0).Value), "0.00")
    StartCell.Value = CDbl(StartCell.Value)
Case 2
    StartCell.Offset(1, 0).Value = Format(StartCell / 3, "0.00")
    StartCell.Offset(1, 0).Value = CDbl(StartCell.Offset(1, 0).Value)
    
    StartCell.Offset(2, 0).Value = Format(StartCell / 3, "0.00")
    StartCell.Offset(2, 0).Value = CDbl(StartCell.Offset(2, 0).Value)
    
    StartCell.Offset(3, 0).Value = Format(StartCell / 3, "0.00")
    StartCell.Offset(3, 0).Value = CDbl(StartCell.Offset(3, 0).Value)
    
    StartCell.Value = Format(CDbl(StartCell.Offset(1, 0).Value) + CDbl(StartCell.Offset(2, 0).Value) + CDbl(StartCell.Offset(3, 0).Value), "0.00")
    StartCell.Value = CDbl(StartCell.Value)
Case 3, 5
    ValueForFirstCouple = StartCell.Offset(1, 0).Value
    ValueForSecondCouple = StartCell.Offset(2, 0).Value
    
    StartCell.Offset(1, 0).Value = Format(ValueForFirstCouple / 2, "0.00")
    StartCell.Offset(1, 0).Value = CDbl(StartCell.Offset(1, 0).Value)
    StartCell.Offset(2, 0).Value = Format(ValueForFirstCouple / 2, "0.00")
    StartCell.Offset(2, 0).Value = CDbl(StartCell.Offset(2, 0).Value)
    
    StartCell.Offset(3, 0).Value = Format(ValueForSecondCouple / 2, "0.00")
    StartCell.Offset(3, 0).Value = CDbl(StartCell.Offset(3, 0).Value)
    StartCell.Offset(4, 0).Value = Format(ValueForSecondCouple / 2, "0.00")
    StartCell.Offset(4, 0).Value = CDbl(StartCell.Offset(4, 0).Value)
    
    StartCell.Value = Format(CDbl(StartCell.Offset(1, 0).Value) + CDbl(StartCell.Offset(2, 0).Value) + CDbl(StartCell.Offset(3, 0).Value) + CDbl(StartCell.Offset(4, 0).Value), "0.00")
    StartCell.Value = CDbl(StartCell.Value)
  Case 6
    StartCell.Offset(1, 0).Value = Format(StartCell / 4, "0.00")
    StartCell.Offset(1, 0).Value = CDbl(StartCell.Offset(1, 0).Value)
    
    StartCell.Offset(2, 0).Value = Format(StartCell / 4, "0.00")
    StartCell.Offset(2, 0).Value = CDbl(StartCell.Offset(2, 0).Value)
    
    StartCell.Offset(3, 0).Value = Format(StartCell / 4, "0.00")
    StartCell.Offset(3, 0).Value = CDbl(StartCell.Offset(3, 0).Value)
    
    StartCell.Offset(4, 0).Value = Format(StartCell / 4, "0.00")
    StartCell.Offset(4, 0).Value = CDbl(StartCell.Offset(4, 0).Value)
    
    StartCell.Value = Format(CDbl(StartCell.Offset(1, 0).Value) + CDbl(StartCell.Offset(2, 0).Value) + CDbl(StartCell.Offset(3, 0).Value + CDbl(StartCell.Offset(2, 0).Value)), "0.00")
    StartCell.Value = CDbl(StartCell.Value)
End Select
End Function
