using UnityEngine;

namespace Patterns.Factory
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyId _id;

        public string Id => _id.Value;
    }
}
