using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolSoundsWooshSettings",menuName = "Settings/PoolSoundsWooshSettings", order=0)]
    public class PoolSoundsWooshSettings : PoolSoundsOfPoolsSettings
    {
        public List<SoundTrack> pool;

    }
}