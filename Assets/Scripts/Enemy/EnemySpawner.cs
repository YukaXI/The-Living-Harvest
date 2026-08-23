using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private bool canSpawn = true;

    void Awake()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random. Range (0, prefab.Length);
            GameObject enemyToSpawn = prefab[rand];
            
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
    

    //Quelle: https://www.youtube.com/watch?v=2PfJZtnfc_Q
}
