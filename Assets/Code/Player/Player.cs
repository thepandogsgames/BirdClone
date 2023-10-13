using Code.Input;
using Code.Player.Jump_Action;
using Code.Scene;
using UnityEngine;

namespace Code.Player
{
    public class Player : MonoBehaviour, IInputs
    {
        [SerializeField] private AudioClip deadSfx;
        
        private JumpController _jumpController;
        private GameManager _gameManager;
        private AudioSource _audioSource;
        private bool _isDead = false;

        private void Awake()
        {
            _jumpController = GetComponent<JumpController>();
            _gameManager = FindObjectOfType<GameManager>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void ActionButtonPressed()
        {
            if (_isDead) return;
            _jumpController.Jump();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DeadZone"))
            {
                _isDead = true;
                _audioSource.PlayOneShot(deadSfx);
                _gameManager.OnPlayerDead();
            }
        }
    }
}
