using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteract : MonoBehaviour
{

  //NPCInteractable

 private Animator animator;
 private void Awake() {
   // animator = GetComponent<Animator>();
}
public void Interact()
{
     Debug.Log("YEZZ BOYYYYY");

     ChatBooble.Create(transform.transform, new Vector3(-.3f,1.7f,0f),"Say Cheeeze");

   //  animator.SetTrigger("Talk");
}
}
