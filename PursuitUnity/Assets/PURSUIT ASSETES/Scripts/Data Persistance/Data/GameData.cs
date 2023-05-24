using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int pontos;
    public SerializableDictionary<string, bool> itensCollected;

    public GameData()
    {
        this.pontos = 0;
        itensCollected = new SerializableDictionary<string, bool>();
    }
}
