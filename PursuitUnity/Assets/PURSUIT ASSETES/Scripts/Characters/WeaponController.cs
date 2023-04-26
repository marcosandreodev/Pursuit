using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    private PlayerWithRifle playerUseRifle;
    private PlayerMovement playerHands;
    private Weapon weapon;
    public bool isWithRifle;
    public bool IsWithHands;
    bool changedGun;
    public Image Swap;
    [SerializeField] private GameObject Bar;
    [SerializeField] private GameObject ShadowBar;
    [SerializeField] private GameObject AMmoBar;
    [SerializeField] private GameObject AmmoIcon;




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

            Swap.sprite = Resources.Load<Sprite>("CH/SwapRifle");
            Bar.SetActive(true);
            ShadowBar.SetActive(true);
            AMmoBar.SetActive(true);
            AmmoIcon.SetActive(true);
        }
        //enable hands
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changedGun = true;
            hands();

            Swap.sprite = Resources.Load<Sprite>("CH/SwapMão");
            Bar.SetActive(false);
            ShadowBar.SetActive(false);
            AMmoBar.SetActive(false);
            AmmoIcon.SetActive(false);
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


        isWithRifle = true;
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