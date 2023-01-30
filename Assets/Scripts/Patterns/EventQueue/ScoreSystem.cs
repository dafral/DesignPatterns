using UnityEngine;

namespace Patterns.EventQueue
{
    public class ScoreSystem : IEventObserver
    {
        public ScoreSystem()
        {

        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId != EventIds.EnemyDeath)
            {
                return;
            }

            EnemyDeathEventData enemyDeathEventData = (EnemyDeathEventData)eventData;
            AddScore(enemyDeathEventData.ScoreToAdd);
        }

        private void AddScore(int scoreToAdd)
        {
            Debug.Log("Score added");
        }
    }
}
