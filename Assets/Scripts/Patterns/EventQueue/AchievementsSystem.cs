using UnityEngine;

namespace Patterns.EventQueue
{
    public class AchievementsSystem : IEventObserver
    {
        private int _numberOfEnemiesDead;

        public AchievementsSystem()
        {
            _numberOfEnemiesDead = 0;
            EventQueue.Instance.Subscribe(EventIds.EnemyDeath, this);
        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId != EventIds.EnemyDeath)
            {
                return;
            }

            EnemyDeath();
        }

        private void EnemyDeath()
        {
            Debug.Log("Enemy Death!");
            _numberOfEnemiesDead += 1;

            if(_numberOfEnemiesDead == 3)
            {
                EventData eventData = new EventData(EventIds.AchievementUnlocked);
                EventQueue.Instance.EnqueueEvent(eventData);
            }
        }

    }
}
