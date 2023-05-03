using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance = 4;
    public float shootDistance = 2;
    bool isShooting;



    public Transform firePoint;
    public GameObject bulletPrefarb;
    public float move;
    public float firerate;
    float nextfire;
    public Weapon pammo;



    public float bullets = 14;


    void Update()
    {
        if (isShooting)
        {
            moveSpeed= 0;
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
                isShooting=true;
                isChasing = false;
            }
        
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    Right();
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    Left();
                    patrolDestination = 0;
                }
            }
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
        if (bullets > 0 )
        {
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;
                Instantiate(bulletPrefarb, firePoint.position, firePoint.rotation);
                bullets -= 1;
            }
        }
    }
}
