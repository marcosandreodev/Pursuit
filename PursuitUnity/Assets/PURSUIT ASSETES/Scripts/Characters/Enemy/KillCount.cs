using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class KillCount : MonoBehaviour
{
    public Text enemyCountText;
    private int kills = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void IncreaseEnemyCount()
    {
        kills++; // Incrementa o contador de inimigos mortos
        UpdateUI();
    }

    private void UpdateUI()
    {
        enemyCountText.text = kills.ToString(); // Atualiza o texto exibido na tela
    }
}