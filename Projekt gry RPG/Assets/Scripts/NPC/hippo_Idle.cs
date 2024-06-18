using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hippo_Idle : StateMachineBehaviour
{
    [SerializeField]
    private float timeUntilMoto;
    private int numberOfAnimations = 2;

    private bool isMoto;

    private float standingTime;
    private int motoAnimation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        resetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(isMoto == false)
        {
            standingTime += Time.deltaTime;

            if (standingTime > timeUntilMoto && stateInfo.normalizedTime % 1 < 0.02f)
            {
                isMoto = true;
                motoAnimation = Random.Range(1, numberOfAnimations+1);
                motoAnimation = motoAnimation * 2 - 1;

                animator.SetFloat("index", motoAnimation - 1);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            resetIdle();
        }

        animator.SetFloat("index", motoAnimation, 0.02f, Time.deltaTime);
    }
    private void resetIdle()
    {
        if (isMoto)
        {
            motoAnimation--;
        }
        isMoto = false;
        standingTime = 0;

        
    }
}
