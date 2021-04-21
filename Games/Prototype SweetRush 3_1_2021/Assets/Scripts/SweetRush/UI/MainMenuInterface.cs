using System.Collections;
using System.Collections.Generic;
using SweetRush;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInterface : InterfaceBase
{
    [SerializeField]
    private Button _runButton = null;
    [SerializeField]
    private Button _quitButton = null;

    // Start is called before the first frame update
    void Start()
    {
        _runButton.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowMainMenuInterface(false);
            UIManager.Instance.ShowInputNameInterface(true);
        });
        
        _quitButton.onClick.AddListener(Application.Quit);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
