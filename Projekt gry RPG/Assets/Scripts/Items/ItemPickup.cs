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
        QuestGiver[] allQuestGivers = FindObjectsOfType<QuestGiver>();
        foreach (QuestGiver qg in allQuestGivers)
        {
            if (qg.questGiverId == 0)
            {
                questGiver = qg;
                break;
            }
        }

        if (questGiver != null)
        {
            Debug.Log("Znaleziono QuestGiver z ID: 0");
        }
        else
        {
            Debug.Log("Nie znaleziono QuestGiver z ID: 0");
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

            if(Player.Instance.quest.id == 0)
            {
                questGiver.quest.itemsCollected++;
                Debug.Log("Item Collected: " + questGiver.quest.itemsCollected + "/" + questGiver.quest.itemsToCollect);
                if (questGiver.quest.itemsCollected == questGiver.quest.itemsToCollect)
                {
                    questGiver.finishQuest();
                }
            }

        }
        else
        {
            Debug.LogError("QuestGiver or quest is not set.");
        }

        Destroy(gameObject);
    }
}

