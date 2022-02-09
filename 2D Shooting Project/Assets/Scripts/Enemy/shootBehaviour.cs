using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBehaviour : StateMachineBehaviour
{
    public float retreatDistance;
    public float shootDelay;
    private float timer;

    private EnemyPatrol enemyPatrol;
    private GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyPatrol = animator.GetComponent<EnemyPatrol>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (Vector2.Distance(animator.transform.position, player.transform.position) < retreatDistance)
        {
            animator.SetBool("isShooting", false);
        }
        else
        {
            if (timer <= 0)
            {
                enemyPatrol.ShootProjectile();
                timer = shootDelay;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
