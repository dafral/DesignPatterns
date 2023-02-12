using UnityEngine;
using Ships.Weapons.Projectiles;
using Ships.Common;
using System.Collections.Generic;
using Common.ObjectPool;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _projectilesConfiguration;
        private readonly Dictionary<string, ObjectPool> _pools;

        public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
        {
            _projectilesConfiguration = projectilesConfiguration;

            Projectile[] projectiles = _projectilesConfiguration.ProjectilePrefabs;
            _pools = new Dictionary<string, ObjectPool>(projectiles.Length);
            foreach (Projectile projectile in projectiles)
            {
                ObjectPool objectPool = new ObjectPool(projectile);
                _pools.Add(projectile.Id, objectPool);
                objectPool.Init(0);
            }
        }

        public Projectile Create(string projectileId, Transform spawningTransform, Teams team)
        {
            Projectile projectile = _pools[projectileId].Spawn<Projectile>(spawningTransform.position, spawningTransform.rotation);
            projectile.Configure(team);

            return projectile;
        }
    }
}
