namespace Events
{
    public interface IEventObserver
    {
        public void Process(EventData eventData);
    }
}
