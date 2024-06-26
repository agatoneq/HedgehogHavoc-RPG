using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public string Desc  = "Ten przedmiot nic nie robi.";

    public virtual void OnUse()
    {
        Debug.Log("Item: " + name + " used");
    }
    public virtual void OnUse(InventorySlot slot)
    {
        OnUse();
    }
    public virtual string GetTooltip()
    {
        Debug.Log("Item: " + name + " type:"+this.GetType());
        return Desc;
    }
}

