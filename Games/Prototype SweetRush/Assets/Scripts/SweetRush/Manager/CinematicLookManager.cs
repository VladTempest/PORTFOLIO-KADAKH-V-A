using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{


    public class CinematicLookManager : SingletonInitiatorBase<CinematicLookManager>
    {
        [HideInInspector]
        public Material cityMaterial=null;
        [HideInInspector]
        public Material roadMaterial=null;
        [HideInInspector]
        public Material groundMaterial=null;

        [SerializeField]
        private GameObject _backgroud=null;
        [SerializeField]
        private GameObject _icecreamTruck=null;
        [SerializeField]
        private PoolDifficultyColourSchemeMaterialsSettings _poolMaterials=null;
        [SerializeField]
        private GameObject _mainCamera = null;
        [SerializeField]
        private GameObject _cinematicCamera = null;
        [SerializeField]
        private int numberOfStepToRotate = 150;
        [SerializeField]
        private int currentStepOfRotation = 0;


        private Coroutine _cameraRotation = null;
        private Coroutine _cameraTransition=null;
        private Vector3 _mainCameraTransformPosition=Vector3.zero;
        private Quaternion _mainCameraTransformRotation=Quaternion.identity;
        readonly Vector3 _offsetRotation = new Vector3(7.6f, -30.3f, -5.5f);

        void OnEnable()
        {
            _mainCameraTransformPosition = _mainCamera.transform.position;
            _mainCameraTransformRotation = _mainCamera.transform.rotation;
        }

        public void ResetCameraTransform()
        {
            if ((_cameraRotation!=null)||(_cameraTransition!=null))
            {
                StopCoroutine(_cameraRotation);
                StopCoroutine(_cameraTransition);
                _mainCamera.transform.position = _mainCameraTransformPosition;
                _mainCamera.transform.rotation=_mainCameraTransformRotation;
                _cinematicCamera.transform.rotation=_mainCameraTransformRotation;
                _cinematicCamera.SetActive(false);
                _mainCamera.SetActive(true);   
            }
            
            
        }
        // Start is called before the first frame update
        public void ChangeActiveCamera()
        {
           
            var playerTransform = PlayerController.Instance.transform;
            Vector3 offsetPosition = new Vector3(3.5f, 3.8f, -6.7f);
            _cinematicCamera.transform.position = playerTransform.position+offsetPosition;
            _cameraRotation=StartCoroutine(SmoothCameraRotationCoroutine(_offsetRotation));
            _cameraTransition=StartCoroutine(SmoothCameraTransitionCoroutine(_mainCamera.transform,_cinematicCamera.transform));
            

        }
        public void ShowModelsOfGameplay(bool isGameActive)
        {
            EnableBackground(isGameActive);
            EnablePlayerModel(isGameActive);
        }
        

        //Set colour scheme accordingly to difficulty level. 
        public void ChooseMaterialsForDecorations(int difficulty)
        {
            groundMaterial = _poolMaterials.pool[0 + 3 * difficulty];
            roadMaterial= _poolMaterials.pool[1 + 3 * difficulty];
            cityMaterial= _poolMaterials.pool[2 + 3 * difficulty];
        }
        private void EnablePlayerModel(bool isGameActive)
        {
            PlayerController.Instance.GetComponent<Rigidbody>().useGravity=isGameActive;
        }

        private void EnableBackground(bool isGameActive)
        {
            _backgroud.SetActive(isGameActive);
            _icecreamTruck.SetActive(isGameActive);
        }

        public Material GetMaterialForBackgroundParts(string nameOfBackgroundPart)
        {
            switch (nameOfBackgroundPart)
            {
                case "ground":
                    return groundMaterial;
                case "city":
                    return cityMaterial;
                case "road":
                    return roadMaterial;
                default:
                    return null;
            }
        }

        private IEnumerator SmoothCameraTransitionCoroutine(Transform startTransform, Transform finalTransform)
        {
            var speedOfTransition = 1f;
            Vector3 currentPosition=startTransform.position;
            while ((Mathf.Abs(currentPosition.x - finalTransform.position.x)+Mathf.Abs(currentPosition.y - finalTransform.position.y)+Mathf.Abs(currentPosition.z - finalTransform.position.z))> 0.1f)
            {
                var currentPositionX = Mathf.Lerp(currentPosition.x, finalTransform.position.x, (speedOfTransition) * Time.deltaTime);
                var currentPositionY = Mathf.Lerp(currentPosition.y, finalTransform.position.y, (speedOfTransition) * Time.deltaTime);
                var currentPositionZ = Mathf.Lerp(currentPosition.z, finalTransform.position.z, (speedOfTransition) * Time.deltaTime);

                currentPosition = new Vector3(currentPositionX, currentPositionY, currentPositionZ);
                _mainCamera.transform.position = currentPosition;
                
                
                yield return null;
            }
            _mainCamera.SetActive(false);
            _cinematicCamera.SetActive(true);
            
        }

        private IEnumerator SmoothCameraRotationCoroutine(Vector3 finalRotation)
        {
            while (currentStepOfRotation <= (numberOfStepToRotate + 1)) 
            {
                Vector3 offsetOfStep = finalRotation / numberOfStepToRotate;
                _mainCamera.transform.Rotate(offsetOfStep,Space.World);
                _cinematicCamera.transform.Rotate(offsetOfStep,Space.World);
                currentStepOfRotation++;
                yield return new WaitForSeconds(0.008f);
            }
            
            currentStepOfRotation = 0;

        }
    }
}
