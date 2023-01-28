using UnityEngine;
using MyInput;
using System;
using Ships.Weapons;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;

        private IInput _input;

        public override void Configure(IInput input, ICheckLimits checkLimits, Vector2 speed, float fireRate, ProjectileId defaultProjectile)
        {
            _input = input;
            _movementController.Configure(this, checkLimits, speed);
            _weaponController.Configure(this, fireRate, defaultProjectile);
        }

        private void Update()
        {
            Vector2 direction = _input.GetDirection();
            _movementController.Move(direction);
            CheckShootingButton();
        }

        private void CheckShootingButton()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }

        
    }
}
