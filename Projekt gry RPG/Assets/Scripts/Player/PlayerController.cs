using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Player;
using UnityEngine;

class PlayerController: MonoBehaviour
{
    Camera camera;
    Player player;
    //public Interactable interactItem; //could be useful later
    public LayerMask items;
    private void Start()
    {
        camera = Camera.main;
        player = Player.Instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) ;
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Interact(interactable);
                }
            }
        }
    }
    void Interact(Interactable newInteract)
    {
        newInteract.Interact();
    }
}

