using UnityEngine;

namespace Ships
{
    class ViewportCheckLimits : ICheckLimits
    {
        private const float _maxBorder = 1;
        private const float _minBorder = 0;
        private readonly Camera _camera;

        public ViewportCheckLimits(Camera camera)
        {
            _camera = camera;
        }

        public Vector2 ClampFinalPosition(Vector2 currentPosition)
        {
            Vector3 viewportPoint = _camera.WorldToViewportPoint(currentPosition);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, _minBorder, _maxBorder);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, _minBorder, _maxBorder);
            return  _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}
