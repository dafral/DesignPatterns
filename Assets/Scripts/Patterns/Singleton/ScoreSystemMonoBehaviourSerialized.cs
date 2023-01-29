using UnityEngine;
using TMPro;

namespace Patterns.Singleton
{
    public class ScoreSystemMonoBehaviourSerialized : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private static ScoreSystemMonoBehaviourSerialized _instance;
        private int _currentScore;

        private void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
        }

        public static ScoreSystemMonoBehaviourSerialized Instance()
        {
            return _instance;
        }

        public void AddScore(int score)
        {
            _currentScore += score;
            _text.SetText(_currentScore.ToString());
        }
    }
}
