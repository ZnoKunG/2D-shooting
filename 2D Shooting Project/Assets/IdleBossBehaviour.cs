using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossBehaviour : StateMachineBehaviour
{
    private Enemy enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.health <= 15)
        {
            animator.SetTrigger("ChangePhase");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
