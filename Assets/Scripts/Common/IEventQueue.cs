using Events;

namespace Events
{
    public interface IEventQueue
    {
        public void Subscribe(EventIds eventId, IEventObserver eventObserver);
        public void Unsubscribe(EventIds eventId, IEventObserver eventObserver);
        public void EnqueueEvent(EventData eventData);
    }
}
