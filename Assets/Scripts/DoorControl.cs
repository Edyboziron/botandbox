using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;     // Kaç derece açýlacak
    public float speed = 90f;         // Derece/saniye
    public bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isMoving = false;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, 0, openAngle) * closedRotation;
    }

    void Update()
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

    public void ToggleDoor()
    {
        if (!isMoving)
        {
            isOpen = !isOpen;
            isMoving = true;
        }
    }
}
