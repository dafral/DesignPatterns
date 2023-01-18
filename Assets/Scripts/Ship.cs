using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Transform _myTransform;
        private Camera _camera;

        private IInput _input;

        private void Awake()
        {
            _camera = Camera.main;
            _myTransform = transform;
        }

        public void Configure(IInput input)
        {
            _input = input;
        }

        private void Update()
        {
            Vector2 direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            Vector3 viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0, 1);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0, 1);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }
    }
}
