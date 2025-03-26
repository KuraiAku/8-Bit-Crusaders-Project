using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public int checkpointSFXIndex = 1;
    public UnityEvent<int> onCheckpointReached;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerRespawn.lastCheckpoint = transform.position;

            onCheckpointReached?.Invoke(checkpointSFXIndex);

            

        }
    }
}