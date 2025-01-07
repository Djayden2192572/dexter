using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    // Add a public variable for assigning a new AudioClip
    public AudioClip newClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic(); // Start playing music on scene load
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ChangeMusic(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("No AudioClip assigned!");
            return;
        }

        audioSource.Stop();        // Stop the current music
        audioSource.clip = clip;   // Assign the new clip
        audioSource.Play();        // Play the new music
    }

    // Example function to change music to the "newClip"
    public void UseNewClip()
    {
        ChangeMusic(newClip);
    }
}
