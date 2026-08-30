using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private EnemyWaveSpawnerManager _waveSpawnerManager;
    [SerializeField] private NPC _dialogueMayor;
    [SerializeField] private NPCDialogue _newDialogueMayor;
     

    private void Awake()
    {
        _waveSpawnerManager = FindAnyObjectByType<EnemyWaveSpawnerManager>();
        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            LevelFade();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            LevelFade();
            _dialogueMayor.dialogueData = _newDialogueMayor;
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

    public void LevelFadeOut()
    {
        anim.SetTrigger("fadeOut");
    }

    public void LevelFadeBrightOut()
    {
        anim.SetTrigger("fadeAfter");
        _waveSpawnerManager._triggerDialogue5.enabled = false;
    }
    
    public void DialogueStart()
    {
        _waveSpawnerManager._triggerDialogue1.StartDialogue();
    }

    public void LevelStartAfterBoss()
    {
        _dialogueMayor.StartDialogue();
    }
}
