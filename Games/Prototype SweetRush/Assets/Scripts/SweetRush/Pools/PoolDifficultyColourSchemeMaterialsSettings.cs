using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolDifficultyColourSchemeMaterialsSettings",menuName = "Settings/PoolDifficultyColourSchemeMaterialsSettings", order=0)]
    public class PoolDifficultyColourSchemeMaterialsSettings : ScriptableObject
    {
        public List<Material> pool;

    }
}
