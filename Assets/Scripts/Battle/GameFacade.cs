using UnityEngine;
using Ships;
using Ships.Enemies;
using UI;
using Core.Services;

namespace Battle
{
    public class GameFacade : MonoBehaviour, IGameFacade
    {
        public void StopBattle()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().StopSpawn();
        }
    }
}
