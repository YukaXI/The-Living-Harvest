using System;
using UnityEngine;
using FMODUnity;

public class EnemyBossHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
   
    private Animator _anim;
    private Rigidbody2D rb;
    private EnemyHealthBar _enemyHealthBar;
    private EnemyBossHealthBar _bossHealthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _enemyHealthBar = GetComponentInChildren<EnemyHealthBar>();
        _bossHealthBar = FindAnyObjectByType<EnemyBossHealthBar>();
    }

    public void ChangeHealth(int amount)
    {
        _bossHealthBar.currentHealth += amount;

        if (_bossHealthBar.currentHealth > maxHealth)
        {
            _bossHealthBar.currentHealth = _bossHealthBar.maxHealth;
        }
    }

    private void Update()
    {
        if (_bossHealthBar.currentHealth <= 0)
        {
            _anim.SetBool("isDead", true);
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    private void EnemyDeathSound()
    {
        RuntimeManager.PlayOneShot("event:/SFX/Character/Enemies/DeathSound");
    }
}