using Ships.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _currentScore;

        public void Reset()
        {
            _currentScore = 0;
        }

        public void AddScore(Teams killedTeam, int scoreToAdd)
        {
            if(killedTeam != Teams.Enemy)
            {
                return;
            }

            _currentScore += scoreToAdd;
            _text.SetText(_currentScore.ToString());
        }
    }
}
