using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    [SerializeField] private Transform bullet;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnColliderEnter2D(Collider2D other)
    {
        DestroyBullet();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;  
        }
    }

    void DestroyBullet()
    {
        Destroy(bullet.gameObject);
    }
}
