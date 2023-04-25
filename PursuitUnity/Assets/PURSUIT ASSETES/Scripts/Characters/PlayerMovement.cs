using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

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

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    private bool jumping;
    private bool running;
    [SerializeField] private float jumpSpeed = 7f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTriggered;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    [SerializeField] private float angleCapsule;
    public LayerMask whatIsGround;

    public GameObject DisplayMessage;

    public bool playerPickedRifle = false;



    Rigidbody2D rb;
    SpriteRenderer sprite;


    const string PLAYER_IDLE = "IdleMain";
    const string PLAYER_WALK = "Walk";
    const string PLAYER_RUN = "Running";
    const string PLAYER_JUMPH = "JumpingH";
    const string PLAYER_FALLH = "FallingH";
    const string PLAYER_JUMPV = "JumpingV";
    const string PLAYER_FALLV = "FallingV";
    const string PLAYER_PICKR = "PickRifle";



    public void walking()
    {
        moveSpeed = 2f;
        runSpeed = 5f;
        if (isGrounded && running == false)
        {

            if (rb.velocity.x != 0 && move != 0)
            {
                ChangeAnimationState(PLAYER_WALK);

            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }
        if (running == true)
        {
            if (isGrounded)
            {

                if (rb.velocity.x != 0 && move != 0)
                {
                    ChangeAnimationState(PLAYER_RUN);
                }

                else
                {
                    ChangeAnimationState(PLAYER_IDLE);
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
                ChangeAnimationState(PLAYER_JUMPV);
            }
            //Queda Vertical
            if (rb.velocity.y < 0)
            {
                ChangeAnimationState(PLAYER_FALLV);
            }
        }
        else
        {
            //Pulo Horizontal
            if (rb.velocity.y > 0 && rb.velocity.x != 0)
            {
                ChangeAnimationState(PLAYER_JUMPH);
            }
            //Queda Horizontal
            if (rb.velocity.y < 0)
            {
                ChangeAnimationState(PLAYER_FALLH);

            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sizeCapsule = new Vector2(0.13f, -0.01f);
        angleCapsule = -90f;


    }

    // Update is called once per frame
    void Update()
    {
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
        if (isTriggered == true)
        {
            DisplayMessage.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                rifleBool = true;
                ChangeAnimationState(PLAYER_PICKR);
                move = 0;
                rb.velocity = new Vector2(0, 0);
                transform.rotation = rifle.rotation;
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
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Rifle" && isGrounded)
        {
            isTriggered = true;
        }
        else
        {
            isTriggered = false;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Rifle" && isGrounded)
        {
            isTriggered = false;
        }
    }

    void DestroyRifle()
    {
        Destroy(rifle.gameObject);
    }

    void PlayerPickedRifle()
    {
        rifleBool = false;
        playerPickedRifle = true;
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

}