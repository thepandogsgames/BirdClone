using UnityEngine;

namespace Code.Player.Jump_Action
{
    public class JumpController : MonoBehaviour
    {
        private IJumpAction _standardJump;
        private IJumpAction _currentJump;

        public void Jump()
        {
            Debug.Log("Jumping");
        }
    }
}
