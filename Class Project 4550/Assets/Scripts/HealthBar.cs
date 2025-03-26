using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fillImage; // Reference to the UI Image for color change
    public Gradient healthGradient; // Gradient for health colors

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
            fillImage.color = healthGradient.Evaluate(slider.normalizedValue); // Apply gradient
        }
    }
}