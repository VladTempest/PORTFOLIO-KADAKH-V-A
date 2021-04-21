using System;
using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;

public class OutOfBoundsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.HasComponent<CubeBahaviour>())
        {
            EventBroker.CallCubeDestroyed();
        }
        Destroy(other.gameObject);
    }
}
