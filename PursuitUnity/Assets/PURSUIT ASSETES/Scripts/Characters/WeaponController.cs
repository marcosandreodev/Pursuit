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
    private Weapon weapon;
    public bool isWithRifle;
    public bool IsWithHands;
    bool changedGun;

    


    //fazer logica para verificar se isHands
    // implementar Animações no Animation Controller de acordo com cada variavel, isWithRifle, IsWithHands

    void Start()
    {
        playerUseRifle = GetComponent<PlayerWithRifle>();
        playerHands = GetComponent<PlayerMovement>();
        weapon = GetComponent<Weapon>();
       
    }

    void Update()
    {
        //enable rifle
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerHands.playerPickedRifle)
        {
            changedGun = true;
            rifle();
        }
        //enable hands
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changedGun = true;
            hands();
            
        }
       
    }

    void firstRifle()
    {
        rifle();
    }

    void rifle()
    {
        playerHands.enabled = false;
        playerUseRifle.enabled = true;
        weapon.enabled = true;


        isWithRifle=true;
        IsWithHands = false;
    }


    void hands()
    {
        playerUseRifle.enabled = false;
        playerHands.enabled = true;
        weapon.enabled = false;
        

        isWithRifle = false;
        IsWithHands = true;
    }
}
