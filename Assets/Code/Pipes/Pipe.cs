using System;
using Code.Scene;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Pipes
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private AudioClip pointSfx;
        [SerializeField] private GameObject whirlwind;
        [SerializeField] private int whirlProb = 0;
        private ScoreManager _scoreManager; 
        private Vector3 _movement;
        private AudioSource _audioSource;

        private void Awake()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!gameObject.activeSelf) return;
            _movement = Vector3.left * (speed * Time.deltaTime); 
            transform.Translate(_movement);

            if (transform.position.x < -11)
            {
                Reset();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            _scoreManager.AddScore(1);
            _audioSource.PlayOneShot(pointSfx);
        }

        public void Reset()
        {
            gameObject.SetActive(false);
            whirlwind.SetActive(false);
            transform.position = new Vector3(startPosition.x,Random.Range(-1.75f, 1.75f), startPosition.z);

            if (Random.Range(0, 100) < whirlProb)
            {
                whirlwind.SetActive(true);
            }
        }
    }
}
