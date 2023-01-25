using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

namespace Patterns.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemiesConfiguration _enemiesConfiguration;
        [SerializeField] private EnemyId _enemyToSpawn1;
        [SerializeField] private EnemyId _enemyToSpawn2;

        private EnemyFactory _enemyFactory;

        private void Awake()
        {
            _enemyFactory = new EnemyFactory(Instantiate(_enemiesConfiguration));
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                _enemyFactory.Create(_enemyToSpawn1.Value);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _enemyFactory.Create(_enemyToSpawn2.Value);
            }
        }
    }
}
