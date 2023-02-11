using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseView : MenuView
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;

        private IGameMenuMediator _gameMenuMediator;

        public override void Configure(IGameMenuMediator gameMenuMediator)
        {
            _gameMenuMediator = gameMenuMediator;

            _resumeButton.onClick.AddListener(_gameMenuMediator.OnResumeGamePressed);
            _restartButton.onClick.AddListener(_gameMenuMediator.OnRestartGamePressed);
            _menuButton.onClick.AddListener(_gameMenuMediator.OnBackToMenuPressed);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }
    }
}