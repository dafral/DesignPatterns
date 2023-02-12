using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        private ShipMediator _ship;
        private Rigidbody2D _rigidbody;
        private ICheckLimits _checkLimits;
        private Vector2 _currentPosition;
        private Vector2 _speed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Configure(ShipMediator ship, ICheckLimits checkLimits, Vector2 speed)
        {
            _currentPosition = _rigidbody.position;

            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _currentPosition += direction * (_speed * Time.deltaTime);
            _currentPosition = _checkLimits.ClampFinalPosition(_currentPosition);
            _rigidbody.MovePosition(_currentPosition);

        }
    }
}
