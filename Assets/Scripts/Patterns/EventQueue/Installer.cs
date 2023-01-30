using UnityEngine;

namespace Patterns.EventQueue
{
    public class Installer : MonoBehaviour
    {
        private void Start()
        {
            new ScoreSystem();
            new AchievementsSystem();
        }
    }
}
