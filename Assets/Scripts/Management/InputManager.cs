using UnityEngine;

namespace Project.Player
{
    [DefaultExecutionOrder(-1000)]
    public class PlayerInputManager : MonoBehaviour
    {
        private InputSystem_Actions _inputSystemActions;

        public InputSystem_Actions.PlayerActions PlayerActions => _inputSystemActions.Player;

        private void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            EnableInput();
        }

        private void OnDisable()
        {
            DisableInput();
        }

        public void EnableInput()
        {
            _inputSystemActions.Enable();
        }
        
        public void DisableInput()
        {
            _inputSystemActions.Disable();
        }
    }
}