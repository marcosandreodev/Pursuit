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
    private PlayerWithSword playerUseSword;
    private Weapon weapon;
    public bool isWithRifle;
    public bool IsWithHands;
    public bool isWithSword;
    bool changedGun;
    public Image Swap;
    [SerializeField] private GameObject Bar;
    [SerializeField] private GameObject ShadowBar;
    [SerializeField] private GameObject AMmoBar;
    [SerializeField] private GameObject AmmoIcon;

    [SerializeField] private GameObject BarE;
    [SerializeField] private GameObject ShadowBarE;
    [SerializeField] private GameObject EnergyBar;
    [SerializeField] private GameObject EnergyIcon;
    private Animator animator;
    private string currentAnimation;

    const string PLAYER_IDLE_SWORD = "ChangeToSword";
    const string PLAYER_IDLE_HANDS = "IdleMain";
    const string PLAYER_IDLE_RIFLE = "IdleMainRifle";


    //fazer logica para verificar se isHands
    // implementar Animações no Animation Controller de acordo com cada variavel, isWithRifle, IsWithHands

    void Start()
    {
        playerUseRifle = GetComponent<PlayerWithRifle>();
        playerHands = GetComponent<PlayerMovement>();
        playerUseSword = GetComponent<PlayerWithSword>();
        animator = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
       
    }

    void Update()
    {
        //enable sword
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeAnimationState(PLAYER_IDLE_SWORD);
            changedGun = true;
            Sword();

            Swap.sprite = Resources.Load<Sprite>("CH/SwapEspada");
            Bar.SetActive(false);
            ShadowBar.SetActive(false);
            AMmoBar.SetActive(false);
            AmmoIcon.SetActive(false);
           
            BarE.SetActive(true);
            ShadowBarE.SetActive(true);
            EnergyBar.SetActive(true);
            EnergyIcon.SetActive(true);
        }

        //enable rifle
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerHands.playerPickedRifle)
        {
            ChangeAnimationState(PLAYER_IDLE_RIFLE);
            changedGun = true;
            rifle();

            Swap.sprite = Resources.Load<Sprite>("CH/SwapRifle");
            Bar.SetActive(true);
            ShadowBar.SetActive(true);
            AMmoBar.SetActive(true);
            AmmoIcon.SetActive(true);

            BarE.SetActive(false);
            ShadowBarE.SetActive(false);
            EnergyBar.SetActive(false);
            EnergyIcon.SetActive(false);
        }

        //enable hands
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAnimationState(PLAYER_IDLE_HANDS);
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
        isWithSword = false;
    }


    void hands()
    {
        playerUseRifle.enabled = false;
        playerHands.enabled = true;
        weapon.enabled = false;


        isWithRifle = false;
        IsWithHands = true;
        isWithSword = false;
    }
    void Sword()
    {
        playerHands.enabled = false;
        playerUseRifle.enabled = false;
        playerUseSword.enabled = true;
        weapon.enabled = false;


        isWithSword = true;
        isWithRifle = false;
        IsWithHands = false;
    }


    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
