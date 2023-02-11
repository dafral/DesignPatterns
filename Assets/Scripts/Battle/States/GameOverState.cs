using Core.Commands;
using Core.Services;
using Events;
using System;

namespace Battle.States
{
    public class GameOverState : IGameState
    {
        public void Start(Action<GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new StopBattleCommand());
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {

        }
    }
}
