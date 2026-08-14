using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthBar healthBar;

    private void Awake()
    {
        healthBar = FindAnyObjectByType<HealthBar>();
    }
    
    
    public void ChangeHealth(int amount)
    {
        healthBar.currentHealth -= amount;

        if (healthBar.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
