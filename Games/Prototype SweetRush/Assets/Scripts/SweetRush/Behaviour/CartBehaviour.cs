using System.Collections;
using System.Collections.Generic;
using SweetRush;
using UnityEngine;

public class CartBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private void AnimationStartJumpEvent()
    {
        AudioManager.Instance.PlaySoundFX(3,3);
    }
    
    private void AnimationStopJumpEvent()
    {
        AudioManager.Instance.PlaySoundFX(3,4);
    }
}
