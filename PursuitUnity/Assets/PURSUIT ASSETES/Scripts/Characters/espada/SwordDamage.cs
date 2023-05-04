using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class SwordDamage : MonoBehaviour
{
    public Image BarE;
    public float ActualEnergy;
    public float MaxEnergy = 4;

    // Start is called before the first frame update
    public int damage = 5;
    public bool isTriggerd;

    private void Start()
    {
        ActualEnergy = MaxEnergy;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        isTriggerd=true;
        if(isTriggerd == true)
        {
            Enemy enemy = coll.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                BarE.fillAmount = Mathf.Clamp(ActualEnergy / MaxEnergy, 0, 4);
                ActualEnergy -= 2;
            }
        }
    }

}
