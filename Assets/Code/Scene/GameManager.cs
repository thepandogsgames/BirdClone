using Code.Persistance;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Scene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject playerMobile;
        [SerializeField] private GameObject ui;
        [SerializeField] private GameObject uiMobile;
        private ISave _save;
        private ILoad _load;
        private ScoreManager _scoreManager;
        [SerializeField] private GameObject endMenu;
        [SerializeField] private GameObject endMenuMobile;
        private GameObject _endMenu;
        private GameObject _playerInstance;

        private void Awake()
        {
            Application.targetFrameRate = 60; //Temp
            var persis = new PlayerPrefPersistance();
            if (Application.isMobilePlatform)
            {
                uiMobile.SetActive(true);
                _endMenu = endMenuMobile;
            }
            else
            {
                ui.SetActive(true);
                _endMenu = endMenu;
            }
            _save = persis;
            _load = persis;
            _scoreManager = FindObjectOfType<ScoreManager>();
            InstancePlayer();
        }

        private void Start()
        {
            _scoreManager.SetMaxScore(_load.LoadBestScore());
        }

        private void InstancePlayer()
        {
            _playerInstance = Instantiate(Application.isMobilePlatform ? playerMobile : player, new Vector3(-1.5f,0f,0f), quaternion.identity);
        }

        public void OnPlayerDead()
        {
            Time.timeScale = 0f;
            _endMenu.SetActive(true);
            SaveScore();
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        private void SaveScore()
        {
            int currentScore = _scoreManager.GetScore();
            if (currentScore > _load.LoadBestScore())
            {
                _save.SaveScore(currentScore);
            }
        }
    }
}
