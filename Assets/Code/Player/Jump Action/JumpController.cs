using Code.Player.Jump_Action.Jumps;
using UnityEngine;

namespace Code.Player.Jump_Action
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private AudioClip jumpSfx;
        [SerializeField] private AudioClip dizzJumpSfx;
        private AudioClip _currentJumpSfx;
        private AudioSource _audioSource;

        private IJumpAction _standardJump;
        private IJumpAction _dizzJump;
        private IJumpAction _currentJump;

        private Rigidbody2D _rb;

        private AudioSource _sceneMusic;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            Config();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Config()
        {
            _standardJump = new StandardJump();
            _dizzJump = new DizzJump();
            _standardJump.Config(_rb, jumpForce);
            _dizzJump.Config(_rb, jumpForce);
            _currentJump = _standardJump;
            _currentJumpSfx = jumpSfx;
        }
        
        public void Jump()
        {
            _currentJump.DoJump();
            _audioSource.PlayOneShot(_currentJumpSfx);
        }

        public void StartDizzy()
        {
            _currentJump = _dizzJump;
            _currentJumpSfx = dizzJumpSfx;
            _rb.gravityScale = -1f;
        }

        public void StopDizz()
        {
            _rb.gravityScale = 1f;
            _currentJumpSfx = jumpSfx;
            _currentJump = _standardJump;
        }
        
    }
}
