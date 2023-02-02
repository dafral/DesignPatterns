using UnityEngine;

namespace Ships.Common
{
    public interface ICheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position);
    }
}
