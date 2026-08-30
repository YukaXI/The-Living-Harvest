using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool isPaused = false;

    private void Awake()
    {
        PauseMenu.SetActive(false);
    }
    
    public void Pause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
            
            if (isPaused)
                Continue();
            else
                OnPause();
        
    }
    
    public void OnPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        PauseController.SetPause(false);
        isPaused = false;
    }  

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
