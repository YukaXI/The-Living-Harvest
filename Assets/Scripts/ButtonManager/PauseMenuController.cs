using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PauseMenu;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeSelf)
                {
                Resume();
                }
            else
            {
                Pause();
            }
        }
    }
    
    public void Resume()
    {
     PauseMenu.SetActive(false);
     Time.timeScale = 1;
     PauseController.SetPause(false);
    }  
    
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Exit()
    {
        Time.timeScale = 1;
        PauseController.SetPause(false);
        
        SceneManager.LoadScene("MainMenu");
    }
}
