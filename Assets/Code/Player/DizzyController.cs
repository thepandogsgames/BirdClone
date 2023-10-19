using System.Collections;
using Code.Player.Jump_Action;
using Code.Scene;
using UnityEngine;

namespace Code.Player
{
    public class DizzyController : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float rotationSpeed = 360;
        [SerializeField] private float dizzDuration = 10f;
        [SerializeField] private AudioSource dizzSfx;

        private Player _player;
        private JumpController _jumpController;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider2D;

        private MusicScene _musicScene;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _jumpController = GetComponent<JumpController>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _musicScene = GameObject.FindGameObjectWithTag("SceneMusic").GetComponent<MusicScene>();
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                StartDizz();
            }
        }

        private void StartDizz()
        {
            StartCoroutine(DoDizz());
        }

        private IEnumerator DoDizz()
        {
            float startTime = Time.time;
            _player.CanMove = false;
            _musicScene.StartDizz();
            transform.rotation = Quaternion.identity;
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _boxCollider2D.enabled = false;
            while (Time.time - startTime < duration)
            {
                float rotation = (Time.time - startTime) * rotationSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);

                _spriteRenderer.enabled = !_spriteRenderer.enabled;

                yield return null;
            }
            _player.CanMove = true;
            _spriteRenderer.enabled = true;
            transform.rotation = Quaternion.identity;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _boxCollider2D.enabled = true;
            _jumpController.StartDizzy();
            dizzSfx.Play();
            StartCoroutine(StopDizz());
        }

        private IEnumerator StopDizz()
        {
            yield return new WaitForSeconds(dizzDuration);
            dizzSfx.Stop();
            _musicScene.StopDizz();
            _jumpController.StopDizz();
            dizzSfx.Stop();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Whirlwind"))
            {
                StartDizz();
            }
        }
    }
}
