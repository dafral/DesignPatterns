using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Battle;
using Events;
using Core.Services;
using System;
using Core.Commands;

namespace UI
{
    public class VictoryOverView : MonoBehaviour, IEventObserver
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

        private void GoToMenu()
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new LoadSceneCommand("Menu"));
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
