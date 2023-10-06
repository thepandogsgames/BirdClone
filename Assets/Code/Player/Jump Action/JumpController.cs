using System;
using Code.Player.Jump_Action.Jumps;
using UnityEngine;

namespace Code.Player.Jump_Action
{
    public class JumpController : MonoBehaviour
    {
        private IJumpAction _standardJump;
        private IJumpAction _currentJump;

        private void Awake()
        {
            Config();
        }

        private void Config()
        {
            _standardJump = new StandardJump();
            _standardJump.Config(GetComponent<Rigidbody2D>(), 2f);
            _currentJump = _standardJump;
        }
        
        public void Jump()
        {
            _currentJump.DoJump();
        }
    }
}
