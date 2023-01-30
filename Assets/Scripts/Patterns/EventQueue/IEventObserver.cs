namespace Patterns.EventQueue
{
    public interface IEventObserver
    {
        public void Process(EventData eventData);
    }
}
