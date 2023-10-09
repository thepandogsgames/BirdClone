using UnityEngine;

namespace Code.Persistance
{
    public class PlayerPrefPersistance : ISave, ILoad
    {
        private const string ScoreKey = "topScore";
        
        public void SaveScore(int score)
        {
            PlayerPrefs.SetInt(ScoreKey, score);
            PlayerPrefs.Save();
        }

        public int LoadBestScore()
        {
            return PlayerPrefs.GetInt(ScoreKey);
        }
    }
}
