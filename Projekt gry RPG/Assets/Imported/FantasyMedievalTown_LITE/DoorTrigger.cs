using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool Trigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (Trigger)
            {
                myDoor.Play("doorOpening", 0, 0.0f);
            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            if (Trigger)
            {
                myDoor.Play("doorClosing", 0, 0.0f);
            }
    }
}
