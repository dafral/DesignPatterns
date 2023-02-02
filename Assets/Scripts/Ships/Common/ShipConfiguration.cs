using UnityEngine;
using MyInput;
using Ships.Weapons;

namespace Ships.Common
{
    public class ShipConfiguration
    {
        public readonly IInput Input;
        public readonly ICheckLimits CheckLimits;
        public readonly Vector2 Speed;
        public readonly int Health;
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectile;
        public readonly Teams Team;
        public readonly ICheckDestroyLimits CheckDestroyLimits;
        public readonly int Score;

        public ShipConfiguration(IInput input,
                                 ICheckLimits checkLimits,
                                 Vector2 speed,
                                 int health,
                                 float fireRate,
                                 ProjectileId defaultProjectile,
                                 Teams team,
                                 ICheckDestroyLimits checkDestroyLimits,
                                 int score)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            Health = health;
            FireRate = fireRate;
            DefaultProjectile = defaultProjectile;
            Team = team;
            CheckDestroyLimits = checkDestroyLimits;
            Score = score;
        }
    }
}
