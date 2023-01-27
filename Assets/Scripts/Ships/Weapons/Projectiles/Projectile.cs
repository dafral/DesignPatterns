using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody;
        [SerializeField] protected float _speed;

        protected const float _secondsToDestroy = 4f;

        protected Transform _myTransform;

        public string Id => _id.Value;

        private void Start()
        {
            _myTransform = transform;

            DoStart();
            StartCoroutine(DestroyIn(_secondsToDestroy));
        }

        private void FixedUpdate()
        {
            DoMove();
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            DoDestroy();
            Destroy(gameObject);
        }

        protected abstract void DoStart();
        protected abstract void DoMove();
        protected abstract void DoDestroy();
    }
}
