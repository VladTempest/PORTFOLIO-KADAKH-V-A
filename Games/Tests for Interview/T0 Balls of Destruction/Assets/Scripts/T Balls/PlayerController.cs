using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject ballShooter = null;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) 
                return;
            
            ballShooter.GetComponent<BallShooter>().InstantiateBalls();
        };

    }
}
