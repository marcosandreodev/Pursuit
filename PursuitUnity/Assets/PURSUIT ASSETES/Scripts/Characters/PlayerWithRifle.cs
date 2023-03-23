using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWithRifle : MonoBehaviour
{
    private float move;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 9f;
    private bool jumping;
    private bool running;
    [SerializeField] private float jumpSpeed = 20f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isTriggered;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    [SerializeField] private float angleCapsule;
    public LayerMask whatIsGround;

    public GameObject DisplayMessage;


    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;


    public void walking()
    {
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

            if (rb.velocity.y > 0)
            {
                animationPlayer.SetBool("JumpingV", true);
                animationPlayer.SetBool("JumpingH", false);
                animationPlayer.SetBool("FallingV", false);
                animationPlayer.SetBool("FallingH", false);
            }
            if (rb.velocity.y < 0)
            {
                animationPlayer.SetBool("JumpingV", false);
                animationPlayer.SetBool("JumpingH", false);
                animationPlayer.SetBool("FallingV", true);
                animationPlayer.SetBool("FallingH", false);
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

        sizeCapsule = new Vector2(0.42f, 0.3f);
        angleCapsule = -90f;
    }

    // Update is called once per frame
    void Update()
    {
        //Reconhecer o ch�o

        isGrounded= Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

        move = Input.GetAxis("Horizontal");

        //input do pulo do personagem

        if (Input.GetButtonDown("Jump") && ghostJump >0)
        {
            jumping=true; 
        }

        // inverter posi��o boneco
        if(move < 0)
        {
            sprite.flipX= true;
        }
        else if(move > 0)
        {
            sprite.flipX= false;
        }


        //Anima��o boneco

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
