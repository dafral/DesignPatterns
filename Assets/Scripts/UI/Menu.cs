using UnityEngine;
using UnityEngine.UI;
using Ships;
using Ships.Enemies;
using System;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;

        [Header("Elements")]
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
        }

        private void StopBattle()
        {
            _enemySpawner.StopSpawn();
            _shipInstaller.DestroyUserShip();
            _screenFade.Show();
        }
    }
}
