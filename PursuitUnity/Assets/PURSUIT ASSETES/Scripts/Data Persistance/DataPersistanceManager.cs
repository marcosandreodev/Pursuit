using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistance> dataPersistancesObjects;

    private FileDataHandler dataHandler;

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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
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
        this.gameData = dataHandler.Load();

        // if no data can be loaded, initialize to a new game 
        if (gameData == null)
        {
            Debug.Log("No data was foud. Initalizing data to defaults");
            NewGame();
        }

        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("loaded kills count : " + gameData.pontos);
    }

    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        Debug.Log("saved kills count : " + gameData.pontos);

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistancesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistancesObjects);
    }
}
