using UnityEngine;

/// <summary>
/// Controls rotating doors that open and close upon lever or trigger activation.
/// </summary>
public class DoorController : MonoBehaviour
{
    [Tooltip("Target rotation angle when open (in degrees).")]
    public float openAngle = 90f;

    [Tooltip("Rotation speed in degrees per second.")]
    public float speed = 90f;

    [Tooltip("Whether the door is currently open.")]
    public bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isMoving = false;

    private void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, 0, openAngle) * closedRotation;
    }

    private void Update()
    {
        if (isMoving)
        {
            Quaternion targetRot = isOpen ? openRotation : closedRotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, speed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRot) < 0.1f)
            {
                transform.rotation = targetRot;
                isMoving = false;
            }
        }
    }

    /// <summary>
    /// Toggles the door between opened and closed states.
    /// </summary>
    public void ToggleDoor()
    {
        if (!isMoving)
        {
            isOpen = !isOpen;
            isMoving = true;
        }
    }
}
