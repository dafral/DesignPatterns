using Core.Services;
using Events;
using Ships.Common;
using System;

namespace Battle.States
{
    public class PlayingState : IGameState, IEventObserver
    {
        private Action<GameStates> _onEndedCallback;
        private int _aliveEnemyShips;
        private bool _allShipsSpawned;

        public void Start(Action<GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.AllShipsSpawned, this);

            _onEndedCallback = onEndedCallback;
            _aliveEnemyShips = 0;
            _allShipsSpawned = false;
        }

        public void Stop()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.ShipSpawned, this);
            ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.AllShipsSpawned, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveEnemyShips -= 1;
                if (CheckGameOver(eventData))
                {
                    return;
                }
            }

            else if (eventData.EventId == EventIds.ShipSpawned)
            {
                _aliveEnemyShips += 1;
            }

            else if (eventData.EventId == EventIds.AllShipsSpawned)
            {
                _allShipsSpawned = true;
            }

            CheckGameState();
        }

        private bool CheckGameOver(EventData eventData)
        {
            ShipDestroyedEventData shipDestroyedEventData = (ShipDestroyedEventData)eventData;
            if (shipDestroyedEventData.Team == Teams.Player)
            {
                _onEndedCallback?.Invoke(GameStates.GameOver);
                return true;
            }

            return false;
        }

        private void CheckGameState()
        {
            if (_aliveEnemyShips == 0 && _allShipsSpawned)
            {
                _onEndedCallback?.Invoke(GameStates.Victory);
            }
        }
    }
}
