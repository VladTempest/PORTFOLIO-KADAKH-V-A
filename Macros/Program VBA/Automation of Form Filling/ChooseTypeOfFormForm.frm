VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} ChooseTypeOfFormForm 
   Caption         =   "ChooseTypeOfForm"
   ClientHeight    =   2415
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   5700
   OleObjectBlob   =   "ChooseTypeOfFormForm.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "ChooseTypeOfFormForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub FourT_equality_Click()
Me.Tag = 6
  Me.Hide
End Sub

Private Sub SkippDevideNRound_Click()

End Sub

Private Sub TwoAT_Plus_TwoTButton_Click()
Me.Tag = 5
Me.Hide
End Sub

Private Sub TwoATRButton_Click()
Me.Tag = 4
  Me.Hide
End Sub
Private Sub FourTButton_Click()
Me.Tag = 3
  Me.Hide
End Sub

Private Sub ThreeTButton_Click()
Me.Tag = 2
  Me.Hide
End Sub

Private Sub TwoTButton_Click()
Me.Tag = 1
Me.Hide
End Sub
