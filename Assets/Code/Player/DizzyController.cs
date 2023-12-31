using System;
using System.Collections;
using Code.Player.Jump_Action;
using Code.Scene;
using TMPro;
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

        private bool _isDizz = false;

        private float _countdown;
        private TextMeshProUGUI _countdownText;

        private IEnumerator _myRoutine;
        
        private void Awake()
        {
            dizzSfx.Stop();
            _player = GetComponent<Player>();
            _jumpController = GetComponent<JumpController>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _musicScene = GameObject.FindGameObjectWithTag("SceneMusic").GetComponent<MusicScene>();
            _countdownText = GameObject.FindGameObjectWithTag("DizzTimer").GetComponent<TextMeshProUGUI>();
            _countdown = dizzDuration;
        }
        
        private void Update()
        {
            if (!_isDizz) return;
            _countdown -= Time.deltaTime;
            UpdateCountdownText();
        }

        private void StartDizz()
        {
            StopRoutine();
            _countdownText.gameObject.SetActive(false);
            _myRoutine = DoDizz();
            StartCoroutine(_myRoutine);
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
            _countdown = dizzDuration;
            _countdownText.gameObject.SetActive(true);
            dizzSfx.Play();
            _isDizz = true;
            StopDizz();
        }

        private void StopDizz()
        {
            StopRoutine();
            _myRoutine = CancelDizz();
            StartCoroutine(_myRoutine);
        }

        private IEnumerator CancelDizz()
        {
            yield return new WaitForSeconds(dizzDuration);
            _isDizz = false;
            _countdownText.gameObject.SetActive(false);
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

        private void UpdateCountdownText()
        {
            _countdownText.text = _countdown.ToString("0");
        }
        
        public bool IsDizz
        {
            get => _isDizz;
            set => _isDizz = value;
        }

        private void StopRoutine()
        {
            if (_myRoutine == null) return;
            StopCoroutine(_myRoutine);
            _myRoutine = null;
        }

        public void Reset()
        {
            StopRoutine();
            _isDizz = false;
            _countdownText.gameObject.SetActive(false);
            _musicScene.StopDizz();
            _jumpController.StopDizz();
            dizzSfx.Stop();
        }
    }
}
