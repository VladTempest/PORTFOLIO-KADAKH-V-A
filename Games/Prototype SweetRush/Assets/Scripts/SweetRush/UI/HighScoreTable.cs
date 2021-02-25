using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//This Highscore has differences from other code cos it was made by youtube tutorial 
namespace SweetRush.UI
{
    public class HighScoreTable : InterfaceBase
    {

        private List<Transform> _highScoreEntryTransformList;

        [SerializeField]
        private Button _restartButton=null;
        [SerializeField]
        private Button _clearListButton=null;
        [SerializeField]
        private Button _quitButton=null;
    
        private Transform _entryContainer;
        private Transform _entryTemplate;

        private List<HighscoreEntry> _placeholderForEntries;

        private Highscores _placeholderHighscores;

        // Start is called before the first frame update


        public void Awake()
        {
            //Create a placeholder for Highscore EntryList in case of pressing button clear
            _placeholderForEntries = new List<HighscoreEntry>()
            {
                new HighscoreEntry(){score=700, name="Orc torch"},
                new HighscoreEntry(){score=600, name="Usain Bolt"},
                new HighscoreEntry(){score=500, name="Jacket kid"},
                new HighscoreEntry(){score=400, name="Tom Cruise"},
                new HighscoreEntry(){score=300, name="Runnin' man"},
                new HighscoreEntry(){score=200, name="Flash"},
                new HighscoreEntry(){score=100, name="Forrest Gump"},
                
            };
            _placeholderHighscores = new Highscores {HighscoreEntryList = _placeholderForEntries};
            string defaultJson = JsonUtility.ToJson(_placeholderHighscores);
            PlayerPrefs.SetString("defaultHighscoreTable",defaultJson);
            
            //Check for existence of highscoreEntries, if there is nothing, set default one
            if (PlayerPrefs.GetString("highscoreTable") == null)
            {
                PlayerPrefs.SetString("highscoreTable", CallTheDefaultHighscorePlaceHolder());
            }
        }
        public void OnEnable()
        {
            //Finding object for further usage
            _entryContainer = transform.Find("HighscoreEntryContainer");
            _entryTemplate = _entryContainer.Find("HighscoreEntryTemplate");
            //Hiding template that used for generating entries in the table
            _entryTemplate.gameObject.SetActive(false);
        
            //Show Clear Button after reopening HighscoreTable
            _clearListButton.gameObject.SetActive(true);
            
            
            //Fill the table from Playerpref memory using Json-s
            string jsonString = PlayerPrefs.GetString("highscoreTable",CallTheDefaultHighscorePlaceHolder());
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
            
            //Create a highscore list from json we got earlier
            _highScoreEntryTransformList=new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.HighscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, _entryContainer,_highScoreEntryTransformList);   
            }
            
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();


            _restartButton.onClick.AddListener(UIManager.Instance.ShowChooseDifficultyInterface);
            _restartButton.onClick.AddListener(DeleteHighscoreTableEntries);
            _restartButton.onClick.AddListener(HideHighscoreTable);
            _clearListButton.onClick.AddListener(ClearHighscoreTable);
            _quitButton.onClick.AddListener(() =>
            {
                //DeleteHighscoreTableEntries();
                HideHighscoreTable();
                GameManager.Instance.PreStartGame();
            });




        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(UIManager.Instance.ShowChooseDifficultyInterface);
            _restartButton.onClick.RemoveListener(DeleteHighscoreTableEntries);
            _restartButton.onClick.RemoveListener(HideHighscoreTable);
            _clearListButton.onClick.RemoveListener(ClearHighscoreTable);
            _quitButton.onClick.RemoveListener(() =>
            {
                DeleteHighscoreTableEntries();
                HideHighscoreTable();
                GameManager.Instance.PreStartGame();
            });
        }


        //Method for checking "is current score high enough to get to the table", if answer is "yes"  adding new entry
        public void AddHighscoreEntry(int score, string playerName)
        {
            int numberOfChanges =0;
            
            //Create HighscoreEntry
            HighscoreEntry highscoreEntry = new HighscoreEntry {score = score, name = playerName};
           
            //Load save Highscores
            
            string jsonString = PlayerPrefs.GetString("highscoreTable",CallTheDefaultHighscorePlaceHolder());
           
            
            if (jsonString == null)
            {
                jsonString=PlayerPrefs.GetString(CallTheDefaultHighscorePlaceHolder());
                
            }
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
            
            if (CharacteristicManager.Instance.currentHighScore <
                highscores.HighscoreEntryList[highscores.HighscoreEntryList.Count - 1].score)
            {
                return;
            }
            //Add new Entry to Highscores
            highscores.HighscoreEntryList.Add(highscoreEntry);
            
            //Sort the list
            for (int i = 0; i < highscores.HighscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.HighscoreEntryList.Count; j++)
                {
                    if (highscores.HighscoreEntryList[j].score > highscores.HighscoreEntryList[i].score)
                    {
                        HighscoreEntry tmp = highscores.HighscoreEntryList[i];
                        highscores.HighscoreEntryList[i] = highscores.HighscoreEntryList[j];
                        highscores.HighscoreEntryList[j] = tmp;
                        numberOfChanges++;
                    }
                }
            }
     
            //Delete last Entry to prevent overload
            highscores.HighscoreEntryList.RemoveAt(highscores.HighscoreEntryList.Count - 1);
          
            //Save updated Highscores
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
            if (numberOfChanges != 0)
            {
                UIManager.Instance.ShowHighScoreInterface(true);
            }
            
        }
        

        private string CallTheDefaultHighscorePlaceHolder()
        {
            //Create a placeholder for Highscore EntryList in case of pressing button clear
            _placeholderForEntries = new List<HighscoreEntry>()
            {
                new HighscoreEntry(){score=700, name="Orc torch"},
                new HighscoreEntry(){score=600, name="Usain Bolt"},
                new HighscoreEntry(){score=500, name="Jacket kid"},
                new HighscoreEntry(){score=400, name="Tom Cruise"},
                new HighscoreEntry(){score=300, name="Runnin' man"},
                new HighscoreEntry(){score=200, name="Flash"},
                new HighscoreEntry(){score=100, name="Forrest Gump"},
                
            };
            _placeholderHighscores = new Highscores {HighscoreEntryList = _placeholderForEntries};
            string defaultJson = JsonUtility.ToJson(_placeholderHighscores);
            PlayerPrefs.SetString("defaultHighscoreTable",defaultJson);
            
            //Check for existence of highscoreEntries, if there is nothing, set default one
            if (PlayerPrefs.GetString("highscoreTable") == null)
            {
                PlayerPrefs.SetString("highscoreTable", CallTheDefaultHighscorePlaceHolder());
            }
            
            return  PlayerPrefs.GetString("defaultHighscoreTable");
        }
        //Method for creating entries in the Highscore table while using template 
        private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container,
            List<Transform> transformList)
        {
            const float templateHeight = 20f;
            Transform entryTransform = Instantiate(_entryTemplate,
                container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            //Reset number of rank after clearing highscore table
           string rankString;
            
            //Use rank's right numeral
            switch (rank)
            {
                default:
                    rankString = rank + "TH";
                    break;
                case 1: rankString = "1ST";
                    break;
                case 2: rankString = "2ND"; 
                    break;
                case 3: rankString = "3RD";
                    break;
            }

            entryTransform.Find("PositionTableTextTemplate").GetComponent<TextMeshProUGUI>().text =rankString;
            
            int score = highscoreEntry.score;
            entryTransform.Find("HighscoreTableTextTemplate").GetComponent<TextMeshProUGUI>().text =score.ToString();

            string playername = highscoreEntry.name;
            entryTransform.Find("NameTableTextTemplate").GetComponent<TextMeshProUGUI>().text =playername;

            //Change color of the first entry to green
            if (rank == 1)
            {
                entryTransform.Find("PositionTableTextTemplate").GetComponent<TextMeshProUGUI>().color =Color.green;
                entryTransform.Find("HighscoreTableTextTemplate").GetComponent<TextMeshProUGUI>().color =Color.green;
                entryTransform.Find("NameTableTextTemplate").GetComponent<TextMeshProUGUI>().color =Color.green;
            }

            
            //Create different colored icon of the trophy for each first three places.
            switch (rank)
            {
                default:
                    entryTransform.Find("Troph").gameObject.SetActive(false);
                    break;
                case 1:
                    entryTransform.Find("Troph").gameObject.GetComponent<RawImage>().color=Color.white;
                    break;
                case 2:
                    entryTransform.Find("Troph").gameObject.GetComponent<RawImage>().color=Color.grey;
                    break;
                case 3:
                    entryTransform.Find("Troph").gameObject.GetComponent<RawImage>().color=Color.red;
                    break;
                    
            }
            transformList.Add(entryTransform);
        }

        private void ClearHighscoreTable()
        {

            DeleteHighscoreTableEntries();

            foreach (HighscoreEntry highscoreEntry in _placeholderHighscores.HighscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, _entryContainer,_highScoreEntryTransformList);   
            }
           
         
            string json = JsonUtility.ToJson(new Highscores {HighscoreEntryList = _placeholderForEntries});
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();

            SaveHighScoreTableForFutureUsage();
            _clearListButton.gameObject.SetActive(false);
        }

        private void DeleteHighscoreTableEntries()
        {
            foreach (Transform i in _highScoreEntryTransformList)
            {
                Destroy(i.gameObject);
                
            }
//Clear list of Entries
            for (int i = 0; i< 7; i++)
            {
                _highScoreEntryTransformList.RemoveAt(0);
            }
            
        }

    
        private void SaveHighScoreTableForFutureUsage()
        {
            
            string json = JsonUtility.ToJson(new Highscores {HighscoreEntryList = _placeholderForEntries});
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();

        }
        //Create a class for highscore list to ease conversion to json 
        private class Highscores
        {
            public List<HighscoreEntry> HighscoreEntryList=null;
        }
        
        [System.Serializable]
        private class HighscoreEntry //Create a class for highscore entries
        {
            public int score;
            public string name;
        }

        private void HideHighscoreTable()
        {
            gameObject.SetActive(false);
        }
        
        
    }
}

   
