using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EquipmentItem : Item
{
    public EquipmentSlot EquipmentType { get; protected set; }
    public List<EquipmentSlot> OtherSlotBlock { get; private set; } = new List<EquipmentSlot>();
    public List<Modifier> ModifierList { get; private set; } = new List<Modifier>();

    public EquipmentItem(string name, Sprite icon, bool isDefaultItem, string desc) : base(name, icon, isDefaultItem, desc)
    {
    }
    public override void OnUse()
    {
        Debug.Log("EquipmentItem - try to equip");
        base.OnUse();
        Equip();
    }

    public Item Equip()
    {
        return Player.Instance.Equipment.ChangeEquipment(this, EquipmentType);
    }
    public void DeEquip()
    {
        Player.Instance.Equipment.ChangeEquipment(null, EquipmentType);

    }
}
public enum EquipmentSlot
{
    MainHand,
    Armour,
    OffHand
}
