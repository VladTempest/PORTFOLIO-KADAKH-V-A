using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{

    public class InterfaceBase : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AudioManager.Instance.PlaySoundFX(6);
        }

        // Update is called once per frame

    }
}
