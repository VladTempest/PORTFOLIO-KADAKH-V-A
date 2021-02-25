Attribute VB_Name = "SumAndCopyAbsoluteModule"
Option Explicit

Sub SumAndCopyAbsolute()
Attribute SumAndCopyAbsolute.VB_ProcData.VB_Invoke_Func = "Û\n14"
Dim Total As Double
If TypeName(Selection) <> "Range" Then Exit Sub
Total = 0
Total = Application.Sum(Selection.SpecialCells(xlCellTypeVisible))
Total = Abs(Total)
With GetObject("New:{1C3B4210-F441-11CE-B9EA-00AA006B1A69}")
.SetText Total
.PutInClipboard
End With
End Sub
