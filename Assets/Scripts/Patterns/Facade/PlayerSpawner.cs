using UnityEngine;

namespace Patterns.Facade
{
    public class PlayerSpawner : MonoBehaviour
    {
        public Player Player = new Player(100, 100);
    }
}
