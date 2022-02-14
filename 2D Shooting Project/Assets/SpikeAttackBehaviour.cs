using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttackBehaviour : StateMachineBehaviour
{
    public int numOfSpike;
    public float startTimeBtwSpike;
    private float timeBtwSpike;
    public GameObject spike;
    public GameObject spikeParticle;
    private int n;

    private GameObject player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeBtwSpike = startTimeBtwSpike;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (n >= numOfSpike)
        {
            n = 0;
            animator.SetBool("SpikeAttack", false);
        }

        if (timeBtwSpike <= 0)
        {
            Debug.Log("Spawn Spikes");
            n++;
            SpikeSpawn();
            timeBtwSpike = startTimeBtwSpike;
        }
        else
        {
            timeBtwSpike -= Time.deltaTime;
        }
       
    }
    

    
    private void SpikeSpawn()
    {
        Vector3 spawnPos = player.transform.position;
        GameObject spikeObject = Instantiate(spike, spawnPos, Quaternion.identity);
        Destroy(spikeObject, 3f);
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
