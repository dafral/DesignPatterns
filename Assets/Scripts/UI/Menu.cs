using UnityEngine;
using UnityEngine.UI;
using Battle;
using Core.Services;

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
            ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
        }

        private void StopBattle()
        {
            ServiceLocator.Instance.GetService<IGameFacade>().StopBattle();
        }
    }
}
