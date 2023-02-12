using UnityEngine;

namespace Ships
{
    class InitialPositionCheckLimits : ICheckLimits
    {
        private readonly Transform _transform;
        private readonly Vector3 _initialPosition;
        private readonly float _maxDistance;

        public InitialPositionCheckLimits(Transform transform, float maxDistance)
        {
            _transform = transform;
            _initialPosition = _transform.position;
            _maxDistance = maxDistance;
        }

        public Vector2 ClampFinalPosition(Vector2 currentPosition)
        {
            Vector2 finalPosition = currentPosition;
            float distance = Mathf.Abs(currentPosition.x - _initialPosition.x);
            if (distance <= _maxDistance)
                return currentPosition;

            if (currentPosition.x > _initialPosition.x)
            {
                finalPosition.x = _initialPosition.x - _maxDistance;
            }
            else
            {
                finalPosition.x = _initialPosition.x + _maxDistance;
            }

            return currentPosition;
        }
    }
}
