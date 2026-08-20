using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public int currentHealth;
   public int maxHealth;
   
   private Animator _anim;
   private Rigidbody2D rb;

   private void Awake()
   {
      currentHealth = maxHealth;
      _anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
   }

   public void ChangeHealth(int amount)
   {
      currentHealth += amount;

      if (currentHealth > maxHealth)
      {
         currentHealth = maxHealth;
      }
   }

   private void Update()
   {
      
      
      if (currentHealth <= 0)
      {
         _anim.SetBool("isDead", true);
         rb.linearVelocity = Vector2.zero;
      }
   }

   private void DestroyEnemy()
   {
      Destroy(this.gameObject);
   }
}
