using UnityEngine;

namespace Patterns.EventQueue
{
    public class Enemy : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                EnemyDeathEventData enemyDeathEventData = new EnemyDeathEventData(10);
                EventQueue.Instance.EnqueueEvent(enemyDeathEventData);
            }
        }
    }
}
