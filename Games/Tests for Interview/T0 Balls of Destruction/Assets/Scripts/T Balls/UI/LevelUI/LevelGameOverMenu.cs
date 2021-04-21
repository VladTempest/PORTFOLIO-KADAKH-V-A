using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;

public class LevelGameOverMenu : MonoBehaviour
{
    
    void Awake()
    {
        EventBroker.AllCubesDestroyed += ShowLevelGameOverMenu;
    }
    void Start()
    {
        HideLevelGameOverMenu();
    }

    private void ShowLevelGameOverMenu()
    {
        gameObject.SetActive(true);
    }
    
    private void HideLevelGameOverMenu()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventBroker.AllCubesDestroyed -= ShowLevelGameOverMenu;
        EventBroker.MenuReturnButtonClicked -= HideLevelGameOverMenu;
    }
}
