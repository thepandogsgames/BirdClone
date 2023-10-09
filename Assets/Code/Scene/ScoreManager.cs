using UnityEngine;

namespace Code.Player
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score;
        private int _maxScore;


        public void AddScore(int score)
        {
            _score += score;
        }

        public int GetScore()
        {
            return _score;
        }

    }
}
