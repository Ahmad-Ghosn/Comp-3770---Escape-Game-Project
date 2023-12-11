using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector2 boundsX = new Vector2(-10f, 10f); // X-axis bounds
    public Vector2 boundsY = new Vector2(-5f, 5f);  // Y-axis bounds

    void LateUpdate()
    {
        if (target == null)
        {
            // Ensure that a target is assigned before attempting to follow
            return;
        }

        // Calculate the desired position based on the player's position
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x, boundsX.x, boundsX.y),
            Mathf.Clamp(target.position.y, boundsY.x, boundsY.y),
            transform.position.z
        );

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
