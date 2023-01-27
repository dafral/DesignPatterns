using UnityEngine;
using System;
using System.Collections.Generic;

namespace Ships
{
    [CreateAssetMenu(menuName = "Ships/Create ShipsConfiguration", fileName = "ShipsConfiguration", order = 0)]
    public class ShipsConfiguration : ScriptableObject
    {
        [SerializeField] private Ship[] _shipsPrefabs;

        private Dictionary<string, Ship> _idToShipPrefab;

        private void Awake()
        {
            _idToShipPrefab = new Dictionary<string, Ship>();
            foreach (Ship shipPrefab in _shipsPrefabs)
            {
                _idToShipPrefab.Add(shipPrefab.Id, shipPrefab);
            }
        }

        public Ship GetShipById(string id)
        {
            if (!_idToShipPrefab.TryGetValue(id, out Ship ship))
            {
                throw new Exception($"Ship {id} not found!");
            }

            return ship;
        }
    }
}