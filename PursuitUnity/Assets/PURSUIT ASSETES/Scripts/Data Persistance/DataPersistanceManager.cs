using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;
    private List<IDataPersistance> dataPersistancesObjects;

    public static DataPersistanceManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than oen Data Persistance Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataPersistancesObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any saved data from a file using data handler
        // if no data can be loaded, initialize to a new game 
        if (gameData = null)
        {
            Debug.Log("Não foi encontrado dados");
            NewGame();
        }

        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("loaded death count ");
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistancesObjects = FindAllDataPersistanceObjects > ()
            .OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistancesObjects);
    }
}
