using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    private Animator anim;
    private CapsuleCollider2D capCollider;
    private Rigidbody2D rb;
    public GameObject explodeEffect;
    public GameObject splashEffect;
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

    private void Explode()
    {
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        GameObject splash = Instantiate(splashEffect, transform.position, transform.rotation);
        Destroy(splash, 4f);
        anim.SetTrigger("Explode");
        rb.velocity = Vector2.zero;
        capCollider.enabled = false;
        rb.Sleep();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
