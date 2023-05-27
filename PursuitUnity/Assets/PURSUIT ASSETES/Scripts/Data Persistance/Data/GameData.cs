using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;

    public int pontos;
    public int dificuldade;
    public int kills;
    public SerializableDictionary<string, bool> itensCollected;
    public SerializableDictionary<string, bool> enemysKilled;
    public Vector3 playerPosition;

    public GameData()
    {
        this.pontos = 0;
        this.kills = 0;
        this.dificuldade = 0;
        itensCollected = new SerializableDictionary<string, bool>();
        enemysKilled = new SerializableDictionary<string, bool>();
        playerPosition= Vector3.zero;
    }

    public int GetPercentageComplete()
    {
        int totalKills = 0;
        foreach(bool killed in enemysKilled.Values) {
            if(killed)
            {
                totalKills++;
            }
        }

        int percentageComplete = -1;
        if(enemysKilled.Count != 0)
        {
            percentageComplete = (totalKills * 100 / enemysKilled.Count);
        }

        return percentageComplete;
    }
}
