using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolBurpsSettings",menuName = "Settings/PoolBurpsSettings", order=0)]
    public class PoolBurpsSettings : ScriptableObject
    {
        public List<BurpBehaviour> pool;

    }
}