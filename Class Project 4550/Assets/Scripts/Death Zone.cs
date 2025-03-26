using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSystems healthSystem = collision.GetComponent<HealthSystems>();
            PlayerRespawn respawn = collision.GetComponent<PlayerRespawn>();

            if (healthSystem != null)
            {
                int damage = healthSystem.maxHealth / 4; // Deal 1/4 of max health
                healthSystem.TakeDamage(damage);
            }

            if (respawn != null)
            {
                collision.transform.position = PlayerRespawn.lastCheckpoint; // or respawn.lastCheckpoint if it's not static
            }
        }
    }
}
