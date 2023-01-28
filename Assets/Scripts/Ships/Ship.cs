using MyInput;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    public abstract class Ship : MonoBehaviour
    {
        [SerializeField] private ShipId _id;

        public string Id => _id.Value;
        public abstract void Configure(IInput input, ICheckLimits checkLimits, Vector2 speed, float fireRate, ProjectileId defaultProjectile);
    }
}