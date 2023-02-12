using Core.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class EventQueue : MonoBehaviour, IEventQueue
    {
        private class PendingData
        {
            public EventIds EventId;
            public IEventObserver EventObserver;

            public PendingData(EventIds eventId, IEventObserver eventObserver)
            {
                EventId = eventId;
                EventObserver = eventObserver;
            }
        }

        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;
        private List<PendingData> _dataToAdd;
        private List<PendingData> _dataToRemove;
        private bool _isProcessingEvents;

        private Dictionary<EventIds, List<IEventObserver>> _observers;

        private void Awake()
        {
            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
            _dataToRemove = new List<PendingData>();
            _observers = new Dictionary<EventIds, List<IEventObserver>>();
        }

        public void Subscribe(EventIds eventId, IEventObserver eventObserver)
        {
            if (_isProcessingEvents)
            {
                _dataToAdd.Add(new PendingData(eventId, eventObserver));
                return;
            }

            DoSubscribe(eventId, eventObserver);
        }

        private void DoSubscribe(EventIds eventId, IEventObserver eventObserver)
        {
            if (!_observers.TryGetValue(eventId, out List<IEventObserver> eventObservers))
            {
                eventObservers = new List<IEventObserver>();
            }

            eventObservers.Add(eventObserver);
            _observers[eventId] = eventObservers;
        }

        public void Unsubscribe(EventIds eventId, IEventObserver eventObserver)
        {
            if (_isProcessingEvents)
            {
                _dataToRemove.Add(new PendingData(eventId, eventObserver));
                return;
            }

            DoUnsuscribe(eventId, eventObserver);
        }

        private void DoUnsuscribe(EventIds eventId, IEventObserver eventObserver)
        {
            _observers[eventId].Remove(eventObserver);
        }

        public void EnqueueEvent(EventData eventData)
        {
            _nextEvents.Enqueue(eventData);
            Debug.Log($"Enqueued event {eventData.EventId} on frame {Time.frameCount}");
        }

        private void LateUpdate()
        {
            ProcessEvents();
        }

        private void ProcessEvents()
        {
            Queue<EventData> tempCurrentEvents = _currentEvents;
            _currentEvents = _nextEvents;
            _nextEvents = tempCurrentEvents;

            foreach (EventData currentEvent in _currentEvents)
            {
                ProcessEvent(currentEvent);
            }

            _currentEvents.Clear();
        }

        private void ProcessEvent(EventData eventData)
        {
            _isProcessingEvents = true;

            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");

            if (_observers.TryGetValue(eventData.EventId, out List<IEventObserver> eventObservers))
            {
                foreach (IEventObserver eventObserver in eventObservers)
                {
                    eventObserver.Process(eventData);
                }
            }

            _isProcessingEvents = false;
            
            ManagePendingObservers();
        }

        private void ManagePendingObservers()
        {
            foreach (PendingData data in _dataToAdd)
            {
                DoSubscribe(data.EventId, data.EventObserver);
            }

            foreach (PendingData data in _dataToRemove)
            {
                DoUnsuscribe(data.EventId, data.EventObserver);
            }
        }
    }
}
