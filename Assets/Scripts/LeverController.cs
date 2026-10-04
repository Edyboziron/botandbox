using UnityEngine;

/// <summary>
/// Controls interactive levers that activate doors or elevators when the player presses 'E' or shoots them.
/// </summary>
public class LeverController : MonoBehaviour
{
    [Tooltip("Optional connected elevator controller to trigger.")]
    public ElevatorController elevator;

    [Tooltip("Optional connected door controller to trigger.")]
    public DoorController door;

    private bool playerInRange = false;
    private bool isFlipped = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Activate when player is in range and presses E
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLever();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }

        // Also activates when hit by a bullet/projectile
        if (collision.CompareTag("Madde") || collision.CompareTag("Bullet"))
        {
            ActivateLever();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    /// <summary>
    /// Flips the lever visual state and triggers connected mechanisms.
    /// </summary>
    private void ActivateLever()
    {
        if (elevator != null)
            elevator.ToggleElevator();

        if (door != null)
            door.ToggleDoor();

        // Flip lever sprite visual direction
        isFlipped = !isFlipped;
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = isFlipped;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
