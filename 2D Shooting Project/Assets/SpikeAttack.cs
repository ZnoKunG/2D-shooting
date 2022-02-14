using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public void SpikeColliderTrigger()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
