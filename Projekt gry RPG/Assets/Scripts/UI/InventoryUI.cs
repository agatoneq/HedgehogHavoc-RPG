using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Player;


public class InventoryUI: MonoBehaviour
{
    Inventory inventory = Player.Instance.Inventory;
    public Transform itemsParent;
    List<InventorySlot> slots;
    private void Start()
    {
        Debug.Log("Inventory ui start");
        inventory.onInventoryChanged+=UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>().ToList();
        Debug.Log("slot count"+slots.Count);
    }
    private void Update()
    {
        
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.Items.Count)
            {
                slots[i]?.AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i]?.ClearSlot();
            }
        }
    }
}

