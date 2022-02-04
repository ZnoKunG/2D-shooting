using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInput : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
