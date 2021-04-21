using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBalls
{
    public class MainMenu : MonoBehaviour
    {
        void Awake()
        {
            EventBroker.MainMenuPlayButtonClicked += HideMainMenu;
            EventBroker.MainMenuExitButtonClicked += ExitGame;
        }
        

        private void HideMainMenu()
        {
            gameObject.SetActive(false);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            EventBroker.MainMenuPlayButtonClicked -= HideMainMenu;

        }
    }
}
