using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolSoundsObstacleKillSettings",menuName = "Settings/PoolSoundsObstacleKillSettings", order=0)]
    public class PoolSoundsObstacleKillSettings : PoolSoundsOfPoolsSettings
    {
        public List<SoundTrack> pool;

    }
}