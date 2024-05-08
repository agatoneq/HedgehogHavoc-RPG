using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat maxhealth;
    public double currentHealth {get; private set;}
    //armor not implemented yet
    //public Stat armor;
    public Stat attackRange;
    public Stat attackRate;
    private double nextAttackTime = 0;

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
        //hurt animation
        // animator.SetTrigger("Hurt");

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

        //die animation
        // animator.SetBool("IsDead", true);

    }

}
