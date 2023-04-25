using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public float bullet;
    public float maxBullet;
    public Image bulletBar;
    public bool NoAmmo;
    public GameObject DisplayMessage;
    



    // Start is called before the first frame update
    void Start()
    {
        maxBullet = bullet;
    }

    // Update is called once per frame
    void Update()
    {
        bulletBar.fillAmount = Mathf.Clamp(bullet / maxBullet, 0, 14);
        if (bullet <= 0 && !NoAmmo)
        {
            NoAmmo = true;
            DisplayMessage.SetActive(true);
        }
    }
}