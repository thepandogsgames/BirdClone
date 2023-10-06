using Code.Input;
using UnityEngine;

namespace Code.Player
{
    public class Player : MonoBehaviour, IInputs
    {
        public void ActionButtonPressed()
        {
            Debug.Log("action pressed");
        }
    }
}
