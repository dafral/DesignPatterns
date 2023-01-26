using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    public class LinearProjectile : Projectile
    {
        private void Start()
        {
            _rigidbody.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(secondsToDestroy));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}
