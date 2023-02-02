using Events;
using Ships.Common;
using System;
using UnityEngine;

namespace Battle
{
    public class GameState : MonoBehaviour, IEventObserver
    {
        private enum GameStates 
        {
            Playing,
            GameOver,
            Victory
        }

        [SerializeField] private GameFacade _gameFacade;
        private GameStates _currentState = GameStates.Playing;

        private int _aliveShips;
        private bool _allShipsSpawned;

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipsSpawned, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Unsubscribe(EventIds.AllShipsSpawned, this);
        }

        public void Reset()
        {
            _currentState = GameStates.Playing;
            _aliveShips = 0;
            _allShipsSpawned = false;
        }

        public void Process(EventData eventData)
        {
            if(_currentState != GameStates.Playing)
            {
                return;
            }

            if(eventData.EventId == EventIds.ShipDestroyed)
            {
                _aliveShips -= 1;
                if(CheckGameOver(eventData))
                {
                    return;
                }
            }

            else if (eventData.EventId == EventIds.ShipSpawned)
            {
                _aliveShips += 1;
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
                _currentState = GameStates.GameOver;
                _gameFacade.StopBattle();
                EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));

                return true;
            }

            return false;
        }

        private void CheckGameState()
        {
            if(_aliveShips == 0 && _allShipsSpawned)
            {
                _gameFacade.StopBattle();
                _currentState = GameStates.Victory;
                EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
            }
        }
    }
}
