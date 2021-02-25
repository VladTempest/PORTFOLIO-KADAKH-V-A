using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{
    
    public class ButtonPressedScript : StateMachineBehaviour{
   
        // Start is called before the first frame update
        void OnStateEnter()
        {
    AudioManager.Instance.PlaySoundFX(3,14);
        }

        // Update is called once per frame

    }
}