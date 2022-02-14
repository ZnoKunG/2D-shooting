using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Behaviour : StateMachineBehaviour
{
    private GameObject player;
    private DamageInput damage;
    private Boss boss;
    private RandomSpawner spawner;
    private int rand;

    public int buffDamage = 5;
    public float minimumDistance;
    public float followSpeed;
    private float startIdleTime;
    private float idleTime;
    public float maxTime;
    public float minTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = animator.GetComponent<Boss>();
        damage = animator.GetComponent<DamageInput>();
        spawner = GameObject.FindGameObjectWithTag("RandomSpawner").GetComponent<RandomSpawner>();
        spawner.enabled = false;
        damage.damage = buffDamage;
        startIdleTime = Random.Range(minTime, maxTime);
        rand = Random.Range(0, 2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, player.transform.position) > minimumDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

        if (boss.health <= 0)
        {
            boss.BossDie();
        }
        // Random number to choose skills
        //SKills : Meteor, Spike, Dash

        if (rand == 0)
        {

            if (startIdleTime <= 0)
            {
                animator.SetBool("SpikeAttack", true);
            }
            else
            {
                startIdleTime -= Time.deltaTime;
            }
        }
        else
        {
            animator.SetTrigger("Charge");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
