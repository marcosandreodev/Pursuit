using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public ObjectId _id;
    public string name;
    public string password;
    public long lastUpdated;
    public int pontos;
    public int level;
    public int kills;
    public SerializableDictionary<string, bool> itensCollected;
    public SerializableDictionary<string, bool> enemysKilled;
    public Vector3 playerPosition;

    public GameData()
    {
        this.pontos = 0;
        this.kills = 0;
        this.level = 0;
        itensCollected = new SerializableDictionary<string, bool>();
        enemysKilled = new SerializableDictionary<string, bool>();
        playerPosition = Vector3.zero;
    }

    public int GetPercentageComplete()
    {

        int percentageComplete = 0;

        if(level == 0)
        {
            percentageComplete = 0;
        }
        if(level == 1) {

            percentageComplete = 50;        
        }
        if (level == 2)
        {

            percentageComplete = 100;
        }
        return percentageComplete;
    }

    public int sGetLevel()
    {
        int isInlevel = level;

        return isInlevel;
    }
}
