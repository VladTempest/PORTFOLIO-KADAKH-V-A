using System;
using System.Collections;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace SweetRush
{
    public class PlayerController : SingletonInitiatorBase<PlayerController>
    {
        private SkinnedMeshRenderer _playerRender { get; set; }
        private Rigidbody _playerRigidbody { get; set; }
        private BoxCollider _playerBoxCollider { get; set; }
        private float _inputHorizontal;
        
        public bool _isGameStart = false;
        public bool _isOnGround = true;
    //Инициализация переменных для управления.
        [SerializeField]
        private float _speed = 100;
        [SerializeField]
        private float _forceJump = 100;
        [SerializeField]
        private float _forceHorizontalJumpMultiplier=0.6f;
        
        [SerializeField]
        private float _fallMultiplier = 2.5f;
        [SerializeField]
        private float _lowJumpMultiplier = 2f;
        [SerializeField]
        private float _xBound = 12;
        private SkinnedMeshRenderer _skinnedMeshRenderer;



        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            _playerRender = GetComponentInChildren<SkinnedMeshRenderer>();
            _playerBoxCollider = GetComponentInChildren<BoxCollider>();
            
            //If Rider is right this initializing of field eliminate critical memory usage in HideThePlayer() 
            _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            

        }

        private void Update()
        {
            if (_isGameStart)
            {
                MovePlayer();
            }
            
        }

        private void FixedUpdate()
        {
            AnimationManager.Instance.CheckForJumpButtonPressed(Input.GetKey(KeyCode.Space));
            JumpImprove();
            BoundariesPlayer();
            if (_isOnGround) AnimationManager.Instance.PlayRunAnimation();
            if (Input.GetKeyDown(KeyCode.F)&&(CharacteristicManager.Instance.IsComboReady()))
            {
                CharacteristicManager.Instance.IncreaseEatablesCounter(false);
                Burp();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            CollisionManager.Instance.CollisionAnalyzer(gameObject, collision.gameObject, ref _isOnGround);
        }

        //Move Player in the game space.
        private void MovePlayer()
        {
            //Описание управления персонажем

            //По горизонатльной оси.
            _inputHorizontal = Input.GetAxis("Horizontal");
            AnimationManager.Instance.SwitchSpeedOfRunAnimation(_inputHorizontal);
            if ((_inputHorizontal != 0) && (_isOnGround))
            {
                {
                    _playerRigidbody.velocity = Vector3.right * (_inputHorizontal * _speed);
                    
                }

                if ((_inputHorizontal > 0) && (Input.GetKeyDown(KeyCode.Space) && (_isOnGround)))
                {
                    AudioManager.Instance.PlaySoundFX(3,8);
                   _isOnGround = false;
                    _playerRigidbody.velocity = Vector3.zero;
                    _playerRigidbody.AddForce(new Vector3(1, 1, 0) * (_forceHorizontalJumpMultiplier * _forceJump),
                        ForceMode.Impulse);
                    AnimationManager.Instance.PlayJumpAnimation();
                }
                else if ((_inputHorizontal < 0) && (Input.GetKeyDown(KeyCode.Space) && (_isOnGround)))
                {
                    AudioManager.Instance.PlaySoundFX(3,8);
                   _isOnGround = false;
                   FreezePlayer();
                    _playerRigidbody.AddForce(new Vector3(-1, 1, 0) * (_forceHorizontalJumpMultiplier * _forceJump),
                        ForceMode.Impulse);
                    AnimationManager.Instance.PlayJumpAnimation();
                }
            }
            //По вертикали.
            if (Input.GetKeyDown(KeyCode.Space) && (_isOnGround))
            {
                AudioManager.Instance.PlaySoundFX(3,8);
                AnimationManager.Instance.PlayJumpAnimation();
                _isOnGround = false;
                FreezePlayer();
                _playerRigidbody.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
            }
        }


        private void JumpImprove() //Method to improve feel of jumping, to make it more Mario-like
        {
            if (_playerRigidbody.velocity.y < 0)
            {
                _playerRigidbody.velocity += Vector3.up * (Physics.gravity.y * (_fallMultiplier - 1) * Time.deltaTime);
            }
            else if (_playerRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                _playerRigidbody.velocity +=
                    Vector3.up * (Physics.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime);
            } 
        }
        //Stop movement out boundaries. 
        private void BoundariesPlayer()
        {
            Vector3 playerTransformPosition = transform.position;
            if (playerTransformPosition.x < -_xBound)
            {
                transform.position = new Vector3(-_xBound, playerTransformPosition.y, playerTransformPosition.z);
            }

            if (playerTransformPosition.x > _xBound)
            {
                transform.position = new Vector3(_xBound, playerTransformPosition.y, playerTransformPosition.z);
            }
            
            
        }

        //Make Player invincible after collision with obstacle. 
        public IEnumerator PlayerInvincibility()
        {
            if (!_isGameStart) yield break;
            yield return new WaitForSeconds(0.1f);
            AnimationManager.Instance.PlayGetHitAnimation();
            _playerBoxCollider.enabled = false;
            while (transform.position.y >= 0.9f)
            {
                if (_playerRender.enabled)
                {
                    yield return new WaitForSeconds(0.1f);
                    _playerRender.enabled = false;
                }
                else
                {
                    yield return new WaitForSeconds(0.08f);
                    _playerRender.enabled = true;
                }
            }
            AnimationManager.Instance.PlayGetHitAnimation();
            _playerRender.enabled = true;
            _playerBoxCollider.enabled = true;
            }

        
        private void Burp()
        {
            SpawnManager.Instance.SpawnBurp();
            
        }

        public void HideThePlayer()
        {
            _skinnedMeshRenderer.enabled=false;
            _playerRigidbody.isKinematic= true;
        }

        public void PlayStepSound()
        {
            AudioManager.Instance.PlaySoundFX(3,9);
        }

        public void FreezePlayer()
        {
            _playerRigidbody.velocity = Vector3.zero;
        }
    }
}