using UnityEngine;
using MyInput;
using Ships.Common;
using UI;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : Ship
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;

        private IInput _input;
        private Teams _team;
        private int _score;

        public override void Configure(ShipConfiguration shipConfiguration)
        {
            _input = shipConfiguration.Input;
            _movementController.Configure(this, shipConfiguration.CheckLimits, shipConfiguration.Speed);
            _weaponController.Configure(this, shipConfiguration.FireRate, shipConfiguration.DefaultProjectile, shipConfiguration.Team);
            _healthController.Configure(this, shipConfiguration.Health, shipConfiguration.Team);
            _team = shipConfiguration.Team;
            _score = shipConfiguration.Score;
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

        public override void OnDamageReceived(bool isDeath)
        {
            if(isDeath)
            {
                ScoreView.Instance.AddScore(_team, _score);

                if(_team == Teams.Player)
                {
                    GameOverView.Instance.Show();
                }
                
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            if(_team == damageable.Team)
            {
                return;
            }

            damageable.AddDamage(1);
        }
    }
}
