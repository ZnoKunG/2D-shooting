using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    public GameObject dieEffect;
    private Weapon weapon;
    public GameObject effect;
    private Shake shake;
    private UltiManager ultiManager;
    private ScoreManager scoreManager;

    public float health;
    public int numOfFlash;
    public float invulnerableTime;
    public Color hurtColor;

    private void Awake()
    {
        weapon = FindObjectOfType<Weapon>();
        spriteRend = GetComponent<SpriteRenderer>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        ultiManager = GameObject.FindGameObjectWithTag("UltiManager").GetComponent<UltiManager>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            health -= weapon.damage;
            if (health > 0)
            {
                shake.CamShake();
                StartCoroutine(Hurt());
            }
            else
            {
                Debug.Log(scoreManager.totalScore);
                scoreManager.totalScore++;
                if (!ultiManager.ultiActive)
                {
                    ultiManager.ultiGage++;
                }
                shake.CamKill();
                Die();
            }
        }
    }

    private IEnumerator Hurt()
    {
        //vulnerable period
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numOfFlash; i++)
        {
            spriteRend.color = hurtColor;
            yield return new WaitForSeconds(invulnerableTime / (numOfFlash * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerableTime / (numOfFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    public void Die()
    {
        GameObject dieAnim = Instantiate(dieEffect, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), Quaternion.identity);
        Destroy(dieAnim, 5f);
        Instantiate(effect, transform.position, effect.transform.rotation);
        Destroy(gameObject);
    }
}
