using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

public class PlayerStats : CharacterStats
{
    Player player;
    public event System.Action<double, double> OnHealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        armor = player.armor;
        damage = player.damage;
        attackRange = player.attackRange;
        attackRate = player.attackRate;
        maxhealth = player.maxhealth;
        player.Equipment.onEquipmentChanged += EquipmentChanged;
    }

    void EquipmentChanged(EquipmentItem newItem, EquipmentItem oldItem)
    {
        if (newItem != null)
        {
            foreach (var m in newItem.ModifierList)
            {
                Stats[m.AffectedStatType].addModifier(m);
            }
        }
        
        if (oldItem != null)
        {
            foreach (var m in newItem.ModifierList)
            {
                Stats[m.AffectedStatType].removeModifier(m);
            }
        }
    }
    
    //implementacja metody Die()
    //implementacja metody Hurt()
    public override void Hurt()
    {
        base.Hurt();

        //hurt animation
        // animator.SetTrigger("Hurt");
        if (OnHealthChanged != null)
        {
            OnHealthChanged(MaxHealth, currentHealth);
        }
    }
}
