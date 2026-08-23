using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthBarSlider;

    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    private void Update()
    {
        healthBarSlider.value = currentHealth;
        healthBarSlider.maxValue = maxHealth;
    }

}
