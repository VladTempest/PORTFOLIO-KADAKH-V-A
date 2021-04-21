using UnityEngine;

namespace SweetRush
{
    public class EatablesBehaviourBase : SpawnedObjectBase
    {
       
        [SerializeField]
        private float _force = 10;
        [SerializeField]
        private bool _wasOnGround = false;
        
        private Rigidbody _eatableRigidbody;

        // Нужна функция Старт(), так как иначе не успевает привязаться объект CollisionManager через скрипт SpawnManager.
        private void Start()
        {
            
            _eatableRigidbody = GetComponent<Rigidbody>();
            PushOutEatable();
            if (GetComponent<EatableHeartPickUpBehaviour>() == null)
            {
                CharacteristicManager.Instance.AddToEatablesQuantity();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            CollisionManager.Instance.CollisionAnalyzer(gameObject,collision.gameObject, ref _wasOnGround);
        }

        private void PushOutEatable()
        {
            var forceX = Random.Range(-1f, -0.6f);
            var forceY = Random.Range(0.5f, 1f);
            _eatableRigidbody.AddForce(
                new Vector3(forceX, forceY, 0) * _force,
                ForceMode.Impulse);
            
            _eatableRigidbody.AddTorque(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f),
                Random.Range(0.0f, 360.0f), ForceMode.Impulse);
        }


    }
}