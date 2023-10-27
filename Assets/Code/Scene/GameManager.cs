using Code.Persistance;
using Code.Pipes;
using Unity.Mathematics;
using UnityEngine;

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
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject menuMobile;
        private GameObject _menu;
        private GameObject _playerInstance;
        private PipePooler _pipePooler;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            var persis = new PlayerPrefPersistance();
            if (Application.isMobilePlatform)
            {
                uiMobile.SetActive(true);
                _menu = menuMobile;
            }
            else
            {
                ui.SetActive(true);
                _menu = menu;
            }
            _save = persis;
            _load = persis;
            _scoreManager = FindObjectOfType<ScoreManager>();
            _pipePooler = FindObjectOfType<PipePooler>();
            InstancePlayer();
            Time.timeScale = 0f;
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
            _menu.SetActive(true);
            Time.timeScale = 0f;
            _pipePooler.Reset();
            _playerInstance.GetComponent<Player.Player>().Reset();
            SaveScore();
        }

        public void StartGame()
        {
            _playerInstance.GetComponent<Player.Player>().CanMove = true;
            _scoreManager.Reset();
            _menu.SetActive(false);
            Time.timeScale = 1f;
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
