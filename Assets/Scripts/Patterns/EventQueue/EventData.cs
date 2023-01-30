namespace Patterns.EventQueue
{
    public class EventData
    {
        public readonly EventIds EventId;

        public EventData(EventIds eventId)
        {
            EventId = eventId;
        }
    }
}
