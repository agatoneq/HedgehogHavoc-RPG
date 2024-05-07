using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }
    void Attack()
    {
        //attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        
        //damage to enemies
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log(enemy.name + "was hit");
            enemy.GetComponent<EnemyCombat>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //hurt animation
       // animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Player died");
        
        //die animation
        //animator.SetBool("IsDead", true);
    }
}
