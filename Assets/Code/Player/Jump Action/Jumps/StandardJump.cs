using UnityEngine;

namespace Code.Player.Jump_Action.Jumps
{
    public class StandardJump : IJumpAction
    {
        private Rigidbody2D _rb;
        private float _jumpforce;
        
        public void DoJump()
        {
            Debug.Log("StandardJump: " + "rb -> " + _rb + " jump force: " + _jumpforce);
        }

        public void Config(Rigidbody2D rigidbody2D, float jumpForce)
        {
            _rb = rigidbody2D;
            _jumpforce = jumpForce;
        }
    }
}
