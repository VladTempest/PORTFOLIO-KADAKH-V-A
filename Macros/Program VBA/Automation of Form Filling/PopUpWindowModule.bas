Attribute VB_Name = "PopUpWindowModule"
Option Explicit
Function PopUpWindow(PopMessage As String, MyAction As Integer, AckTime As Integer, YesCoefficient As Double, NoCoefficient As Double) As Double
    Dim InfoBox As Object
Dim AckTimeNew As Integer
    Dim rsp As Integer
    '------------------------------------------------------------------------
    Set InfoBox = CreateObject("WScript.Shell")
    AckTimeNew = 2     ' number of seconds to wait
    '------------------------------------------------------------------------
    '- set the infobox buttons required
'    MyAction = 0   'OK only
    'MyAction = 1   'OK Cancel
'    MyAction = 2   'Abort,Retry,Ignore
'    MyAction = 3   'Yes,No,Cancel
'    MyAction = 4   'Yes,No
'    MyAction = 5   'Retry,Cancel
'    MyAction = 6   'Cancel,Try again, Continue
    '------------------------------------------------------------------------
    '- show infobox
     rsp = InfoBox.Popup(PopMessage, _
        AckTimeNew, Space(50) & "Выберите коэффициент", MyAction)
    '------------------------------------------------------------------------
    '- Respond to selection. Depends on available buttons.
    Select Case rsp
        Case -1
            PopUpWindow = YesCoefficient ' timed out
        '-
        Case vbOK
            PopUpWindow = YesCoefficient
        Case vbCancel: End
        Case vbAbort: MsgBox ("Abort")
        Case vbRetry: MsgBox ("Retry")
        Case vbIgnore: MsgBox ("Ignore")
        Case vbYes
            PopUpWindow = YesCoefficient
        Case vbNo
            PopUpWindow = NoCoefficient
        Case vbRetry: MsgBox ("Retry")
        Case 9: MsgBox ("9")             ' not used ?
        Case 10: MsgBox ("Try Again")
        Case 11: MsgBox ("Continue")
    End Select
    Application.SendKeys "{ENTER}"
End Function

