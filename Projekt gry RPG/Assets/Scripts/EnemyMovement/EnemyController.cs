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
        //starting the Evil animation
        animator.ResetTrigger("Evil");
        //always face the target
        faceTarget();
        //distance between enemy and player
        float distance = Vector3.Distance(target.position, transform.position);
        //if smaller then lookRadius enemy moves towards player
        if (distance <= lookRadius) 
        {
            animator.SetTrigger("Evil");
            agent.SetDestination(target.position);
        }
        //enemy attacks when it's standing near player
        if (distance <= agent.stoppingDistance)
        {
            //attack the player
            combat.Attack();
        }
    }

    void faceTarget()
    {
            //getting player position
            Vector3 direction = (target.position - transform.position).normalized;
            //rotating enemy towards player
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, 0, -direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
