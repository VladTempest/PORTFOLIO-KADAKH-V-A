using System.Collections;
using System.Collections.Generic;
using SweetRush;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDifficultyInterface : InterfaceBase
{
    [SerializeField]
    private Button _easyButton=null;
    [SerializeField]
    private Button _mediumButton=null;
    [SerializeField]
    private Button _hardButton=null;
    // Start is called before the first frame update
    void Awake()
    {
       _easyButton.onClick.AddListener(SetEasyDifficulty);
       _easyButton.onClick.AddListener(StartGameByClick);
       _easyButton.onClick.AddListener(HideChooseDifficultyInterface);
       _mediumButton.onClick.AddListener(SetMediumDifficulty);
       _mediumButton.onClick.AddListener(StartGameByClick);
       _mediumButton.onClick.AddListener(HideChooseDifficultyInterface);
       _hardButton.onClick.AddListener(SetHardDifficulty);
       _hardButton.onClick.AddListener(StartGameByClick);
       _hardButton.onClick.AddListener(HideChooseDifficultyInterface);
    }

    private void SetEasyDifficulty()
    {
        GameManager.Instance.difficultyLevel = GameDifficulty.Easy;
    }
    
    private void SetMediumDifficulty()
    {
        GameManager.Instance.difficultyLevel = GameDifficulty.Medium;
    }
    
    private void SetHardDifficulty()
    {
        GameManager.Instance.difficultyLevel =  GameDifficulty.Hard;
    }

    // Update is called once per frame
    private void HideChooseDifficultyInterface()
    {
        gameObject.SetActive(false);
    }

    private void StartGameByClick()
    {
        UIManager.Instance.ShowTutorialInterface(true);
        
    }
}
