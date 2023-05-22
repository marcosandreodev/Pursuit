using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public static int pontos = 0;
    private static PontuacaoUI pontuacaoUI;
    private static string pontosPlayerPrefsKey = "Pontuacao";

    private void Start()
    {
        LoadPontuacao();
        if (pontuacaoUI != null)
        {
            pontuacaoUI.UpdateUI();
        }
    }

    public static void AddPontos(int pontosParaAdicionar)
    {
        pontos += pontosParaAdicionar;
        if (pontuacaoUI != null)
        {
            pontuacaoUI.UpdateUI();
        }
        SavePontuacao();
    }

    public static void SetPontuacaoUI(PontuacaoUI ui)
    {
        pontuacaoUI = ui;
    }

    private static void SavePontuacao()
    {
        PlayerPrefs.SetInt(pontosPlayerPrefsKey, pontos);
        PlayerPrefs.Save();
    }

    private static void LoadPontuacao()
    {
        if (PlayerPrefs.HasKey(pontosPlayerPrefsKey))
        {
            pontos = PlayerPrefs.GetInt(pontosPlayerPrefsKey);
        }
    }
}
