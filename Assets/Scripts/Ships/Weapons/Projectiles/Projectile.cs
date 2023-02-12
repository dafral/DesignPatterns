using UnityEngine;
using System.Collections;
using Ships.Common;
using System;
using Common.ObjectPool;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : RecyclableObject, IDamageable
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody;
        [SerializeField] protected float _speed;

        protected const float _secondsToDestroy = 4f;
        protected Transform _myTransform;

        public string Id => _id.Value;

        public Teams Team { get; private set; }

        public Action<Projectile> OnRecycle;

        private void Awake()
        {
            _myTransform = transform;
        }

        public void Configure(Teams team)
        {
            Team = team;
        }

        public override void Init()
        {
            DoStart();
            StartCoroutine(RecycleIn(_secondsToDestroy));
        }

        public override void Release()
        {

        }


        private void FixedUpdate()
        {
            DoMove();
        }

        private IEnumerator RecycleIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            RecycleProjectile();
        }


        private void RecycleProjectile()
        {
            OnRecycle?.Invoke(this);
            Recycle();
        }

        public void AddDamage(int amount)
        {
            RecycleProjectile();
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
    }
}
