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
    double nextAttackTime = 0;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<EnemyStats>();
        attackRange = (float)myStats.AttackRange;
        animator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.Log("audioManager jest nullem");
        }
    }
    void Update()

    {
        nextAttackTime -= Time.deltaTime;
    }
    public void Attack()
    {
        if (nextAttackTime <= 0)
        {
            //attack animation
            animator.SetTrigger("Attack");

            //detect enemies in range
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            //damage to enemies
            foreach (Collider player in hitPlayer)
            {

                Debug.Log(player);
                Debug.Log(player.name + " was hit");
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    audioManager.PlaySFX(audioManager.playerWasHit); //dziwek uderzenia gracza
                    playerStats.TakeDamage(myStats.Damage);
                }
            }
                nextAttackTime = 1f / myStats.AttackRate;
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
