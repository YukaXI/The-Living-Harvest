using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Quelle: https://www.youtube.com/watch?v=S0gmSDRXzgs
    
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;

    public int maxHealth;
    public int currHealth;

    private void Awake()
    {
        currHealth = maxHealth;
    }


    private void Update()
    {
        healthBarValueText.text = currHealth.ToString() + "/" + maxHealth.ToString();

        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;
    }
}
