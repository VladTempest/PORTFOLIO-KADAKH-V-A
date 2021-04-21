using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SweetRush
{
    public class TutorialInterface : InterfaceBase
    {
        [FormerlySerializedAs("_OKButton")]
        [SerializeField]
        private Button _okButton = null;
        // Start is called before the first frame update
        void Start()
        {
            _okButton.onClick.AddListener(() =>
            {
                UIManager.Instance.ShowTutorialInterface(false);
                GameManager.Instance.StartGame();
            });
        }

        // Update is called once per frame
       
    }
}
