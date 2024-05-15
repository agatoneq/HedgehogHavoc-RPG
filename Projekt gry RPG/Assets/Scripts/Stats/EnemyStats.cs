using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    Animator animator;

    public event System.Action<double,double> OnHealthChanged;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
    public override void Die()
    {
        base.Die();
        
        //ragdoll efect / death animation
        animator.SetTrigger("IsDead");
        Invoke("DestroyObj", 0.5f);

    }
    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
