using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystems : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask trapLayer;
    public Slider healthBar; // UI Slider for health bar

    private bool iframeActive;
    private float iframeDuration = 0.5f;

    private bool isTouchingTrap;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    void Update()
    {
        Debug.Log("Current Health: " + currentHealth);
        isTouchingTrap = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, trapLayer);

        if (isTouchingTrap && !iframeActive)
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Respawn();
        }
        else
        {
            StartCoroutine(iFrame());
        }
    }
    IEnumerator iFrame()
    {
        iframeActive = true;
        yield return new WaitForSeconds(iframeDuration); // Wait for 0.5 seconds
        iframeActive = false;
    }

    void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // Reload current scene
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // Normalize health (0 to 1)
        }
    }
}