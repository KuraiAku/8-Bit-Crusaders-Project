using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static Vector3 lastCheckpoint;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        lastCheckpoint = startPosition;
    }

    public void Respawn()
    {
        transform.position = lastCheckpoint;
    }
}