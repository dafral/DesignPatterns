using UnityEngine;

namespace Ships.Weapons
{
    public class ProjectileFactory
    {
        private readonly ProjectilesConfiguration _projectilesConfiguration;

        public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
        {
            _projectilesConfiguration = projectilesConfiguration;
        }

        public Projectile Create(string projectileId, Transform spawningTransform)
        {
            Projectile projectilePrefab = _projectilesConfiguration.GetProjectileById(projectileId);
            return Object.Instantiate(projectilePrefab, spawningTransform.position, spawningTransform.rotation);
        }
    }
}
