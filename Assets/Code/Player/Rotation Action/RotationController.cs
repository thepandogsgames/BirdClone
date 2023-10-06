using UnityEngine;

namespace Code.Player.Rotation_Action
{
    public class RotationController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        private Transform _transform;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _transform.rotation = Quaternion.Euler(0,0, _rb.velocity.y * rotationSpeed);
        }
    }
}
