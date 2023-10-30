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
        [SerializeField] private TextMeshProUGUI scoreTextMobile;
        [SerializeField] private TextMeshProUGUI finalScoreTextMobile;
        [SerializeField] private TextMeshProUGUI maxScoreTextMobile;
        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _finalScoreText;
        private TextMeshProUGUI _maxScoreText;

        private void Awake()
        {
            if (Application.isMobilePlatform)
            {
                _scoreText = scoreTextMobile;
                _finalScoreText = finalScoreTextMobile;
                _maxScoreText = maxScoreTextMobile;
            }
            else
            {
                _scoreText = scoreText;
                _finalScoreText = finalScoreText;
                _maxScoreText = maxScoreText;
            }
        }

        public void AddScore(int score)
        {
            _score += score;
            UpdateScore();
        }

        private void UpdateScore()
        {
            _scoreText.text = _score.ToString();
            _finalScoreText.text = _score.ToString();
            if (_maxScore < _score)
            {
                _maxScore = _score;
                _maxScoreText.text = _maxScore.ToString();
            }
        }
        
        public void SetMaxScore(int score)
        {
            _maxScore = score;
            _maxScoreText.text = _maxScore.ToString();
        }

        public int GetScore()
        {
            return _score;
        }

        public void Reset()
        {
            _score = 0;
            _scoreText.text = _score.ToString();
        }
    }
}
