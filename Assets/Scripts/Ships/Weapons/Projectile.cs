using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        private const float secondsToDestroy = 4f;

        public string Id => _id.Value;

        private void Start()
        {
            _rigidbody.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(secondsToDestroy));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
