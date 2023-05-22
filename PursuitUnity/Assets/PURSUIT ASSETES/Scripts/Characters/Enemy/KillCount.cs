using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public Text enemyCountText;
    private int kills;

    private void Start()
    {
        kills = PlayerPrefs.GetInt("KillCount", 0); // Recupera o valor armazenado em PlayerPrefs ou usa 0 como valor padrão
        UpdateUI();
    }

    public void IncreaseEnemyCount()
    {
        kills++; // Incrementa o contador de inimigos mortos
        PlayerPrefs.SetInt("KillCount", kills); // Salva o novo valor em PlayerPrefs
        UpdateUI();
    }

    private void UpdateUI()
    {
        enemyCountText.text = kills.ToString(); // Atualiza o texto exibido na tela
    }
}