Attribute VB_Name = "RepositionTransformerSummModule"
Option Explicit

Sub RepositionTransformerSumm()

Dim AdressOfSumm95 As Range: Set AdressOfSumm95 = Application.Range("K95")
Dim StartAdressOfSumm105 As Range: Set StartAdressOfSumm105 = Application.Range("F105")
Dim FinalAdressOfSumm105 As Range: Set FinalAdressOfSumm105 = Application.Range("H105")

AdressOfSumm95.Formula = "=H105"
FinalAdressOfSumm105.Formula = "=SUM(F106:F110)"
StartAdressOfSumm105.Clear

End Sub
