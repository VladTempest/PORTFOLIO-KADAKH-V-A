using UnityEngine;

namespace SweetRush
{


    public enum ObstacleType
    {
        Chick=0,
        Crow=1,
        Dog=2,
        Frog=3
    }
    public class ObstacleBehaviour : SpawnedObjectBase


    {
        public ObstacleType type=0;
        
        [SerializeField] private float _speed=10;
        
        
        private Rigidbody _obstacleRigidbody;

        // Start is called before the first frame update
        private void Start()
        {
            _obstacleRigidbody = GetComponent<Rigidbody>();
            CharacteristicManager.Instance.AccelerationOfSpeed(ref _speed);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var velocityY=_obstacleRigidbody.velocity.y;
            _obstacleRigidbody.velocity=new Vector3(-1*(_speed * Time.deltaTime),velocityY,0);
        }
    }
}