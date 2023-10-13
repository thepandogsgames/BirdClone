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
            if (other.CompareTag("Player"))
            {
                _scoreManager.AddScore(1);
                _audioSource.PlayOneShot(pointSfx);
            }
        }

        public void Reset()
        {
            gameObject.SetActive(false);
            transform.position = startPosition;
            transform.position = new Vector3(transform.position.x,Random.Range(-1.75f, 1.75f), transform.position.z);  
        }
    }
}
