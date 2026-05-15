using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam; // Inspector'da "Main Camera"yý buraya sürükleyin
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private Vector3 velocity;
    private float gravity = -9.81f;

    void Start()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        // Kamera atanmamýþsa otomatik bul
        if (cam == null) cam = Camera.main.transform;
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0) velocity.y = -2f;

        // WASD Girdileri
        Vector2 input = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y = 1;
            if (Keyboard.current.sKey.isPressed) input.y = -1;
            if (Keyboard.current.aKey.isPressed) input.x = -1;
            if (Keyboard.current.dKey.isPressed) input.x = 1;
        }

        // --- HAREKET MANTIÐI ---
        if (input.magnitude >= 0.1f)
        {
            // Kameranýn baktýðý açýyý derece cinsinden alýyoruz
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Karakteri bu açýya doðru yumuþakça döndür
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Hareket yönünü o açýya göre hesapla
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Yerçekimi
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}