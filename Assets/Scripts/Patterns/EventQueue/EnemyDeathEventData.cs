namespace Patterns.EventQueue
{
    public class EnemyDeathEventData : EventData
    {
        public readonly int ScoreToAdd;

        public EnemyDeathEventData(int scoreToAdd) : base(EventIds.EnemyDeath)
        {
            ScoreToAdd = scoreToAdd;
        }
    }
}
