using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Maintains distance constraints between connected chain / rope segments in 2D space.
/// Uses iterative position correction (Verlet-like constraint solver).
/// </summary>
[RequireComponent(typeof(Transform))]
public class ChainDistanceConstraint : MonoBehaviour
{
    [Header("Chain Setup")]
    [Tooltip("List of connected chain link rigidbodies in sequential order.")]
    public List<Rigidbody2D> links;

    [Tooltip("Maximum allowed distance between adjacent chain links.")]
    public float maxDistance = 1f;

    [Range(1, 10)]
    [Tooltip("Higher solver iterations yield stiffer and more stable chains.")]
    public int solverIterations = 4;

    private void FixedUpdate()
    {
        if (links == null || links.Count < 2) return;

        // Iterative corrections - distribute distance error evenly between neighboring links
        for (int it = 0; it < solverIterations; it++)
        {
            for (int i = 1; i < links.Count; i++)
            {
                Rigidbody2D a = links[i - 1];
                Rigidbody2D b = links[i];

                if (a == null || b == null) continue;

                Vector2 posA = a.position;
                Vector2 posB = b.position;

                Vector2 delta = posB - posA;
                float dist = delta.magnitude;

                if (dist == 0f) continue;

                if (dist > maxDistance)
                {
                    float error = dist - maxDistance;
                    Vector2 correctionDir = delta / dist;

                    // Evenly distribute correction across both bodies (50% each)
                    Vector2 corr = correctionDir * (error * 0.5f);

                    Vector2 newA = posA + corr;
                    Vector2 newB = posB - corr;

                    // Apply updated positions via physics engine
                    a.MovePosition(newA);
                    b.MovePosition(newB);
                }
            }
        }
    }
}
