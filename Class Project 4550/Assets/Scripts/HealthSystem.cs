using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystems : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar; // UI Slider for health bar

    private bool iframeActive;
    private float iframeDuration = 0.5f;

    private PlayerRespawn respawnSystem;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        respawnSystem = GetComponent<PlayerRespawn>(); // Get reference to PlayerRespawn
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0; // Prevent negative health

        UpdateHealthBar();

        if (currentHealth == 0)
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
        yield return new WaitForSeconds(iframeDuration);
        iframeActive = false;
    }

    void Respawn()
    {
        if (respawnSystem != null)
        {
            transform.position = PlayerRespawn.lastCheckpoint; // Move to last checkpoint
            currentHealth = maxHealth; // Restore full health
            UpdateHealthBar();
        }
        else
        {
            Debug.LogError("PlayerRespawn component not found on player.");
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // Normalize health (0 to 1)
        }
    }
}