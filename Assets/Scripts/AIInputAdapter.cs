using UnityEngine;

namespace Ships
{
    public class AIInputAdapter : IInput
    {
        private const float _borderRight = 0.05f;
        private const float _borderLeft = 0.95f;

        private readonly Ship _ship;
        private int _currentDirectionX;

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
                _currentDirectionX = 1;
            }
            else if(viewportPoint.x > _borderLeft)
            {
                _currentDirectionX = -1;
            }

            return new Vector2(_currentDirectionX, 0);
        }
    }
}