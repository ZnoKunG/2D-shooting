using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossBehaviour : StateMachineBehaviour
{
    private Boss boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.health <= 15)
        {
            animator.SetTrigger("ChangePhase");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
