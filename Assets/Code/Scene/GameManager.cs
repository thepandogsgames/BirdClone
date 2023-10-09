using System;
using Code.Persistance;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Scene
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private ISave _save;
        private ILoad _load;
        private ScoreManager _scoreManager;

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

    }
}
