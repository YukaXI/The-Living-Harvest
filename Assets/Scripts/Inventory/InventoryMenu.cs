using UnityEngine;
using UnityEngine.InputSystem;

namespace Project
{
    public class InventoryMenu : MonoBehaviour
    {
        public GameObject inventoryMenu;
        public bool isPaused;

        private void Awake()
        {
            inventoryMenu.SetActive(false);
        }
        
        public void OpenInventory(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed) return;
            
            if (isPaused)
                ResumeGame();
            else
                PauseGame();

        }
        
        public void ResumeGame()
        {
            inventoryMenu.SetActive(false);
            isPaused = false;
        }

        public void PauseGame()
        {
            inventoryMenu.SetActive(true);
            isPaused = true;
        }
    }
}