using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Enemy : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private int health = 100;
    public GameObject deathEffect;
    bool isDead = false;
    public int value;

    public Challange challange;

    public void TakeDamage(int damage)
    {
        health -= damage;
 
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (health <= 0)
            {
                Debug.Log("entrou2");
                isDead = true;
                KillCount.instance.IncreaseKills(value);
                Destroy(gameObject);
            }
        }
    }

    private void Die()
    {
      
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        isDead = true;
    }

    public void LoadData(GameData data)
    {
        data.enemysKilled.TryGetValue(id, out isDead);
        if (isDead)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.enemysKilled.ContainsKey(id))
        {
            data.enemysKilled.Remove(id);
        }
        data.enemysKilled.Add(id, isDead);
    }
}
