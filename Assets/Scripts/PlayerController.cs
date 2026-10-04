using UnityEngine;

/// <summary>
/// Controls the player character (Bot): 2D movement, jump, wall-sliding, shooting, and audio effects.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal movement speed.")]
    public float moveSpeed = 5f;

    [Tooltip("Upward velocity applied upon jumping.")]
    public float jumpForce = 10f;

    [Tooltip("Transform used to check if the player is on the ground.")]
    public Transform groundCheck;

    [Tooltip("Transform used to check if the player is touching a wall.")]
    public Transform wallCheck;

    [Tooltip("Layer mask representing ground surfaces.")]
    public LayerMask groundLayer;

    [Tooltip("Radius around check points to detect ground or wall collisions.")]
    public float checkRadius = 0.2f;

    [Tooltip("Terminal downward speed while sliding down a wall.")]
    public float wallSlideSpeed = 2f;

    [Header("Shooting")]
    [Tooltip("Prefab for spawned bullets.")]
    public GameObject bulletPrefab;

    [Tooltip("Spawn position and orientation for bullets.")]
    public Transform firePoint;

    [Tooltip("Initial bullet launch speed.")]
    public float bulletSpeed = 10f;

    [Header("Sound")]
    [Tooltip("Sound clip played when shooting.")]
    public AudioClip shootSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private float moveInput;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Jump if grounded or touching a wall
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isTouchingWall))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Flip facing direction based on input
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }

        // Shoot projectile
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, groundLayer);

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Wall sliding mechanics
        if (isTouchingWall && !isGrounded && moveInput != 0)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlideSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        if (rbBullet != null)
        {
            Vector2 direction = facingRight ? Vector2.right : Vector2.left;
            rbBullet.linearVelocity = direction * bulletSpeed;
        }

        // Play shoot sound effect
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
