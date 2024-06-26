using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqInventorySlot : InventorySlot
{
    public EquipmentSlot slotType= EquipmentSlot.MainHand;

    EqInventorySlot()
    {
        Player.Instance.Equipment.UISlots[slotType] = this;
    }

}
