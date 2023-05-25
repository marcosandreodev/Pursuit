using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFlashLight : MonoBehaviour
{
    public GameObject flashLigh;
    public PlayerMovement player;
    public WeaponController weaponController;

    public void Start()
    {
        weaponController = GetComponent<WeaponController>();
    }
    public void Update()
    {
        if (player.isFlashLightOn)
        {
            if (weaponController.IsWithHands)
            {
                flashLigh.SetActive(true);
            }
            if (!weaponController.IsWithHands)
            {
                flashLigh.SetActive(false);
            }
        }
        else
        {
            flashLigh.SetActive(false);
        }
    }
}
