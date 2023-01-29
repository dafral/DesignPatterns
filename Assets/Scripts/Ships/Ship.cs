using UnityEngine;
using Ships.Common;
using System;

namespace Ships
{
    public abstract class Ship : MonoBehaviour
    {
        [SerializeField] private ShipId _id;

        public string Id => _id.Value;

        public abstract void Configure(ShipConfiguration shipConfiguration);

        public abstract void OnDamageReceived(bool isDeath);
    }
}