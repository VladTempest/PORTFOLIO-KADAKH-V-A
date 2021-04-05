Attribute VB_Name = "FirstBlocksCopyFromToModule"
Option Explicit
Function FirstBlocksCopyFromTo(WorkbookToCopyTo As Workbook, WorksheetWithCharacters As Worksheet, WorksheetWithTemplate As Worksheet, PlaceToPaste As Range, TypeOfCharacter As String)
Dim PlayerName As String
Dim CharacterName As String
Dim CharacterRace As String
Dim CharacterSex As String
Dim CharacterAge As String
Dim CharacterPlaceOfBorn As String
Dim CharacterProfession As String

Dim Intellect As Integer
Dim Reaction As Integer
Dim Dexterity As Integer
Dim Body As Integer
Dim Speed As Integer
Dim Empathy As Integer
Dim Craft As Integer
Dim Will As Integer
Dim Luck As Integer

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

Dim PlaceOfBorn As String
Dim Family As String
Dim Parents As String
Dim Status As String
Dim InfluentialFriend As String

Dim Cloth As String
Dim Character As String
Dim Hair As String
Dim Finery As String

'If TypeOfCharacter = "Живой игрок" Then
'    PlayerName = Range("D2").Value
'Else
'    PlayerName = "НПЦ"
'End If


PlayerName = Range("D2").Value
CharacterName = Range("D3").Value
CharacterRace = Range("D4").Value
CharacterSex = Range("D5").Value
CharacterPlaceOfBorn = Range("D6").Value
CharacterAge = Range("D7").Value
CharacterProfession = Range("D8").Value


Intellect = Range("C15").Value
Reaction = Range("C16").Value
Dexterity = Range("C17").Value
Body = Range("C18").Value
Speed = Range("C19").Value
Empathy = Range("C20").Value
Craft = Range("C21").Value
Will = Range("C22").Value
Luck = Range("C23").Value

Streinght = Range("J15").Value
Run = Range("J16").Value
Jump = Range("J17").Value
Weight = Range("J18").Value
Recreation = Range("J19").Value

ArmorHead = Range("O14")
ArmorTorso = Range("O15")
ArmorRHand = Range("O16")
ArmorLHand = Range("O17")
ArmorRLeg = Range("O18")
ArmorLLeg = Range("O19")

Injure = Range("Z2").Value
Health = Range("X3").Value
Stamina = Range("X5").Value
Resolve = Range("X7").Value
Energy = Range("BI2").Value



WeaponNameFirst = Range("Y19").Value
AccuracyFirst = Range("Y20").Value
DamageFirst = Range("Y21").Value
ReliabilityFirst = Range("Y22").Value
DistanceFirst = Range("Y23").Value
WeaponNameSecond = Range("Y28").Value
AccuracySecond = Range("Y29").Value
DamageSecond = Range("Y30").Value
ReliabilitySecond = Range("Y31").Value
DistanceSecond = Range("Y32").Value



If Not (CharacterProfession = "Ведьмак") Then
    PlaceOfBorn = Range("BP3").Value
    Family = Range("BP5").Value
    Parents = Range("BP7").Value
    Status = Range("BP9").Value
    InfluentialFriend = Range("BP11").Value
    
    Cloth = Range("BM2").Value
    Character = Range("BM4").Value
    Hair = Range("BM6").Value
    Finery = Range("BM8").Value
Else
    PlaceOfBorn = CStr(Range("BW3").Value) + "/" + CStr(Range("BY3").Value)
    Family = Range("BW5").Value
    Parents = Range("BW7").Value
    Status = Range("BW9").Value
    InfluentialFriend = Range("BW11").Value
    
    Cloth = Range("BT2").Value
    Character = Range("BT4").Value
    Hair = Range("BT6").Value
    Finery = Range("BT8").Value
End If


'ActiveWorkbook.Close
WorkbookToCopyTo.Activate
WorksheetWithTemplate.Activate
Range("O2:Z23").Copy
WorksheetWithCharacters.Activate

PlaceToPaste.Offset(0, -1).PasteSpecial (xlPasteAll)

PlaceToPaste.Value = PlayerName
PlaceToPaste.Offset(1, 0).Value = CharacterName
PlaceToPaste.Offset(2, 0).Value = CharacterRace + "/" + CharacterProfession
PlaceToPaste.Offset(3, 0).Value = CharacterSex + "/" + CharacterAge
PlaceToPaste.Offset(4, 0).Value = CharacterPlaceOfBorn

PlaceToPaste.Offset(6, 0).Value = Intellect
PlaceToPaste.Offset(7, 0).Value = Reaction
PlaceToPaste.Offset(8, 0).Value = Dexterity
PlaceToPaste.Offset(9, 0).Value = Body
PlaceToPaste.Offset(10, 0).Value = Speed
PlaceToPaste.Offset(11, 0).Value = Empathy
PlaceToPaste.Offset(12, 0).Value = Craft
PlaceToPaste.Offset(13, 0).Value = Will
PlaceToPaste.Offset(14, 0).Value = Luck

PlaceToPaste.Offset(1, 2).Value = ArmorHead
PlaceToPaste.Offset(2, 2).Value = ArmorTorso
PlaceToPaste.Offset(3, 2).Value = ArmorRHand
PlaceToPaste.Offset(4, 2).Value = ArmorLHand
PlaceToPaste.Offset(5, 2).Value = ArmorRLeg
PlaceToPaste.Offset(6, 2).Value = ArmorLLeg


PlaceToPaste.Offset(8, 2).Value = Streinght
PlaceToPaste.Offset(9, 2).Value = Run
PlaceToPaste.Offset(10, 2).Value = Jump
PlaceToPaste.Offset(11, 2).Value = Weight
PlaceToPaste.Offset(12, 2).Value = Recreation

PlaceToPaste.Offset(0, 4).Value = Injure
PlaceToPaste.Offset(1, 4).Value = Health
PlaceToPaste.Offset(2, 4).Value = Stamina
PlaceToPaste.Offset(3, 4).Value = Resolve
PlaceToPaste.Offset(4, 4).Value = Energy


PlaceToPaste.Offset(15, 0).Value = WeaponNameFirst
PlaceToPaste.Offset(16, 0).Value = AccuracyFirst
PlaceToPaste.Offset(17, 0).Value = DamageFirst
PlaceToPaste.Offset(18, 0).Value = ReliabilityFirst
PlaceToPaste.Offset(19, 0).Value = DistanceFirst
PlaceToPaste.Offset(15, 1).Value = WeaponNameSecond
PlaceToPaste.Offset(16, 1).Value = AccuracySecond
PlaceToPaste.Offset(17, 1).Value = DamageSecond
PlaceToPaste.Offset(18, 1).Value = ReliabilitySecond
PlaceToPaste.Offset(19, 1).Value = DistanceSecond



If Not TypeOfCharacter = "Живой игрок" Then
    PlaceToPaste.Offset(0, 8).Value = PlaceOfBorn
    PlaceToPaste.Offset(1, 8).Value = Family
    PlaceToPaste.Offset(2, 8).Value = Parents
    PlaceToPaste.Offset(3, 8).Value = Status
    PlaceToPaste.Offset(4, 8).Value = InfluentialFriend
    
    PlaceToPaste.Offset(0, 6).Value = Cloth
    PlaceToPaste.Offset(1, 6).Value = Character
    PlaceToPaste.Offset(2, 6).Value = Hair
    PlaceToPaste.Offset(3, 6).Value = Finery
End If
End Function


