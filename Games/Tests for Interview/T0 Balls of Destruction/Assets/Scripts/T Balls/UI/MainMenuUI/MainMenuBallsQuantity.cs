using System;
using System.Collections;
using System.Collections.Generic;
using TBalls;
using TMPro;
using UnityEngine;

public class MainMenuBallsQuantity : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.UsedBallsQuantity.ToString();
    }
}
