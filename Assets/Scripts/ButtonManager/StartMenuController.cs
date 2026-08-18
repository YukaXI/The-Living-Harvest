using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public GameObject CreditsMenu;
public void OnStartClick()
{
    SceneManager.LoadScene("Test");  //("..") Scene eingeben in die man rein alden will
}

public void OnExitClick()
{
    Application.Quit();
    Debug.Log("Quit");
}

public void OnCreditsClick()
{ 
    if(CreditsMenu != null)
    {
        CreditsMenu.SetActive(true);
    }
}
}
