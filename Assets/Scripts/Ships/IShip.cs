using UnityEngine;

namespace Ships
{
    public abstract class Ship : MonoBehaviour
    {
        [SerializeField] private ShipId _id;

        public string Id => _id.Value;
    }
}