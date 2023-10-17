using System.Collections;
using System.Globalization;
using Code.Player.Jump_Action.Jumps;
using UnityEngine;

namespace Code.Player.Jump_Action
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private AudioClip jumpSfx;
        [SerializeField] private float dizzDuration;
        private AudioSource _audioSource;

        private IJumpAction _standardJump;
        private IJumpAction _dizzJump;
        private IJumpAction _currentJump;

        private Rigidbody2D _rb;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                StartDizzy();
            }
        }

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
        }
        
        public void Jump()
        {
            _currentJump.DoJump();
            _audioSource.PlayOneShot(jumpSfx);
        }

        public void StartDizzy()
        {
            _currentJump = _dizzJump;
            _rb.gravityScale *= -1f;
            StartCoroutine(DisableDizz());
        }
        
        private IEnumerator DisableDizz()
        {
            yield return new WaitForSeconds(dizzDuration);
            _rb.gravityScale *= -1f;
            _currentJump = _standardJump;
        }
    }
}
