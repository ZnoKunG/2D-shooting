using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject projectile;
    public Transform shotPoint;
    public GameObject shotEffect;
 
    public float shotPower;
    public float damage;
    private float shotTime;
    public float startTimebtwShots;
    [SerializeField] private float offset;
    private void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (shotTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                Instantiate(shotEffect, shotPoint.position, shotPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shotPoint.up * shotPower, ForceMode2D.Impulse);
                
                shotTime = startTimebtwShots;
            }
        }
        else
        {
            shotTime -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - transform.position; //get vector point from one to another point
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + offset; // we need angle = arctan(y/x) so we put lookDir.y first
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
