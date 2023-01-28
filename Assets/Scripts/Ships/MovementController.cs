using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        private ShipMediator _ship;
        private Transform _myTransform;
        private ICheckLimits _checkLimits;
        private Vector2 _speed;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(ShipMediator ship, ICheckLimits checkLimits, Vector2 speed)
        {
            _ship = ship;
            _checkLimits = checkLimits;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }
    }
}
