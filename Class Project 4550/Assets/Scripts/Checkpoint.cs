using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    public AudioClip checkpoint_sound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerRespawn.lastCheckpoint = transform.position;


            AudioManager.instance.PlaySFX(checkpoint_sound);
        }
    }

    private void start()
    {
        audioSOurce = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = checkpoint_sound;
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);

    }
}