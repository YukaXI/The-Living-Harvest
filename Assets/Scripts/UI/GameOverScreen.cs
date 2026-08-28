using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    
    private void Awake()
    {
        if (_canvasGroup != null)
        {  
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
    
    public void ShowGameOverScreen()
    {
        StartCoroutine(ShowRoutine());
    }
    
    private IEnumerator ShowRoutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        
        Time.timeScale = 0;
        
        if (_canvasGroup != null)
            {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            }
    }
    
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2Field");
    }
    
    
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
