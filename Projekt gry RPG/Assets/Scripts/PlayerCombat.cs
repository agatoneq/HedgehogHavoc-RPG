using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class PlayerCombat : MonoBehaviour
{
    CharacterStats myStats;

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;


    float attackRange;
    double nextAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
        attackRange = (float)myStats.attackRange.getValue();
    }
    // Update is called once per frame
    void Update()

    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / myStats.attackRate.getValue();
            }

        }
    }
    void Attack()
    {
        //attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, (float) myStats.attackRate.getValue(), enemyLayers);
        
        //damage to enemies
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(myStats.damage.getValue());
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
