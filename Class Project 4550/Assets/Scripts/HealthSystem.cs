using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystems : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private HealthBar healthBar; // HealthBar reference

    private bool iframeActive;
    private float iframeDuration = 0.5f;

    private PlayerRespawn respawnSystem;

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth); // Initialize UI health bar
        }

        respawnSystem = GetComponent<PlayerRespawn>(); // Get reference to PlayerRespawn
    }

    public void TakeDamage(int damage)
    {
        if (iframeActive) return; // Prevent taking damage during iFrames

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0; // Prevent negative health

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth); // Update health bar
        }

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

            if (healthBar != null)
            {
                healthBar.SetHealth(currentHealth); // Update health bar
            }
        }
        else
        {
            Debug.LogError("PlayerRespawn component not found on player.");
        }
    }
}