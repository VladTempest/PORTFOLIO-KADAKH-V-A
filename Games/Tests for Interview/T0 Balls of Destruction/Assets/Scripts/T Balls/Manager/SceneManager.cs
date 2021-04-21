

namespace TBalls
{


    public class SceneManager : SingletonBase<SceneManager>
    {
        private static bool _spawned = false;

        private void Awake()
        {
            DontDestroyOnLoad (this);
            if(_spawned) {            
                Destroy(gameObject);
            }
            else {            
                _spawned = true;            
            }
            
            
            EventBroker.ResetButtonClicked += ResetScene;
            EventBroker.MenuMainMenuButtonClicked += LoadMainMenu;
        }

        public void ResetScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Level");
        }

        public void LoadMainMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Main menu");
        }

        private void OnDestroy()
        {
            EventBroker.ResetButtonClicked -= ResetScene;
            EventBroker.MenuMainMenuButtonClicked -= LoadMainMenu;
        }


    }
}
