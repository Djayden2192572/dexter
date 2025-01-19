using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicTracks;  // Array of music tracks
    private AudioSource audioSource;  // AudioSource to play music
    private int currentTrackIndex = 0;  // Current track index

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic(currentTrackIndex);  // Start playing the first track
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))  // Check for the M key press
        {
            currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;  // Loop through the tracks
            PlayMusic(currentTrackIndex);
        }
    }

    void PlayMusic(int trackIndex)
    {
        audioSource.clip = musicTracks[trackIndex];
        audioSource.Play();
    }
}
