using Code.Input;
using Code.Player.Jump_Action;
using Code.Scene;
using UnityEngine;

namespace Code.Player
{
    public class Player : MonoBehaviour, IInputs
    {
        private JumpController _jumpController;
        private GameManager _gameManager;

        private void Awake()
        {
            _jumpController = GetComponent<JumpController>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void ActionButtonPressed()
        {
            _jumpController.Jump();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DeadZone"))
            {
                _gameManager.OnPlayerDead();
            }
        }
    }
}
