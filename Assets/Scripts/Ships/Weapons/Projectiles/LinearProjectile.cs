using UnityEngine;
using System.Collections;

namespace Ships.Weapons.Projectiles
{
    public class LinearProjectile : Projectile
    {
        protected override void DoStart()
        {
            _rigidbody.velocity = transform.up * _speed;
        }
        
        protected override void DoMove()
        {

        }

        protected override void DoDestroy()
        {

        }

    }
}
