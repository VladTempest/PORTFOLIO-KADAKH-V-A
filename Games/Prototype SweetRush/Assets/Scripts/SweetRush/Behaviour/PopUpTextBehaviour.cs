using System.Collections;
using System.Collections.Generic;
using SweetRush;
using UnityEngine;

public class PopUpTextBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _delayTransparencyIncrease=0.05f;
    [SerializeField]
    private float _finalTransparency = 0.1f;
    [SerializeField]
    private float _stepOfTransparencyIncrease = 0.2f;
    [SerializeField]
    private float _startTimeOfTransparencyIncrease = 0.5f;
    private TextMesh _textMeshComponent;
    // Start is called before the first frame update
    void Awake()
    {
        _textMeshComponent = GetComponent<TextMesh>();
        _textMeshComponent.text = CharacteristicManager.Instance.GetLastAddedValueToHighScore().ToString();
        StartCoroutine(GradientTransparency());
    }

    private void ChooseValueByObjectOfCollision()
    {
        CharacteristicManager.Instance.GetLastAddedValueToHighScore();
    }
    private IEnumerator GradientTransparency()
    {
        yield return (new WaitForSeconds(_startTimeOfTransparencyIncrease));
        
        var textColor = _textMeshComponent.color;
        textColor.a = _textMeshComponent.color.a;
        while (textColor.a > _finalTransparency)
        {
            textColor.a -= _stepOfTransparencyIncrease;
            _textMeshComponent.color = textColor;
            yield return (new WaitForSeconds(_delayTransparencyIncrease));
        }
        Destroy(gameObject);
    }
    
}


