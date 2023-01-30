namespace Patterns.Observer
{
    public interface IObserver
    {
        void Updated(ISubject subject);
    }
}
