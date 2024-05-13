using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class EnemyCombat : MonoBehaviour
{
    CharacterStats myStats;

    Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    float attackRange;

    float nextAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
        attackRange = (float)myStats.attackRange.getValue();
        animator = GetComponent<Animator>();
    }
    public void Attack()
    {
        //attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //damage to enemies
        foreach (Collider player in hitPlayer)
        {
            Debug.Log(player.name + "was hit");
            player.GetComponent<PlayerStats>().TakeDamage(myStats.damage.getValue());
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
