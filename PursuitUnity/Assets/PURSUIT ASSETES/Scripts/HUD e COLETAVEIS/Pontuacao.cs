using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public static int pontos = 0;
    private static PontuacaoUI pontuacaoUI;

    public static void AddPontos(int pontosParaAdicionar)
    {
        pontos += pontosParaAdicionar;
        if (pontuacaoUI != null)
        {
            pontuacaoUI.UpdateUI();
        }
    }

    public static void SetPontuacaoUI(PontuacaoUI ui)
    {
        pontuacaoUI = ui;
    }
}
