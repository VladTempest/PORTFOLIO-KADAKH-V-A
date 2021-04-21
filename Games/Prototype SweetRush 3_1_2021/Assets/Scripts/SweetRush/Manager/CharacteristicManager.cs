using System;
using UnityEngine;

namespace SweetRush
{


    public class CharacteristicManager : SingletonInitiatorBase<CharacteristicManager>
    {
        public int maxCombo=3;
        public int currentCombo=0;
        public int currentHighScore = 0;
        public float valueOfAcceleration=1.0f;
        public string playerName=null;
        private int numberOfExsistedEatables = 0;
        public int numberOfCoughtEatables = 0;
        public int maxnumberOfExistedEatables = 100;
        public int currentHealth = 0;
        
        private int _lastAddedValueToHighScore = 0;
        [SerializeField]
        private int _addValueEatable = 10;
        [SerializeField]
        private int _addValueObstacle = 100;
        
        
       //Method returns state of the game after checking player's health  
        public bool CheckForGameOver(int currentHealth)
        {
            this.currentHealth=currentHealth;
            if (currentHealth != 0) return false;
            GameManager.Instance.PreStopGame();
            return true;
        }

        //Method increasing value of caught eatables 
        public void IncreaseEatablesCounter(bool doesComboGoOn)
        {
            if (doesComboGoOn)
            {
                numberOfCoughtEatables++;
                {
                    if (numberOfCoughtEatables==maxnumberOfExistedEatables)
                    {
                        GameManager.Instance.PreStopGame();
                    }
                }
                UIManager.Instance.SetConditionOfWin();
                if (currentCombo < maxCombo)
                {
                    currentCombo++;
                    UIManager.Instance.IncreaseBurpIndicatorUI(currentCombo, maxCombo);
                    if (currentCombo == maxCombo)
                    {
                        StartCoroutine(UIManager.Instance.BurpReadyText());
                    }
                }
                
            }
            else
            {
                currentCombo = 0;
                UIManager.Instance.IncreaseBurpIndicatorUI(currentCombo, maxCombo);
            }
        }

        //Method checking for combo if combo is not ready it will return smth idk
        public bool IsComboReady()
        {
            if (currentCombo != maxCombo)
            {
                //Debug.Log("Не готово!");
            }
          
            return (currentCombo == maxCombo);
        }

        //Method adding points to highscore and also changing Highscore UI 
        public void AddPointsForEatables()
        {
            _lastAddedValueToHighScore = _addValueEatable + _addValueEatable * (currentCombo - 1);
            currentHighScore +=_lastAddedValueToHighScore;
            UIManager.Instance.ChangeHighScore(currentHighScore);
        }

        public void AddPointsForObstacles(int _numberOfKilledByThisBurp)
        {
            _lastAddedValueToHighScore=_addValueObstacle+_addValueObstacle*(_numberOfKilledByThisBurp-1);
            currentHighScore+=_lastAddedValueToHighScore;
            UIManager.Instance.ChangeHighScore(currentHighScore);
        }
        
        
        public void ResetCharacteristicsTable()
        {
            IncreaseEatablesCounter(false);
            currentHighScore = 0;
            UIManager.Instance.ChangeHighScore(currentHighScore);
            numberOfCoughtEatables = 0;
            numberOfExsistedEatables = 0;
        }

        //Method that increase speed for new spawned obstacles if difficulty increased
        public void AccelerationOfSpeed(ref float speed)
        {
            speed *= valueOfAcceleration;
        }

        //Method that keeping score of existing eatables 
        public void AddToEatablesQuantity()
        {
            numberOfExsistedEatables++;
            if (numberOfExsistedEatables % 13 == 0)
            {
                GameManager.Instance.UpDifficulty(1.3f,1.05f,1.1f);
            }
        }

        public int GetLastAddedValueToHighScore()
        {
            return _lastAddedValueToHighScore;
        }
        //Method that change max number of eatables depending of difficulty level
        public void SetMaxNumberOfEatables(int difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case 0:
                {
                    maxnumberOfExistedEatables = 25;
                    break;
                }
                case 1:
                {
                    maxnumberOfExistedEatables = 50;
                    break;
                }
                case 2:
                {
                    maxnumberOfExistedEatables = 75;
                    break;
                }
                
            }
        }
    }
}
