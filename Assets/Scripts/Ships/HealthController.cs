using Ships.Common;
using System;
using UnityEngine;

namespace Ships
{
    public class HealthController : MonoBehaviour, IDamageable
    {
        private int _health;
        private Ship _ship;

        public Teams Team { get; private set; }

        public void Configure(ShipMediator ship, int health, Teams team)
        {
            _ship = ship;
            _health = health;
            Team = team;
        }

        public void AddDamage(int amount)
        {
            _health = Mathf.Max(0, _health - amount);

            bool isDeath = _health <= 0;
            _ship.OnDamageReceived(isDeath);
        }
    }
}
