using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    public GameObject dieEffect;
    private Weapon weapon;

    public float health;
    public int numOfFlash;
    public float invulnerableTime;

    private void Awake()
    {
        weapon = FindObjectOfType<Weapon>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            health -= weapon.damage;
            if (health > 0)
            {
                StartCoroutine(Hurt());
            }
            else
            {
                Die();
            }
        }
    }

    private IEnumerator Hurt()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numOfFlash; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulnerableTime / (numOfFlash * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerableTime / (numOfFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    private void Die()
    {
        GameObject dieAnim = Instantiate(dieEffect, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
        Destroy(dieAnim, 5f);
    }
}
