using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuReturnButton : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(EventBroker.CallMenuReturnButtonClicked);
    }
    
    void OnDestroy()
    {
        gameObject.GetComponent<Button>().onClick.RemoveListener(EventBroker.CallMenuReturnButtonClicked);
    }
}
