Attribute VB_Name = "MasterMacroStrippedModule"
Option Explicit

Sub MasterMacroStripped()

Dim TypeOfPS As Integer
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


'Call DevideNRound(TypeOfPS)
'Application.Wait Now + TimeValue("0:00:2")
Call GetSummOfColumns6_13
Call PasteFormule(1)
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
    





End Sub


