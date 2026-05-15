using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f; // Merminin ne kadar s�re sonra yok olaca��n� belirler
    private Rigidbody2D rb;
    private Transform playerTransform;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        // Player'�n y�n�ne g�re merminin h�z�n� belirler
        if (playerTransform.localScale.x > 0)
        {
            rb.linearVelocity = new Vector2(speed, 0); // Sa�a do�ru
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0); // Sola do�ru
        }

        // Belirlenen s�re sonunda mermiyi yok etme komutu
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �arp��an nesnenin d��man olup olmad���n� kontrol eder
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // D��man� yok et
            Destroy(gameObject);      // Mermiyi yok et
        }
    }
}