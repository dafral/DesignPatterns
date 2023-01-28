using UnityEngine;

namespace Ships.Common
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration _configuration;

        public ShipFactory(ShipsConfiguration shipsConfiguration)
        {
            _configuration = shipsConfiguration;
        }

        public ShipBuilder Create(string shipId)
        {
            Ship shipPrefab = _configuration.GetShipById(shipId);

            return new ShipBuilder().
                FromPrefab(shipPrefab);

            //return Object.Instantiate(shipPrefab, spawningTransform.position, spawningTransform.rotation);
        }

    }
}