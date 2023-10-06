using UnityEngine;

namespace Code.Player.Jump_Action
{
    public interface  IJumpAction
    {
        public void DoJump();
        public void Config(Rigidbody2D rigidbody2D, float jumpForce);
    }
}
