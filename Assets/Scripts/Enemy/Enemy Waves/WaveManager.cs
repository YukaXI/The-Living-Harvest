using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
   [SerializeField] private int killCount;

   [SerializeField]
   private EnemySpawner[] _enemySpawner;
   
   
   public void AddKill()
   {
      killCount++;
   }

   private void Update()
   {
      if (killCount == 20)
      {
         StopAllSpawners();
      }
   }

   private void SpawnerStop(bool state)
   {
      foreach (EnemySpawner spawner in _enemySpawner)
      {
         if (spawner != null)
         {
            spawner.canSpawn = state;
         }
      }
   }
   
   public void StartAllSpawners()
   {
      SpawnerStop(true);
   }

   public void StopAllSpawners()
   {
      SpawnerStop(false);
   }
}
