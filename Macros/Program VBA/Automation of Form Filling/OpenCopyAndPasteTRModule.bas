Attribute VB_Name = "OpenCopyAndPasteTRModule"
Option Explicit

Sub OpenCopyAndPasteTransformerList()
Dim AddressesRange As Range: Set AddressesRange = Selection
Dim AddressesCell As Range

Dim StartBook As Workbook: Set StartBook = ActiveWorkbook

Dim CurrentWorkbook As Workbook

Dim CurrentCellinAddresses As Range
Dim CurrentCellinPSForm As Range

Dim CopiedValue As String
Dim NumberOfOffset As Integer
For Each AddressesCell In AddressesRange

AddressesCell.Offset(0, 7).Activate
Set CurrentCellinAddresses = ActiveCell
    If Not AddressesCell.Rows.Hidden Then
        Workbooks.Open Filename:=AddressesCell.Value
        Set CurrentWorkbook = ActiveWorkbook
    
    
Set CurrentCellinPSForm = Application.Range("C106")
    
    Do While Not (CurrentCellinPSForm.Value = "   Прочие" Or IsEmpty(CurrentCellinPSForm))
        CopiedValue = CurrentCellinPSForm.Value
        StartBook.Activate
        CurrentCellinAddresses.Value = CopiedValue
        ActiveCell.Offset(0, 1).Activate
        Set CurrentCellinAddresses = ActiveCell
        CurrentWorkbook.Activate
        CurrentCellinPSForm.Offset(1, 0).Activate
        Set CurrentCellinPSForm = ActiveCell
    Loop
    
ActiveWorkbook.Close False
StartBook.Activate
End If
Next

End Sub
