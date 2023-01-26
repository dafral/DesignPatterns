using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileId _id;
        [SerializeField] protected Rigidbody2D _rigidbody;
        [SerializeField] protected float _speed;

        protected const float secondsToDestroy = 4f;

        public string Id => _id.Value;
    }
}
