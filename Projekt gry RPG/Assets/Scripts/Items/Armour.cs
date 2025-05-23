﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Armour")]
class Armour: EquipmentItem
{
    [SerializeField]
    public double ArmourValue;
    public Armour(string name, Sprite icon, bool isDefaultItem, string desc) : base(name, icon, isDefaultItem, desc)
    {
        base.EquipmentType = EquipmentSlot.Armour;

        ModifierList.Add(new Modifier(StatType.Armour, ArmourValue));
    }
    public override List<Modifier> makeMods()
    {
        var list = new List<Modifier>();

        list.Add(new Modifier(StatType.Armour, ArmourValue));
        Debug.Log(name + "dodano mod o wartości " + ArmourValue);
        return list;
    }
}

