using Common.ObjectPool;
using System.Collections.Generic;

namespace Ships.Common
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;
        private Dictionary<string, ObjectPool> _pools;

        public ShipFactory(ShipsConfiguration shipsConfiguration)
        {
            _configuration = shipsConfiguration;

            Ship[] ships = _configuration.ShipsPrefabs;
            _pools = new Dictionary<string, ObjectPool>(ships.Length);
            foreach (Ship ship in ships)
            {
                ObjectPool objectPool = new ObjectPool(ship);
                _pools.Add(ship.Id, objectPool);
                objectPool.Init(0);
            }
        }

        public ShipBuilder Create(string shipId)
        {
            return new ShipBuilder().FromObjectPool(_pools[shipId]);

            //return Object.Instantiate(shipPrefab, spawningTransform.position, spawningTransform.rotation);
        }

    }
}