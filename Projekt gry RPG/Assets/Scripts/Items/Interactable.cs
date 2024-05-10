using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; //range of interaction
    public Transform interactionTransform;
    bool isFocused = false;
    Transform player;
    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    private void Update()
    {
        //If player is focusing object and it was not interacted already
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            //if we are close enought
            if (distance <= radius)
            {
                //make interaction
                Interact();
                hasInteracted = true;
            }
        }

    }
    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused(Transform playerTransform)
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
