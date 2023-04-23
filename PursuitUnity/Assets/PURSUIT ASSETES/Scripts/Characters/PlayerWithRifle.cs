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
    [SerializeField] private float jumpSpeed = 7f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTriggered;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    [SerializeField] private float angleCapsule;
    public LayerMask whatIsGround;
    bool facingRight = true;
    bool isShooting = false;
    bool isReloading =false;

    public GameObject DisplayMessage;


    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;

    public void StopReloading()
    {
        animationPlayer.SetBool("Reloading", false);
        moveSpeed = 2f;
        runSpeed = 5f;
    }

    public void Shooting()
    {
        moveSpeed = 2f;
        runSpeed = 5f;
        animationPlayer.SetBool("Running", false);
        animationPlayer.SetBool("Walking", false);
        animationPlayer.SetBool("JumpingV", false);
        animationPlayer.SetBool("JumpingH", false);
        animationPlayer.SetBool("FallingV", false);
        animationPlayer.SetBool("FallingH", false);
        animationPlayer.SetBool("Shooting", true);     
    }

    public void walking()
    {
        moveSpeed = 2f;
        runSpeed = 5f;
        if (isGrounded && running == false)
        {
            animationPlayer.SetBool("Running", false);
            animationPlayer.SetBool("Walking", false);
            animationPlayer.SetBool("JumpingV", false);
            animationPlayer.SetBool("JumpingH", false);
            animationPlayer.SetBool("FallingV", false);
            animationPlayer.SetBool("FallingH", false);
            


            if (rb.velocity.x != 0 && move != 0)
            {
                animationPlayer.SetBool("Walking", true);
                animationPlayer.SetBool("Shooting", false);

            }
            else
            {
                animationPlayer.SetBool("Walking", false);
            }
        }
        if (running == true)
        {
            if (isGrounded)
            {
                animationPlayer.SetBool("Running", false);
                animationPlayer.SetBool("Walking", false);
                animationPlayer.SetBool("JumpingV", false);
                animationPlayer.SetBool("JumpingH", false);
                animationPlayer.SetBool("FallingV", false);
                animationPlayer.SetBool("FallingH", false);
                


                if (rb.velocity.x != 0 && move != 0)
                {
                    animationPlayer.SetBool("Running", true);
                }
                
                else
                {
                    animationPlayer.SetBool("Running", false);
                    animationPlayer.SetBool("Walking", false);
                }
            }
        }
    }

    public void jump()
    {
        if (rb.velocity.x == 0)
        {
            animationPlayer.SetBool("Walking", false);
            animationPlayer.SetBool("Shooting", false);

            if (rb.velocity.y > 0)
            {
                animationPlayer.SetBool("JumpingV", true);
                animationPlayer.SetBool("JumpingH", false);
                animationPlayer.SetBool("FallingV", false);
                animationPlayer.SetBool("FallingH", false);
                animationPlayer.SetBool("Shooting", false);
            }
            if (rb.velocity.y < 0)
            {
                animationPlayer.SetBool("JumpingV", false);
                animationPlayer.SetBool("JumpingH", false);
                animationPlayer.SetBool("FallingV", true);
                animationPlayer.SetBool("FallingH", false);
                animationPlayer.SetBool("Shooting", false);
            }
        }
        else
        {
            if (rb.velocity.y > 0 && rb.velocity.x != 0)
            {
                animationPlayer.SetBool("JumpingV", false);
                animationPlayer.SetBool("JumpingH", true);
                animationPlayer.SetBool("FallingV", false);
                animationPlayer.SetBool("FallingH", false);
                animationPlayer.SetBool("Shooting", false);
            }
            if (rb.velocity.y < 0)
            {
                animationPlayer.SetBool("JumpingV", false);
                animationPlayer.SetBool("JumpingH", false);
                animationPlayer.SetBool("FallingV", false);
                animationPlayer.SetBool("FallingH", true);

            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animationPlayer = GetComponent<Animator>();

        sizeCapsule = new Vector2(0.13f, -0.04f);
        angleCapsule = -90f;


    }

    // Update is called once per frame
    void Update()
    {
        //Reconhecer o chão

        isGrounded= Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

        move = Input.GetAxis("Horizontal");

        //input do pulo do personagem

        if (Input.GetButtonDown("Jump") && ghostJump >0)
        {
            jumping=true; 
        }

        // inverter posição boneco
        if (move < 0 && facingRight)
        {
            flip();
        }
        else if (move > 0 && !facingRight)
        {
            flip();
        }


        if (Input.GetButtonDown("Fire1"))
        {
            isShooting=true;
            
        }
        if (Input.GetButton("Fire1") && isReloading)
        {
            animationPlayer.SetBool("Shooting", true);
        }

            if (Input.GetButtonUp("Fire1"))
        {
            animationPlayer.SetBool("Shooting", false);
            isShooting = false;  
        }
        if (isShooting)
        {
            Shooting();
        }
        if (Input.GetKeyDown(KeyCode.R)){
            isReloading = true;
            animationPlayer.SetBool("Reloading", true);
            moveSpeed = 0f;
            runSpeed = 0f;
            animationPlayer.SetBool("Shooting", false);
            isShooting = false;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            isReloading = false;
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

    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(feetPosition.position, sizeCapsule);
    }

    void FixedUpdate()
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
