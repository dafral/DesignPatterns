using MyInput;
using System;
using UnityEngine;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        [SerializeField] private Transform[] _spawnPositions;
        
        private ShipFactory _shipFactory;
        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;

        private void Awake()
        {
            _shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
        }

        private void Update()
        {
            if(_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            _currentTimeInSeconds += Time.deltaTime;

            SpawnConfiguration spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];

            if(spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for (int i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
            {
                ShipToSpawnConfiguration shipConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
                Transform spawnPosition = _spawnPositions[i % _spawnPositions.Length];
                Ship ship = _shipFactory.Create(shipConfiguration.ShipId.Value, spawnPosition);

                ship.Configure(new AIInputAdapter(ship), new ViewportCheckLimits(ship.transform, Camera.main), 
                    shipConfiguration.Speed, shipConfiguration.FireRate, shipConfiguration.ProjectileId);
            }
        }
    }
}