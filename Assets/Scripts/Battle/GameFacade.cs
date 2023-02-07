using UnityEngine;
using Ships;
using Ships.Enemies;
using UI;
using Core.Services;

namespace Battle
{

    public class GameFacade : MonoBehaviour, IGameFacade
    {
        public void StartBattle()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<GameStateController>().Reset();
            serviceLocator.GetService<EnemySpawner>().StartSpawn();
            serviceLocator.GetService<ShipInstaller>().SpawnUserShip();
            serviceLocator.GetService<LoadingScreen>().Hide();
            serviceLocator.GetService<ScoreView>().Reset();
        }

        public void StopBattle()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().StopSpawn();
            serviceLocator.GetService<LoadingScreen>().Show();
        }
    }
}
