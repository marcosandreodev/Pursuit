using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeSword : SwordDamage, ISword
{
    // Start is called before the first frame update

    private GameObject swordRange;
    void Start()
    {
       
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            swordRange.SetActive(true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            swordRange.SetActive(false);
        }
    }
    
}
