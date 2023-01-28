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
        public readonly float FireRate;
        public readonly ProjectileId DefaultProjectile;

        public ShipConfiguration(IInput input, ICheckLimits checkLimits, Vector2 speed, float fireRate, ProjectileId defaultProjectile)
        {
            Input = input;
            CheckLimits = checkLimits;
            Speed = speed;
            FireRate = fireRate;
            DefaultProjectile = defaultProjectile;
        }
    }
}
