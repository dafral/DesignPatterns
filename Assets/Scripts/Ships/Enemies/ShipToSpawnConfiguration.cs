using Ships.Common;
using Ships.Weapons;
using UnityEngine;

namespace Ships.Enemies
{
    [CreateAssetMenu(menuName = "Ships/Create ShipToSpawnConfiguration", fileName = "ShipToSpawnConfiguration", order = 2)]
    public class ShipToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private ShipId _shipId;
        [SerializeField] private ProjectileId _defaultProjectile;
        [SerializeField] private Vector2 _speed;
        [SerializeField] private int _health;
        [SerializeField] private float _fireRate;
        [SerializeField] private int _score;

        public ShipId ShipId => _shipId;
        public ProjectileId ProjectileId => _defaultProjectile;
        public Vector2 Speed => _speed;
        public int Health => _health;
        public float FireRate => _fireRate;
        public int Score => _score;
    }
}