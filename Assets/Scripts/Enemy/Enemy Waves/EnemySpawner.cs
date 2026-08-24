using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [SerializeField] private float spawnRate = 1f;
    
    public bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            if (canSpawn)
            {
                int rand = Random.Range(0, prefab.Length);
                GameObject enemyToSpawn = prefab[rand];

                Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            }
        }
    }
    

    //Quelle: https://www.youtube.com/watch?v=2PfJZtnfc_Q
}
