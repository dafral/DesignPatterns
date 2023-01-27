using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private AnimationCurve _horizontalPosition;

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
            Vector3 horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
            _rigidbody.MovePosition(_currentPosition + horizontalPosition);

            _currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {

        }
    }
}
