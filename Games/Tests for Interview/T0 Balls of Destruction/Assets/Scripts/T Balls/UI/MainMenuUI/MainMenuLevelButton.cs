using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLevelButton : MonoBehaviour
{
    [SerializeField]
    private int _level = 0;
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>EventBroker.CallLevelChosen(_level));
    }
    
    void OnDestroy()
    {
        gameObject.GetComponent<Button>().onClick.RemoveListener(() =>EventBroker.CallLevelChosen(_level));
    }
}

