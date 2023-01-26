using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 0)]
    public class ProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] private Projectile[] _projectilePrefabs;

        private Dictionary<string, Projectile> _idToProjectilePrefab;

        private void Awake()
        {
            _idToProjectilePrefab = new Dictionary<string, Projectile>();
            foreach (Projectile projectilePrefab in _projectilePrefabs)
            {
                _idToProjectilePrefab.Add(projectilePrefab.Id, projectilePrefab);
            }
        }

        public Projectile GetProjectileById(string id)
        {
            if(!_idToProjectilePrefab.TryGetValue(id, out Projectile projectile))
            {
                throw new Exception($"Projectile {id} not found!"); 
            }
            
            return projectile;
        }
    }
}
