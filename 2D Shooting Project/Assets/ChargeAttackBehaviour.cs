using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttackBehaviour : StateMachineBehaviour
{
    public float chargeSpeed;
    public float chargeDelay;
    public float chargeDamage;
    public float chargePeriod;
    private float damageBeforeDash;

    private GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        damageBeforeDash = animator.GetComponent<DamageInput>().damage;
        animator.GetComponent<DamageInput>().damage = chargeDamage;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 chargeDir =  player.transform.position;
        if (chargeDelay <= 0)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, chargeDir, chargeSpeed * Time.deltaTime);
        }
        else
        {
            chargeDelay -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<DamageInput>().damage = damageBeforeDash;
    }
}
