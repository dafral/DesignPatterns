using UnityEngine;
using MyInput;
using Ships.Common;
using UI;
using Events;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : Ship, IEventObserver
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;

        private IInput _input;
        private Teams _team;
        private int _score;

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.GameOver, this);
        }

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
                ShipDestroyedEventData eventData = new ShipDestroyedEventData(gameObject.GetInstanceID(), _team, _score);
                EventQueue.Instance.EnqueueEvent(eventData);
                
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

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.GameOver)
            {
                Destroy(gameObject);
            }
        }
    }
}
