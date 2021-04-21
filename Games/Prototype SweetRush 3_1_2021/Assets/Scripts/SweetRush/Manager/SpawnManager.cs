using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SweetRush
{
    public class SpawnManager : SingletonInitiatorBase<SpawnManager>
    {
      
        public bool _isGameStart=false;

        public GameObject iceCreamTruck=null;
        
        

        private Transform _playerTransformComponent;
       
        private readonly Vector3 _playerStartPosition = new Vector3(-8f,1f,0);
        private int _maxNumberOfObstacleTypes;
        private Coroutine _spawnObstaclesroutine = null;
        private Coroutine _spawnEatablesroutine = null;
        private GameObject _spawnedCart;
        private GameObject _spawnedKillerObject=null;
        
        [SerializeField]
        private float _minDelayTimeObstacles = 1;
        [SerializeField]
        private float _maxDelayTimeObstacles = 3f;

        [SerializeField]
        private float _minDelayTimeEatables = 2f;
        [SerializeField]
        private float _maxDelayTimeEatables = 4f;
    
       [SerializeField]
        private PoolObstacleSettings _poolObstacles = null;
        [SerializeField]
        private PoolEatablesSettings _poolEatables = null;
        [SerializeField]
        private PoolBurpsSettings _poolBurps = null;
        
        
        [SerializeField]
        private GameObject _cartPrefab=null;
        [SerializeField]
        private GameObject _killerObjectPrefab = null;

        

        public void Awake()
        {
            _playerTransformComponent = PlayerController.Instance.transform;

            if (_isGameStart)
            {
                _spawnObstaclesroutine = StartCoroutine(SpawnObstacles(_minDelayTimeObstacles, _maxDelayTimeObstacles));
                _spawnEatablesroutine = StartCoroutine(SpawnEatables(_minDelayTimeEatables, _maxDelayTimeEatables));
            }
        }

        


        private IEnumerator SpawnObstacles(float minDelayTimeObstaclesLocal, float maxDelayTimeObstaclesLocal)
        {

            while (_isGameStart)
            {
                yield return new WaitForSeconds(Random.Range(minDelayTimeObstaclesLocal, maxDelayTimeObstaclesLocal));
                if (!_isGameStart) continue;
                var index = Random.Range(0, _maxNumberOfObstacleTypes);
                var transform1 = transform;
                var positionComponentObstacle = transform1.position;
                Instantiate(_poolObstacles.pool[index],
                    index > 1
                        ? positionComponentObstacle
                        : new Vector3(positionComponentObstacle.x, 3.5f, positionComponentObstacle.z),
                    transform1.rotation);
            }
        }

        private IEnumerator SpawnEatables(float minDelayTimeEatablesLocal, float maxDelayTimeEatablesLocal)
        {
            
            while (_isGameStart)
            {
                yield return new WaitForSeconds(Random.Range(minDelayTimeEatablesLocal, maxDelayTimeEatablesLocal));
                if (!_isGameStart) continue;
                var index = Random.Range(0, _poolEatables.pool.Count);
                var positionComponentEatable = transform.position;
                AudioManager.Instance.PlaySoundFX(1);
                AnimationManager.Instance.PlayIceCreamTruckBumpingOnBumpAnimation(Random.Range(0.6f,0.8f));
                //AudioManager.Instance.TestSound1();
                Instantiate(_poolEatables.pool[index],
                    new Vector3(Random.Range(positionComponentEatable.x - 7,positionComponentEatable.x - 5), positionComponentEatable.y + 3,
                        positionComponentEatable.z),
                    transform.rotation);
                

            }
        }

        public void SpawnBurp()
        {
            if (_isGameStart)
            {
                //Can be more variants of Burps potentially
                var index = Random.Range(0, _poolBurps.pool.Count);
                var position = _playerTransformComponent.position;
                var burpGameObject=Instantiate(_poolBurps.pool[index],
                    new Vector3(position.x+0.5f,
                        position.y + 1.5f, 0),
                    _playerTransformComponent.rotation);
                AudioManager.Instance.PlaySoundFX(3,2);
                StartCoroutine(UIManager.Instance.ShakeBurpInterface());
            }
        }

        public void SpawnPlayerAndStuff()
        {
            //Spawn Player
            PlayerController.Instance.GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
            _playerTransformComponent.position = _playerStartPosition;
            PlayerController.Instance.GetComponent<Rigidbody>().isKinematic = false;

 
            
            (_spawnedCart=Instantiate (_cartPrefab, new Vector3(16.82f, 0.31f, 1.73f), Quaternion.Euler(0,90f,0))).transform.parent = iceCreamTruck.transform;
            _spawnedCart.transform.localScale=new Vector3(2.5f,2.5f,2.5f);
            AnimationManager.Instance.GetIceCreamTruckAnimatorComponent();
            
            
        }

        public void DestroySpawnedStuff()
        {
            Destroy(_spawnedCart);
        }


        //This method stop spawn coroutine and start another with lesser parameters
        public void SpawnAccelerator(float accelerationValueSpawn, float accelerationValueSpeedOfBackground)
        {
            StopCoroutine(_spawnObstaclesroutine);
            StopCoroutine(_spawnEatablesroutine);
            
            _spawnObstaclesroutine=StartCoroutine(SpawnObstacles(_minDelayTimeObstacles/accelerationValueSpawn, _maxDelayTimeObstacles/accelerationValueSpawn));
            _spawnEatablesroutine=StartCoroutine(SpawnEatables(_minDelayTimeEatables/accelerationValueSpawn, _maxDelayTimeEatables/accelerationValueSpawn));
            

            BackGroundBehaviour.Instance._speed *= accelerationValueSpeedOfBackground;
        }

        public void SetPoolMaxIndexAccordingToDifficulty(int difficultyLevel)
        {
            _maxNumberOfObstacleTypes = _poolObstacles.pool.Count;
            if (difficultyLevel==0) _maxNumberOfObstacleTypes -= 1;

        }

        public void SpawnKillerObject(bool isGameActive)
        {
            _spawnedKillerObject = Instantiate(_killerObjectPrefab, Vector3.zero, transform.rotation);

        }
    }
}