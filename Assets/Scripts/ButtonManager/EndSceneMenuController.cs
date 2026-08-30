using System;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class EndSceneMenuController : MonoBehaviour
{
    public void Exit()
    { 
        SceneManager.LoadScene("MainMenu");
    }

}
