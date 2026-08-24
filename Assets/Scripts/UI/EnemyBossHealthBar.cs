using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossHealthBar : MonoBehaviour
{
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;


    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    private void Update()
    {
        healthBarValueText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        
        healthBarSlider.value = currentHealth;
        healthBarSlider.maxValue = maxHealth;
    }

}