using UnityEngine;

namespace Ships.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Create ProjectileId", fileName = "ProjectileId", order = 1)]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}
