using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        //players stats change based on equipment
        //EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }

    //when equipment is implemented
    //changing current player's items
    /*void onEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.addModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
         }
        
        if (oldItem != null)
        {
            armor.removeModifier(newItem.armorModifier);
            damage.removeModifier(newItem.damageModifier);
         }
    }
    */
    //implementacja metody Die()
    //implementacja metody Hurt()
}
