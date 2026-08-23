using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] float sizeX = 1f;
    [SerializeField] float sizeY =1f;
    [SerializeField] float spawnCooldown = 1f;

    private float spawnTime;

    void Awake()
    {
        spawnTime = spawnCooldown;
    }

    private void Update()
    {
        if (spawnTime > 0) spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = spawnCooldown;
        }
    }

    private void Spawn()
    {
        float xPos = (Random.value - 0.5f)*2 * sizeX + gameObject.transform.position.x;
        float yPos = (Random.value - 0.5f)*2 * sizeY + gameObject.transform.position.y;

        var spawn = Instantiate(spawner);
        
        spawn.transform.position = new Vector3(xPos, yPos, 0);
    }

    //Quelle: https://www.youtube.com/shorts/3UNDp1TlxdM
}
