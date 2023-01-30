using System.Collections.Generic;

namespace Patterns.Observer
{
    public class Skill : ISubject
    {
        private readonly List<IObserver> _observers;

        public int Charges { get; private set; }

        public bool IsReady => Charges > 0;

        public Skill()
        {
            Charges = 3;
            _observers = new List<IObserver>();
        }

        public void Subscribe(IObserver IObserver)
        {
            _observers.Add(IObserver);
            IObserver.Updated(this);
        }

        public void Unsuscribe(IObserver IObserver)
        {
            _observers.Remove(IObserver);
        }

        public void Notify()
        {
            foreach (IObserver IObserver in _observers)
            {
                IObserver.Updated(this);
            }
        }

        public void Use()
        {
            if(Charges <= 0)
            {
                return;
            }

            Charges -= 1;
            Notify();
        }
    }
}
