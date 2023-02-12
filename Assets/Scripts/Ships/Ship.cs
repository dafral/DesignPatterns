using UnityEngine;
using Ships.Common;
using System;
using Common.ObjectPool;

namespace Ships
{
    public abstract class Ship : RecyclableObject
    {
        [SerializeField] private ShipId _id;

        public string Id => _id.Value;

        public abstract void Configure(ShipConfiguration shipConfiguration);

        public abstract void OnDamageReceived(bool isDeath);

        public override void Init()
        {

        }

        public override void Release()
        {

        }
    }
}