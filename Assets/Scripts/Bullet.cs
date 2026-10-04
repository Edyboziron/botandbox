using UnityEngine;

/// <summary>
/// Controls bullet projectile movement, lifetime, and collision with enemies.
/// </summary>
public class Bullet : MonoBehaviour
{
    [Tooltip("Movement speed of the bullet.")]
    public float speed = 10f;

    [Tooltip("Time before the bullet is automatically destroyed.")]
    public float lifetime = 5f;

    private Rigidbody2D rb;
    private Transform playerTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
    }

    private void Start()
    {
        if (rb != null)
        {
            // Determine flight direction based on player facing direction
            float dir = (playerTransform != null && playerTransform.localScale.x < 0) ? -1f : 1f;
            rb.linearVelocity = new Vector2(speed * dir, 0);
        }

        // Destroy after lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check collision with enemies
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
