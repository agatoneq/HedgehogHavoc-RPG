using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqInventorySlot : InventorySlot
{
    public EquipmentSlot slotType;

    EqInventorySlot()
    {
    }
    public override void Start()
    {
        base.Start();
        Player.Instance.Equipment.UISlots[slotType] = this;
    }
    public override void Use()
    {
        var a = (EquipmentItem)item;
        a.DeEquip();
    }

}
