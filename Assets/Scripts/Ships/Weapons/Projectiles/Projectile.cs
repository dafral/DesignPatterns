using UnityEngine;
using System.Collections;
using Ships.Common;
using System;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour, IDamageable
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody;
        [SerializeField] protected float _speed;

        protected const float _secondsToDestroy = 4f;
        protected Transform _myTransform;

        public string Id => _id.Value;

        public Teams Team { get; private set; }

        public Action<Projectile> OnDestroy;

        public void Configure(Teams team)
        {
            Team = team;
        }

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


        private void DestroyProjectile()
        {
            DoDestroy();
            OnDestroy?.Invoke(this);
            Destroy(gameObject);
        }

        public void AddDamage(int amount)
        {
            DestroyProjectile();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            
            if(damageable.Team == Team)
            {
                return;
            }

            damageable.AddDamage(1);
        }

        protected abstract void DoStart();
        protected abstract void DoMove();
        protected abstract void DoDestroy();
    }
}
