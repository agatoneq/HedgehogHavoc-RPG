using UnityEngine;

public class Swing : MonoBehaviour
{
    // Amplituda ruchu wahadła (zakres w stopniach)
    public float amplitude = 60f;
    // Prędkość ruchu wahadła
    public float speed = 1f;
    // Kąt początkowy
    private float startAngle;

    private float nextAttackTime = 0;
    private float damageAmount = 10f;

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

        private void OnTriggerEnter(Collider other)
    {
                 Debug.Log("Ała kłoda");
                PlayerStats playerStats = other.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    Debug.Log("kłoda boli");
                
                    playerStats.TakeDamage(100000.0);
                }
               
    }
                
    
}