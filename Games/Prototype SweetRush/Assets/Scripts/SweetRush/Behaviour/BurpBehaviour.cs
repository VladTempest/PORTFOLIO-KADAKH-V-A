using System.Collections;

using UnityEngine;

namespace SweetRush
{
    public class BurpBehaviour : SpawnedObjectBase
    {
        private Rigidbody _burpRigidbody;
        private bool _placeholder = true;

        
        [SerializeField]
        private float _speed = 10f;

        
        [SerializeField]
        private float _burpLifeTime = 1;

        public int numberOfKilledByThisBurp = 0;
        
       
        
        private void Start()
        {
            // Нужна функция Старт(), так как иначе не успевает привязаться объект CollisionManager через скрипт SpawnManager.
            _burpRigidbody = GetComponent<Rigidbody>();
            //Shaky cam from burp
            FXManager.Instance.CameraShakeEffect(_burpLifeTime);
            StartCoroutine(BurpSuicide());
        }

        private void Update()
        {
            //Translate movements to Burp.
            _burpRigidbody.velocity = Vector3.right * _speed;
        }

        private void OnTriggerEnter(Collider other)
        {
        
            //Sends information about collision to Collision Manager.
           CollisionManager.Instance.CollisionAnalyzer(gameObject, other.gameObject, ref _placeholder);
        }

        private IEnumerator BurpSuicide() //Destroying Burp after LifeTime. 
        {
            yield return new WaitForSeconds(_burpLifeTime);
            Destroy(gameObject.GetComponent<BoxCollider>());
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
