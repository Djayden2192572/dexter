using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Assign Dexter's parent object here.
    public Vector3 offset = new Vector3(0, 2, -5); // Adjust as needed.
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position of the camera.
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Make the camera look at Dexter.
        transform.LookAt(target);
    }
}


