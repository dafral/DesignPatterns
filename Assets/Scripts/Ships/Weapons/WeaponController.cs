using Ships.Weapons;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPoint;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private float _fireRateInSeconds;

        private ShipMediator _ship;
        private float _remainingSecondsToBeAbleToShoot;
        private string _activeprojectileId;

        public void Configure(ShipMediator ship)
        {
            _ship = ship;
            _activeprojectileId = "Projectile2";
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
            Projectile prefab = _projectilePrefabs.First(projectile => projectile.Id.Equals(_activeprojectileId));
            Instantiate(prefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        }
    }
}
