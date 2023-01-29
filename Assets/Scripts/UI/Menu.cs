using UnityEngine;
using UnityEngine.UI;
using Battle;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _startBattleButton;
        [SerializeField] private Button _stopBattleButton;
        [SerializeField] private GameFacade _gameFacade;

        private void Awake()
        {
            _startBattleButton.onClick.AddListener(StartBattle);
            _stopBattleButton.onClick.AddListener(StopBattle);
        }

        private void StartBattle()
        {
            _gameFacade.StartBattle();
        }

        private void StopBattle()
        {
            _gameFacade.StopBattle();
        }
    }
}
