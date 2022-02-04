using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    private Animator anim;
    private CapsuleCollider2D capCollider;
    private Rigidbody2D rb;
    private void Awake()
    {
        capCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        Explode();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Explode()
    {
        anim.SetTrigger("Explode");
        rb.velocity = Vector2.zero;
        capCollider.enabled = false;
        rb.Sleep();
    }
}
