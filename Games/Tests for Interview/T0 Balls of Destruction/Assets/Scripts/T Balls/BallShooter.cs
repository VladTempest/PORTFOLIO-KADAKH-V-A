using System.Collections;
using System.Collections.Generic;
using TBalls;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class BallShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballPrefab=null;
    [SerializeField]
    private Transform _mainCameraTransform = null;
    [SerializeField]
    private float _pushPower = 1000f;
    
    // Start is called before the first frame update
    public void InstantiateBalls()
    {
        GameObject ball = Instantiate(_ballPrefab, _mainCameraTransform.position, transform.rotation);
        AccelerateTowardsAim(ball);
        EventBroker.CallBallInstantiated();
    }

    private void AccelerateTowardsAim(GameObject ball)
    {
        ball.transform.LookAt(GetAimDirection());
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward*_pushPower);
    }

    private Vector3 GetAimDirection()
    {
        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetDistanceTowardsAim());
        GetDistanceTowardsAim();
        position = Camera.main.ScreenToWorldPoint(position);
        return position;
    }

   private float GetDistanceTowardsAim()
   {
       RaycastHit hit;
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out hit))
       {
           return (Camera.main.transform.position - hit.transform.position).magnitude;
       }
       return 10f;
   }
    // Update is called once per frame

}
