using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{
    
    public class ButtonHighlitedScript : StateMachineBehaviour
    {

        
       
        // Start is called before the first frame update
        public void OnStateEnter()
        {
            
            AudioManager.Instance.PlaySoundFX(3,15);
        }

       
        
        
        // Update is called once per frame

    }
}