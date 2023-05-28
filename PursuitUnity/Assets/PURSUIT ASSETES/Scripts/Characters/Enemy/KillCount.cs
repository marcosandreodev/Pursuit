using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class KillCount : MonoBehaviour, IDataPersistance
{
    public static KillCount instance;

    public TMP_Text enemyCountText;
    public int kills;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        enemyCountText.text = "Kills: "+ kills.ToString();
    }

    public void IncreaseKills(int v)
    {
        kills += v;
        enemyCountText.text = "Kills: " + kills.ToString();
    }

    public void Update()
    {
        enemyCountText.text = "Kills: " + kills.ToString();
    }

    public void LoadData(GameData data)
    {
        //this.pontuacao = data.pontos;

        foreach (KeyValuePair<string, bool> pair in data.enemysKilled)
        {
            if (pair.Value)
            {
                kills ++;
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.kills = this.kills;
    }
}