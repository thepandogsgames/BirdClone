using UnityEngine;

namespace Code.Player.Jump_Action.Jumps
{
    public class DizzJump : IJumpAction
    {
        private Rigidbody2D _rb;
        private float _jumpforce;
        public void DoJump()
        {
            _rb.velocity = Vector2.down * _jumpforce;
        }

        public void Config(Rigidbody2D rigidbody2D, float jumpForce)
        {
            _rb = rigidbody2D;
            _jumpforce = jumpForce;
        }
    }
}
