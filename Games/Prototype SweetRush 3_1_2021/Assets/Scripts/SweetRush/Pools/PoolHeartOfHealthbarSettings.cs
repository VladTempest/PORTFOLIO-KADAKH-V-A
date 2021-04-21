using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolHeartOfHealthbarSettings",menuName = "Settings/PoolHeartOfHealthbarSettings", order=0)]
    public class PoolHeartOfHealthbarSettings : ScriptableObject
    {
        public List<GameObject> pool;

    }
}