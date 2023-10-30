using Code.Input;
using Code.Player.Jump_Action;
using Code.Scene;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Player
{
    public class Player : MonoBehaviour, IInputs
    {
        [SerializeField] private AudioClip deadSfx;
        
        private JumpController _jumpController;
        private DizzyController _dizzyController;
        private GameManager _gameManager;
        private AudioSource _audioSource;
        private bool _canMove = false;
        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }
        private void Awake()
        {
            _jumpController = GetComponent<JumpController>();
            _dizzyController = GetComponent<DizzyController>();
            _gameManager = FindObjectOfType<GameManager>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void ActionButtonPressed()
        {
            if (!_canMove) return;
            _jumpController.Jump();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DeadZone"))
            {
                _canMove = false;
                _audioSource.PlayOneShot(deadSfx);
                _gameManager.OnPlayerDead();
            }
        }

        public void Reset()
        {
            transform.localPosition = new Vector3(-1.5f, 0f, 0f);
            transform.localRotation = quaternion.identity;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _jumpController.Reset();
            _dizzyController.Reset();
        }
    }
}
