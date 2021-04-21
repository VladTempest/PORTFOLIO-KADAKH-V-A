using System.Collections.Generic;
using UnityEngine;


namespace SweetRush
{
    [CreateAssetMenu(fileName = "PoolFXSettings",menuName = "Settings/PoolFXSettings", order=0)]
    public class PoolFXSettings : ScriptableObject
    {
        public List<GameObject> pool;
        
           /*
            * 0-explosion_obstacle
            * 1-explosion_pie
            * 2-collision_obstacle_player
            * 3-collision_eatable_player
            * 4-dust_fromFalling_pie
            * 5_dust_fromJumping_Player
            * 6-collision_pickupheart_Player
            * 7-collision_obstacle_pie
            */

    }
}