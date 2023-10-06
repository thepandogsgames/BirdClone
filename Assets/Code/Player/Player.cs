using System;
using Code.Input;
using Code.Player.Jump_Action;
using UnityEngine;

namespace Code.Player
{
    public class Player : MonoBehaviour, IInputs
    {
        private JumpController _jumpController;

        private void Awake()
        {
            _jumpController = GetComponent<JumpController>();
        }

        public void ActionButtonPressed()
        {
            _jumpController.Jump();
        }
    }
}
