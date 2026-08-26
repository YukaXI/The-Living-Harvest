using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabWaveOne;
    [SerializeField] private GameObject[] prefabWaveTwo;
    [SerializeField] private GameObject[] prefabWaveThree;
    
    [SerializeField] private float spawnRate = 1f;
    private float timer;
    private int currentEnemyWaveOne;
    private int currentEnemyWaveTwo;
    private int currentEnemyWaveThree;
    
    [SerializeField] private bool waveOne = true;
    [SerializeField] private bool waveTwo = false;
    [SerializeField] private bool waveThree = false;
    
    private void Start()
    {
        timer = spawnRate;
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
            
            timer = spawnRate;
        }
    }
    

    //Quelle: https://www.youtube.com/watch?v=25B009a0Ks0&list=PLSR2vNOypvs76M6NQBeDHsJVh_jdWkdi1&index=12
}
