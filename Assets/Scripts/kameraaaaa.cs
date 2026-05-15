using UnityEngine;

public class CameraFollo : MonoBehaviour
{
    public Transform target;        // Takip edilecek karakter
    public float smoothTime = 0.3f; // Yumuþak takip süresi
    public Vector3 offset;          // Kamera ofseti (örn. (0, 0, -10))

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // Sadece Y ekseninde takip et, X sabit kalsýn
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, target.position.z) + offset;

            // SmoothDamp ile akýcý takip
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            transform.position = smoothedPosition;
        }
    }
}
