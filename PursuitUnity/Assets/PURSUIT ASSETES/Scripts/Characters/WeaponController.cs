using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WeaponController : MonoBehaviour
{
    private PlayerWithRifle playerUseRifle;
    private PlayerMovement playerHands;
 


    void Start()
    {
        playerUseRifle = GetComponent<PlayerWithRifle>();
        playerHands = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //enable rifle
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            playerUseRifle.enabled = true;
            playerHands.enabled = false;
        }
        //enable hands
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            playerHands.enabled = true;
            playerUseRifle.enabled = false;
        }
    }
}
