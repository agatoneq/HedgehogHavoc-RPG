using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/EquipmentItem")]
public class EquipmentItem : Item
{
    public EquipmentSlot EquipmentType { get; protected set; }
    public List<EquipmentSlot> OtherSlotBlock { get; private set; } = new List<EquipmentSlot>();
    public List<Modifier> ModifierList { get; private set; } = new List<Modifier>();

    public override void OnUse(InventorySlot slot)
    {
        Debug.Log("EquipmentItem - try to equip");
        base.OnUse();
        var newItem = Equip();
        if (newItem != null)
            slot.AddItem(newItem);
        else
            slot.ClearSlot();
    }

    public Item Equip()
    {
        return Player.Instance.Equipment.ChangeEquipment(this, EquipmentType);
    }
}
public enum EquipmentSlot
{
    MainHand,
    Armour,
    OffHand
}
