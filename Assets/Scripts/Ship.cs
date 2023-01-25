using UnityEngine;
using MyInput;
using System;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _projectileSpawnPoint;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private float _fireRateInSeconds;

        private Transform _myTransform;
        private IInput _input;
        private ICheckLimits _checkLimits;
        private float _remainingSecondsToBeAbleToShoot;

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
            TryShoot();
        }

        private void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if(_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }

            if (_input.IsFireActionPressed())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
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
