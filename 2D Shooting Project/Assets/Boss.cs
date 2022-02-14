using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    public GameObject dieEffect;
    private Weapon weapon;
    public GameObject dieParticle;
    private Shake shake;
    private UltiManager ultiManager;
    private ScoreManager scoreManager;
    private LevelLoader transition;
    public Slider healthbar;

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
        transition = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
    }

    
    private void Update()
    {
        healthbar.value = health;
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
    public void BossDie()
    {
        GameObject dieAnim = Instantiate(dieEffect, transform.position, dieEffect.transform.rotation);
        Destroy(dieAnim, 5f);
        Instantiate(dieParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        transition.LoadNextLevel();
    }
}
