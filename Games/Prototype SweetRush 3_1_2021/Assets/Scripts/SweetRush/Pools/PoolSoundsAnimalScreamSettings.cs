using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolSoundsAnimalScreamSettings",menuName = "Settings/PoolSoundsAnimalScreamSettings", order=0)]
    public class PoolSoundsAnimalScreamSettings : PoolSoundsOfPoolsSettings
    {
        public List<SoundTrack> pool;

    }
}