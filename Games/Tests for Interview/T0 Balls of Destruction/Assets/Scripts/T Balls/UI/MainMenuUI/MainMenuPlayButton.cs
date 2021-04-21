using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TBalls
{
    public class MainMenuPlayButton : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(EventBroker.CallMainMenuPlayButtonClicked);
        }

        void OnDestroy()
        {
            gameObject.GetComponent<Button>().onClick.RemoveListener(EventBroker.CallMainMenuPlayButtonClicked);
        }

    }
}
