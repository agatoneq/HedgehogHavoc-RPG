using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Player;
using UnityEngine;

class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        Player.Instance.Inventory.AddItem(item);
        Debug.Log("picked up item:"+item.name);
        Destroy(gameObject);
    }
}

