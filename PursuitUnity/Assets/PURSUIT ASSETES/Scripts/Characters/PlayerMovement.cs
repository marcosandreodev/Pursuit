using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float move;
    [SerializeField] private float moveSpeed = 5f;
    private bool jumping;
    [SerializeField] private float jumpSpeed = 6f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    public Transform feetPosition;
    public float sizeRadius;
    public LayerMask whatIsGround;



    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;

    public void walking()
    {
        if (isGrounded)
        {
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
            if (rb.velocity.y > 0)
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
    }

    // Update is called once per frame
    void Update()
    {
        //Reconhecer o chão

        isGrounded= Physics2D.OverlapCircle(feetPosition.position,sizeRadius,whatIsGround);

        move = Input.GetAxis("Horizontal");

        //input do pulo do personagem

        if (Input.GetButtonDown("Jump") && ghostJump >0)
        {
            jumping=true; 
        }

        // inverter posição boneco
        if(move < 0)
        {
            sprite.flipX= true;
        }
        else if(move > 0)
        {
            sprite.flipX= false;
        }


        //Animação boneco

        if (isGrounded)
        {
            ghostJump = 0.2f;
            walking();
        }
        else
        {
            ghostJump-=Time.deltaTime; 
            if (ghostJump <= 0 ) {
                ghostJump = 0;
            }
            jump();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetPosition.position, sizeRadius);
    }

    void FixedUpdate()
    {
        //andar
        rb.velocity= new Vector2(move * moveSpeed, rb.velocity.y);
        //pulo
        if (jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed;

            jumping= false;
        }
    }
}
