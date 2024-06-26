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

    public Item(string name, Sprite icon, bool isDefaultItem, string desc)
    {
        this.name = name;
        this.icon = icon;
        this.isDefaultItem = isDefaultItem;
        this.Desc = desc;
    }
    public virtual void OnUse()
    {
        Debug.Log("Item: " + name + " used");
    }
    public virtual string GetTooltip()
    {
        Debug.Log("Item: " + name + " type:"+this.GetType());
        return Desc;
    }
}

