using UnityEngine;
using MyInput;
using Ships.Common;

namespace Ships
{

    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;

        private IInput _input;

        public override void Configure(ShipConfiguration shipConfiguration)
        {
            _input = shipConfiguration.Input;
            _movementController.Configure(this, shipConfiguration.CheckLimits, shipConfiguration.Speed);
            _weaponController.Configure(this, shipConfiguration.FireRate, shipConfiguration.DefaultProjectile);
        }

        private void FixedUpdate()
        {
            Vector2 direction = _input.GetDirection();
            _movementController.Move(direction);
        }

        private void Update()
        {
            CheckShootingButton();
        }

        private void CheckShootingButton()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Ship collided with {collision.name}");
        }
    }
}
