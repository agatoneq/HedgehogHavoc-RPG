using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetect : MonoBehaviour
{

// PlayerInteract

private void Update() {
    
     if(Input.GetKeyDown(KeyCode.E))
     {

    float interactRange =10f;

    Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange );
    foreach (Collider collider in colliderArray)
    {
       if(collider.TryGetComponent(out NpcInteract NpcI))
       {
        NpcI.Interact();
       }
    }
    }
}


}
