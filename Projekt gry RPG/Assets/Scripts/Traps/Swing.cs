using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    // Amplituda ruchu wahadła (zakres w stopniach)
    public float amplitude = 60f;
    // Prędkość ruchu wahadła
    public float speed = 1f;
    // Kąt początkowy
    private float startAngle;

    void Start()
    {
        // Zachowaj początkowy kąt obiektu
        startAngle = transform.eulerAngles.x;
    }

    void Update()
    {
        // Oblicz nowy kąt
        float angle = startAngle + amplitude * Mathf.Sin(Time.time * speed);
        // Ustaw nowy kąt na osi X
        transform.eulerAngles = new Vector3(angle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}