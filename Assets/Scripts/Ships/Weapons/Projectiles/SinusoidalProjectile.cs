using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float _amplitude;
        [SerializeField] private float _frequency;

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
            Vector3 horizontalPosition = _myTransform.right * (_amplitude * Mathf.Sin(_currentTime * _frequency));
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
