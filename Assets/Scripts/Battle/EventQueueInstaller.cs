using UnityEngine;
using Core.Services;
using Events;

namespace Core
{
    public class EventQueueInstaller : Installer
    {
        [SerializeField] private EventQueue _eventQueue;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_eventQueue.gameObject);
            serviceLocator.RegisterService<IEventQueue>(_eventQueue);
        }
    }
}
