using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    private Animator anim;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Invoke("Explode", lifeTime);
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}
