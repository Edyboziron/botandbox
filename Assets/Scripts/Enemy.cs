using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Basic enemy AI that detects the player within range and pursues them.
/// Colliding with the player defeats them and resets the level.
/// </summary>
public class Enemy : MonoBehaviour
{
    [Tooltip("Movement speed when pursuing the player.")]
    public float speed = 3f;

    [Tooltip("Detection radius within which the enemy starts pursuing.")]
    public float followRange = 10f;

    private Transform player;
    private bool isFollowing = false;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure the player object has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isFollowing = distanceToPlayer <= followRange;

        if (isFollowing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);

            // Reload the current level upon player death
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
