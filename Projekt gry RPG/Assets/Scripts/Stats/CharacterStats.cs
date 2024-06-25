using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Player;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage ;
    public double Damage { get { return damage.getValue(); }}
    public Stat maxhealth ;
    public double MaxHealth { get { return maxhealth.getValue(); } }
    public double currentHealth {get; set;}
    //armor not implemented yet
    public Stat armor ;
    public double Armor { get { return armor.getValue(); } }
    public Stat attackRange;
    public double AttackRange { get { return attackRange.getValue(); } }
    public Stat attackRate ;
    public double AttackRate { get { return attackRate.getValue(); } }
    public Dictionary<StatType,Stat> Stats;

    public CharacterStats()
    {
        Stats = new Dictionary<StatType, Stat>()
        {
            {StatType.AttackRange, attackRange },
            {StatType.AttackRate, attackRate },
            {StatType.Armour, armor },
            {StatType.MaxHealth, maxhealth },
            {StatType.Damage, damage }
        };
    }

    public void TakeDamage(double damage)
    {
        //when armor is implemented 
        /*
         * damage -= armor.getBaseValue();
         * damage = Mathf.Clamp((int)damage, 0, int.MaxValue);
         */

        currentHealth -= damage;
        Debug.Log(transform.name + "takes "+ damage + "damage.");
        Debug.Log(transform.name + "life " + currentHealth / maxhealth.getValue() + ".");
        Hurt();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //to be overwitten
        //dying depends on character
        Debug.Log(transform.name + "died.");

    }
    public virtual void Hurt()
    {
        //to be overwitten
        //depends on character
    }
}
public enum StatType
{
    Damage,
    Armour,
    MaxHealth,
    AttackRange,
    AttackRate
}
