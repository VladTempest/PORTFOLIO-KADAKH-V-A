using System;
using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    
    void Awake()
    {
        EventBroker.OpenMenuButtonClicked += ShowLevelMenu;
        EventBroker.MenuReturnButtonClicked += HideLevelMenu;
        EventBroker.AllCubesDestroyed += HideLevelMenu;
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
        EventBroker.OpenMenuButtonClicked -= ShowLevelMenu;
        EventBroker.MenuReturnButtonClicked -= HideLevelMenu;
        EventBroker.AllCubesDestroyed -= HideLevelMenu;
 
    }
    
}
