using UnityEngine;

namespace TBalls
{
    public class GameManager : SingletonBase<GameManager>
    {
        private int _cubeQuantity = 0;
        private int _usedBallsQuantity = 0;
        private int _levelLoaded = 0;

        private static bool _spawned = false;
        
        public int CubeQuantity
        {
            get { return _cubeQuantity; }
            set
            {
                _cubeQuantity = value;
                if (_cubeQuantity==0)
                {
                    EventBroker.CallAllCubesDestroyed();
                }
            }
        }

        public int UsedBallsQuantity
        {
            get
            {   _usedBallsQuantity=PlayerPrefs.GetInt("BallsQuantity", 0);
                return _usedBallsQuantity;
            }
            set
            {
                _usedBallsQuantity = value;
                PlayerPrefs.SetInt("BallsQuantity", _usedBallsQuantity);
                
            }
        }

        public int LevelLoaded
        {
            get
            {
                return _levelLoaded;
            }
            set
            {
                _levelLoaded = value;
            }
        }
        public void SetWinCondition(int cubeQuantity)
        {
            CubeQuantity = cubeQuantity;
        }
        public void ReduceCubeQuantity()
        {
            --CubeQuantity;
        }
        
        public void IncrementBallsQuantity()
        {
            ++UsedBallsQuantity;
        }

        public void Awake()
        {
            DontDestroyOnLoad (this);
            if(_spawned) {            
                Destroy(gameObject);
            }
            else {            
                _spawned = true;            
            }
            
            
            EventBroker.CubeDestroyed += ReduceCubeQuantity;
            EventBroker.BallInstantiated += IncrementBallsQuantity;
            EventBroker.LevelChosen += ChooseLevel;
        }

        public void ChooseLevel(int ChosenLevel)
        {
            LevelLoaded = ChosenLevel;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level");
        }
        
        private void OnDestroy()
        {
            EventBroker.CubeDestroyed -= ReduceCubeQuantity;
            EventBroker.BallInstantiated -= IncrementBallsQuantity;
        }


        
    }
}



