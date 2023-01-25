using UnityEngine;
using System.Collections.Generic;

namespace Patterns.Factory
{
    [CreateAssetMenu(menuName = "Factory/Create EnemiesConfiguration", fileName = "EnemiesConfiguration", order = 0)]
    public class EnemiesConfiguration : ScriptableObject
    {
        [SerializeField] private Enemy[] _enemyPrefabs;

        private Dictionary<string, Enemy> _IdToEnemyPrefab;

        private void Awake()
        {
            _IdToEnemyPrefab = new Dictionary<string, Enemy>();
            foreach (Enemy enemyPrefab in _enemyPrefabs)
            {
                _IdToEnemyPrefab.Add(enemyPrefab.Id, enemyPrefab);
            }
        }

        public Enemy GetEnemyById(string id)
        {
            return _IdToEnemyPrefab[id];
        }
    }
}
