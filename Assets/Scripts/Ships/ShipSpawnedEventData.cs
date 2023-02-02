using Ships.Common;

namespace Events
{
    public class ShipSpawnedEventData : EventData
    {
        public readonly int InstanceId;
        public readonly Teams Team;

        public ShipSpawnedEventData(int instanceId, Teams team) : base(EventIds.ShipSpawned)
        {
            InstanceId = instanceId;
            Team = team;
        }
    }
}
