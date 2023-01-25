using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{

    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _myTransform;
        private IInput _input;
        private ICheckLimits _checkLimits;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        private void Update()
        {
            Vector2 direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            _checkLimits.ClampFinalPosition();
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}
