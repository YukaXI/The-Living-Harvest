using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneMenuController : MonoBehaviour
{
    
public void Exit()
{
    SceneManager.LoadScene("MainMenu");
}

}
