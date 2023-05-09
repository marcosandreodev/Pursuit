using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    public Text enemyCountText;
    private int enemyCount = 0;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            IncreaseEnemyCount();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    public void IncreaseEnemyCount()
    {
        enemyCount++;// incrementa o contador de inimigos mortos
        enemyCountText.text = "" + enemyCount; // atualiza o texto exibido na tela
    }
}
