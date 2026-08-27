using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private EnemyWaveSpawnerManager _waveSpawnerManager;
     

    private void Awake()
    {
        _waveSpawnerManager = FindAnyObjectByType<EnemyWaveSpawnerManager>();
        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            LevelFade();
        }
    }

    public void SceneSwitch(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LevelFade()
    {
        anim.SetTrigger("fadeIn");
    }

    public void DialogueStart()
    {
        _waveSpawnerManager._triggerDialogue1.StartDialogue();
    }
}
