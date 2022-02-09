using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runBehaviour : StateMachineBehaviour
{
    public float speed;
    public float shootDistance;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Vector3 randomPos;
    private GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(randomPos);
        if (Vector2.Distance(animator.transform.position, randomPos) > 0.2f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, randomPos, speed * Time.deltaTime);
        }
        else
        {
            randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        if (Vector2.Distance(animator.transform.position, player.transform.position) > shootDistance)
        {
            animator.SetBool("isShooting", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
