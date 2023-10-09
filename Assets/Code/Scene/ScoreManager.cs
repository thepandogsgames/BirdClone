using UnityEngine;

namespace Code.Scene
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score = 0;
        private int _maxScore = 0;

        
        public void AddScore(int score)
        {
            _score += score;
        }

        public void SetMaxScore(int score)
        {
            _maxScore = score;
        }
    }
}
