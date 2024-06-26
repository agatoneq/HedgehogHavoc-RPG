using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Equipment
    {
        public event System.Action<EquipmentItem, EquipmentItem> onEquipmentChanged;
        public Dictionary<EquipmentSlot, EquipmentItem> EquipmentSlots { get; private set; }
        public Dictionary<EquipmentSlot, EqInventorySlot> UISlots { get; private set; } //możliwe że do zmiany w przyszłości
        public Equipment()
        {
            UISlots = new Dictionary<EquipmentSlot, EqInventorySlot>();
            EquipmentSlots = new Dictionary<EquipmentSlot, EquipmentItem>() 
            { 
                {EquipmentSlot.MainHand, null}
                ,{EquipmentSlot.OffHand, null}
                ,{ EquipmentSlot.Armour, null}
            };
        }
        public Item ChangeEquipment(EquipmentItem newItem, EquipmentSlot targetSlot)
        {
            //na razie uproszczona wersja
            var oldItem = EquipmentSlots[targetSlot];
            UISlots[targetSlot]?.AddItem(newItem);
            Debug.Log("change Started");
            EquipmentSlots[targetSlot] = newItem;
            Debug.Log("change Started");

            //onEquipmentChanged(newItem, oldItem);
            Debug.Log("change Compleate");
            return oldItem;
        }
        
    }
}
