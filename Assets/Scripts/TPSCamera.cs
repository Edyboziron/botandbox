using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCamera : MonoBehaviour
{
    public Transform target; // Karakter nesneniz
    public Vector3 offset = new Vector3(0.6f, 1.6f, -2.5f); // Omuz üstü ayarý

    public float sensitivityX = 0.15f;
    public float sensitivityY = 0.15f;

    public float minAngle = -30f;
    public float maxAngle = 60f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Baþlangýçta kameranýn mevcut açýsýný alalým ki zýplama yapmasýn
        Vector3 rot = transform.localRotation.eulerAngles;
        yRotation = rot.y;
        xRotation = rot.x;
    }

    void LateUpdate()
    {
        if (target == null || Mouse.current == null) return;

        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        // Mouse hareketlerini ekle
        yRotation += mouseDelta.x * sensitivityX;
        xRotation += mouseDelta.y * sensitivityY; // Ters ise burayý -= yapabilirsin

        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        // Kameranýn dönüþünü mouse verilerine göre sabitle (Karakterden baðýmsýz)
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // Karakterin pozisyonunu takip et ama rotasyonunu görmezden gel
        Vector3 focusPoint = target.position + Vector3.up * 1.5f;

        transform.position = focusPoint + (rotation * offset);
        transform.rotation = rotation; // LookAt yerine direkt rotation kullanmak daha stabildir
    }
}