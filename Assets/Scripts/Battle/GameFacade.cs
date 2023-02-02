using UnityEngine;
using Ships;
using Ships.Enemies;
using UI;

namespace Battle
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private GameState _gameState;

        public void StartBattle()
        {
            _gameState.Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
            ScoreView.Instance.Reset();
        }

        public void StopBattle()
        {
            _enemySpawner.StopSpawn();
            _screenFade.Show();
        }
    }
}
