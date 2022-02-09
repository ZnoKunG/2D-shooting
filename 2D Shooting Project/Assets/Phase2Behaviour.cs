using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Behaviour : StateMachineBehaviour
{
    private GameObject player;
    private LevelLoader transition;
    private Enemy boss;
    private RandomSpawner spawner;
    public float minimumDistance;
    public float followSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = animator.GetComponent<Enemy>();
        transition = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        spawner = GameObject.FindGameObjectWithTag("RandomSpawner").GetComponent<RandomSpawner>();
        spawner.enabled = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, player.transform.position) > minimumDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }

        if (boss.health <= 0)
        {
            transition.LoadNextLevel();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
