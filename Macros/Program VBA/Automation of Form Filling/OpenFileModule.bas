Attribute VB_Name = "OpenFileModule"
Option Explicit

Sub OpenFile()
Attribute OpenFile.VB_ProcData.VB_Invoke_Func = "Ö\n14"
Dim copiedFile As String

copiedFile = ActiveCell.Value

'ActiveCell.Offset(ReturnFirstUnhiddenRow(ActiveCell), 0).Interior.Color = vbRed
Debug.Print -ReturnFirstUnhiddenRow(ActiveCell)
ActiveCell.Interior.Color = vbYellow


ActiveCell.Offset(-ReturnFirstUnhiddenRow(ActiveCell), 0).Activate
Workbooks.Open Filename:=copiedFile
End Sub


Function ReturnFirstUnhiddenRow(CurrentCell As Range) As Integer

Dim FirstUnHiddenCllOffset As Integer
FirstUnHiddenCllOffset = 1
Do While CurrentCell.Offset(-FirstUnHiddenCllOffset, 0).Rows.Hidden
FirstUnHiddenCllOffset = FirstUnHiddenCllOffset + 1
Loop

ReturnFirstUnhiddenRow = FirstUnHiddenCllOffset
End Function
