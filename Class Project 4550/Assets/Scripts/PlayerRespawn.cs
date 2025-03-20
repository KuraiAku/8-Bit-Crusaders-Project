using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + V)]
public class PlayerRespawn : MonoBehaviour
{
    private const string V = "(),nq}";
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

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}