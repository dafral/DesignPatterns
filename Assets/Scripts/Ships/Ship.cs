using UnityEngine;
using Ships.Common;

namespace Ships
{
    public abstract class Ship : MonoBehaviour
    {
        [SerializeField] private ShipId _id;

        public string Id => _id.Value;
        public abstract void Configure(ShipConfiguration shipConfiguration);

        protected abstract void OnTriggerEnter2D(Collider2D collision);
    }
}