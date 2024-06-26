using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
class Weapon : EquipmentItem
{
    [SerializeField]
    public int DamageValue= 10;
    [SerializeField]
    public bool isTwoHanded =false;
    public Weapon(string name, Sprite icon, bool isDefaultItem, string desc) : base(name, icon, isDefaultItem, desc)
    {
        base.EquipmentType = EquipmentSlot.MainHand;
        if (isTwoHanded)
            base.OtherSlotBlock.Add( EquipmentSlot.OffHand);

    }
    public override List<Modifier> makeMods()
    {
        var list = new List<Modifier>();

        list.Add(new Modifier(StatType.Damage, DamageValue));
        Debug.Log(name + "dodano mod o wartości " + DamageValue);
        return list;
    }
}

