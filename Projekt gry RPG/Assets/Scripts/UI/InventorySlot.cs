using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour, IHasToolTip
{
    // Start is called before the first frame update
    public Image icon;
    protected Item item;

    private GameObject ToolDesc;
    TextMeshProUGUI textMeshPro;

    public virtual void Start()
    {
        ToolDesc = GameObject.Find("ToolDesc");

        if(ToolDesc != null) textMeshPro = ToolDesc.GetComponent<TextMeshProUGUI>();
        else Debug.Log("Obiekt opsiu nie znaleziono");
    }

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

    public virtual void Use()
    {
        item?.OnUse();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null) textMeshPro.text = "";
    }

    public void ShowTooltip()
    {        
        if(item != null) textMeshPro.text = item?.GetTooltip();
    }
}
