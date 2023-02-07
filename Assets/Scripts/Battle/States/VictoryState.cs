using Core.Services;
using Events;
using System;

namespace Battle.States
{
    public class VictoryState : IGameState
    {
        public void Start(Action<GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<IGameFacade>().StopBattle();
            ServiceLocator.Instance.GetService<IEventQueue>().EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {

        }
    }
}
