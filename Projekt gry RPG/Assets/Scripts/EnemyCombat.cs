using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    //dodanie atakowania gracza przez przeciwnika
    void Update()
    {
        //ustalenie czêstotliwoœci ataków
        //wywo³anie funkcji Attack po podejœciu do gracza
            Attack();

    }
    void Attack()
    {
        //attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //damage to enemies
        foreach (Collider player in hitPlayer)
        {
            Debug.Log(player.name + "was hit");
            player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died");

        //die animation
        animator.SetBool("IsDead", true);

        //disable enemy
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}
