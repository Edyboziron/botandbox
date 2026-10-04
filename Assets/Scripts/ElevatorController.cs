using UnityEngine;

/// <summary>
/// Controls moving platforms / elevators that move between their start position and target height.
/// </summary>
public class ElevatorController : MonoBehaviour
{
    [Tooltip("Movement speed of the elevator.")]
    public float moveSpeed = 2f;

    [Tooltip("Target elevation offset the elevator rises to.")]
    public float targetHeight = 5f;

    private Vector3 startPos;
    private Vector3 topPos;
    private bool goingUp = false;
    private bool isMoving = false;

    private void Start()
    {
        startPos = transform.position;
        topPos = new Vector3(startPos.x, startPos.y + targetHeight, startPos.z);
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 target = goingUp ? topPos : startPos;
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                isMoving = false;
            }
        }
    }

    /// <summary>
    /// Toggles the elevator moving direction (up or down).
    /// </summary>
    public void ToggleElevator()
    {
        if (!isMoving)
        {
            goingUp = !goingUp;
            isMoving = true;
        }
    }
}
