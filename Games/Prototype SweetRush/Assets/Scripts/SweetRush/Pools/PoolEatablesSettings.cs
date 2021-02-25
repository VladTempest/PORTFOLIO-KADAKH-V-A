using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolEatablesSettings",menuName = "Settings/PoolEatablesSettings", order=0)]
    public class PoolEatablesSettings : ScriptableObject
    {
        public List<EatablesBehaviourBase> pool;

    }
}