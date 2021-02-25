Attribute VB_Name = "PasteFormuleModule"
Option Explicit

Function PasteFormule(TypeOfPS As Integer)

Dim PowerRange As Range: Set PowerRange = Application.Range("G106:G112")
Dim PowerCell As Range

Select Case TypeOfPS
    Case 1
        
        For Each PowerCell In PowerRange
        
            If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                PowerCell.Formula = "=J105" + "/(1*" + ReturnStringValueWithDot(ReturnLifeTimeCoefficient(PowerCell.Offset(0, -4))) + "*0.9)" + _
                "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
            End If
        Next
    Case 2
        
        For Each PowerCell In PowerRange
        
            If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                PowerCell.Formula = "=J105" + "/(" + ReturnStringValueWithDot(GetCoefficientKi(PowerCell)) + "*" + ReturnStringValueWithDot(ReturnLifeTimeCoefficient(PowerCell.Offset(0, -4))) + "*0.9)" + _
                "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
            End If
        Next
        
    Case 3
        For Each PowerCell In PowerRange
                If PowerCell.Row = 106 Or PowerCell.Row = 107 Then
                        If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                            PowerCell.Formula = "=(J106+J107)" + "/(1*" + ReturnStringValueWithDot(ReturnLifeTimeCoefficient(PowerCell.Offset(0, -4))) + "*0.9)" + _
                            "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
                        End If
        
                ElseIf PowerCell.Row = 108 Or PowerCell.Row = 109 Or PowerCell.Row = 110 Or PowerCell.Row = 111 Then
                        If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                            PowerCell.Formula = "=(J108+J109)" + "/(1*" + ReturnStringValueWithDot(ReturnLifeTimeCoefficient(PowerCell.Offset(0, -4))) + "*0.9)" + _
                            "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
                        End If
                
                End If
            Next
    Case 4
        
        For Each PowerCell In PowerRange
        
            If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                PowerCell.Formula = "=J105" + "/(0.9*" + "(1-" + ReturnStringValueWithDot(GetNominalVoltage(PowerCell.Offset(0, -4), "U_sn")) + "/" + ReturnStringValueWithDot(GetNominalVoltage(PowerCell.Offset(0, -4), "U_vn")) + ")" + ")" + _
                "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
            End If
        Next
        
        Case 5
            For Each PowerCell In PowerRange
                If PowerCell.Row = 106 Or PowerCell.Row = 107 Then
                        If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                            PowerCell.Formula = "=(J106+J107)" + "/(0.9*" + "(1-" + ReturnStringValueWithDot(GetNominalVoltage(PowerCell.Offset(0, -4), "U_sn")) + "/" + ReturnStringValueWithDot(GetNominalVoltage(PowerCell.Offset(0, -4), "U_vn")) + ")" + ")" + _
                            "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
                        End If
        
                ElseIf PowerCell.Row = 108 Or PowerCell.Row = 109 Or PowerCell.Row = 110 Or PowerCell.Row = 111 Then
                        If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                            PowerCell.Formula = "=(J108+J109)" + "/(1*" + ReturnStringValueWithDot(ReturnLifeTimeCoefficient(PowerCell.Offset(0, -4))) + "*0.9)" + _
                            "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
                        End If
                
                End If
            Next
        Case 6
        
        For Each PowerCell In PowerRange
        
            If Not IsEmpty(PowerCell.Offset(0, -1)) Then
                PowerCell.Formula = "=J105" + "/(" + ReturnStringValueWithDot(GetCoefficientKi(PowerCell)) + "*" + ReturnStringValueWithDot(ReturnLifeTimeCoefficient(PowerCell.Offset(0, -4))) + "*0.9)" + _
                "*" + ReturnStringValueWithDot(ReturnTerritoryCoefficient(Cells(95, 6).Value))
            End If
        Next
        
        
        
    End Select


End Function

Function ReturnStringValueWithDot(InputValue As Double) As String

ReturnStringValueWithDot = Replace(CStr(InputValue), ",", ".")
End Function
