using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
[Header("CUe")]
[SerializeField] private GameObject visualCue;

[Header("Text")]
[SerializeField] private TextAsset inkJSON;


private bool playerInRange;

private void Awake()
{
    playerInRange = false;
    visualCue.SetActive(false);
}

private void Update()
{
    if(playerInRange)
    {
        visualCue.SetActive(true);
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(inkJSON);
        }
    }
    else
    {
     visualCue.SetActive(false);
    }
}

public void OnTriggerEnter3D(Collider collider)
{
  if(collider.gameObject.tag == "Player")
  {
    playerInRange = true;
  }
}

private void OnTriggerExit3D(Collider collider)
{

}  

}
