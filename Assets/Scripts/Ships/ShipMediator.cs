using UnityEngine;
using MyInput;
using Ships.Common;
using UI;
using Events;
using Core.Services;
using System;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : Ship, IEventObserver
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private HealthController _healthController;

        private IEventQueue _eventQueue;
        private IInput _input;
        private Teams _team;
        private ICheckDestroyLimits _checkDestroyLimits;
        private int _score;

        public override void Configure(ShipConfiguration shipConfiguration)
        {
            _input = shipConfiguration.Input;
            _movementController.Configure(this, shipConfiguration.CheckLimits, shipConfiguration.Speed);
            _weaponController.Configure(this, shipConfiguration.FireRate, shipConfiguration.DefaultProjectile, shipConfiguration.Team);
            _healthController.Configure(this, shipConfiguration.Health, shipConfiguration.Team);
            _team = shipConfiguration.Team;
            _checkDestroyLimits = shipConfiguration.CheckDestroyLimits;
            _score = shipConfiguration.Score;
        }

        public override void Init()
        {
            _eventQueue = ServiceLocator.Instance.GetService<IEventQueue>();
            _eventQueue.Subscribe(EventIds.GameOver, this);
            _eventQueue.Subscribe(EventIds.Victory, this);
            _eventQueue.Subscribe(EventIds.Restart, this);
        }

        public override void Release()
        {
            _eventQueue.Unsubscribe(EventIds.GameOver, this);
            _eventQueue.Unsubscribe(EventIds.Victory, this);
            _eventQueue.Unsubscribe(EventIds.Restart, this);
        }

        private void FixedUpdate()
        {
            Vector2 direction = _input.GetDirection();
            _movementController.Move(direction);
        }

        private void Update()
        {
            CheckShootingButton();
            CheckDestroyLimits();
        }

        private void CheckDestroyLimits()
        {
            if (_checkDestroyLimits.IsInsideTheLimits(transform.position))
            {
                return;
            }

            Recycle();
            ShipDestroyedEventData eventData = new ShipDestroyedEventData(gameObject.GetInstanceID(), _team, 0);
            _eventQueue.EnqueueEvent(eventData);
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
                _eventQueue.EnqueueEvent(eventData);

                Recycle();
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
            if (eventData.EventId != EventIds.GameOver &&
                eventData.EventId != EventIds.Victory && 
                eventData.EventId != EventIds.Restart)
            {
                return;
            }

            _weaponController.Restart();

            Recycle();
        }
    }
}
