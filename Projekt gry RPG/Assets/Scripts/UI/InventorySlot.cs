using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;
    Item item;
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public void ClearSlot() 
    {
        icon.sprite = null;
        icon.enabled = false;
        item = null;
    }
}
