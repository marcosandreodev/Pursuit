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



    public float bullets = 10;
    public float MaxBulets;
    public Image Bar;
    public float BarDamage;

    public GameObject fireLight;

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
                Bar.fillAmount = Mathf.Clamp(bullets / MaxBulets, 0, 10);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                fireLight.SetActive(false);
            }
        }

    }
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            fireLight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            fireLight.SetActive(false);
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
                fireLight.SetActive(true);
                bullets -= 1;
            }
        }
        if (bullets == 0)
        {
            Bar.fillAmount = Mathf.Clamp(bullets / MaxBulets, 0, 0);
            fireLight.SetActive(false);
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
        bullets = 10;
        MaxBulets = bullets;
        Bar.fillAmount = Mathf.Clamp(bullets / MaxBulets, 10, 10);
    }
}