using UnityEngine;
using Ships.Weapons.Projectiles;
using Ships.Common;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _projectilesConfiguration;

        public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
        {
            _projectilesConfiguration = projectilesConfiguration;
        }

        public Projectile Create(string projectileId, Transform spawningTransform, Teams team)
        {
            Projectile projectilePrefab = _projectilesConfiguration.GetProjectileById(projectileId);
            Projectile projectile = Object.Instantiate(projectilePrefab, spawningTransform.position, spawningTransform.rotation);
            projectile.Configure(team);

            return projectile;
        }
    }
}
