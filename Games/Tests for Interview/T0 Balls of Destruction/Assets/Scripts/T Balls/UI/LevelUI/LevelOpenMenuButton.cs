using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;
using UnityEngine.UI;

public class LevelOpenMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(EventBroker.CallOpenMenuButtonClicked);
        EventBroker.OpenMenuButtonClicked += HideButton;
        EventBroker.AllCubesDestroyed += HideButton;
        EventBroker.MenuReturnButtonClicked += ShowButton;
        
    }

    void HideButton()
    {
        gameObject.SetActive(false);
    }
    
    void ShowButton()
    {
        gameObject.SetActive(true);
    }
    void OnDestroy()
    {
        gameObject.GetComponent<Button>().onClick.RemoveListener(EventBroker.CallOpenMenuButtonClicked);
        
        EventBroker.OpenMenuButtonClicked -= HideButton;
        EventBroker.AllCubesDestroyed -= HideButton;
        EventBroker.MenuReturnButtonClicked -= ShowButton;
    }
}
