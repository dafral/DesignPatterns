using Core.Commands;
using Core.Services;
using Events;
using System;

namespace Battle.States
{
    public class VictoryState : IGameState
    {
        public void Start(Action<GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(new StopBattleCommand());
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {

        }
    }
}
