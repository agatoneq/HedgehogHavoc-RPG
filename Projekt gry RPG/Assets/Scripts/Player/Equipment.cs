using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public class Equipment
    {
        public event System.Action<EquipmentItem, EquipmentItem> onEquipmentChanged;
        public Dictionary<EquipmentSlot, EquipmentItem> EquipmentSlots { get; private set; } //możliwe że do zmiany w przyszłości
        public Equipment()
        {
            EquipmentSlots= new Dictionary<EquipmentSlot, EquipmentItem>() 
            { 
                {EquipmentSlot.MainHand, null}
                ,{EquipmentSlot.OffHand, null}
                ,{ EquipmentSlot.Armour, null}
            };
        }
        public void ChangeEquipment(EquipmentItem newItem, EquipmentSlot targetSlot)
        {
            //na razie uproszczona wersja
            var oldItem = EquipmentSlots[targetSlot];
            onEquipmentChanged(newItem, oldItem);
        }

    }
}
