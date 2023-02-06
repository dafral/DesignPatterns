using UnityEngine;
using TMPro;

namespace Patterns.ServiceLocator
{
    public class ScoreSystemMonoBehaviour : MonoBehaviour, IScoreSystem
    {
        [SerializeField] private TextMeshProUGUI _text;
        private int _currentScore;

        public void AddScore(int score)
        {
            _currentScore += score;
            Debug.Log(_currentScore);
            _text.SetText(_currentScore.ToString());
        }
    }
}
