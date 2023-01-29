
using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystem
    {
        private static ScoreSystem _instance;
        private int _currentScore;

        public static ScoreSystem Instance => _instance ?? (_instance = new ScoreSystem());
        
        private ScoreSystem()
        {

        }

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
        }
    }
}
