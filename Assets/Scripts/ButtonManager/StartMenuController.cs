using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuController : MonoBehaviour
{
    public void OnStartClick()
{
    SceneManager.LoadScene("Level1Village");  //("..") Scene eingeben in die man rein alden will
}

public void OnExitClick()
{
    Application.Quit();
    Debug.Log("Quit");
}
}
