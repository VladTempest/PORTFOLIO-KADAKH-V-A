Attribute VB_Name = "ChooseYourPSTypeModule"
Option Explicit

Sub ChooseYourPowerStationType()
Attribute ChooseYourPowerStationType.VB_ProcData.VB_Invoke_Func = "Й\n14"
Dim ChooseTypeForm As ChooseTypeOfFormForm
Dim SkipDevideNRound As Boolean
Dim TypeOfPS As Integer

Set ChooseTypeForm = New ChooseTypeOfFormForm

ChooseTypeForm.Caption = "Выбрать тип формы"
ChooseTypeForm.Show
Select Case ChooseTypeForm.Tag
    Case 1
        SkipDevideNRound = CheckCheckBox(ChooseTypeForm)
        TypeOfPS = 1
    Case 2
        SkipDevideNRound = CheckCheckBox(ChooseTypeForm)
        TypeOfPS = 2
    Case 3
        SkipDevideNRound = CheckCheckBox(ChooseTypeForm)
        TypeOfPS = 3
    Case 4
        SkipDevideNRound = CheckCheckBox(ChooseTypeForm)
        TypeOfPS = 4
    Case 5
        SkipDevideNRound = CheckCheckBox(ChooseTypeForm)
        TypeOfPS = 5
    Case 6
        SkipDevideNRound = CheckCheckBox(ChooseTypeForm)
        TypeOfPS = 6
End Select

Call Master(TypeOfPS, SkipDevideNRound)



Unload ChooseTypeForm
Set ChooseTypeForm = Nothing
End Sub

Function CheckCheckBox(ChooseTypeForm) As Boolean

CheckCheckBox = ChooseTypeForm.SkippDevideNRound.Value
End Function
