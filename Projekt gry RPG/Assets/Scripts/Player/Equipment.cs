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
            var inventory = Player.Instance.Inventory;
            var oldItem = EquipmentSlots[targetSlot];
            inventory.AddItemToInv(oldItem);    //odłożenie starego item do inv
            if (newItem == null)
            {
                Debug.Log("UnEquip");
                EquipmentSlots[targetSlot] = null;
                UISlots[targetSlot]?.ClearSlot();
            }
            else
            {

                Debug.Log("Equip");
                UISlots[targetSlot]?.AddItem(newItem);
                EquipmentSlots[targetSlot] = newItem;
                inventory.TakeItem(newItem);
            }

            onEquipmentChanged.Invoke(newItem, oldItem);
            Debug.Log("change Compleate");
            return oldItem;
        }
    }
}
