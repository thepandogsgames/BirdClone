using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Pipes
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 startPosition;
        private Vector3 _movement;

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
            if (!other.CompareTag("Player"))
            {
                Reset();
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
