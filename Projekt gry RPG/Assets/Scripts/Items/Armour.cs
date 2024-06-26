using System;
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
    public Armour()
    {
        base.EquipmentType = EquipmentSlot.Armour;

        ModifierList.Add(new Modifier(StatType.Armour, ArmourValue));
    }
}

