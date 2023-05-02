using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWithRifle : MonoBehaviour
{
    private float move;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    private bool jumping;
    private bool running;
    [SerializeField] private float jumpSpeed = 4f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTriggered;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    [SerializeField] private float angleCapsule;
    public LayerMask whatIsGround;
    bool facingRight = true;
    public bool isAtacking = false;
    public bool isReloading = false;

    public GameObject DisplayMessage;


    Rigidbody2D rb;
    SpriteRenderer sprite;
    private Animator animator;
    private string currentAnimation;

    const string PLAYER_IDLE = "IdleMainRifle";
    const string PLAYER_WALK = "WalkRifle";
    const string PLAYER_RUN = "RunningRifle";
    const string PLAYER_JUMPH = "JumpingHRifle";
    const string PLAYER_FALLH = "FallingHRifle";
    const string PLAYER_JUMPV = "JumpingVRifle";
    const string PLAYER_FALLV = "FallingVRifle";
    const string PLAYER_RELOAD = "Reload";
    const string PLAYER_SHOOT = "Shoot";

    public void StopReloading()
    {

        if (Input.GetButton("Fire1"))
        {
            ChangeAnimationState(PLAYER_SHOOT);
        }
        isReloading = false;
        moveSpeed = 2f;
        runSpeed = 5f;

    }

    public void Shooting()
    {
        ChangeAnimationState(PLAYER_SHOOT);
        moveSpeed = 2f;
        runSpeed = 5f;
    }


    public void walking()
    {
        moveSpeed = 2f;
        runSpeed = 5f;
        if (isGrounded && running == false && isReloading == false && isAtacking == false)
        {

            if (rb.velocity.x != 0 && move != 0)
            {
                ChangeAnimationState(PLAYER_WALK);

            }
            else
            {
                if (!isAtacking && !isReloading)
                {
                    ChangeAnimationState(PLAYER_IDLE);
                }
            }
        }
        if (running == true && isReloading == false && isAtacking == false)
        {
            if (isGrounded)
            {

                if (rb.velocity.x != 0 && move != 0)
                {
                    ChangeAnimationState(PLAYER_RUN);
                }

                else
                {
                    if (!isAtacking)
                    {
                        ChangeAnimationState(PLAYER_IDLE);
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

        sizeCapsule = new Vector2(0.13f, -0.04f);
        angleCapsule = -90f;
    }

    // Update is called once per frame
    void Update()
    {
        //Reconhecer o chão

        isGrounded = Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

        move = gameObject.GetComponent<MoveRightOrLeft>().direction;

        //input do pulo do personagem

        if (Input.GetButtonDown("Jump") && ghostJump > 0)
        {
            jumping = true;
        }

        // inverter posição boneco


        if (Input.GetButtonDown("Fire1") && move == 0 && !jumping)

        {
            isAtacking = true;
        }
        if (Input.GetButton("Fire1") && !isReloading && move == 0 && !jumping)
        {
            isAtacking = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isAtacking = false;
        }
        if (isReloading && Input.GetButtonDown("Fire1"))
        {
            isAtacking = false;
        }
        if (isAtacking)
        {         
            Shooting();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            ChangeAnimationState(PLAYER_RELOAD);
            moveSpeed = 0f;
            runSpeed = 0f;
            move = 0;
            isAtacking = false;
        }

        //Animação boneco

        if (isGrounded)
        {
            ghostJump = 0.2f;
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



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(feetPosition.position, sizeCapsule);
    }

    void FixedUpdate()
    {
        if (!isReloading)
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