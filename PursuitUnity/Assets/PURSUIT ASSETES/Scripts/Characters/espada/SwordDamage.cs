using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float Energy;

    // Start is called before the first frame update
    public int damage = 5;
    public bool isTriggerd;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        isTriggerd=true;
        if(isTriggerd)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Energy -= 1;
            }
        }
    }

}
