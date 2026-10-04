using UnityEngine;

/// <summary>
/// Constrains the distance between the player and the connected cube (box) within minimum and maximum limits.
/// </summary>
public class RopeLimit : MonoBehaviour
{
    [Tooltip("Target box/cube transform to tether to.")]
    public Transform cube;

    [Tooltip("Maximum allowed rope distance.")]
    public float maxDistance = 5f;

    [Tooltip("Minimum allowed rope distance.")]
    public float minDistance = 1f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (cube == null) return;

        float distance = Vector2.Distance(transform.position, cube.position);

        // Push away if closer than minimum distance
        if (distance < minDistance)
        {
            Vector2 dir = ((Vector2)transform.position - (Vector2)cube.position).normalized;
            transform.position = (Vector2)cube.position + dir * minDistance;
        }

        // Pull closer if further than maximum distance
        if (distance > maxDistance)
        {
            Vector2 dir = ((Vector2)transform.position - (Vector2)cube.position).normalized;
            transform.position = (Vector2)cube.position + dir * maxDistance;
        }
    }
}
