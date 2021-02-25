using System.Collections;
using SweetRush.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SweetRush
{
    public class UIManager : SingletonInitiatorBase<UIManager>
    {
        [SerializeField]
        private GameObject _healthBar = null;
        [SerializeField]
        private GameObject _burpInterface=null;
        //[SerializeField]
        //private Button _startButton = null;
        //[SerializeField]
        //private Button _stopButton = null;
        [SerializeField]
        private GameObject _burpIsReadyText=null;
        [SerializeField]
        private GameObject _highScoreText=null;
        [SerializeField]
        private GameObject _highScoreTable=null;
        [SerializeField]
        private GameObject _inputNameWindow = null;
        [SerializeField]
        private GameObject _textInput=null;
        [SerializeField]
        private Button _okButton=null;
        [SerializeField]
        private GameObject _playerName = null;
        [SerializeField]
        private GameObject _conditionOfWinInterface= null;
        [SerializeField]
        private GameObject _chooseDifficultyInterface = null;
        [SerializeField]
        private GameObject _backgroundGameplay = null;
        [SerializeField]
        private GameObject _popUpScore = null;
        [SerializeField]
        private GameObject _mainMenu = null;
        [SerializeField]
        private GameObject _highscoreInterface=null;
        [SerializeField]
        private GameObject _tutorialInterface=null;

        
        private HealthBar _healthBarComponent=null;
        private BurpInterface _burpInterfaceComponent=null;
        private RectTransform _burpInterfaceRectTransformComponent=null;
        private TextMeshProUGUI _highScoreTextMeshProUGIComponent = null;
        private HighScoreTable _highScoreTableComponent=null;
        private TextMeshProUGUI _textMeshProUGUI;
        


        public void Start() //Using Start cos if using Awake Create buttons () can't initialize buttons.
        {
            //If Rider is right this initializing of field eliminate critical memory usage in SetConditionOfWin() 
            _textMeshProUGUI = _conditionOfWinInterface.GetComponent<TextMeshProUGUI>();
            
            
            //CreateUIButtons();
            _healthBarComponent = _healthBar.GetComponent<HealthBar>();
            _burpInterfaceComponent = _burpInterface.GetComponent<BurpInterface>();
            _burpInterfaceRectTransformComponent = _burpInterface.GetComponent<RectTransform>();
            _highScoreTextMeshProUGIComponent=_highScoreText.GetComponent<TextMeshProUGUI>();
            _highScoreTableComponent = _highScoreTable.GetComponent<HighScoreTable>();
            _okButton.onClick.AddListener(()=>
            {
                MemorizePlayerName();
                ShowChooseDifficultyInterface();
                ShowPlayerName();
                ShowInputNameInterface(false);
            });

            //Show input window on start
            
        }

        
        public void CreateInterface(bool isThisStart)
        {
            CreateFreshHealthBar(isThisStart);
            _playerName.SetActive(isThisStart);
            _burpInterface.SetActive(isThisStart);
            _highScoreText.SetActive(isThisStart);
            _conditionOfWinInterface.SetActive(isThisStart);
            _backgroundGameplay.SetActive(isThisStart);


        }
        public void CreateFreshHealthBar(bool isThisStart) //Method to create (or restart) Healthbar.
        {
            if (isThisStart)
            {
                if (_healthBarComponent.healthBarVisible.Length != 0)
                {
                    for (int i = 0; i < _healthBarComponent.healthBarVisible.Length; i++)
                    {
                        Destroy(_healthBarComponent.healthBarVisible[i]);
                    }
                }

                _healthBarComponent.CreateHealthBar();
            }
            else
            {
                if (_healthBarComponent.healthBarVisible.Length == 0) return;
                for (int i = 0; i < _healthBarComponent.healthBarVisible.Length; i++)
                {
                    Destroy(_healthBarComponent.healthBarVisible[i]);
                }
            }
        }

        public void ChangeHealthUI(int changeValue) //Method to call method (?) changing Health in Healthbar.
        {
            _healthBarComponent.ChangeHealth(changeValue);
        }
        /*private void CreateUIButtons() //Method for creating UI.
        {
            _startButton.GetComponent<Button>().onClick.AddListener(GameManager.Instance.StartGame);
            _stopButton.GetComponent<Button>().onClick.AddListener(GameManager.Instance.StopGame);
        }*/

        public void ShowHighscoreTable(bool isThisStart) //Method to show highscoretable
        {
            _highScoreTable.SetActive(!isThisStart);
            
        }
        public void IncreaseBurpIndicatorUI(int currentCombo, int maxCombo)//Method to call method (?) changing Health in BurpInterface.
        {
            _burpInterfaceComponent.IncreaseBurpIndicator(currentCombo, maxCombo);
        }

        public void ChangeHighScore(int currentHighScore)//Method to change current text of highscrore UI
        {
            int previousHighScore = System.Convert.ToInt32(_highScoreTextMeshProUGIComponent.text);
            StartCoroutine(GradualScoreIncreasing(previousHighScore, currentHighScore));
        }
        public IEnumerator BurpReadyText() //Method that showing and hiding "Press F to Burp" in cycle
        {
            while (CharacteristicManager.Instance.IsComboReady())
            {
                if (_burpIsReadyText.activeSelf)
                {
                    yield return new WaitForSeconds(0.6f);
                    _burpIsReadyText.SetActive(false);
                }
                else
                {
                    yield return new WaitForSeconds(0.6f);
                    _burpIsReadyText.SetActive(true);
                }
            }
            _burpIsReadyText.SetActive(false);
        }

        public IEnumerator ShakeBurpInterface()
        {float burpInterfaceShakeTime = 1.0f;
         float burpInterfaceShakeAmount = 50.0f;
         float burpInterfaceShakeSpeed = 2.0f;
                
            Vector3 origPosition = _burpInterfaceRectTransformComponent.localPosition;
//Count elapsed time (in seconds)
            float elapsedTime = 0.0f;
//Repeat for total shake time
            while (elapsedTime < burpInterfaceShakeTime)
            {
//Pick random point on unit sphere
                Vector3 randomPoint = origPosition + Random.insideUnitSphere *
                    burpInterfaceShakeAmount;
//Update Position
                _burpInterfaceRectTransformComponent.localPosition = Vector3.Lerp(_burpInterfaceRectTransformComponent.localPosition, randomPoint,
                    Time.deltaTime * burpInterfaceShakeSpeed);
//Break for next frame
                yield return null;
//Update time
                elapsedTime += Time.deltaTime;
            }

//Restore camera position
            _burpInterfaceRectTransformComponent.localPosition = origPosition;
        }
        
        public void WriteHighscoreToTable() //Method that trying to add current highscore to the Highscore table
        {
            
            var highscore = CharacteristicManager.Instance.currentHighScore;
            _highScoreTableComponent.AddHighscoreEntry(highscore,GetPlayerName());
        }

        

        
        public void MemorizePlayerName()//Method for memorizing player name for futher using in highscore table and name UI
        {
            PlayerPrefs.SetString("GetPlayerName", _textInput.GetComponent<TextMeshProUGUI>().text);
            CharacteristicManager.Instance.playerName = _textInput.GetComponent<TextMeshProUGUI>().text;
        }

        private string GetPlayerName()//Method to get memorized name of player from Playerprefs
        {
            return PlayerPrefs.GetString("GetPlayerName");
        }

        private void ShowPlayerName() //Method for showing Name UI and using for it Playerpref
        {
            _playerName.GetComponent<TextMeshProUGUI>().text = GetPlayerName();
        }
        
        public void KillTheInterface() //Method for potential hiding interface...
        {
            _playerName.SetActive(false);
        }

        public void SetConditionOfWin()//Method for showing and updating Condition of Win UI
        {
            _textMeshProUGUI.text =
                $"{CharacteristicManager.Instance.numberOfCoughtEatables}/{CharacteristicManager.Instance.maxnumberOfExistedEatables}";
        }

        public void ShowChooseDifficultyInterface()
        {
            _chooseDifficultyInterface.SetActive(true);
        }

        public void InstantiatePopUpScore(Vector3 transformPosition) //Method instantiates popup score when collison player/eatable or burp/obstacle happens
        {
            Instantiate(_popUpScore, transformPosition, Quaternion.identity);
        }

        public IEnumerator GradualScoreIncreasing(int previousHighscore,int goalHighscore) //Method gradually add points to HighScore
        {
            var currentHighscore = previousHighscore;
            var increasingStep = (goalHighscore - previousHighscore) / 8;
            while ((goalHighscore-increasingStep) > currentHighscore)
            {
                currentHighscore += increasingStep;
                yield return (new WaitForSeconds(0.01f));
                _highScoreTextMeshProUGIComponent.text = currentHighscore.ToString();
            }
            _highScoreTextMeshProUGIComponent.text = goalHighscore.ToString();
        }

        public void ShowMainMenuInterface(bool tryingToShow)
        {
            _mainMenu.SetActive(tryingToShow);
        }

        public void ShowInputNameInterface(bool isItPreStartGame)
        {
            _inputNameWindow.SetActive(isItPreStartGame);
        }
        public void ShowHighScoreInterface(bool isItPreStopGame)
        {
            _highscoreInterface.SetActive(isItPreStopGame);
        }
        
        public void ShowTutorialInterface(bool isItPreStopGame)
        {
            _tutorialInterface.SetActive(isItPreStopGame);
        }
        
    }
}
