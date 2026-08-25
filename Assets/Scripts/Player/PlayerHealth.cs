using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthBar healthBar;
    private Animator _anim;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        healthBar = FindAnyObjectByType<HealthBar>();
        _enemyHealth = FindAnyObjectByType<EnemyHealth>();
    }
    
    public void ChangeHealth(int amount)
    {
        healthBar.currentHealth += amount;

        if (healthBar.currentHealth <= 0)
        {
            _anim.SetBool("isDead", true);
            _enemyHealth.currentHealth = 0;
        }
    }
    
    public int GetHealth()
    {
        if (healthBar != null)
        {
            return healthBar.currentHealth;
        }
        return 0;
    }
        
}
