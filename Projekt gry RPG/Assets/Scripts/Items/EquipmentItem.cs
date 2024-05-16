using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EquipmentItem : Item
{
    public EquipmentSlot EquipmentType { get; protected set; }
    public List<EquipmentSlot> OtherSlotBlock { get; private set; } = new List<EquipmentSlot>();
    public List<Modifier> ModifierList { get; private set; } = new List<Modifier>();
}
public enum EquipmentSlot
{
    MainHand,
    Armour,
    OffHand
}

