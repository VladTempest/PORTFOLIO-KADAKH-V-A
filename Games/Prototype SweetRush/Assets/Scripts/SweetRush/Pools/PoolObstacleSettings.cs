using System.Collections.Generic;
using UnityEngine;

namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolObstacleSettings",menuName = "Settings/PoolObstacleSettings", order=0)]
    public class PoolObstacleSettings : ScriptableObject
    {
        public List<ObstacleBehaviour> pool;

    }
}
