using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

        private Vector3 _currentPosition;
        private float _currentTime;

        protected override void DoStart()
        {
            _currentTime = 0;
            _currentPosition = _myTransform.position;
        }

        protected override void DoMove()
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            Vector3 horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
            _rigidbody.MovePosition(_currentPosition + horizontalPosition);

            _currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {
            throw new System.NotImplementedException();
        }
    }
}
