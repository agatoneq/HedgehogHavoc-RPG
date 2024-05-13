using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    EnemyCombat combat;
    
    public float lookRadius = 10f;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<EnemyCombat>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //always face the target
        animator.ResetTrigger("Evil");
        faceTarget();
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) 
        {
            animator.SetTrigger("Evil");
            agent.SetDestination(target.position);
        }

        if (distance <= agent.stoppingDistance)
        {
            //attack the player
            combat.Attack();
        }
    }

    void faceTarget()
    {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
