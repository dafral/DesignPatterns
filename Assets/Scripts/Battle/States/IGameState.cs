using System;

namespace Battle.States
{
    public interface IGameState
    {
        public void Start(Action<GameStates> onEndedCallback);
        public void Stop();
    }
}
