using UnityEngine;

namespace Patterns.Factory
{
    public class EnemyFactory : MonoBehaviour
    {
        private readonly EnemiesConfiguration _enemiesConfiguration;

        public EnemyFactory(EnemiesConfiguration enemiesConfiguration)
        {
            _enemiesConfiguration = enemiesConfiguration;
        }

        public void Create(string enemyId)
        {
            Enemy enemyPrefab = _enemiesConfiguration.GetEnemyById(enemyId);
            Instantiate(enemyPrefab, Random.onUnitSphere * 3, Quaternion.identity);
        }
    }
}
