using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideProps : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("collide");
    }
}
