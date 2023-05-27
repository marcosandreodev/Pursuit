using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string NomeLevel;
    [SerializeField] private GameObject PainelMenuI;
    [SerializeField] private GameObject PainelO;
    [SerializeField] private string NomeCheck;

    public DataPersistanceManager dataPersistanceManager;

    public int dificuldade = 2;
    public Image legenda;



    public void NovoJogo()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(NomeLevel);
    }
    public void AbrirOp()
    {
        PainelMenuI.SetActive(false);
        PainelO.SetActive(true);
        dataPersistanceManager.LoadGame();
    }
    public void FechaOp()
    {
        PainelO.SetActive(false);
        PainelMenuI.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
        OnApplicationQuit();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
   
    public void ChooseChallange()
    {
        dificuldade = 1;
    }

    public void SaveData(GameData data)
    {
        data.dificuldade = dificuldade;
    }

    public void LoadData(GameData data) 
    { 
        dificuldade+= data.dificuldade;
    }

    public void SaveInfos()
    {
        dataPersistanceManager.SaveGame();
        dataPersistanceManager.LoadGame();
    }
}
