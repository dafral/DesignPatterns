using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Facade
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private PlayerSpawner _playerSpawner;
        
        private IDataStore _dataStore;

        private void Awake()
        {
            _dataStore = new PlayerPrefsDataStoreAdapter();
        }

        public void SaveGame()
        {
            SaveData saveData = new SaveData(_enemySpawner.Enemies, _playerSpawner.Player);
            _dataStore.SetData(saveData, "SaveData");

            LogData(saveData, "saved");
        }

        public void LoadGame()
        {
            SaveData saveData = _dataStore.GetData<SaveData>("SaveData");
            _enemySpawner.Enemies = saveData.Enemies;
            _playerSpawner.Player = saveData.Player;

            LogData(saveData, "loaded");
        }

        private void LogData(SaveData saveData, string command)
        {
            foreach (Enemy enemy in saveData.Enemies)
            {
                Debug.Log($"Enemy {command} with health: {enemy.Health} and stamina: {enemy.Stamina}!");
            }

            Debug.Log($"Player {command} with health: {saveData.Player.Health} and stamina: {saveData.Player.Mana}!");
        }
    }
}
