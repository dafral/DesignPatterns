using UnityEngine;
using Ships.Common;
using System.Collections.Generic;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        [SerializeField] private Transform[] _spawnPositions;

        private List<Ship> _spawnedShips;

        private ShipFactory _shipFactory;
        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;
        private bool _canSpawn;

        private void Awake()
        {
            _shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
        }

        public void StartSpawn()
        {
            _canSpawn = true;
            _spawnedShips = new List<Ship>();
        }

        public void StopSpawn()
        {
            _canSpawn = false;
            _currentConfigurationIndex = 0;
            _currentTimeInSeconds = 0;

            foreach (Ship ship in _spawnedShips)
            {
                Destroy(ship.gameObject);
            }

            _spawnedShips.Clear();
        }

        private void Update()
        {
            if(!_canSpawn)
            {
                return;
            }

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
                ShipBuilder shipBuilder = _shipFactory.Create(shipConfiguration.ShipId.Value);

                Ship ship = shipBuilder.
                            WithPosition(spawnPosition.position).
                            WithRotation(spawnPosition.rotation).
                            WithInputType(ShipBuilder.InputType.AI).
                            WithCheckLimitsType(ShipBuilder.CheckLimitsType.Viewport).
                            WithConfiguration(shipConfiguration).
                            Build();

                _spawnedShips.Add(ship);
            }
        }
    }
}