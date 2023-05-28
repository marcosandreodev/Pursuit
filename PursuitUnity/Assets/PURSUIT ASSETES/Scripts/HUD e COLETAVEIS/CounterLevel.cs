using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterLevel : MonoBehaviour, IDataPersistance
{
    public int level;


    public void Start()
    {
        IncreasePoint();
    }

    public void IncreasePoint()
    {
        Debug.Log("Open IncreasePoint");
        level ++; 
    }

    public void LoadData(GameData data)
    {
        data.level = this.level;
        Debug.Log("Load level: " + level);
    }

    public void SaveData(GameData data)
    {
        data.level = this.level;

        Debug.Log("Save levle: " + level);
    }
   
}
