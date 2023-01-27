using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Ships/Create ShipId", fileName = "ShipId", order = 1)]
    public class ShipId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}