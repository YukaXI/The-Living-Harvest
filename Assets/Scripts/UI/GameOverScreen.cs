using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    
    private void Start()
    {
        _playerHealth = FindAnyObjectByType<PlayerHealth>();
    }
    
    private void Update()
    {
       if (_playerHealth == null)
       { 
           _playerHealth = FindAnyObjectByType<PlayerHealth>();
           return;
       }
       
       if (_playerHealth.GetHealth() <= 0)
       {
           gameObject.SetActive(true);
       }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("MainLevel");
    }
    
    
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
