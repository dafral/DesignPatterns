using Ships.Common;

namespace Events
{
    public class ShipDestroyedEventData : EventData
    {
        public readonly int InstanceId;
        public readonly Teams Team;
        public readonly int ScoreToAdd;

        public ShipDestroyedEventData(int instanceId, Teams team, int scoreToAdd) : base(EventIds.ShipDestroyed)
        {
            InstanceId = instanceId;
            Team = team;
            ScoreToAdd = scoreToAdd;
        }
    }
}
