using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.Services;

namespace UI
{

    public class VictoryOverView : MenuView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;

        private IGameMenuMediator _gameMenuMediator;

        public override void Configure(IGameMenuMediator gameMenuMediator)
        {
            _gameMenuMediator = gameMenuMediator;

            _restartButton.onClick.AddListener(_gameMenuMediator.OnRestartGamePressed);
            _menuButton.onClick.AddListener(_gameMenuMediator.OnBackToMenuPressed);
        }

        public override void Show()
        {
            _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
