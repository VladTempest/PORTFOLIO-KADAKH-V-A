using System;
using UnityEngine;

namespace SweetRush
{
    public class BurpInterface : MonoBehaviour
    {
        public GameObject burpMask;
        public GameObject burp;
        

        private RectTransform _maskRectTransformComponent;

        [SerializeField]
        private Vector3 _scaleOfMaxSize=new Vector3(1.8f,2f,2f);
        private void Awake()
        {
            _maskRectTransformComponent = burpMask.GetComponent<RectTransform>();
            IncreaseBurpIndicator(CharacteristicManager.Instance.currentCombo,CharacteristicManager.Instance.maxCombo);
        }
        
        public void IncreaseBurpIndicator(int currentCombo, int maxCombo)
        {
            burp.transform.SetParent(transform);
            _maskRectTransformComponent.localScale = new Vector3(_scaleOfMaxSize.x,
                0.01f + _scaleOfMaxSize.y * ((float)currentCombo/maxCombo), _scaleOfMaxSize.z);
            burp.transform.SetParent(burpMask.transform);
        }
        
    }
}