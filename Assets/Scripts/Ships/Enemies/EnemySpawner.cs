using UnityEngine;
using Ships.Common;
using System.Collections.Generic;
using Events;
using System;
using Core.Services;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private LevelConfiguration _levelConfiguration;
        [SerializeField] private Transform[] _spawnPositions;

        private ShipFactory _shipFactory;
        private float _currentTimeInSeconds;
        private int _currentConfigurationIndex;
        private bool _canSpawn;

        private void Start()
        {
            _shipFactory = ServiceLocator.Instance.GetService<ShipFactory>();
        }

        public void StartSpawn()
        {
            _canSpawn = true;
        }

        public void StopSpawn()
        {
            _canSpawn = false;
            _currentConfigurationIndex = 0;
            _currentTimeInSeconds = 0;
        }

        private void Update()
        {
            if (!_canSpawn)
            {
                return;
            }

            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            _currentTimeInSeconds += Time.deltaTime;

            SpawnConfiguration spawnConfiguration = _levelConfiguration.SpawnConfigurations[_currentConfigurationIndex];

            if (spawnConfiguration.TimeToSpawn > _currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            _currentConfigurationIndex += 1;

            if (_currentConfigurationIndex >= _levelConfiguration.SpawnConfigurations.Length)
            {
                ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.AllShipsSpawned));
            }
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
                            WithCheckLimitsType(ShipBuilder.CheckLimitsType.InitialPosition).
                            WithConfiguration(shipConfiguration).
                            WithTeam(Teams.Enemy).
                            WithDestroyCheckLimits().
                            Build();

                ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new ShipSpawnedEventData(ship.GetInstanceID(), Teams.Enemy));
            }
        }
    }
}