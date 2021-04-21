using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace SweetRush
{


//---------------------
    public class FXManager : SingletonInitiatorBase<FXManager>
    {
        private Image _flashImageComponent = null;
        private Image _gameOverRedImageComponent = null;
        private Transform _mainCameraTransformComponent = null;
        private Coroutine _currentFlashEffectCoroutine = null;
        private Coroutine _currentGameOverRedEffectCoroutine;
        [SerializeField]
        private GameObject _mainCamera = null;

        [SerializeField]
        private float _speedOfFlashFadeIn=2f;
        [SerializeField]
        private float _speedOfFGameOverRedFadeIn=1f;
        

        [SerializeField]
        private float _cameraShakeTime = 2.0f;
        [SerializeField]
        private float _cameraShakeAmount = 3.0f;
        [SerializeField]
        private float _cameraShakeSpeed = 2.0f;

        [SerializeField]
        private PoolFXSettings _poolFX=null;

        [SerializeField]
        private GameObject _flashImage=null;
        
        [SerializeField]
        private GameObject _gameOverRedImage=null;
        

        
        //---------------------
// Use this for initialization
        void Awake()
        {
            _mainCameraTransformComponent = _mainCamera.GetComponent<Transform>();
            _flashImageComponent = _flashImage.GetComponent<Image>();
            _gameOverRedImageComponent=_gameOverRedImage.GetComponent<Image>();


        }

      

        public void PlayFlashScreenEffect()
        {
            _flashImage.SetActive(true);
            if (_currentFlashEffectCoroutine!=null) StopCoroutine(_currentFlashEffectCoroutine);
            _currentFlashEffectCoroutine=StartCoroutine(FlashEffectCoroutine());
        }
        public void PlayGameOverRedScreenEffect(bool isItPreStopGameScreen)
        {
            var startColor = Color.red;
            
            _gameOverRedImage.SetActive(isItPreStopGameScreen);
            
            startColor.a=0.0f;
            _gameOverRedImageComponent.color = startColor;
            if (_currentGameOverRedEffectCoroutine != null&&!isItPreStopGameScreen)
            {
                StopCoroutine(_currentGameOverRedEffectCoroutine);
                _gameOverRedImageComponent.color = startColor;
                
                
                return;
            }
            _currentGameOverRedEffectCoroutine=StartCoroutine(PlayGameOverRedEffectCoroutine());
        }
        
        

        
        
        
        private IEnumerator FlashEffectCoroutine()
        {
            var targetAlpha = 0.0f;
            Color curColor = Color.white;
            curColor.a = 0.9f;
            _flashImageComponent.color = curColor;
            while (Mathf.Abs(curColor.a - targetAlpha) > 0.08f)
            {
               curColor.a = Mathf.Lerp(curColor.a, targetAlpha, (_speedOfFlashFadeIn) * Time.deltaTime);
                _flashImageComponent.color = curColor;
                yield return null;
            }
            _flashImage.SetActive(false);
            curColor.a = 0.9f;
            _flashImageComponent.color = curColor;

        }

        private IEnumerator PlayGameOverRedEffectCoroutine()
        {
            yield return new WaitForSeconds(1);
            var targetAlpha = 1f;
            Color curColor = Color.red;
            curColor.a = 0.0f;
            _gameOverRedImageComponent.color = curColor;
            while (Mathf.Abs(curColor.a - targetAlpha) > 0.08f)
            {
                curColor.a = Mathf.Lerp(curColor.a, targetAlpha, (_speedOfFGameOverRedFadeIn) * Time.deltaTime);
                _gameOverRedImageComponent.color = curColor;
                yield return null;
            }
            _gameOverRedImageComponent.color = curColor;
            
        }




        public void PlayFX(GameObject explodingObject, int indexOfFX)
        {
            //GameObject playingFX=
                Instantiate(_poolFX.pool[indexOfFX], explodingObject.transform.position, transform.rotation);
           // StartCoroutine(DestroyPlayedFX(playingFX)); //it isn't needed for now, but it stays for extra caution sake
        }

        //DestroydPlayedFX isn't needed for now, but it stays for extra caution sake 
        private IEnumerator DestroyPlayedFX(GameObject playedFX)
        {
            yield return new WaitForSeconds(5);
            Destroy(playedFX);
        } 
        public void CameraShakeEffect(float shakeTime)
        {
            _cameraShakeTime = shakeTime;
            StartCoroutine(CameraShake());
        }

        private IEnumerator CameraShake()
        {
            Vector3 OrigPosition = _mainCameraTransformComponent.localPosition;
//Count elapsed time (in seconds)
            float ElapsedTime = 0.0f;
//Repeat for total shake time
            while (ElapsedTime < _cameraShakeTime)
            {
//Pick random point on unit sphere
                Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere *
                    _cameraShakeAmount;
//Update Position
                _mainCameraTransformComponent.localPosition = Vector3.Lerp(_mainCameraTransformComponent.localPosition, RandomPoint,
                    Time.deltaTime * _cameraShakeSpeed);
//Break for next frame
                yield return null;
//Update time
                ElapsedTime += Time.deltaTime;
            }

//Restore camera position
            _mainCameraTransformComponent.localPosition = OrigPosition;
        }

    }
}

