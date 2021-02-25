using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolSoundsEatingSettings",menuName = "Settings/PoolSoundsEatingSettings", order=0)]
    public class PoolSoundsEatingSettings : PoolSoundsOfPoolsSettings
    {
        public List<SoundTrack> pool;

    }
}