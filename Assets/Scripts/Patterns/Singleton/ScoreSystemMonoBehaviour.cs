using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystemMonoBehaviour : MonoBehaviour
    {
        private static ScoreSystemMonoBehaviour _instance;
        private int _currentScore;

        public static ScoreSystemMonoBehaviour Instance()
        {
            if(_instance == null)
            {
                GameObject gameObject = new GameObject();
                _instance = gameObject.AddComponent<ScoreSystemMonoBehaviour>();
            }

            return _instance;
        }

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
        }
    }
}
