using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private Animator animator;
    private string currentAnimation;

    public float move;
    [SerializeField] private bool rifleBool = false;
    [SerializeField] private Transform rifle;
    [SerializeField] private GameObject PlayerRifle;
    private PlayerWithRifle playerUseRifle;
    private PlayerMovement playerHands;

    private float moveSpeed = 10f;
    private float runSpeed = 25f;
    private bool jumping;
    private bool running;
    private float jumpSpeed = 13f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTriggered;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    [SerializeField] private float angleCapsule;
    public LayerMask whatIsGround;

    public GameObject DisplayMessage;

    public bool playerPickedRifle = false;

    public Image Swap;
    [SerializeField] private GameObject Bar;
    [SerializeField] private GameObject ShadowBar;
    [SerializeField] private GameObject AMmoBar;
    [SerializeField] private GameObject AmmoIcon;

    Rigidbody2D rb;
    private SpriteRenderer sprite;
    public bool isFlashLightOn = false;
    public Vector2 posInicial;

    string PLAYER_IDLE = "IdleMain";
    string PLAYER_WALK = "Walk";
    string PLAYER_RUN = "Running";
    string PLAYER_JUMPH = "JumpingH";
    string PLAYER_FALLH = "FallingH";
    string PLAYER_JUMPV = "JumpingV";
    string PLAYER_FALLV = "FallingV";

    string PLAYER_IDLES = "IdleMainS";
    string PLAYER_WALKS = "WalkS";
    string PLAYER_RUNS = "RunningS";
    string PLAYER_JUMPHS = "JumpingHS";
    string PLAYER_FALLHS = "FallingHS";
    string PLAYER_JUMPVS = "JumpingVS";
    string PLAYER_FALLVS = "FallingVS";



    public void walking()
    {
        if (isGrounded && running == false)
        {

            if (rb.velocity.x != 0 && move != 0)
            {
                if(isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_WALKS);
                }
                if (!isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_WALK);
                }
            }
            else
            {
                if (isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_IDLES);
                }
                if (!isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_IDLE);
                }
            }
        }
        if (running == true)
        {
            if (isGrounded)
            {

                if (rb.velocity.x != 0 && move != 0)
                {
                    if (isFlashLightOn)
                    {
                        ChangeAnimationState(PLAYER_RUNS);
                    }
                    if (!isFlashLightOn)
                    {
                        ChangeAnimationState(PLAYER_RUN);
                    }
                }

                else
                {
                    if (isFlashLightOn)
                    {
                        ChangeAnimationState(PLAYER_IDLES);
                    }
                    if (!isFlashLightOn)
                    {
                        ChangeAnimationState(PLAYER_IDLES);
                    }
                }
            }
        }
    }



    public void jump()
    {
        if (rb.velocity.x == 0)
        {
            //Pulo Vertical
            if (rb.velocity.y > 0)
            {
                if (isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_JUMPVS);
                }
                if (!isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_JUMPV);
                }
            }
            //Queda Vertical
            if (rb.velocity.y < 0)
            {
                if (isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_FALLVS);
                }
                if (!isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_FALLV);
                }
            }
        }
        else
        {
            //Pulo Horizontal
            if (rb.velocity.y > 0 && rb.velocity.x != 0)
            {
                if (isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_JUMPHS);
                }
                if (!isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_JUMPH);
                }
            }
            //Queda Horizontal
            if (rb.velocity.y < 0)
            {
                if (isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_FALLHS);
                }
                if (!isFlashLightOn)
                {
                    ChangeAnimationState(PLAYER_FALLH);
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sizeCapsule = new Vector2(0.4f, 0.12f);
        angleCapsule = -90f;

    }

    public void FlashLightBlocked()
    {
        isFlashLightOn= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))        {
            if (isFlashLightOn)
            {
               isFlashLightOn = false;
            }
            else
            {
                isFlashLightOn = true;
            }
        }

        if (rifleBool == false)
        {
            //Reconhecer o chão

            isGrounded = Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

            move = gameObject.GetComponent<MoveRightOrLeft>().direction;

            //animação idle



            //input do pulo do personagem

            if (Input.GetButtonDown("Jump") && ghostJump > 0)
            {
                jumping = true;
            }

            // inverter posição boneco

            //Animação boneco

            if (isGrounded)
            {

                ghostJump = 0.1f;
                walking();
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    running = true;

                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    running = false;
                }

            }
            else
            {
                ghostJump -= Time.deltaTime;
                if (ghostJump <= 0)
                {
                    ghostJump = 0;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift) && rb.velocity.y == 0)
                {
                    running = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift) && rb.velocity.y != 0)
                {
                    running = false;
                }
                jump();
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(feetPosition.position, sizeCapsule);
    }

    void FixedUpdate()
    {
        if (rifleBool == false)
        {
            //andar
            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
            //pulo

            if (running)
            {
                rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
            }

            if (jumping)
            {
                rb.velocity = Vector2.up * jumpSpeed;

                jumping = false;

            }
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}