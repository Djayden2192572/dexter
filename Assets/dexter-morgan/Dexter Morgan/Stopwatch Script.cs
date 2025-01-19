using UnityEngine;
using TMPro;  // For TextMeshPro

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI timeText;  // TextMeshProUGUI for displaying time
    private float timeElapsed = 0f;  // Time passed since start
    private bool isRunning = true;  // Flag to check if the stopwatch is running

    void Update()
    {
        if (isRunning)  // Only update time if stopwatch is running
        {
            timeElapsed += Time.deltaTime;  // Increment time by the time passed in this frame
            UpdateTimeDisplay();  // Update the display
        }
    }

    void UpdateTimeDisplay()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + timeElapsed.ToString("F2") + "s";  // Display with 2 decimals
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishCube"))  // Check if the player hits the FinishCube
        {
            isRunning = false;  // Stop the stopwatch
            Debug.Log("Time Stopped: " + timeElapsed.ToString("F2") + "s");
        }
    }
}


