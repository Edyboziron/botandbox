using System.Collections.Generic;
using UnityEngine;

public class RopeStabilizer : MonoBehaviour
{
    public List<Rigidbody2D> ropeSegments = new List<Rigidbody2D>();
    [Range(0f, 1f)] public float damping = 0.9f;

    void FixedUpdate()
    {
        foreach (Rigidbody2D rb in ropeSegments)
        {
            // K���k h�zlar� s�f�rla
            if (rb.linearVelocity.magnitude < 0.05f)
                rb.linearVelocity = Vector2.zero;
            else
                rb.linearVelocity *= damping;

            if (Mathf.Abs(rb.angularVelocity) < 0.05f)
                rb.angularVelocity = 0;
            else
                rb.angularVelocity *= damping;
        }
    }
}
