using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;
using Events;
using Core.Services;

namespace UI
{
    public class VictoryOverView : MonoBehaviour, IEventObserver
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

            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.Victory, this);
        }

        private void RestartGame()
        {
            ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
            gameObject.SetActive(false);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                _scoreText.SetText(ServiceLocator.Instance.GetService<ScoreView>().CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}
