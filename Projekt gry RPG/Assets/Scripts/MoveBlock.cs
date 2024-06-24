using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private Vector3 lastPosition;
    private string terrainTag = "NoWalk";

    void Start()
    {
        // Ustaw początkową pozycję gracza
        lastPosition = transform.position;
    }

    void Update()
    {
        // Zachowaj aktualną pozycję gracza
        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Sprawdź, czy gracz wszedł w kolizję z obiektem o tagu Terrain
        if (collision.gameObject.CompareTag(terrainTag))
        {
            Debug.Log("jest kolizja");
            // Cofnij gracza na ostatnią bezpieczną pozycję
            transform.position = lastPosition;
        }
    }
}
