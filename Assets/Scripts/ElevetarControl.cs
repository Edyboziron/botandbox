using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float targetHeight = 5f; // Asansörün çýkacaðý yükseklik

    private Vector3 startPos;
    private Vector3 topPos;
    private bool goingUp = false;   // Hedef yukarý mý aþaðý mý
    private bool isMoving = false;  // Þu an hareket ediyor mu

    void Start()
    {
        startPos = transform.position;
        topPos = new Vector3(startPos.x, startPos.y + targetHeight, startPos.z);
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 target = goingUp ? topPos : startPos;
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

            // Hedefe ulaþtýðýnda durdur
            if (Vector3.Distance(transform.position, target) < 0.01f)
                isMoving = false;
        }
    }

    public void ToggleElevator()
    {
        if (!isMoving) // Harekette deðilken tekrar çaðrýlabilir
        {
            goingUp = !goingUp; // Yönü deðiþtir
            isMoving = true;
        }
    }
}
