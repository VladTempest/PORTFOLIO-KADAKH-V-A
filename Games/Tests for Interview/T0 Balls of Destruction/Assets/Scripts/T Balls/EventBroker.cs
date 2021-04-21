using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TBalls
{
    public class EventBroker
    {
        #region level

        public static event Action CubeDestroyed;
        public static event Action AllCubesDestroyed;
        public static event Action BallInstantiated;
        
        #region level/UI
        public static event Action ResetButtonClicked;
        public static event Action OpenMenuButtonClicked;
        
        public static event Action MenuReturnButtonClicked;
        public static event Action MenuMainMenuButtonClicked;
        
        
        #endregion level/UI
        
        
        #endregion level
        
        #region mainMenu

        public static event Action MainMenuPlayButtonClicked;
        public static event Action MainMenuExitButtonClicked;

        public static event Action<int> LevelChosen; 
        
        #endregion mainMenu

        
        
        
        
        
        #region level
        
        public static void CallCubeDestroyed()
        {
            CubeDestroyed?.Invoke();
        }
        
        public static void CallAllCubesDestroyed()
        {
            AllCubesDestroyed?.Invoke();
        }
        
        public static void CallBallInstantiated()
        {
            BallInstantiated?.Invoke();
        }
        
        #region level/UI
        public static void CallResetButtonClicked()
        {
            ResetButtonClicked?.Invoke();
        }

        public static void CallOpenMenuButtonClicked()
        {
            OpenMenuButtonClicked?.Invoke();
        }
        
        public static void CallMenuReturnButtonClicked()
        {
            MenuReturnButtonClicked?.Invoke();
        }
        
        public static void CallMenuMainMenuButtonClicked()
        {
            MenuMainMenuButtonClicked?.Invoke();
        }
        #endregion level/UI
        
        #endregion level
        
        #region mainMenu
        
        public static void CallMainMenuPlayButtonClicked()
        {
            MainMenuPlayButtonClicked?.Invoke();
        } 
        public static void CallMainMenuExitButtonClicked()
        {
            MainMenuExitButtonClicked?.Invoke();
        }
        
        public static void CallLevelChosen(int chosenLevel)
        {
            LevelChosen?.Invoke(chosenLevel);
        }
        
        #endregion mainMenu
    }
}
