Attribute VB_Name = "RoundToNormativeModule"
Option Explicit

Sub RoundToNormative()
Dim NotRoundedValueRange As Range: Set NotRoundedValueRange = Application.Range("G106:G112")
Dim NotRoundedValueCell As Range

For Each NotRoundedValueCell In NotRoundedValueRange
If Not IsEmpty(NotRoundedValueCell) Then
    NotRoundedValueCell.Value = RoundToNormativeValue(NotRoundedValueCell.Value)
End If
Next

End Sub


Function RoundToNormativeValue(ValueToRound As Double) As Double

    Dim VoltageIndex As Integer
    Dim DifferenceToNormativeValue As Double
    Dim NormativeValuesKVA As Variant, NormativeValuesMVA As Variant
    NormativeValuesKVA = Array(0.01, 0.016, 0.025, 0.04, 0.063, _
                               0.1, 0.16, 0.25, 0.4, 0.63, _
                               1, 1.6, 2.5, 4, 6.3 _
                                              , 10, 16, 25, 40, 63 _
                                                               , 100, 160, 250, 320, 400, 630, _
                               , 1000, 1600, 2500, 3200, 4000, 6300, _
                               , 10000, 16000, 25000, 32000, 40000, 63000, 80000 _
                                                                          , 100000, 125000, 160000, 200000, 250000, 400000, 500000, 630000, 800000 _
                                                                                                                                           , 1000000, 1250000, 1600000, 2000000, 2500000, 3150000, 4000000, 5000000, 6300000, 8000000)


    NormativeValuesMVA = NormativeValuesKVA
    For VoltageIndex = 0 To (GetArrLength(NormativeValuesKVA) - 1)
        NormativeValuesMVA(VoltageIndex) = CDbl(NormativeValuesKVA(VoltageIndex)) / 1000
    Next VoltageIndex

    For VoltageIndex = 0 To (GetArrLength(NormativeValuesMVA) - 1)
        DifferenceToNormativeValue = CDbl(NormativeValuesMVA(VoltageIndex)) - ValueToRound
        If DifferenceToNormativeValue >= 0 Then
            RoundToNormativeValue = CDbl(NormativeValuesMVA(VoltageIndex))
'            RoundToNormativeValue = PopUpWindow("Итоговая нагрузка " & ValueToRound & " МВ*А" & Chr$(13) & Chr$(10) & _
'            "округлена до нормативного значения: " & RoundToNormativeValue & " МВ*А" & _
'            Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 1, 2, RoundToNormativeValue, 0)
            Exit Function
        End If
    Next VoltageIndex
   
End Function

Public Function GetArrLength(a As Variant) As Long
   If IsEmpty(a) Then
      GetArrLength = 0
   Else
      GetArrLength = UBound(a) - LBound(a) + 1
   End If
End Function


