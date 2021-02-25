Attribute VB_Name = "PasteInColumn11Module"
Option Explicit

Sub PasteInColumn11()
Attribute PasteInColumn11.VB_ProcData.VB_Invoke_Func = "Â\n14"
Dim CopiedValue As String
Application.Range("P105").Activate
ActiveCell.Interior.Color = xlNone
With GetObject("New:{1C3B4210-F441-11CE-B9EA-00AA006B1A69}")
        .GetFromClipboard
        CopiedValue = .GetText
        'MsgBox m
End With
ActiveCell.Value = CDbl(CopiedValue)
End Sub
