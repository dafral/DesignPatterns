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
        [SerializeField] private ScoreView _scoreView;

        public void StartBattle()
        {
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
            _scoreView.Reset();
        }

        public void StopBattle()
        {
            _enemySpawner.StopSpawn();
            _shipInstaller.DestroyUserShip();
            _screenFade.Show();
        }
    }
}
