namespace Patterns.Observer
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsuscribe(IObserver observer);
        void Notify();
    }
}
