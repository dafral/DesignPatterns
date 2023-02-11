using Core.Commands;
using Core.Services;
using Events;
using UnityEngine;

namespace UI
{
    public class GameMenuMediator : MonoBehaviour, IGameMenuMediator, IEventObserver
    {
        [SerializeField] private MenuView _victoryOverView;
        [SerializeField] private MenuView _gameOverView;
        [SerializeField] private MenuView _pauseView;

        private IEventQueue _eventQueue;
        private CommandQueue _commandQueue;

        private void Awake()
        {
            _victoryOverView.Configure(this);
            _gameOverView.Configure(this);
            _pauseView.Configure(this);
        }

        private void Start()
        {
            _eventQueue = ServiceLocator.Instance.GetService<IEventQueue>();
            _commandQueue = ServiceLocator.Instance.GetService<CommandQueue>();

            _eventQueue.Subscribe(EventIds.Victory, this);
            _eventQueue.Subscribe(EventIds.GameOver, this);
        }

        private void OnDestroy()
        {
            _eventQueue.Unsubscribe(EventIds.Victory, this);
            _eventQueue.Unsubscribe(EventIds.GameOver, this);
        }

        public void OnBackToMenuPressed()
        {
            _commandQueue.AddCommand(new LoadSceneCommand("Menu"));
            _commandQueue.AddCommand(new ResumeGameCommand());
        }

        public void OnPauseGamePressed()
        {
            _pauseView.Show();
            _commandQueue.AddCommand(new PauseGameCommand());
        }

        public void OnRestartGamePressed()
        {
            _gameOverView.Hide();
            _victoryOverView.Hide();
            _pauseView.Hide();

            _commandQueue.AddCommand(new StopBattleCommand());
            _commandQueue.AddCommand(new StartBattleCommand());
            _commandQueue.AddCommand(new ResumeGameCommand());

            _eventQueue.EnqueueEvent(new EventData(EventIds.Restart));
        }

        public void OnResumeGamePressed()
        {
            _pauseView.Hide();
            _commandQueue.AddCommand(new ResumeGameCommand());
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                _victoryOverView.Show();
            }

            else if (eventData.EventId == EventIds.GameOver)
            {
                _gameOverView.Show();
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OnPauseGamePressed();
            }
        }
    }
}
