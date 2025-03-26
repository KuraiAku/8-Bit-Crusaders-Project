using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fillImage; // UI Image to change color
    public Gradient healthGradient; // Gradient for color transition

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        UpdateHealthBarColor();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        UpdateHealthBarColor();
    }

    private void UpdateHealthBarColor()
    {
        if (fillImage != null)
        {
            float normalizedHealth = slider.value / slider.maxValue;
            fillImage.color = healthGradient.Evaluate(normalizedHealth); // Direct gradient mapping
        }
    }
}