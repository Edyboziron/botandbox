using UnityEngine;

/// <summary>
/// Smoothly follows a target along the vertical (Y) axis while keeping the X axis locked.
/// Used in vertical drop/fall levels such as the esophagus (yemek borusu) stage.
/// </summary>
public class CameraFollowY : MonoBehaviour
{
    [Tooltip("Target transform to follow.")]
    public Transform target;

    [Tooltip("Smooth time for camera interpolation.")]
    public float smoothTime = 0.3f;

    [Tooltip("Camera offset (e.g., (0, 0, -10)).")]
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            // Follow only on the Y axis, keep current X
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, target.position.z) + offset;

            // Smoothly interpolate camera movement
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            transform.position = smoothedPosition;
        }
    }
}
