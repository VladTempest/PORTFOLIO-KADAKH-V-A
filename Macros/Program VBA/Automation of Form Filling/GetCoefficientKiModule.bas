Attribute VB_Name = "GetCoefficientKiModule"
Option Explicit

Function GetCoefficientKi(CurrentCell As Range) As Double
Dim GetCoefficientKiValue As Double
Dim StartCellForArray As Range: Set StartCellForArray = Application.Range("F106")
Dim TransformerPower As Variant
Dim TransformerIndex As Integer
TransformerPower = Array(0, 0, 0, 0)

For TransformerIndex = 0 To (GetArrLength(TransformerPower) - 1)
        TransformerPower(TransformerIndex) = CDbl(StartCellForArray.Offset(TransformerIndex, 0))
Next TransformerIndex

TransformerPower(CurrentCell.Row - 106) = 0

 
GetCoefficientKi = (Summa(TransformerPower) - Maximum(TransformerPower) + CurrentCell.Offset(0, -1).Value) / CurrentCell.Offset(0, -1).Value



End Function


Function Maximum(arr) As Double
Maximum = Application.WorksheetFunction.Max(arr)
End Function

Function Summa(arr) As Double
Summa = Application.WorksheetFunction.Sum(arr)
End Function
