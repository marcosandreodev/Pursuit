using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefarb;
    public Rigidbody2D playerPrefarb;
    public float move;
   

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        if (playerPrefarb.velocity.x == 0 && playerPrefarb.velocity.y == 0 && move == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefarb, firePoint.position, firePoint.rotation);
    }
}
