using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public AudioClip checkpoint_sound;
    private AudioSource audioSource; // Declare the AudioSource variable

    private void Start() // Fixed casing: "Start()" instead of "start()"
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = checkpoint_sound;
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerRespawn.lastCheckpoint = transform.position;

            if (AudioManager.instance != null) // Ensure AudioManager exists before calling it
            {
                AudioManager.instance.PlaySFX(checkpoint_sound);
            }
            else
            {
                Debug.LogWarning("AudioManager instance is missing! Check if it is added to the scene.");
            }
        }
    }
}