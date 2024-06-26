using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IHasToolTip
{
    // Start is called before the first frame update
    public Image icon;
    Item item;
    public void AddItem (Item newItem)
    {
        item = newItem;
        Debug.Log("InventorySlot - item added: "+ item);
        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        Debug.Log("InventorySlot cleared");
        icon.sprite = null;
        icon.enabled = false;
        item = null;
    }

    public void Use()
    {
        item?.OnUse(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void ShowTooltip()
    {        
        item?.GetTooltip();
    }
}
