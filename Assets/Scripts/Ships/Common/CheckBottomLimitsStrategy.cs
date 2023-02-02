using UnityEngine;

namespace Ships.Common
{
    public class CheckBottomLimitsStrategy : ICheckDestroyLimits
    {
        private readonly Camera _camera;

        public CheckBottomLimitsStrategy(Camera camera)
        {
            _camera = camera;
        }

        public bool IsInsideTheLimits(Vector3 position)
        {
            Vector3 viewportPoint = _camera.WorldToViewportPoint(position);
            return viewportPoint.y > 0;
        }
    }
}
