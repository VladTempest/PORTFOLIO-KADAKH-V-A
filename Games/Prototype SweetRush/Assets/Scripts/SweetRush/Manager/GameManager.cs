using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace SweetRush
{
    public class GameManager : SingletonInitiatorBase<GameManager>
    {
        public bool _isGameStart = false;
        public GameDifficulty difficultyLevel = 0;

        [SerializeField]
        private float _gravityModifier = 3;


        // Start is called before the first frame update
        private void Awake()
        {
            Physics.gravity *= _gravityModifier;
            PreStartGame();
        }


        public void PreStopGame()
        {
            _isGameStart = false;
            
            UIManager.Instance.CreateInterface(_isGameStart);
            
            SpawnManager.Instance._isGameStart = _isGameStart;

            StartCoroutine(TransferToStopGame());
            
            KillAllObjects();
            AudioManager.Instance.PlayOrStopOST(_isGameStart);
            //скрыть интерфейс
            BackGroundBehaviour.Instance._isGameStart = false;
            PlayerController.Instance._isGameStart = _isGameStart;
            PlayerController.Instance.FreezePlayer();
            CinematicLookManager.Instance.ChangeActiveCamera();
            if (CharacteristicManager.Instance.currentHealth !=0)
            {
                FXManager.Instance.PlayFX(gameObject, 8);
                AudioManager.Instance.PlaySoundFX(3,13);
                AnimationManager.Instance.PlayDancinAnimation();
                UIManager.Instance.WriteHighscoreToTable();
            }
            else
            {
                FXManager.Instance.PlayGameOverRedScreenEffect(true);
                AudioManager.Instance.PlaySoundFX(3,12);
                AudioManager.Instance.PlaySoundFX(3,11);
                AnimationManager.Instance.PlayDeathAnimation();
                CharacteristicManager.Instance.ResetCharacteristicsTable();
                UIManager.Instance.WriteHighscoreToTable();
            }
            AnimationManager.Instance.PlayCartGoinAwayAnimation();
        }

        public void StopGame() //Message to managers and playerController that game stopped.
        {
                FXManager.Instance.PlayGameOverRedScreenEffect(false);
        
                SpawnManager.Instance._isGameStart = _isGameStart;
                SpawnManager.Instance.DestroySpawnedStuff();


                
                PlayerController.Instance.HideThePlayer();

                
                //Temporary HighScore will show up at he every stop of the level

                UIManager.Instance.WriteHighscoreToTable();
                UIManager.Instance.ShowHighscoreTable(_isGameStart);
                UIManager.Instance.ShowHighScoreInterface(false);



                CharacteristicManager.Instance.ResetCharacteristicsTable();
                AnimationManager.Instance.PlayIceCreamTruckMoveForwardAnimation(_isGameStart);
                AnimationManager.Instance.StopAndRestartPlayingPlayerAnimation();
                //BackGroundBehaviour.Instance._isGameStart = _isGameStart;
                CinematicLookManager.Instance.ShowModelsOfGameplay(_isGameStart);
                CinematicLookManager.Instance.ResetCameraTransform();
                
                AudioManager.Instance.PlayOrStopOST(_isGameStart);



            
        }

        public void StartGame() ////Message to managers and playerController that game started.
        {
            if (!_isGameStart)
            {
                _isGameStart = true;
                
                KillAllObjects();
                //For now start difficulty - minimal (0), also there is medium(1) and hard(2)
                ChooseStartDifficulty(difficultyLevel);
                SpawnManager.Instance._isGameStart = _isGameStart;
                SpawnManager.Instance.Awake();
                SpawnManager.Instance.SpawnPlayerAndStuff();

                PlayerController.Instance._isGameStart = _isGameStart;



                UIManager.Instance.CreateInterface(_isGameStart);
                UIManager.Instance.ShowHighscoreTable(_isGameStart);



                

                CinematicLookManager.Instance.ShowModelsOfGameplay(_isGameStart);
                



                //Reset speed of Run Animation
                AnimationManager.Instance.SwitchSpeedOfRunAnimation(0);
                AnimationManager.Instance.PlayIceCreamTruckMoveForwardAnimation(_isGameStart);
                AnimationManager.Instance.PlayRunAnimation();


                BackGroundBehaviour.Instance._isGameStart = _isGameStart;
            }
        }

        public void PreStartGame()
        {
            
            UIManager.Instance.ShowMainMenuInterface(true);
            AudioManager.Instance.PlayOrStopOST(false);
            AudioManager.Instance.PlayOrStopOST(true, 3, 0);
            
        }
        //Method to make game harder
        public void UpDifficulty(float valueOfDecreaseSpawnDelay, float valueOfBackgroundSpeedAcceleration, float valueOfObstaclesAcceleration)
        {
            SpawnManager.Instance.SpawnAccelerator(valueOfDecreaseSpawnDelay, valueOfBackgroundSpeedAcceleration);
            //Next line of code make every new spawned object move faster for specific value for this difficulty state.
            CharacteristicManager.Instance.valueOfAcceleration *= valueOfObstaclesAcceleration;
        }

        //Method to choose start difficulty parameters
        private void ChooseStartDifficulty(GameDifficulty difficulty)
        {
            AudioManager.Instance.ChooseSoundtrackByDifficulty(difficulty);
            int difficultyLevel = (int)difficulty;
            //If "Easy" difficulty, then don't use last hard Obstacle in spawnmanager
            SpawnManager.Instance.SetPoolMaxIndexAccordingToDifficulty(difficultyLevel);
            CharacteristicManager.Instance.SetMaxNumberOfEatables(difficultyLevel);
            CharacteristicManager.Instance.valueOfAcceleration = 0.7f + difficultyLevel * 0.3f;
            UIManager.Instance.SetConditionOfWin();
            CinematicLookManager.Instance.ChooseMaterialsForDecorations(difficultyLevel);



        }

        private void KillAllObjects()
        {
            SpawnManager.Instance.SpawnKillerObject(_isGameStart);

        }
        private IEnumerator TransferToStopGame(){
            yield return new WaitForSeconds(3);
            StopGame();
        }

    
    }
    
    

    public enum GameDifficulty 
    {Easy=0, 
        Medium=1,
        Hard=2
    }
}
