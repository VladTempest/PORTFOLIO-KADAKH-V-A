using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolSoundsPopSettings",menuName = "Settings/PoolSoundsPopSettings", order=0)]
    public class PoolSoundsPopSettings : PoolSoundsOfPoolsSettings
    {
        public List<SoundTrack> pool;

    }
}