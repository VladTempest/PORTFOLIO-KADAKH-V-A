using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuMainMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(EventBroker.CallMenuMainMenuButtonClicked);
    }
    
    void OnDestroy()
    {
        gameObject.GetComponent<Button>().onClick.RemoveListener(EventBroker.CallMenuMainMenuButtonClicked);
    }
}
