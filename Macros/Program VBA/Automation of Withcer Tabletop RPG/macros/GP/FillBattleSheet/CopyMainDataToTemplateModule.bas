Attribute VB_Name = "CopyMainDataToTemplateModule"
Option Explicit

Function CopyMainDataToTemplate(WorksheetCopyFrom As Worksheet, WorksheetCopyTo As Worksheet, FinalRow As Integer, StartCell As Range)
Dim CurrentCell As Range: Set CurrentCell = Range("T" & FinalRow)

Dim NamePlayerNPC As String
Dim NameCharacters As String

Dim Intellect As Integer
Dim Reaction As Integer
Dim Dexterity As Integer
Dim Body As Integer
Dim Speed As Integer
Dim Will As Integer

Dim ArmorHead As String
Dim ArmorTorso As String
Dim ArmorRHand As String
Dim ArmorLHand As String
Dim ArmorRLeg As String
Dim ArmorLLeg As String


Dim Streinght As Integer
Dim Run As Integer
Dim Jump As Integer
Dim Weight As Integer
Dim Recreation As Integer

Dim Injure As Integer
Dim Health As Integer
Dim Stamina As Integer
Dim Resolve As Integer
Dim Energy As Integer

Dim WeaponNameFirst As String
Dim AccuracyFirst As String
Dim DamageFirst As String
Dim ReliabilityFirst As String
Dim DistanceFirst As String

Dim WeaponNameSecond As String
Dim AccuracySecond As String
Dim DamageSecond As String
Dim ReliabilitySecond As String
Dim DistanceSecond As String

WorksheetCopyFrom.Activate

NamePlayerNPC = StartCell.Value
NameCharacters = StartCell.Offset(1, 0).Value

Intellect = StartCell.Offset(6, 0).Value
Reaction = StartCell.Offset(7, 0).Value
Dexterity = StartCell.Offset(8, 0).Value
Body = StartCell.Offset(9, 0).Value
Speed = StartCell.Offset(10, 0).Value
Will = StartCell.Offset(13, 0).Value


Streinght = StartCell.Offset(8, 2).Value
Run = StartCell.Offset(9, 2).Value
Jump = StartCell.Offset(10, 2).Value
Recreation = StartCell.Offset(12, 2).Value

ArmorHead = StartCell.Offset(1, 2).Value
ArmorTorso = StartCell.Offset(2, 2).Value
ArmorRHand = StartCell.Offset(3, 2).Value
ArmorLHand = StartCell.Offset(4, 2).Value
ArmorRLeg = StartCell.Offset(5, 2).Value
ArmorLLeg = StartCell.Offset(6, 2).Value

Injure = StartCell.Offset(0, 4).Value
Health = StartCell.Offset(1, 4).Value
Stamina = StartCell.Offset(2, 4).Value
Resolve = StartCell.Offset(3, 4).Value
Energy = StartCell.Offset(3, 4).Value

WeaponNameFirst = StartCell.Offset(15, 0).Value
AccuracyFirst = StartCell.Offset(16, 0).Value
DamageFirst = StartCell.Offset(17, 0).Value
ReliabilityFirst = StartCell.Offset(18, 0).Value
DistanceFirst = StartCell.Offset(19, 0).Value
WeaponNameSecond = StartCell.Offset(15, 1).Value
AccuracySecond = StartCell.Offset(16, 1).Value
DamageSecond = StartCell.Offset(17, 1).Value
ReliabilitySecond = StartCell.Offset(18, 1).Value
DistanceSecond = StartCell.Offset(19, 1).Value

WorksheetCopyTo.Activate

CurrentCell.Offset(0, 1).Value = NamePlayerNPC
CurrentCell.Offset(1, 1).Value = NameCharacters

CurrentCell.Offset(2, 1).Value = Intellect
CurrentCell.Offset(3, 1).Value = Reaction
CurrentCell.Offset(4, 1).Value = Dexterity
CurrentCell.Offset(5, 1).Value = Body
CurrentCell.Offset(6, 1).Value = Speed
CurrentCell.Offset(7, 1).Value = Will

CurrentCell.Offset(1, 9).Value = ArmorHead
CurrentCell.Offset(2, 9).Value = ArmorTorso
CurrentCell.Offset(3, 9).Value = ArmorRHand
CurrentCell.Offset(4, 9).Value = ArmorLHand
CurrentCell.Offset(5, 9).Value = ArmorRLeg
CurrentCell.Offset(6, 9).Value = ArmorLLeg


CurrentCell.Offset(8, 1).Value = Streinght
CurrentCell.Offset(9, 1).Value = Run
CurrentCell.Offset(10, 1).Value = Jump
CurrentCell.Offset(11, 1).Value = Recreation

CurrentCell.Offset(0, 3).Value = Injure
CurrentCell.Offset(1, 3).Value = Health
CurrentCell.Offset(2, 3).Value = Stamina
CurrentCell.Offset(3, 3).Value = Resolve
CurrentCell.Offset(4, 3).Value = Energy


CurrentCell.Offset(0, 6).Value = WeaponNameFirst
CurrentCell.Offset(1, 6).Value = AccuracyFirst
CurrentCell.Offset(2, 6).Value = DamageFirst
CurrentCell.Offset(3, 6).Value = ReliabilityFirst
CurrentCell.Offset(4, 6).Value = DistanceFirst
CurrentCell.Offset(0, 7).Value = WeaponNameSecond
CurrentCell.Offset(1, 7).Value = AccuracySecond
CurrentCell.Offset(2, 7).Value = DamageSecond
CurrentCell.Offset(3, 7).Value = ReliabilitySecond
CurrentCell.Offset(4, 7).Value = DistanceSecond


End Function
