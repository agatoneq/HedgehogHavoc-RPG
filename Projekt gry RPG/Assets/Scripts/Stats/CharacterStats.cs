using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public double Damage { get { return damage.getValue(); }}
    public Stat maxhealth;
    public double MaxHealth { get { return maxhealth.getValue(); } }
    public double currentHealth {get; private set;}
    //armor not implemented yet
    //public Stat armor;
    public Stat attackRange;
    public double AttackRange { get { return attackRange.getValue(); } }
    public Stat attackRate;
    public double AttackRate { get { return attackRate.getValue(); } }

    private void Awake()
    {
        currentHealth = maxhealth.getValue();
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
