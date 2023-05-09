using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoUI : MonoBehaviour
{
    [SerializeField] private Text textoPontuacao;
    public int inici = 0;
    

    private void Start()
    {
        textoPontuacao = GetComponent<Text>();
        Pontuacao.SetPontuacaoUI(this);
    }

    public void UpdateUI()
    {
        textoPontuacao.text += Pontuacao.pontos;
    }
}
