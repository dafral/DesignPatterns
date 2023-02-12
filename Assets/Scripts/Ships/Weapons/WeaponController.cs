using Core.Services;
using Ships.Common;
using Ships.Weapons;
using Ships.Weapons.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPoint;

        private List<Projectile> _firedProjectiles;
        private ShipMediator _ship;
        private ProjectileFactory _projectileFactory;
        private Teams _team;
        private float _fireRateInSeconds;
        private float _remainingSecondsToBeAbleToShoot;
        private string _activeprojectileId;

        private void Awake()
        {
            _projectileFactory = ServiceLocator.Instance.GetService<ProjectileFactory>();
            _firedProjectiles = new List<Projectile>();
        }

        public void Configure(ShipMediator ship, float fireRate, ProjectileId defaultProjectile, Teams team)
        {
            _ship = ship;
            _activeprojectileId = defaultProjectile.Value;
            _fireRateInSeconds = fireRate;
            _team = team;
        }

        private void Update()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
        }

        public void TryShoot()
        {
            if (_remainingSecondsToBeAbleToShoot > 0)
            {
                return;
            }

            Shoot();
        }

        private void Shoot()
        {
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            
            Projectile projectile = _projectileFactory.
                Create(_activeprojectileId,
                       _projectileSpawnPoint,
                       _team);

            projectile.OnRecycle += OnProjectileDestroy;
            _firedProjectiles.Add(projectile);
        }

        private void OnProjectileDestroy(Projectile projectile)
        {
            _firedProjectiles.Remove(projectile);
            projectile.OnRecycle -= OnProjectileDestroy;
        }

        public void Restart()
        {
            for (int i = 0; i < _firedProjectiles.Count; i++)
            {
                _firedProjectiles[i].Recycle();
            }

            _firedProjectiles.Clear();
        }
    }
}
