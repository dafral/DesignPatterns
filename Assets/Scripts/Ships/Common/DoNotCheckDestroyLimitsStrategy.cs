using UnityEngine;

namespace Ships.Common
{
    public class DoNotCheckDestroyLimitsStrategy : ICheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position)
        {
            return true;
        }
    }
}
