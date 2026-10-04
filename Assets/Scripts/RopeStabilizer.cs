using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dampens oscillations and stabilizes velocity on rope/chain segments to avoid chaotic physics explosions.
/// </summary>
public class RopeStabilizer : MonoBehaviour
{
    [Tooltip("List of rigidbodies that make up the rope segments.")]
    public List<Rigidbody2D> ropeSegments = new List<Rigidbody2D>();

    [Range(0f, 1f)]
    [Tooltip("Damping factor applied each fixed frame (lower = more damping).")]
    public float damping = 0.9f;

    private void FixedUpdate()
    {
        foreach (Rigidbody2D rb in ropeSegments)
        {
            if (rb == null) continue;

            // Zero out tiny velocities to prevent endless jitter
            if (rb.linearVelocity.magnitude < 0.05f)
            {
                rb.linearVelocity = Vector2.zero;
            }
            else
            {
                rb.linearVelocity *= damping;
            }

            if (Mathf.Abs(rb.angularVelocity) < 0.05f)
            {
                rb.angularVelocity = 0;
            }
            else
            {
                rb.angularVelocity *= damping;
            }
        }
    }
}
