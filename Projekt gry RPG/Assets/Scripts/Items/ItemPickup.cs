using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Player;
using UnityEngine;

class ItemPickup : Interactable
{
    public QuestGiver questGiver;
    public Item item;
    public string Name { get { return item.name; } set { item.name = value; } }

    void Start()
    {
        if (questGiver == null)
        {
            questGiver = FindObjectOfType<QuestGiver>();
            if (questGiver == null)
            {
                Debug.LogError("QuestGiver not found in the scene. Please assign it manually.");
            }
        }
    }
    
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Player.Instance.Inventory.AddItemToInv(item);
        Debug.Log("Picked up item: " + item.name);

        if (questGiver != null && questGiver.quest != null)
        {
            questGiver.quest.itemsCollected++;
            Debug.Log("Item Collected: " + questGiver.quest.itemsCollected + "/" + questGiver.quest.itemsToCollect);
        }
        else
        {
            Debug.LogError("QuestGiver or quest is not set.");
        }

        Destroy(gameObject);
    }
}

