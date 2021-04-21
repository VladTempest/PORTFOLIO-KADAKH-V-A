using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBalls
{
    public class MainMenuLevelMenu : MonoBehaviour
    {
        void Awake()
        {
            EventBroker.MainMenuPlayButtonClicked += ShowLevelMenu;
        }
        void Start()
        {
            HideLevelMenu();
        }

        private void ShowLevelMenu()
        {
            gameObject.SetActive(true);
        }

        private void HideLevelMenu()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            EventBroker.MainMenuPlayButtonClicked -= ShowLevelMenu;
            
        }
    }
}
