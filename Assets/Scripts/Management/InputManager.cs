using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Player
{
    [DefaultExecutionOrder(-1000)]
    public class PlayerInputManager : MonoBehaviour
    {
        private InputSystem_Actions _inputSystemActions;
        private PlayerMovement _playerMovement;
        private PauseMenuController _pauseMenu;

        public InputSystem_Actions.PlayerActions PlayerActions => _inputSystemActions.Player;
        
        private InputAction _attackAction;
        private InputAction _inventoryAction;
        private InputAction _pauseAction;
        
        public bool IsInteractPressed => _inputSystemActions.Player.Interact.WasPressedThisFrame();
        
        private void Awake()
        {
            _playerMovement = FindAnyObjectByType<PlayerMovement>();
            _pauseMenu = FindAnyObjectByType<PauseMenuController>();
            _inputSystemActions = new InputSystem_Actions();
            
            _attackAction = _inputSystemActions.Player.Attack;
            _pauseAction = _inputSystemActions.Player.Pause;
            _inventoryAction = _inputSystemActions.Player.Inventory;
            
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
            _inventoryAction.performed += _playerMovement.Inventory;
            _pauseAction.performed +=  _pauseMenu.Pause;
           
        }
        
        public void DisableInput()
        {
            _attackAction.performed -= _playerMovement.Attack;
            _inventoryAction.performed -= _playerMovement.Inventory;
            _pauseAction.canceled -= _pauseMenu.Pause;
            
            _inputSystemActions.Disable();
        }
    }
}