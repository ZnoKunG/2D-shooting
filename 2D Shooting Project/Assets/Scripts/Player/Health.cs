using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    public float health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    [Header("iFrames")]
    [SerializeField] private float invulnerableTime;
    [SerializeField] private int numOfFlash;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true; //display hearts at a specific number
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health > 0)
        {
            StartCoroutine(Invunerable());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private IEnumerator Invunerable()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        //Invunerable duration and Effect
        for (int i = 0; i < numOfFlash; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invulnerableTime / (numOfFlash * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerableTime / (numOfFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }


}
