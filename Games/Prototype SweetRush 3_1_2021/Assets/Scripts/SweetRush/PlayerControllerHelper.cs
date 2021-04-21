using System.Collections;
using System.Collections.Generic;
using SweetRush;
using UnityEngine;

public class PlayerControllerHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void PlayStepSound()
    {
        transform.parent.GetComponent<PlayerController>().PlayStepSound();
    }
    
    
    
}
