using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefarb;
    public Rigidbody2D playerPrefarb;
    public float move;
    public float firerate;
    float nextfire;
    public Weapon pammo;



    public float bullets = 14;
    public float MaxBulets;
    public Image Bar;
    public float BarDamage;



    public bool isReloading = false;

    public GameObject CanvaR;

    void Start()
    {
        MaxBulets = bullets;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        if (playerPrefarb.velocity.x == 0 && playerPrefarb.velocity.y == 0 && move == 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                Bar.fillAmount = Mathf.Clamp(bullets / MaxBulets, 0, 14);
            }
        }

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            CanvaR.SetActive(false);
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
        if (bullets == 0)
        {
            CanvaR.SetActive(true);
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
        bullets = 14;
        Bar.fillAmount = Mathf.Clamp(bullets / MaxBulets, 14, 14);
    }
}