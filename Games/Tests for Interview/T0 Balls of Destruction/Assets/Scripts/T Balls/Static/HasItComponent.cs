using UnityEngine;

namespace TBalls
{
    public static class HasItComponent
    {
        public static bool HasComponent<T>(this GameObject flag) where T : Component
        {
            return flag.GetComponentInParent<T>() != null;
        }
    }
}
