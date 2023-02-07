using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;
using Events;
using Core.Services;

namespace UI
{
    public class GameOverView : MonoBehaviour, IEventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
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
            ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
            gameObject.SetActive(false);
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
