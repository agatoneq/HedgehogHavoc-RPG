using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]


class Weapon : EquipmentItem
{
    [SerializeField]
    public double DamageValue;
    [SerializeField]
    public bool isTwoHanded =false;
    public Weapon()
    {
        base.EquipmentType = EquipmentSlot.MainHand;
        if (isTwoHanded)
            base.OtherSlotBlock.Add( EquipmentSlot.OffHand);

        ModifierList.Add(new Modifier(StatType.Damage, DamageValue));
    }
}

