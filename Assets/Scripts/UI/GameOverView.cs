using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;
using Events;
using Ships.Common;

namespace UI
{
    public class GameOverView : MonoBehaviour, IEventObserver
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameFacade _gameFacade;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void Start()
        {
            gameObject.SetActive(false);

            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.GameOver, this);
        }

        private void RestartGame()
        {
            _gameFacade.StartBattle();
            gameObject.SetActive(false);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                ShipDestroyedEventData shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                if (shipDestroyedEventData.Team == Teams.Player)
                {
                    _gameFacade.StopBattle();
                    EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
                }

                return;
            }

            else if (eventData.EventId == EventIds.GameOver)
            {
                _scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}
