using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiraniaScrypt : MonoBehaviour
{
    // Promień półkola
    public float radius = 5f;
    // Prędkość ruchu
    public float speed = 1f;
    // Punkt środkowy półkola
    private Vector3 center;
    AudioManager audioManager;


    void Start()
    {
        // Ustaw środek półkola na aktualną pozycję obiektu
        center = transform.position;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.Log("audioManager jest nullem");
        }
    }

    void Update()
    {
        // Oblicz nową pozycję na półkolu
        float angle = Mathf.PI * Mathf.Sin(Time.time * speed);
        float x = center.x + radius * Mathf.Cos(angle);
        float y = center.y + radius * Mathf.Sin(angle);
        float z = center.z;

        // Ustaw nową pozycję obiektu
        transform.position = new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponentInChildren<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(10.0);
            audioManager.PlaySFX(audioManager.piranhaBite);
        }
    }
}
