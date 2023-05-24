using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CounterItem : MonoBehaviour, IDataPersistance
{
    public static CounterItem instance;

    public TMP_Text pontuacaoText;
    public int pontuacao;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pontuacaoText.text = "Score: " + pontuacao.ToString();
    }

    public void IncreasePoint(int v)
    {
        pontuacao += v;
        pontuacaoText.text = "Score: " + pontuacao.ToString();
    }

    public void Update()
    {
        pontuacaoText.text = "Score: " + pontuacao.ToString();
    }

    public void LoadData(GameData data)
    {
        //this.pontuacao = data.pontos;

        foreach(KeyValuePair<string, bool> pair in data.itensCollected) 
        {
            if(pair.Value)
            {
                pontuacao++;
            }
        }
    }

    public void SaveData(ref GameData data)
    {
        data.pontos = this.pontuacao;
    }
}
