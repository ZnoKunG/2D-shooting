using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhaseBehaviour : StateMachineBehaviour
{
    private Shake camShake;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        camShake.BossPhase2();
    }

    
}
