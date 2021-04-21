using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{
    public class BackGroundBehaviour : SingletonInitiatorBase<BackGroundBehaviour>
    {
        
        public bool _isGameStart=false;


        public float _speed = 25;

        

        private void FixedUpdate()
        {
            if (_isGameStart)
            {
                BackgroundMovement(); 
            }
            else
            {
                transform.Translate( Vector3.zero);
            }
           
        }

        public void BackgroundMovement() //Description of cycled background movement.
        {
            transform.Translate(Vector3.left * (_speed * Time.deltaTime));
            if (transform.position.x <= -112)
            {
                transform.position = new Vector3(0, 4, 7);
            }
        }
    }
}