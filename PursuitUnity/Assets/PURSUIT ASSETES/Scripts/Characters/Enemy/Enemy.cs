using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    private KillCount killCount;

    private void Start()
    {
        killCount = FindObjectOfType<KillCount>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        if (killCount != null)
        {
            killCount.IncreaseEnemyCount();
        }
    }
}
