using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificuldadeController : MonoBehaviour
{
    public static int nivelDificuldade = 2;

    // Modificadores de dificuldade
    public static float danoInimigo = 1.0f;
    public static float velocidadeInimigo = 1.0f;
    public static int vidaJogador = 100;

    private void Awake()
    {
        // Carrega a dificuldade salva, se existir
        if (PlayerPrefs.HasKey("Dificuldade"))
        {
            nivelDificuldade = PlayerPrefs.GetInt("Dificuldade");
        }
        else
        {
            nivelDificuldade = 2; // Dificuldade média como padrão
        }

        // Aplica os modificadores de dificuldade de acordo com o nível selecionado
        switch (nivelDificuldade)
        {
            case 1:
                danoInimigo = 0.5f;
                velocidadeInimigo = 0.8f;
                vidaJogador = 150;
                break;
            case 2:
                danoInimigo = 1.0f;
                velocidadeInimigo = 1.0f;
                vidaJogador = 100;
                break;
            case 3:
                danoInimigo = 1.5f;
                velocidadeInimigo = 1.2f;
                vidaJogador = 80;
                break;
        }
    }

    public static void SetDificuldade(int nivel)
    {
        nivelDificuldade = nivel;

        // Salva o nível de dificuldade escolhido
        PlayerPrefs.SetInt("Dificuldade", nivel);

        // Atualiza os modificadores de dificuldade de acordo com o novo nível
        switch (nivelDificuldade)
        {
            case 1:
                danoInimigo = 0.5f;
                velocidadeInimigo = 0.8f;
                vidaJogador = 150;
                break;
            case 2:
                danoInimigo = 1.0f;
                velocidadeInimigo = 1.0f;
                vidaJogador = 100;
                break;
            case 3:
                danoInimigo = 1.5f;
                velocidadeInimigo = 1.2f;
                vidaJogador = 80;
                break;
        }
    }
}