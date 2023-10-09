using System;
using TMPro;
using UnityEngine;

namespace Code.Scene
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score = 0;
        private int _maxScore = 0;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private TextMeshProUGUI maxScoreText;

        public void AddScore(int score)
        {
            _score += score;
            UpdateScore();
        }

        private void UpdateScore()
        {
            scoreText.text = _score.ToString();
            finalScoreText.text = _score.ToString();
            if (_maxScore < _score)
            {
                _maxScore = _score;
                maxScoreText.text = _maxScore.ToString();
            }
        }
        
        public void SetMaxScore(int score)
        {
            _maxScore = score;
            maxScoreText.text = _maxScore.ToString();
        }

        public int GetScore()
        {
            return _score;
        }
    }
}
