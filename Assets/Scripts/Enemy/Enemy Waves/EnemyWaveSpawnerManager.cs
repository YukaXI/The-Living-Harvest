using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class EnemyWaveSpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner1;
    [SerializeField] private EnemySpawner _spawner2;
    [SerializeField] private EnemySpawner _spawner3;
    
    public NewNPCForWaves _triggerDialogue1;
    public NewNPCForWaves _triggerDialogue2;
    public NewNPCForWaves _triggerDialogue3;
    public NewNPCForWaves _triggerDialogue4;
    public NewNPCForWaves _triggerDialogue5;
  
    public GameObject _triggerDialogue1GM;
    public GameObject _triggerDialogue2GM;
    public GameObject _triggerDialogue3GM;
    public GameObject _triggerDialogue4GM;
    public GameObject _triggerDialogue5GM;

    private void Start()
    {
        //_triggerDialogue1GM.SetActive(true);
        _triggerDialogue2GM.SetActive(false);
        _triggerDialogue3GM.SetActive(false);
        _triggerDialogue4GM.SetActive(false);
        _triggerDialogue5GM.SetActive(false);
       _triggerDialogue1.StartDialogue();
    }

    public void WaveActiveOne()
    {
        _spawner1.waveOne = true;
        _spawner2.waveOne = true;
        _spawner3.waveOne = true;
    }

    public void WaveActiveTwo()
    {
        _spawner1.waveTwo = true;
        _spawner2.waveTwo = true;
        _spawner3.waveTwo = true;
    }
    
    public void WaveActiveThree()
    {
        _spawner1.waveThree = true;
        _spawner2.waveThree = true;
        _spawner3.waveThree = true;    
    }

    public void WaveActiveBoss()
    {
        _spawner1.waveFour = true;
        _spawner2.enabled = false;
        _spawner3.enabled = false;
    }
    
    public void BossDefeated()
    {
        Debug.Log("Boss Defeated");
        //SceneManager.LoadScene("MainLevel");
    }
}
