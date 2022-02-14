using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInput : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
