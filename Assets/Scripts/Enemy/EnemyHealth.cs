using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public int currentHealth;
   public int maxHealth;

   private void Awake()
   {
      currentHealth = maxHealth;
   }

   public void ChangeHealth(int amount)
   {
      currentHealth += amount;

      if (currentHealth > maxHealth)
      {
         currentHealth = maxHealth;
      }

      else if (currentHealth <= 0)
      {
         Destroy(gameObject);
      }
      
      else if (gameObject.CompareTag("EnemySpawn")  && currentHealth <= 0);
      {
         gameObject.SetActive(false);
      }
   }
}
