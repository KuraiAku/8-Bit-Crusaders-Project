using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSystems healthSystem = collision.GetComponent<HealthSystems>();

            if (healthSystem != null)
            {
                int damage = healthSystem.maxHealth / 4; // Take 1/4 of max health
                healthSystem.TakeDamage(damage);

                // Move player back to last checkpoint
                collision.transform.position = PlayerRespawn.lastCheckpoint;
            }
        }
    }
}