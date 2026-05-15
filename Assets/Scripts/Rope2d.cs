using UnityEngine;

public class RopeLimit : MonoBehaviour
{
    public Transform cube;
    public float maxDistance = 5f;  // izin verilen maksimum ip uzunluğu
    public float minDistance = 1f;  // kutuya en fazla bu kadar yaklaşabilirsin

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, cube.position);

        // Çok yaklaştıysa geri it
        if (distance < minDistance)
        {
            Vector2 dir = (transform.position - cube.position).normalized;
            transform.position = (Vector2)cube.position + dir * minDistance;
        }

        // Çok uzaklaştıysa geri çek
        if (distance > maxDistance)
        {
            Vector2 dir = (transform.position - cube.position).normalized;
            transform.position = (Vector2)cube.position + dir * maxDistance;
        }
    }
}
