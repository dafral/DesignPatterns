using UnityEngine;

namespace Ships
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _shipsConfiguration;

        public ShipFactory(ShipsConfiguration shipsConfiguration)
        {
            _shipsConfiguration = shipsConfiguration;
        }

        public Ship Create(string shipId, Transform spawningTransform)
        {
            Ship shipPrefab = _shipsConfiguration.GetShipById(shipId);
            return Object.Instantiate(shipPrefab, spawningTransform.position, spawningTransform.rotation);
        }

    }
}