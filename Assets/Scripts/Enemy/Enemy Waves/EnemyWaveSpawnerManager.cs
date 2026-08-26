using UnityEngine;

public class EnemyWaveSpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner1;
    [SerializeField] private EnemySpawner _spawner2;

    private void Awake()
    {
        _spawner1.enabled = true;
        _spawner2.enabled = true;
    }

    public void WaveActiveOne()
    {
        
    }

    public void WaveActiveTwo()
    {
        
    }
    
    public void WaveActiveThree()
    {
        
    }
}
