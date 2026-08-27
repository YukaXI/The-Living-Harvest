using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private EnemyWaveSpawnerManager _spawnerManager;
    private NewNPCForWaves _npc;
    
    [SerializeField] private GameObject[] prefabWaveOne;
    [SerializeField] private GameObject[] prefabWaveTwo;
    [SerializeField] private GameObject[] prefabWaveThree;
    [SerializeField] private GameObject[] prefabWaveFour;
    
    [SerializeField] private float spawnRate = 1f;
    private float timer;
    private int currentEnemyWaveOne;
    private int currentEnemyWaveTwo;
    private int currentEnemyWaveThree;
    private int currentEnemyWaveFour;
    
    public bool waveOne = false;
    public bool waveTwo = false;
    public bool waveThree = false;
    public bool waveFour = false;
    
    [Obsolete("Obsolete")]
    private void Awake()
    {
        timer = spawnRate;
        _spawnerManager = FindAnyObjectByType<EnemyWaveSpawnerManager>();
    }


    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (waveOne)
        {
            
            Instantiate(prefabWaveOne[currentEnemyWaveOne], transform.position, Quaternion.identity);
            currentEnemyWaveOne++;
            if (currentEnemyWaveOne >= prefabWaveOne.Length)
            {
                waveOne = false;
            }

            if (!waveOne)
            {
                _spawnerManager._triggerDialogue1GM.SetActive(false);
                _spawnerManager._triggerDialogue2GM.SetActive(true);
                if (_spawnerManager._triggerDialogue2 != null)
                {
                    _spawnerManager._triggerDialogue2.StartDialogue();
                }
            }
            
            timer = spawnRate;
        }
        
        else if(waveTwo)
        {
            
            Instantiate(prefabWaveTwo[currentEnemyWaveTwo], transform.position, Quaternion.identity);
            currentEnemyWaveTwo++;
            if (currentEnemyWaveTwo >= prefabWaveTwo.Length)
            {
                waveTwo = false;
            }
            
            if (!waveTwo)
            {
                _spawnerManager._triggerDialogue2GM.SetActive(false);
                _spawnerManager._triggerDialogue3GM.SetActive(true);
                if (_spawnerManager._triggerDialogue3 != null)
                {
                    _spawnerManager._triggerDialogue3.StartDialogue();
                }
            }

            timer = spawnRate;
        }
        
        else if(waveThree)
           
        {
            Instantiate(prefabWaveThree[currentEnemyWaveThree], transform.position, Quaternion.identity);
            currentEnemyWaveThree++;
            if (currentEnemyWaveThree >= prefabWaveThree.Length) 
            {
                waveThree = false;
            }
            
            if (!waveThree)
            {
                _spawnerManager._triggerDialogue3GM.SetActive(false);
                _spawnerManager._triggerDialogue4GM.SetActive(true);
                if (_spawnerManager._triggerDialogue4 != null)
                {
                    _spawnerManager._triggerDialogue4.StartDialogue();
                }
            }
            
            timer = spawnRate;
        }
        
        else if (waveFour)
        {
            Instantiate(prefabWaveFour[currentEnemyWaveFour], transform.position, Quaternion.identity);
            currentEnemyWaveFour++;
            if (currentEnemyWaveFour >= prefabWaveFour.Length) 
            {
                waveFour = false;
            }
            
            timer = spawnRate;
        }
    }
    

    //Quelle: https://www.youtube.com/watch?v=25B009a0Ks0&list=PLSR2vNOypvs76M6NQBeDHsJVh_jdWkdi1&index=12
}
