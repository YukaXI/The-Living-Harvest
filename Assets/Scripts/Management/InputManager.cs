using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Player
{
    [DefaultExecutionOrder(-1000)]
    public class PlayerInputManager : MonoBehaviour
    {
        private InputSystem_Actions _inputSystemActions;

        private PlayerMovement _playerMovement;

        public InputSystem_Actions.PlayerActions PlayerActions => _inputSystemActions.Player;

        private InputAction _attackAction;
        
        private void Awake()
        {
            _playerMovement = FindAnyObjectByType<PlayerMovement>();
            _inputSystemActions = new InputSystem_Actions();
            _attackAction = _inputSystemActions.Player.Attack;
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
            
            _attackAction.performed += _playerMovement.Attack;
            //_attackAction.canceled += _playerMovement.AttackEnde;
        }
        
        public void DisableInput()
        {
            _attackAction.performed -= _playerMovement.Attack;
            //_attackAction.canceled -= _playerMovement.AttackEnde;
            
            _inputSystemActions.Disable();
        }
    }
}