using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{
    public class KillerObjectBehaviour : MonoBehaviour
    {
        private bool _placeholder = true;
        // Start is called before the first frame update
        void Update()
        {
           if (GameManager.Instance._isGameStart) Destroy(gameObject); 
        }
        private void OnTriggerEnter(Collider other)
        {

            //Sends information about collision to Collision Manager.
            CollisionManager.Instance.CollisionAnalyzer(gameObject, other.gameObject, ref _placeholder);
        }
    }
}
