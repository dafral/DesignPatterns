using Ships.Weapons;
using System.Linq;
using UnityEngine;

namespace Ships
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPoint;
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;
        [SerializeField] private ProjectileId _defaultProjectileId;
        [SerializeField] private float _fireRateInSeconds;

        private ShipMediator _ship;
        private ProjectileFactory _projectileFactory;
        private float _remainingSecondsToBeAbleToShoot;
        private string _activeprojectileId;

        private void Awake()
        {
            _projectileFactory = new ProjectileFactory(Instantiate(_projectilesConfiguration));

        }

        public void Configure(ShipMediator ship)
        {
            _ship = ship;
            _activeprojectileId = _defaultProjectileId.Value;
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
            _projectileFactory.Create(_activeprojectileId, _projectileSpawnPoint);

        }
    }
}
