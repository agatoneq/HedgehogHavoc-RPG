using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float rotationSpeed = 20f;

    // Zakres rotacji w stopniach
    public float minRotation = -45f;
    public float maxRotation = 45f;

    // Aktualny kąt rotacji
    private float currentRotation = 0f;

    void Update()
    {
        // Pobierz wejście od gracza (np. strzałki w lewo i w prawo)
        float input = Input.GetAxis("Horizontal");

        // Oblicz zmianę kąta rotacji
        float rotationChange = rotationSpeed * Time.deltaTime;

        // Oblicz nowy kąt rotacji
        currentRotation += rotationChange;

        if(currentRotation >= maxRotation) rotationSpeed = -20f;
        else if(currentRotation <= minRotation) rotationSpeed = 20f;

        // Zastosuj rotację do obiektu
        transform.localRotation = Quaternion.Euler(currentRotation, 0f, 0f);
    }
}
