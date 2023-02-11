using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;
using Events;
using Core.Services;
using Core.Commands;

namespace UI
{
    public class GameOverView : MonoBehaviour, IEventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _menuButton.onClick.AddListener(GoToMenu);
        }

        private void Start()
        {
            gameObject.SetActive(false);

            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.GameOver, this);
        }

        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new StartBattleCommand());
            gameObject.SetActive(false);
        }

        private void GoToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}
