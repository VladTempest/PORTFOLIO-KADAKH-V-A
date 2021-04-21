using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolSoundsMainSettings",menuName = "Settings/PoolSoundsMainSettings", order=0)]
    public class PoolSoundsMainSettings : PoolSoundsOfPoolsSettings
    {
        public List<SoundTrack> pool;

    }
}