using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float shotSpeed;
    public float retreatSpeed;
    public float minimumDistance;
    public float followDistance;
    public float shootDelay;
    private float timer;

    public GameObject projectile;
    private GameObject player;
    private Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < minimumDistance)
        {
            anim.SetBool("isPatrolling", true); 
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -retreatSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isPatrolling", false);
        }

        if (Vector2.Distance(transform.position, player.transform.position) > followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, retreatSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isPatrolling", false);
        }
        if (timer <= 0)
        {
            ShootProjectile();
            timer = shootDelay;
        }
        else
        {
            timer -= Time.deltaTime;
        }


    }
    public void ShootProjectile()
    {
        anim.SetBool("isShooting", true);
        GameObject shotRight = Instantiate(projectile, transform.position + new Vector3(1f, 0, 0), Quaternion.identity);
        shotRight.GetComponent<Rigidbody2D>().AddForce(shotSpeed * transform.right, ForceMode2D.Impulse);
        GameObject shotLeft = Instantiate(projectile, transform.position + new Vector3(-1f, 0, 0), Quaternion.identity);
        shotLeft.GetComponent<Rigidbody2D>().AddForce(-shotSpeed * transform.right, ForceMode2D.Impulse);
        GameObject shotUp = Instantiate(projectile, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        shotUp.GetComponent<Rigidbody2D>().AddForce(shotSpeed * transform.up, ForceMode2D.Impulse);
        GameObject shotDown = Instantiate(projectile, transform.position + new Vector3(0, -1f, 0), Quaternion.identity);
        shotDown.GetComponent<Rigidbody2D>().AddForce(-shotSpeed * transform.up, ForceMode2D.Impulse);
        Destroy(shotRight, 3f);
        Destroy(shotLeft, 3f);
        Destroy(shotUp, 3f);
        Destroy(shotDown, 3f);
        anim.SetBool("isShooting", false);
    }
}
