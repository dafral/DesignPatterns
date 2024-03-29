using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.EventQueue
{
    public class EventQueue : MonoBehaviour
    {
        public static EventQueue Instance { get; private set; }

        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;

        private Dictionary<EventIds, List<IEventObserver>> _observers;

        private void Awake()
        {
            Instance = this;

            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
            _observers = new Dictionary<EventIds, List<IEventObserver>>();
        }

        public void Subscribe(EventIds eventId, IEventObserver eventObserver)
        {
            if(!_observers.TryGetValue(eventId, out List<IEventObserver> eventObservers))
            {
                eventObservers = new List<IEventObserver>();
            }

            eventObservers.Add(eventObserver);
            _observers[eventId] = eventObservers;
        }

        public void Unsuscribe(EventIds eventId, IEventObserver eventObserver)
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

        //private void ProcessEvent(EventData eventData)
        //{
        //    Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");
        //    switch (eventData.EventId)
        //    {
        //        case EventIds.EnemyDeath:
        //            EnemyDeathEventData enemyDeathEventData = (EnemyDeathEventData)eventData;
        //            AchievementsSystem.Instance.EnemyDeath();
        //            ScoreSystem.Instance.AddScore(enemyDeathEventData.ScoreToAdd);
        //            break;
        //        case EventIds.AchievementUnlocked:
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}

        private void ProcessEvent(EventData eventData)
        {
            Debug.Log($"Processing event {eventData.EventId} on frame {Time.frameCount}");

            if (_observers.TryGetValue(eventData.EventId, out List<IEventObserver> eventObservers))
            {
                foreach (IEventObserver eventObserver in eventObservers)
                {
                    eventObserver.Process(eventData);
                }
            }
        }
    }
}
