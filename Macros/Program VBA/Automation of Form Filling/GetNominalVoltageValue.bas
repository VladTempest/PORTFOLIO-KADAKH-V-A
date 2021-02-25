Attribute VB_Name = "GetNominalVoltageValue"
Option Explicit

Function GetNominalVoltage(StartCell As Range, TypeOfVoltage As String) As Double


Dim ColummnOfNecessaryVoltage As Integer

Dim StartBook As Workbook
Dim StartSheet As Worksheet
Dim FirstStartCell As Range

Set StartBook = ActiveWorkbook
Set StartSheet = ActiveSheet
Set FirstStartCell = ActiveCell

Dim TransformerStationCoupling As String
Dim FileWithVoltageValues As String
FileWithVoltageValues = "Приложение_13_-_ТД_по_ПС(мод) .xls"


Dim RowOfFoundCoupling As Integer
Dim ColumnOfFoundCoupling As Integer: ColumnOfFoundCoupling = 1


Select Case TypeOfVoltage
Case "U_vn"
    ColummnOfNecessaryVoltage = 14
Case "U_sn"
    ColummnOfNecessaryVoltage = 15
End Select



TransformerStationCoupling = Cells(95, 3).Value + StartCell.Value

Workbooks(FileWithVoltageValues).Activate

TransformerStationCoupling = Replace(TransformerStationCoupling, " ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, Chr(10), "")

TransformerStationCoupling = Replace(TransformerStationCoupling, "-", "")

TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС 35 кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС35кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС 110 кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС110кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС 220 кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС220кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС 10 кВ", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, "ПС10кВ", "")

TransformerStationCoupling = Replace(TransformerStationCoupling, "VI", "6")
TransformerStationCoupling = Replace(TransformerStationCoupling, "V", "5")
TransformerStationCoupling = Replace(TransformerStationCoupling, "IV", "4")
TransformerStationCoupling = Replace(TransformerStationCoupling, "III", "3")
TransformerStationCoupling = Replace(TransformerStationCoupling, "II", "2")
TransformerStationCoupling = Replace(TransformerStationCoupling, "I", "1")

TransformerStationCoupling = Replace(TransformerStationCoupling, "ё", "е")
TransformerStationCoupling = Replace(TransformerStationCoupling, "Ё", "е")

TransformerStationCoupling = Replace(TransformerStationCoupling, ".", "")
TransformerStationCoupling = Replace(TransformerStationCoupling, ",", "")



Workbooks(FileWithVoltageValues).Activate

If IsThereResultOfSearch(ActiveWorkbook.ActiveSheet.Columns("A:A").Find(TransformerStationCoupling, LookIn:=xlValues)) Then
    RowOfFoundCoupling = ActiveWorkbook.ActiveSheet.Columns("A:A").Find(TransformerStationCoupling, LookIn:=xlValues).Row
    GetNominalVoltage = Cells(RowOfFoundCoupling, ColummnOfNecessaryVoltage).Value
Else
     GetNominalVoltage = 666420
End If


If GetNominalVoltage = 666420 Then
        GetNominalVoltage = PopUpWindow("Не найден трансформатор " & TransformerStationCoupling & "." & Chr$(13) & Chr$(10) & _
        " Да - если использовать значение 230 по умолчанию," & Chr$(13) & Chr$(10) & _
        "Нет - если взять 110" _
        & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 230, 110)
        StartBook.Activate
        StartSheet.Activate
        FirstStartCell.Activate
        
        Exit Function
End If
StartBook.Activate
StartSheet.Activate
FirstStartCell.Activate
        
End Function


