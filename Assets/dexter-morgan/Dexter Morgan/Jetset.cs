using UnityEngine;

public class PlaySoundOnKeyPress : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource

    void Update()
    {
        // Check if the "T" key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Play the sound effect
            audioSource.Play();
        }
    }
}
