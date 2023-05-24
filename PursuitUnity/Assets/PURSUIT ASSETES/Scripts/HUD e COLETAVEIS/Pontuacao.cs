using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour, IDataPersistance
{
    private int pontos = 0;
    public Text textoPontuacao;

    private void Start()
    {
        // subscribe to events
        GameEventsManager.instance.onCoinCollected += OnCoinCollected;
    }

    private void OnDestroy()
    {
        // unsubscribe from events
        GameEventsManager.instance.onCoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        pontos++;
    }


    public void LoadData(GameData data)
    {
        this.pontos = data.pontos;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("Salvou dados");
        data.pontos = this.pontos;
    }

    public void Update()
    {
        Debug.Log("Entrou Update Score");
        textoPontuacao.text = pontos.ToString();
    }
}

