using System;
using UnityEngine;
using FMODUnity;

public class EnemyHealth : MonoBehaviour
{
   public int currentHealth;
   public int maxHealth;
   
   private Animator _anim;
   private Rigidbody2D rb;
   private EnemyHealthBar  _enemyHealthBar;

   [SerializeField] 
   private GameObject _enemyHealthBarUI;

   private void Awake()
   {
      currentHealth = maxHealth;
      _anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      _enemyHealthBar = GetComponentInChildren<EnemyHealthBar>();
   }

   public void ChangeHealth(int amount)
   {
      _enemyHealthBar.currentHealth += amount;

      if (_enemyHealthBar.currentHealth > maxHealth)
      {
         _enemyHealthBar.currentHealth = _enemyHealthBar.maxHealth;
      }
   }

   private void Update()
   {
      if (_enemyHealthBar.currentHealth <= 0)
      {
         _anim.SetBool("isDead", true);
         rb.linearVelocity = Vector2.zero;
      }
   }

   private void DestroyEnemy()
   {
      Destroy(this.gameObject);
   }

   private void DestroyHealthBar()
   {
      _enemyHealthBarUI.SetActive(false);
   }
   
   private void EnemyDeathSound()
   {
      RuntimeManager.PlayOneShot("event:/SFX/Character/Enemies/DeathSound");
   }
}
