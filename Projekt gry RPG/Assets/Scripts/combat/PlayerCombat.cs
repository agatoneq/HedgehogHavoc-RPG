using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]

public class PlayerCombat : MonoBehaviour
{
    CharacterStats myStats;
    Camera cam;

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;


    float attackRange;
    double nextAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        myStats = GetComponent<PlayerStats>();
        attackRange = (float)myStats.AttackRange;
    }
    // Update is called once per frame
    void Update()
    {
        nextAttackTime -= Time.deltaTime;
        if (nextAttackTime <= 0)
        { //Attack() called when player pressed left mouse button
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                    nextAttackTime = 1f / myStats.AttackRate;
                }
        }
    }
    void Attack()
    {
        //attack animation
        animator.SetTrigger("Attack");
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //checking if player is looking at the enemy
        if (Physics.Raycast(ray, out hit, 150))
        {
            if (hit.collider.GetComponent<EnemyStats>()) {
                //detect enemies in range
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

                //deal damage to enemies
                foreach (Collider enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyStats>().TakeDamage(myStats.Damage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
