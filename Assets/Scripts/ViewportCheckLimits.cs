using UnityEngine;

namespace Ships
{
    class ViewportCheckLimits : ICheckLimits
    {
        private const float _maxBorder = 1;
        private const float _minBorder = 0;
        private readonly Transform _transform;
        private readonly Camera _camera;

        public ViewportCheckLimits(Transform transform, Camera camera)
        {
            _transform = transform;
            _camera = camera;
        }

        public void ClampFinalPosition()
        {
            Vector3 viewportPoint = _camera.WorldToViewportPoint(_transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, _minBorder, _maxBorder);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, _minBorder, _maxBorder);
            _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}
