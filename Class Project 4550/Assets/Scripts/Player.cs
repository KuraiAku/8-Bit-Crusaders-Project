using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthSystems healthSystem; // Reference to the HealthSystems script

    void Update()
    {
        // Temporary damage test (Press Space to take 20 damage)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthSystem.TakeDamage(20); // Call the existing TakeDamage() method
        }
    }
}