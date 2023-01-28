using UnityEngine;
using Ships;

namespace MyInput
{
    public class AIInputAdapter : IInput
    {
        private const float _borderRight = 0.05f;
        private const float _borderLeft = 0.95f;

        private readonly Ship _ship;
        private float _currentDirectionX;

        public AIInputAdapter(Ship ship)
        {
            _ship = ship;
            _currentDirectionX = 1;
        }

        public Vector2 GetDirection()
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);

            if(viewportPoint.x < _borderRight)
            {
                _currentDirectionX = _ship.transform.right.x;
            }
            else if(viewportPoint.x > _borderLeft)
            {
                _currentDirectionX = -_ship.transform.right.x;
            }

            return new Vector2(_currentDirectionX, 1);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}