using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private AnimationCurve _horizontalPosition;

        private Transform _myTransform;
        private Vector3 _currentPosition;
        private float _currentTime;

        private void Awake()
        {
            _myTransform = transform;
        }

        private void Start()
        {
            _currentTime = 0;
            _currentPosition = _myTransform.position;
            StartCoroutine(DestroyIn(secondsToDestroy));
        }

        private void FixedUpdate()
        {
            _currentPosition += _myTransform.up * (_speed * Time.deltaTime);
            Vector3 horizontalPosition = _myTransform.right * _horizontalPosition.Evaluate(_currentTime);
            _rigidbody.MovePosition(_currentPosition + horizontalPosition);

            _currentTime += Time.deltaTime;
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
