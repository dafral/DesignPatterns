using UnityEngine;
using Core.Services;
using Battle;
using UI;
using Ships;
using Ships.Enemies;
using Ships.Weapons;
using Ships.Common;
using System;

namespace Core.Installers
{
    public class GameInstaller : GeneralInstaller
    {
        [Header("Services")]
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameStateController _gameStateController;
        [SerializeField] private ScreenFade _screenFade;

        [Header("Configurations")]
        [SerializeField] private ShipsConfiguration _shipsConfiguration;
        [SerializeField] private ProjectilesConfiguration _projectilesConfiguration;

        protected override void DoStart()
        {
            
        }

        protected override void DoInstallDependencies()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.RegisterService(_scoreView);
            serviceLocator.RegisterService(_shipInstaller);
            serviceLocator.RegisterService(_enemySpawner);
            serviceLocator.RegisterService(_gameStateController);
            serviceLocator.RegisterService(_screenFade);
            
            InstallShipFactory();
            InstallProjectileFactory();
        }

        private void OnDestroy()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.UnregisterService<ScoreView>();
            serviceLocator.UnregisterService<ShipInstaller>();
            serviceLocator.UnregisterService<EnemySpawner>();
            serviceLocator.UnregisterService<GameStateController>();
            serviceLocator.UnregisterService<ScreenFade>();
            serviceLocator.UnregisterService<ShipFactory>();
            serviceLocator.UnregisterService<ProjectileFactory>();
        }

        private void InstallShipFactory()
        {
            ShipFactory shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
            ServiceLocator.Instance.RegisterService(shipFactory);
        }

        private void InstallProjectileFactory()
        {
            ProjectileFactory projectileFactory = new ProjectileFactory(Instantiate(_projectilesConfiguration));
            ServiceLocator.Instance.RegisterService(projectileFactory);
        }
    }
}
