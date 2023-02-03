using UnityEngine;
using System.Collections.Generic;
using Events;
using Battle.States;
using System;
using System.Threading.Tasks;

namespace Battle
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private GameFacade _gameFacade;

        private IGameState _currentState;
        private Dictionary<GameStates, IGameState> _idToState;

        private void Awake()
        {
            _idToState = new Dictionary<GameStates, IGameState>
                {
                    {GameStates.Playing, new PlayingState() },
                    {GameStates.GameOver, new GameOverState(_gameFacade) },
                    {GameStates.Victory, new VictoryState(_gameFacade) }
                };
        }

        private void Start()
        {
            _currentState = GetState(GameStates.Playing);
            _currentState.Start(ChangeToNextState);
        }

        public void Reset()
        {
            ChangeToNextState(GameStates.Playing);
        }

        private async void ChangeToNextState(GameStates nextState)
        {
            await Task.Yield();

            _currentState = GetState(nextState);
            _currentState.Start(ChangeToNextState);
        }

        private IGameState GetState(GameStates state)
        {
            return _idToState[state];
        }


    }
}
