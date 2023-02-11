using UnityEngine;
using UnityEngine.UI;
using Core.Services;
using Core.Commands;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new StartBattleCommand());
        }

        private void StopBattle()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new StopBattleCommand());
        }
    }
}
