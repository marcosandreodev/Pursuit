using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{

    public Text enemyCountText;
    public int kills = 20;
    public Enemy enemy;

    public void IncreaseEnemyCount()
    {
        kills += enemy.enemyCount;// incrementa o contador de inimigos mortos
        enemyCountText.text = "" + kills; // atualiza o texto exibido na tela
    }
}
