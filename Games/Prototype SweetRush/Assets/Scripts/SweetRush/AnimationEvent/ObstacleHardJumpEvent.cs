using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHardJumpEvent : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _hardObstacleRigidbody=null;

    [SerializeField]
    private float _force=600f;
    private void Awake()
    {
        //_hardObstacleRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void AddForceToFrog()
    {
        _hardObstacleRigidbody.AddForce(0,_force,0,ForceMode.Impulse);
    }

    
}
