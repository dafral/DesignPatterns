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

        public void ClampFinalPosition()
        {
            Vector3 currentPosition = _transform.position;
            Vector3 finalPosition = currentPosition;
            float distance = Mathf.Abs(currentPosition.x - _initialPosition.x);
            
            if (distance <= _maxDistance)
            {
                return;
            }
            
            finalPosition.x = currentPosition.x > _initialPosition.x ?
                _initialPosition.x + _maxDistance :
                _initialPosition.x - _maxDistance;

            _transform.position = finalPosition;
        }
    }
}
