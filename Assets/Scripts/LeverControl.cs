using UnityEngine;

public class LeverController : MonoBehaviour
{
    public ElevatorController elevator;  // Boþ býrakabilirsin
    public DoorController door;           // Kapý baðla
    private bool playerInRange = false;

    private bool isFlipped = false; // Lever yön durumu
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Oyuncu yakýndaysa ve E'ye basarsa
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

        // Eðer mermi (Madde) çarparsa anýnda çalýþsýn
        if (collision.CompareTag("Madde"))
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

    private void ActivateLever()
    {
        if (elevator != null)
            elevator.ToggleElevator();

        if (door != null)
            door.ToggleDoor();

        // Lever yönünü deðiþtir
        isFlipped = !isFlipped;
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = isFlipped;
        }
        else
        {
            // Eðer spriteRenderer yoksa ölçekle çevir
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        Debug.Log("Lever çalýþtý ve yön deðiþti!");
    }
}
