using System;
using UnityEngine;

namespace Code.Pipes
{
    public class Whirlwind : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnBecameVisible()
        {
            _audioSource.Play();
        }

        private void OnBecameInvisible()
        {
            _audioSource.Stop();
        }
    }
}
