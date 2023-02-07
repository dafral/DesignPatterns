using Core.Services;
using Events;
using Ships.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour, IEventObserver
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _currentScore;
       
        public int CurrentScore
        {
            get => _currentScore;
            private set
            {
                _currentScore = value;
                _text.SetText(_currentScore.ToString());
            }
        }

        private void Start()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Subscribe(EventIds.ShipDestroyed, this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<IEventQueue>().Unsubscribe(EventIds.ShipDestroyed, this);
        }

        public void Reset()
        {
            CurrentScore = 0;
        }

        private void AddScore(Teams killedTeam, int scoreToAdd)
        {
            if(killedTeam != Teams.Enemy)
            {
                return;
            }

            CurrentScore += scoreToAdd;
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                ShipDestroyedEventData shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                AddScore(shipDestroyedEventData.Team, shipDestroyedEventData.ScoreToAdd);
            }
        }
    }
}
