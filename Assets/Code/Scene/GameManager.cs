using System;
using Code.Persistance;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private ISave _save;
        private ILoad _load;
        private ScoreManager _scoreManager;
        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject endMenu;

        private void Awake()
        {
            var persis = new PlayerPrefPersistance();
            _save = persis;
            _load = persis;
            _scoreManager = FindObjectOfType<ScoreManager>();
            _scoreManager.SetMaxScore(_load.LoadBestScore());
            InstancePlayer();
        }

        private void InstancePlayer()
        {
            Instantiate(player, Vector3.zero, quaternion.identity );
        }

        public void OnPlayerDead()
        {
            Time.timeScale = 0f;
            endMenu.SetActive(true);
            SaveScore();
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void SaveScore()
        {
            int currentScore = _scoreManager.GetScore();
            if (currentScore > _load.LoadBestScore())
            {
                _save.SaveScore(currentScore);
            }
        }
    }
}
