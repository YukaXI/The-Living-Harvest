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
    
    private void FindReferences()
    {
        if (healthBar == null)
        {
            healthBar = FindAnyObjectByType<HealthBar>(); 
        }
        
        if (_enemyHealth == null)
        { 
            _enemyHealth = FindAnyObjectByType<EnemyHealth>();
        } 
    }
    
    public void ChangeHealth(int amount)
    {
        if (healthBar == null) FindReferences();
        if (healthBar == null) return;
        
        healthBar.currentHealth += amount;
        
        healthBar.currentHealth = Mathf.Max(0, healthBar.currentHealth);
        
        if (healthBar.currentHealth <= 0)
        {
            Debug.Log("Player Dead");
            if (_anim != null)
            {
                _anim.SetBool("isDead", true);
            }
            
            if (_enemyHealth != null)
            {
                _enemyHealth.currentHealth = 0;
            }
            
            GameOverScreen gameOver = FindAnyObjectByType<GameOverScreen>();
            if (gameOver != null)
            {
                gameOver.ShowGameOverScreen();
            }
        }

    }
    
    public int GetHealth()
    {
        if (healthBar == null)
        {
            FindReferences();
        }
        
        if (healthBar != null)
        {
            return healthBar.currentHealth;
        }
        return 0;
    }
        
}
