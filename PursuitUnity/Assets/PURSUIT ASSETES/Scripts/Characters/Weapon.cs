using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefarb;
    public Rigidbody2D playerPrefarb;
    public float move;
    public float firerate;
    float nextfire;
    public int bullets = 32;
    public bool isReloading = false;




    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        if (playerPrefarb.velocity.x == 0 && playerPrefarb.velocity.y == 0 && move == 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        
    }
    void Update()
    {
        if (bullets == 0 && Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (bullets > 0 && !isReloading)
        {
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;
                Instantiate(bulletPrefarb, firePoint.position, firePoint.rotation);
                bullets -= 1;
            }
            
        }

    }

    void IsNotReloading()
    {
        isReloading = false;
    }

    void IsReloading()
    {
        isReloading = true;
    }
    
    void Reload()
    {
        bullets = 32;
    }
}
