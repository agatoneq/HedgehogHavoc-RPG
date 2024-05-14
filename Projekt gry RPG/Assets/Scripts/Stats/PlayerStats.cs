using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

public class PlayerStats : CharacterStats
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        foreach (var i in player.Equipment)
        {
            //players stats change based on equipment
        }
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
