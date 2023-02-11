using UnityEngine;
using UnityEngine.UI;
using Core.Commands;
using Core.Services;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private void Start()
        {
            _startGameButton.onClick.AddListener(AddGoToGameCommand);
        }

        private void AddGoToGameCommand()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Game"));
        }
    }
}
