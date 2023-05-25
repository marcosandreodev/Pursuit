using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance = 4;
    public float shootDistance = 2;
    bool isShooting;
    private string currentAnimation;
    bool isWalking;
    public PlayerHealth health;


    public Transform firePoint;
    public GameObject bulletPrefarb;
    public float firerate;
    float nextfire;
    public Weapon pammo;

    const string ENEMY_IDLE = "VIdle";
    const string ENEMY_WALK = "VWalk";
    const string ENEMY_SHOOT = "VShoot";
    const string ENEMY_RELOAD = "VReload";

    public bool isReloading;

    public float bullets = 14;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health= GetComponent<PlayerHealth>();
    }


    void Update()
    {       

        if (isShooting)
        {
           isChasing = false;

            moveSpeed = 0;
            if (transform.position.x > playerTransform.position.x)
            {
                Left();
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                Shoot();
            }

            if (transform.position.x < playerTransform.position.x)
            {
                Right();
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                Shoot();
            }

        }
        if (isChasing)
        {
            moveSpeed = 2f;
            isShooting = false;
            if (transform.position.x > playerTransform.position.x)
            {
                Left();
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < playerTransform.position.x)
            {
                Right();
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            
            if (Vector2.Distance(transform.position, playerTransform.position) < shootDistance)
            {
                ChangeAnimationState(ENEMY_SHOOT);
                isShooting =true;
                isWalking = false;
                isChasing = false;
            }
        
            if (patrolDestination == 0)
            {
                isWalking = true;
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    Right();
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                isWalking = true;
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    Left();
                    patrolDestination = 0;
                }
            }
        }

        if (isWalking == false)
        {
            ChangeAnimationState(ENEMY_SHOOT);
        }

        if (isShooting == false)
        {
            ChangeAnimationState(ENEMY_WALK);
        }
    }


    void Right()
    {
        transform.localScale = new Vector3(1, 1, 1);
        firePoint.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Left()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        firePoint.transform.localRotation = Quaternion.Euler(0, 180, 0);
        

    }

    void Shoot()
    {
        if (bullets > 0)
        {
            isReloading = false;
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;
                Instantiate(bulletPrefarb, firePoint.position, firePoint.rotation);
                bullets -= 1;
            }
        }

        if (bullets == 0 )
        {
            Reload();
        }
    }

    void Reload()
    {
        ChangeAnimationState(ENEMY_RELOAD);
        isReloading = true;
    }

    void StopReload()
    {
        ChangeAnimationState(ENEMY_SHOOT);
        bullets = 14;
        isReloading = false;
    }


    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
