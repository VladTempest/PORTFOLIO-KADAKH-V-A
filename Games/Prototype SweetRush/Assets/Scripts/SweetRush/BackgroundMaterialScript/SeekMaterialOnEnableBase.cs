using System.Collections;
using System.Collections.Generic;
using SweetRush;
using UnityEngine;

public class SeekMaterialOnEnableBase: MonoBehaviour
{
    private Material _materialOfBackgroundPart;
    protected string _nameOfBackgroundPart=null;
    // Start is called before the first frame update
    void OnEnable()
    {
        _materialOfBackgroundPart=CinematicLookManager.Instance.GetMaterialForBackgroundParts(_nameOfBackgroundPart);
        GetComponent<MeshRenderer>().material = _materialOfBackgroundPart;
    }

}
