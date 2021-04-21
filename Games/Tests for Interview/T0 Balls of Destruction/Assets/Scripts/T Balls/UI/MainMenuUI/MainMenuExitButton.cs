using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TBalls
{
    public class MainMenuExitButton : MonoBehaviour
    {
        void Awake()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(EventBroker.CallMainMenuExitButtonClicked);
        }

        void OnDestroy()
        {
            gameObject.GetComponent<Button>().onClick.RemoveListener(EventBroker.CallMainMenuExitButtonClicked);
        }
    }
}
