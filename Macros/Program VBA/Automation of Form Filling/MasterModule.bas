Attribute VB_Name = "MasterModule"
Option Explicit

Function Master(TypeOfPS As Integer, SkipDivideNRound As Boolean)
Attribute Master.VB_ProcData.VB_Invoke_Func = "Й\n14"
'    Dim MyFSO As FileSystemObject
'    Set MyFSO = New FileSystemObject
    Dim MyFSO As Object
    Set MyFSO = CreateObject("Scripting.FileSystemObject")
    'Потом поменять один вид объявления на другой

    Dim CurrentFile As Workbook
    Set CurrentFile = ActiveWorkbook

    Dim PathForNotRounded As String
    PathForNotRounded = CurrentFile.Path & "\" & "Неокругленные"

    Dim PathForRounded As String
    PathForRounded = CurrentFile.Path & "\" & "Округленные"

Call RepositionTransformerSumm
Call DeleteEmptyInstanceInTransformerList
If Not SkipDivideNRound Then
        Call DevideNRound(TypeOfPS)
End If
'Application.Wait Now + TimeValue("0:00:2")
Call PasteFormule(TypeOfPS)
'Application.Wait Now + TimeValue("0:00:2")

Application.DisplayAlerts = False
ActiveWorkbook.Save
Application.DisplayAlerts = True

Call CreateEntityWithExistenceCheck(CurrentFile, PathForNotRounded, "Folder")
Call CreateEntityWithExistenceCheck(CurrentFile, PathForNotRounded, "File")



Call RoundToNormative
'Application.Wait Now + TimeValue("0:00:2")
Call GetPercentValue
'Application.Wait Now + TimeValue("0:00:2")
Application.DisplayAlerts = False
ActiveWorkbook.Save
Application.DisplayAlerts = True
Call CreateEntityWithExistenceCheck(CurrentFile, PathForRounded, "Folder")
Call CreateEntityWithExistenceCheck(CurrentFile, PathForRounded, "File")
    




End Function



Function CreateEntityWithExistenceCheck(CurrentFile As Workbook, CreationPath As String, EntityType As String)

    Dim MyFSO As FileSystemObject
    Set MyFSO = New FileSystemObject

    Select Case EntityType
    Case "Folder"
        If Not MyFSO.FolderExists(CreationPath) Then
            MyFSO.CreateFolder (CreationPath)
        End If
    Case "File"
        If Dir(CurrentFile.Path & "\" & CurrentFile.Name) <> "" Then
            MyFSO.CopyFile CurrentFile.Path & "\" & CurrentFile.Name, CreationPath & "\", True
        End If
    Case Else
        Debug.Print "Not a case: " & EntityType
    End Select
End Function

Function ReturnTerritoryCoefficient(NameOfTerritory As String) As Double
Select Case NameOfTerritory
    Case "Московская область"
        ReturnTerritoryCoefficient = 1.01
'        ReturnTerritoryCoefficient = PopUpWindow("Коэффициент подобран 1.01 Московская область." & Chr$(13) & Chr$(10) & _
'        " Да - если оставить 1.01," & Chr$(13) & Chr$(10) & _
'        "Нет - если взять 1" _
'        & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 1.01, 1)
        Exit Function
    Case "Москва"
        ReturnTerritoryCoefficient = 1
'         ReturnTerritoryCoefficient = PopUpWindow("Коэффициент подобран 1 Москва." & Chr$(13) & Chr$(10) & _
'         " Да - если оставить 1," & Chr$(13) & Chr$(10) & _
'         "Нет - если взять 1.01" _
'         & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 1, 1.01)
        Exit Function
    Case Else
        MsgBox "Нет коэффициента для области: " & NameOfTerritory
End Select
End Function

Function ReturnLifeTimeCoefficient(StartCell As Range) As Double
Dim StartBook As Workbook
Dim StartSheet As Worksheet
Dim FirstStartCell As Range

Set StartBook = ActiveWorkbook
Set StartSheet = ActiveSheet
Set FirstStartCell = ActiveCell

Dim LifeTimeDifference As Integer
Dim LifeTimeFromGISTEKForm As Integer
Dim TransformerStationCoupling As String
Dim FileWithLifeTimeValues As String
FileWithLifeTimeValues = "Приложение_13_-_ТД_по_ПС(мод) .xls"


Dim RowOfFoundCoupling As Integer
Dim ColumnOfFoundCoupling As Integer


TransformerStationCoupling = Cells(95, 3).Value + StartCell.Value

Workbooks(FileWithLifeTimeValues).Activate

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



Workbooks(FileWithLifeTimeValues).Activate
ColumnOfFoundCoupling = 1


If IsThereResultOfSearch(ActiveWorkbook.ActiveSheet.Columns("A:A").Find(TransformerStationCoupling, LookIn:=xlValues)) Then
    RowOfFoundCoupling = ActiveWorkbook.ActiveSheet.Columns("A:A").Find(TransformerStationCoupling, LookIn:=xlValues).Row
    LifeTimeFromGISTEKForm = Cells(RowOfFoundCoupling, ColumnOfFoundCoupling).Offset(0, 7).Value
    LifeTimeDifference = 2021 - LifeTimeFromGISTEKForm
    'Debug.Print LifeTimeDifference
    'Debug.Print RowOfFoundCoupling
Else
    LifeTimeDifference = 32767
End If



Select Case LifeTimeDifference
    Case 0 To 29
        ReturnLifeTimeCoefficient = 1.3
'        ReturnLifeTimeCoefficient = PopUpWindow(LifeTimeFromGISTEKForm & " - Коэффициент подобран 1.3 срок службы менее 30 лет." _
'        & Chr$(13) & Chr$(10) & "Да - если оставить 1.3," & Chr$(13) & Chr$(10) & _
'        "Нет - если взять 1" _
'        & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 1.3, 1)
        StartBook.Activate
        StartSheet.Activate
        FirstStartCell.Activate
        Exit Function
    Case 30 To 1000
        ReturnLifeTimeCoefficient = 1
'        ReturnLifeTimeCoefficient = PopUpWindow(LifeTimeFromGISTEKForm & " - Коэффициент подобран 1 срок службы 30 и более лет." & Chr$(13) & Chr$(10) & _
'        " Да - если оставить 1," & Chr$(13) & Chr$(10) & _
'        "Нет - если взять 1.3" _
'        & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 1, 1.3)
        StartBook.Activate
          StartSheet.Activate
        FirstStartCell.Activate
        
        Exit Function
    Case 32767
        ReturnLifeTimeCoefficient = PopUpWindow("Трансформатор по сцепке " & TransformerStationCoupling & " не найден." & Chr$(13) & Chr$(10) & _
        " Да - если использовать значение 1.3 по умолчанию," & Chr$(13) & Chr$(10) & _
        "Нет - если взять 1" _
        & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 1.3, 1)
        StartBook.Activate
          StartSheet.Activate
        FirstStartCell.Activate
        
        Exit Function
    Case Else
        ReturnLifeTimeCoefficient = PopUpWindow("Неверный срок службы " & LifeTimeDifference & "." & Chr$(13) & Chr$(10) & _
        " Да - если использовать значение 1.3 по умолчанию," & Chr$(13) & Chr$(10) & _
        "Нет - если взять 1" _
        & Chr$(13) & Chr$(10) & "Нажмите Отмена для остановки работы макроса", 3, 2, 1.3, 1)
        StartBook.Activate
        StartSheet.Activate
        FirstStartCell.Activate
        
        Exit Function
End Select
StartBook.Activate
StartSheet.Activate
FirstStartCell.Activate
        
End Function

Function IsThereResultOfSearch(ReturnedFromSearchValue) As Boolean

If ReturnedFromSearchValue Is Nothing Then
    IsThereResultOfSearch = False
    Exit Function
Else
    IsThereResultOfSearch = True
    Exit Function
End If
End Function
