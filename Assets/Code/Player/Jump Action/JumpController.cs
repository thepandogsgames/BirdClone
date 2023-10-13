using System;
using Code.Player.Jump_Action.Jumps;
using UnityEngine;

namespace Code.Player.Jump_Action
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private AudioClip jumpSfx;
        private AudioSource _audioSource;

        private IJumpAction _standardJump;
        private IJumpAction _currentJump;

        private void Awake()
        {
            Config();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Config()
        {
            _standardJump = new StandardJump();
            _standardJump.Config(GetComponent<Rigidbody2D>(), jumpForce);
            _currentJump = _standardJump;
        }
        
        public void Jump()
        {
            _currentJump.DoJump();
            _audioSource.PlayOneShot(jumpSfx);
        }
    }
}
