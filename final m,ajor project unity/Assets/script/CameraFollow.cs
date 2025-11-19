using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target the camera will follow
    public Transform target;

    // How smoothly the camera follows
    public float smoothSpeed = 0.125f;

    // Offset from the target position
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            // Desired position is target position + offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Apply the position
            transform.position = smoothedPosition;

            // Optional: make the camera look at the target
            transform.LookAt(target);
        }
    }
}
