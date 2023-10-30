using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Input
{
    [RequireComponent(typeof(IInputs))]
    public class InputListener : MonoBehaviour
    {
        private IInputs _inputActor;

        private void Awake()
        {
            _inputActor = GetComponent<IInputs>();
        }

        public void ActionButtonPressed(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _inputActor.ActionButtonPressed();
            }
        }
    }
}
