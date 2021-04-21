using System.Collections.Generic;
using UnityEngine;


namespace TBalls
{
    [CreateAssetMenu(fileName = "PoolFiguresSettings",menuName = "Settings/PoolFiguresSettings", order=0)]
    public class PoolFiguresSettings : ScriptableObject
    {
        public List<GameObject> pool;

    }
}